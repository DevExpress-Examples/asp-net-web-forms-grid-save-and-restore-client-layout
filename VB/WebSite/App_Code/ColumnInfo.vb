Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Xml.Serialization
Imports DevExpress.Data
Imports DevExpress.Web.ASPxGridView

<XmlInclude(GetType(DataColumnInfo)), XmlInclude(GetType(CommandColumnInfo)), XmlInclude(GetType(BandColumnInfo))> _
Public MustInherit Class ColumnInfoBase
	Public Sub New()
	End Sub
	Public Sub New(ByVal column As GridViewColumn)
		Caption = column.Caption
		Width = column.Width
		Name = column.Name
		ExportWidth = column.ExportWidth
		VisibleIndex = column.VisibleIndex
		Visible = column.Visible
	End Sub

	Private privateVisibleIndex As Integer
	Public Property VisibleIndex() As Integer
		Get
			Return privateVisibleIndex
		End Get
		Set(ByVal value As Integer)
			privateVisibleIndex = value
		End Set
	End Property

	Private privateWidth As Unit
	Public Property Width() As Unit
		Get
			Return privateWidth
		End Get
		Set(ByVal value As Unit)
			privateWidth = value
		End Set
	End Property
	Private privateVisible As Boolean
	Public Property Visible() As Boolean
		Get
			Return privateVisible
		End Get
		Set(ByVal value As Boolean)
			privateVisible = value
		End Set
	End Property
	Private privateName As String
	Public Property Name() As String
		Get
			Return privateName
		End Get
		Set(ByVal value As String)
			privateName = value
		End Set
	End Property
	Private privateCaption As String
	Public Property Caption() As String
		Get
			Return privateCaption
		End Get
		Set(ByVal value As String)
			privateCaption = value
		End Set
	End Property
	Private privateExportWidth As Integer
	Public Property ExportWidth() As Integer
		Get
			Return privateExportWidth
		End Get
		Set(ByVal value As Integer)
			privateExportWidth = value
		End Set
	End Property



	Public Overridable Sub RestoreGridViewColumn(ByVal column As GridViewColumn)
		column.Caption = Caption
		column.Width = Width
		column.Name = Name
		column.ExportWidth = ExportWidth
		column.VisibleIndex = VisibleIndex
		column.Visible = Visible
	End Sub
End Class

Public Class DataColumnInfo
	Inherits ColumnInfoBase
	Public Sub New()
	End Sub
	Public Sub New(ByVal column As GridViewDataColumn)
		MyBase.New(column)
		RealTypeName = column.GetType().ToString()
		FieldName = column.FieldName
		GroupIndex = column.GroupIndex
		SortIndex = column.SortIndex
		SortOrder = column.SortOrder
	End Sub

	Private privateRealTypeName As String
	Public Property RealTypeName() As String
		Get
			Return privateRealTypeName
		End Get
		Set(ByVal value As String)
			privateRealTypeName = value
		End Set
	End Property
	Private privateFieldName As String
	Public Property FieldName() As String
		Get
			Return privateFieldName
		End Get
		Set(ByVal value As String)
			privateFieldName = value
		End Set
	End Property
	Private privateGroupIndex As Integer
	Public Property GroupIndex() As Integer
		Get
			Return privateGroupIndex
		End Get
		Set(ByVal value As Integer)
			privateGroupIndex = value
		End Set
	End Property
	Private privateSortIndex As Integer
	Public Property SortIndex() As Integer
		Get
			Return privateSortIndex
		End Get
		Set(ByVal value As Integer)
			privateSortIndex = value
		End Set
	End Property
	Private privateSortOrder As ColumnSortOrder
	Public Property SortOrder() As ColumnSortOrder
		Get
			Return privateSortOrder
		End Get
		Set(ByVal value As ColumnSortOrder)
			privateSortOrder = value
		End Set
	End Property

	Public Overrides Sub RestoreGridViewColumn(ByVal column As GridViewColumn)
		If column Is Nothing Then
			Return
		End If
		If GetType(GridViewDataColumn).Assembly.GetType(RealTypeName) IsNot column.GetType() Then
			Return
		End If

		MyBase.RestoreGridViewColumn(column)
		Dim c As GridViewDataColumn = CType(column, GridViewDataColumn)
		c.FieldName = FieldName
		c.GroupIndex = GroupIndex
		c.SortIndex = SortIndex
		c.SortOrder = SortOrder
	End Sub
End Class

Public NotInheritable Class CommandColumnInfo
	Inherits ColumnInfoBase
	Public Sub New()
	End Sub
	Public Sub New(ByVal column As GridViewCommandColumn)
		MyBase.New(column)
		ShowEditButton = column.EditButton.Visible
		ShowNewButton = column.NewButton.Visible
		ShowEditButton = column.EditButton.Visible
		ShowSelectCheckbox = column.ShowSelectCheckbox
	End Sub

	Private privateShowEditButton As Boolean
	Public Property ShowEditButton() As Boolean
		Get
			Return privateShowEditButton
		End Get
		Set(ByVal value As Boolean)
			privateShowEditButton = value
		End Set
	End Property
	Private privateShowNewButton As Boolean
	Public Property ShowNewButton() As Boolean
		Get
			Return privateShowNewButton
		End Get
		Set(ByVal value As Boolean)
			privateShowNewButton = value
		End Set
	End Property
	Private privateShowDeleteButton As Boolean
	Public Property ShowDeleteButton() As Boolean
		Get
			Return privateShowDeleteButton
		End Get
		Set(ByVal value As Boolean)
			privateShowDeleteButton = value
		End Set
	End Property
	Private privateShowSelectCheckbox As Boolean
	Public Property ShowSelectCheckbox() As Boolean
		Get
			Return privateShowSelectCheckbox
		End Get
		Set(ByVal value As Boolean)
			privateShowSelectCheckbox = value
		End Set
	End Property

	Public Overrides Sub RestoreGridViewColumn(ByVal column As GridViewColumn)
		If column Is Nothing Then
			Return
		End If
		MyBase.RestoreGridViewColumn(column)
		Dim c As GridViewCommandColumn = CType(column, GridViewCommandColumn)
		c.EditButton.Visible = ShowEditButton
		c.NewButton.Visible = ShowNewButton
		c.EditButton.Visible = ShowEditButton
		c.ShowSelectCheckbox = ShowSelectCheckbox
	End Sub
End Class

Public NotInheritable Class BandColumnInfo
	Inherits ColumnInfoBase
	Public Sub New()
	End Sub
	Public Sub New(ByVal column As GridViewBandColumn)
		MyBase.New(column)
	End Sub

	Public Overrides Sub RestoreGridViewColumn(ByVal column As GridViewColumn)
		If column Is Nothing Then
			Return
		End If
		MyBase.RestoreGridViewColumn(column)
		Dim c As GridViewBandColumn = CType(column, GridViewBandColumn)
		'To-Do: Save child column information		
	End Sub
End Class