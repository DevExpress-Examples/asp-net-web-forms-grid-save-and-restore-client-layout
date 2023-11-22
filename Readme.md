<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128541128/15.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4437)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# Grid View for ASP.NET Web Forms - How to save and restore the client layout

<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e4437/)**
<!-- run online end -->

This example demonstrates how to save and restore the client layout of the Grid View control. In the example, the [session state](https://learn.microsoft.com/en-us/dotnet/api/system.web.httpcontext.session?view=netframework-4.8.1) stores the grid layout in XML format. You can use any other storage instead of the session state.

The Grid View's [ClientLayout](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxGridBase.ClientLayout) event allows you to save the grid layout each time a user changes it and restore this layout on the first page load. Use the [LayoutMode](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxClientLayoutArgs.LayoutMode) event argument to identify whether to save or restore the layout.

## Files to Review

* [ClientLayoutSerializer.cs](./CS/WebSite/App_Code/ClientLayoutSerializer.cs) (VB: [ClientLayoutSerializer.vb](./VB/WebSite/App_Code/ClientLayoutSerializer.vb))
* [ColumnInfo.cs](./CS/WebSite/App_Code/ColumnInfo.cs) (VB: [ColumnInfo.vb](./VB/WebSite/App_Code/ColumnInfo.vb))
* [GridViewInfo.cs](./CS/WebSite/App_Code/GridViewInfo.cs) (VB: [GridViewInfo.vb](./VB/WebSite/App_Code/GridViewInfo.vb))
* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/WebSite/Default.aspx.vb))

## Documentation

- [Save and Restore Client Layout](https://docs.devexpress.com/AspNet/4342/components/grid-view/concepts/save-and-restore-client-layout)

## More Examples

- [How to use a list box editor to save and restore client layout](https://github.com/DevExpress-Examples/asp-net-web-forms-grid-use-listbox-to-save-and-restore-client-layout)
