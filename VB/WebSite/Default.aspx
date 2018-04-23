<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>How to implement custom saving in XML and restoring of ASPxGridView client layout</title>
</head>
<body>
	<form id="form1" runat="server">
		<div style="float: left">
			Categories:<br />
			<dx:ASPxGridView runat="server" AutoGenerateColumns="False" DataSourceID="dsCategories"
				KeyFieldName="CategoryID" ID="grid1" ClientInstanceName="grid" Width="612px" OnClientLayout="grid_ClientLayout">
				<Columns>
					<dx:GridViewDataTextColumn FieldName="CategoryID" ReadOnly="True" VisibleIndex="0">
						<EditFormSettings Visible="False" />
					</dx:GridViewDataTextColumn>
					<dx:GridViewDataTextColumn FieldName="CategoryName" VisibleIndex="1">
					</dx:GridViewDataTextColumn>
					<dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="2">
					</dx:GridViewDataTextColumn>
				</Columns>
				<Settings ShowFilterBar="Visible" ShowFilterRow="True" ShowFilterRowMenu="True" />
			</dx:ASPxGridView>
		</div>
		<div style="padding:20px 0 0 800px;">
			<dx:ASPxHyperLink ID="ASPxHyperLink1" runat="server" Text="Re-open page in new windos" Target="_blank" NavigateUrl="~/Default.aspx">
			</dx:ASPxHyperLink>
		</div>
		<div style="clear: both;"></div>
		<br />
		<br />
		Products:<br />
		<dx:ASPxGridView runat="server" AutoGenerateColumns="False" DataSourceID="dsProducts"
			KeyFieldName="ProductID" ID="grid" ClientInstanceName="grid" OnClientLayout="grid_ClientLayout">
			<Columns>
				<dx:GridViewCommandColumn VisibleIndex="0">
					<EditButton Visible="True">
					</EditButton>
					<NewButton Visible="True">
					</NewButton>
					<DeleteButton Visible="True">
					</DeleteButton>
				</dx:GridViewCommandColumn>
				<dx:GridViewDataTextColumn FieldName="ProductID" ReadOnly="True" VisibleIndex="1">
					<EditFormSettings Visible="False" />
					<EditFormSettings Visible="False"></EditFormSettings>
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="ProductName" VisibleIndex="2">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="SupplierID" VisibleIndex="3">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataComboBoxColumn FieldName="CategoryID" VisibleIndex="4">
					<PropertiesComboBox DataSourceID="dsCategories" TextField="CategoryName"
						ValueField="CategoryID" ValueType="System.Int32">
					</PropertiesComboBox>
				</dx:GridViewDataComboBoxColumn>
				<dx:GridViewDataTextColumn FieldName="QuantityPerUnit" VisibleIndex="5">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="UnitPrice" VisibleIndex="6">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="UnitsInStock" VisibleIndex="7">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="UnitsOnOrder" VisibleIndex="8">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="ReorderLevel" VisibleIndex="9">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataCheckColumn FieldName="Discontinued" VisibleIndex="10">
				</dx:GridViewDataCheckColumn>
			</Columns>
			<Settings ShowFilterBar="Visible" ShowFilterRow="True" ShowFilterRowMenu="True" />
		</dx:ASPxGridView>
		<br />
		<br />
		Employees:<br />
		<dx:ASPxGridView runat="server" AutoGenerateColumns="False" DataSourceID="dsEmployee"
			KeyFieldName="EmployeeID" ID="grid0" ClientInstanceName="grid" Width="1476px" OnClientLayout="grid_ClientLayout">
			<Columns>
				<dx:GridViewDataTextColumn FieldName="EmployeeID" ReadOnly="True" VisibleIndex="0">
					<EditFormSettings Visible="False" />
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="LastName" VisibleIndex="1">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="FirstName" VisibleIndex="2">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="Title" VisibleIndex="3">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="TitleOfCourtesy" VisibleIndex="4">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataDateColumn FieldName="BirthDate" VisibleIndex="5">
				</dx:GridViewDataDateColumn>
				<dx:GridViewDataDateColumn FieldName="HireDate" VisibleIndex="6">
				</dx:GridViewDataDateColumn>
				<dx:GridViewDataTextColumn FieldName="Address" VisibleIndex="7">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="City" VisibleIndex="8">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="Region" VisibleIndex="9">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="PostalCode" VisibleIndex="10">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="Country" VisibleIndex="11">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="HomePhone" VisibleIndex="12">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="Extension" VisibleIndex="13">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="Notes" VisibleIndex="14">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="ReportsTo" VisibleIndex="15">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="PhotoPath" VisibleIndex="16">
				</dx:GridViewDataTextColumn>
			</Columns>
			<Settings ShowFilterBar="Visible" ShowFilterRow="True" ShowFilterRowMenu="True" />
		</dx:ASPxGridView>
		<div style="padding:20px 0 0 800px;">
			<dx:ASPxHyperLink ID="ASPxHyperLink2" runat="server" Text="Re-open page in new windos" Target="_blank" NavigateUrl="~/Default.aspx">
			</dx:ASPxHyperLink>
		</div>
		<asp:SqlDataSource ID="dsProducts" runat="server" ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>"
			SelectCommand="SELECT [ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued] FROM [Products]"></asp:SqlDataSource>
		<asp:SqlDataSource ID="dsCategories" runat="server" ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>"
			SelectCommand="SELECT [CategoryID], [CategoryName], [Description] FROM [Categories]"></asp:SqlDataSource>
		<asp:SqlDataSource ID="dsEmployee" runat="server" ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>"
			SelectCommand="SELECT [EmployeeID], [LastName], [FirstName], [Title], [TitleOfCourtesy], [BirthDate], [HireDate], [Address], [City], [Region], [PostalCode], [Country], [HomePhone], [Photo], [Extension], [Notes], [ReportsTo], [PhotoPath] FROM [Employees]"></asp:SqlDataSource>
	</form>
</body>
</html>