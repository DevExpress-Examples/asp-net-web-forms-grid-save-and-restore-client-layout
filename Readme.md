<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128541128/12.1.9%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4437)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [ClientLayoutSerializer.cs](./CS/WebSite/App_Code/ClientLayoutSerializer.cs) (VB: [ClientLayoutSerializer.vb](./VB/WebSite/App_Code/ClientLayoutSerializer.vb))
* [ColumnInfo.cs](./CS/WebSite/App_Code/ColumnInfo.cs) (VB: [ColumnInfo.vb](./VB/WebSite/App_Code/ColumnInfo.vb))
* [GridViewInfo.cs](./CS/WebSite/App_Code/GridViewInfo.cs) (VB: [GridViewInfo.vb](./VB/WebSite/App_Code/GridViewInfo.vb))
* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/WebSite/Default.aspx.vb))
<!-- default file list end -->
# How to implement custom saving in XML and restoring of ASPxGridView client layout
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/128541128/)**
<!-- run online end -->


<p>This example demonstrates simple implementation of a solution for custom saving the client-side ASPxGridView layout in XML to a custom data source and restoring the layout from the source. The layout data is saved before the ASPxGridView renders a callback's resultant data. On first page loading, the data is restored.</p><br />
<p>Session is used as a temporary storage. You can use any other appropriate storage instead of it.</p>

<br/>


