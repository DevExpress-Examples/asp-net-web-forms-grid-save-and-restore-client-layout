Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Reflection
Imports System.Text
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Xml
Imports System.Xml.Serialization
Imports DevExpress.Web.ASPxGridView

Public Class ClientLayoutSerializer
	Private grid As ASPxGridView
	Private Const SessionPostfix As String = "_layoutData"

	Public Sub New(ByVal grid As ASPxGridView)
		Me.grid = grid
	End Sub

	Public Sub RestoreClientLayout()
		If HttpContext.Current.Session(grid.ClientID & SessionPostfix) Is Nothing Then
			Return
		End If
		Dim dataString As String = CType(HttpContext.Current.Session(grid.ClientID & SessionPostfix), String)
		DeserializeColumns(dataString)
	End Sub
	Public Sub SaveClientLayout()
		Dim data As String = SerializeColumns()
		HttpContext.Current.Session(grid.ClientID & SessionPostfix) = data
	End Sub

	Private Function SerializeColumns() As String
		Dim sb As New StringBuilder()
		Using xw As XmlWriter = XmlWriter.Create(sb)
			xw.WriteStartDocument()

			Dim g As New GridViewInfo(grid)
			For Each column As GridViewColumn In grid.Columns
				If TypeOf column Is GridViewDataColumn Then
					g.Columns.Add(New DataColumnInfo(TryCast(column, GridViewDataColumn)))
				ElseIf TypeOf column Is GridViewCommandColumn Then
					g.Columns.Add(New CommandColumnInfo(TryCast(column, GridViewCommandColumn)))
				ElseIf TypeOf column Is GridViewBandColumn Then
					g.Columns.Add(New BandColumnInfo(TryCast(column, GridViewBandColumn)))
				End If
			Next column
			Dim xmlSerializer As New XmlSerializer(g.GetType())
			xmlSerializer.Serialize(xw, g)
		End Using
		Return sb.ToString()
	End Function

	Private Sub DeserializeColumns(ByVal layoutData As String)
		Dim doc As New XmlDocument()
		doc.LoadXml(layoutData)

		Dim gridInfo As GridViewInfo = Nothing
		Dim xmlSerializer As New XmlSerializer(GetType(GridViewInfo))
		Using xr As XmlReader = XmlReader.Create(New StringReader(layoutData))
			gridInfo = CType(xmlSerializer.Deserialize(xr), GridViewInfo)
		End Using
		gridInfo.RestoreGridViewLayout(grid)
	End Sub
End Class