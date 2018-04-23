using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Serialization;
using DevExpress.Web.ASPxGridView;

public class ClientLayoutSerializer {
	private ASPxGridView grid;
	private const string SessionPostfix = "_layoutData";

	public ClientLayoutSerializer(ASPxGridView grid) {
		this.grid = grid;
	}

	public void RestoreClientLayout() {
		if (HttpContext.Current.Session[grid.ClientID + SessionPostfix] == null)
			return;
		string dataString = (String)HttpContext.Current.Session[grid.ClientID + SessionPostfix];
		DeserializeColumns(dataString);
	}
	public void SaveClientLayout() {
		string data = SerializeColumns();
		HttpContext.Current.Session[grid.ClientID + SessionPostfix] = data;
	}

	private string SerializeColumns() {
		StringBuilder sb = new StringBuilder();
		using (XmlWriter xw = XmlWriter.Create(sb)) {
			xw.WriteStartDocument();			

			GridViewInfo g = new GridViewInfo(grid);
			foreach (GridViewColumn column in grid.Columns) {
				if (column is GridViewDataColumn)			
					g.Columns.Add(new DataColumnInfo(column as GridViewDataColumn));
				else if (column is GridViewCommandColumn)			
					g.Columns.Add(new CommandColumnInfo(column as GridViewCommandColumn));
				else if (column is GridViewBandColumn)			
					g.Columns.Add(new BandColumnInfo(column as GridViewBandColumn));
			}			
			XmlSerializer xmlSerializer = new XmlSerializer(g.GetType());
			xmlSerializer.Serialize(xw, g);
		}
		return sb.ToString();
	}

	private void DeserializeColumns(string layoutData) {
		XmlDocument doc = new XmlDocument();
		doc.LoadXml(layoutData);

		GridViewInfo gridInfo = null;
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(GridViewInfo));
		using (XmlReader xr = XmlReader.Create(new StringReader(layoutData))) {
			gridInfo = (GridViewInfo)xmlSerializer.Deserialize(xr);
		}
		gridInfo.RestoreGridViewLayout(grid);
	}
}