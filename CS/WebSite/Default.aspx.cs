using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;

public partial class _Default : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e) {
	}
	
	protected void grid_ClientLayout(object sender, ASPxClientLayoutArgs e) {
		ASPxGridView g = sender as ASPxGridView;
		ClientLayoutSerializer serializer = new ClientLayoutSerializer(g);
		if (e.LayoutMode == ClientLayoutMode.Loading)
			serializer.RestoreClientLayout();		
		else 			
			serializer.SaveClientLayout();	
		

	}
}