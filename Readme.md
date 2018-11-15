<!-- default file list -->
*Files to look at*:

* [ClientLayoutSerializer.cs](./CS/WebSite/App_Code/ClientLayoutSerializer.cs) (VB: [ClientLayoutSerializer.vb](./VB/WebSite/App_Code/ClientLayoutSerializer.vb))
* [ColumnInfo.cs](./CS/WebSite/App_Code/ColumnInfo.cs) (VB: [ColumnInfo.vb](./VB/WebSite/App_Code/ColumnInfo.vb))
* [GridViewInfo.cs](./CS/WebSite/App_Code/GridViewInfo.cs) (VB: [GridViewInfo.vb](./VB/WebSite/App_Code/GridViewInfo.vb))
* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx.vb](./VB/WebSite/Default.aspx.vb))
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/WebSite/Default.aspx.vb))
<!-- default file list end -->
# How to implement custom saving in XML and restoring of ASPxGridView client layout


<p>This example demonstrates simple implementation of a solution for custom saving the client-side ASPxGridView layout in XML to a custom data source and restoring the layout from the source. The layout data is saved before the ASPxGridView renders a callback's resultant data. On first page loading, the data is restored.</p><br />
<p>Session is used as a temporary storage. You can use any other appropriate storage instead of it.</p>

<br/>


