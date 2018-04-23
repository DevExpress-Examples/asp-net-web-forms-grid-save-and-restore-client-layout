Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports DevExpress.Web.ASPxGridView

''' <summary>
''' Summary description for GridViewInfo
''' </summary>
Public Class GridViewInfo
	Public Sub New()
	End Sub
	Public Sub New(ByVal grid As ASPxGridView)
		Columns = New List(Of ColumnInfoBase)(grid.Columns.Count)
		FilterExpression = grid.FilterExpression
		PageIndex = grid.PageIndex
	End Sub
	Private privateColumns As List(Of ColumnInfoBase)
	Public Property Columns() As List(Of ColumnInfoBase)
		Get
			Return privateColumns
		End Get
		Set(ByVal value As List(Of ColumnInfoBase))
			privateColumns = value
		End Set
	End Property
	Private privateFilterExpression As String
	Public Property FilterExpression() As String
		Get
			Return privateFilterExpression
		End Get
		Set(ByVal value As String)
			privateFilterExpression = value
		End Set
	End Property
	Private privatePageIndex As Integer
	Public Property PageIndex() As Integer
		Get
			Return privatePageIndex
		End Get
		Set(ByVal value As Integer)
			privatePageIndex = value
		End Set
	End Property

	Public Sub RestoreGridViewLayout(ByVal grid As ASPxGridView)
		For Each column As ColumnInfoBase In Columns
			Dim dataColumnInfo As DataColumnInfo = TryCast(column, DataColumnInfo)
			If dataColumnInfo IsNot Nothing Then
				column.RestoreGridViewColumn(grid.Columns(dataColumnInfo.FieldName))
				Continue For
			End If
			If TypeOf column Is CommandColumnInfo Then
				column.RestoreGridViewColumn(GetSpecificColumn(Of GridViewCommandColumn)(grid))
				Continue For
			End If
			If TypeOf column Is BandColumnInfo Then
				column.RestoreGridViewColumn(GetSpecificColumn(Of GridViewBandColumn)(grid))
				Continue For
			End If
		Next column
		grid.FilterExpression = FilterExpression
		grid.PageIndex = PageIndex
	End Sub

	Private Function GetSpecificColumn(Of T As GridViewColumn)(ByVal grid As ASPxGridView) As T
		For Each c As GridViewColumn In grid.Columns
			If TypeOf c Is T Then
				Return CType(c, T)
			End If
		Next c

		Return Nothing
	End Function
End Class