Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Xml.Serialization
Imports DevExpress.Data
Imports DevExpress.Web

<XmlInclude(GetType(DataColumnInfo)), XmlInclude(GetType(CommandColumnInfo)), XmlInclude(GetType(BandColumnInfo))> _
Public MustInherit Class ColumnInfoBase
    Public Sub New()
    End Sub
    Public Sub New(ByVal column As GridViewColumn)
        Caption = column.Caption
        Width = column.Width.ToString()
        Name = column.Name
        ExportWidth = column.ExportWidth
        VisibleIndex = column.VisibleIndex
        Visible = column.Visible
    End Sub

    Public Property VisibleIndex() As Integer

    Public Property Width() As String
    Public Property Visible() As Boolean
    Public Property Name() As String
    Public Property Caption() As String
    Public Property ExportWidth() As Integer



    Public Overridable Sub RestoreGridViewColumn(ByVal column As GridViewColumn)
        column.Caption = Caption
        column.Width = Unit.Parse(Width)
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

    Public Property RealTypeName() As String
    Public Property FieldName() As String
    Public Property GroupIndex() As Integer
    Public Property SortIndex() As Integer
    Public Property SortOrder() As ColumnSortOrder

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
        ShowEditButton = column.ShowEditButton
        ShowNewButton = column.ShowSelectButton
        ShowDeleteButton = column.ShowDeleteButton
        ShowSelectCheckbox = column.ShowSelectCheckbox
    End Sub

    Public Property ShowEditButton() As Boolean
    Public Property ShowNewButton() As Boolean
    Public Property ShowDeleteButton() As Boolean
    Public Property ShowSelectCheckbox() As Boolean

    Public Overrides Sub RestoreGridViewColumn(ByVal column As GridViewColumn)
        If column Is Nothing Then
            Return
        End If
        MyBase.RestoreGridViewColumn(column)
        Dim c As GridViewCommandColumn = CType(column, GridViewCommandColumn)
        c.ShowEditButton = ShowEditButton
        c.ShowNewButton = ShowNewButton
        c.ShowDeleteButton = ShowDeleteButton
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