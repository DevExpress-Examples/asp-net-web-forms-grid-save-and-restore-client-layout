using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml.Serialization;
using DevExpress.Data;
using DevExpress.Web;

[XmlInclude(typeof(DataColumnInfo))]
[XmlInclude(typeof(CommandColumnInfo))]
[XmlInclude(typeof(BandColumnInfo))]
public abstract class ColumnInfoBase {
	public ColumnInfoBase() {
	}
	public ColumnInfoBase(GridViewColumn column) {
		Caption = column.Caption;
		Width = column.Width.ToString();
		Name = column.Name;
		ExportWidth = column.ExportWidth;
		VisibleIndex = column.VisibleIndex;
		Visible = column.Visible;
	}

	public int VisibleIndex { get; set; }

	public string Width { get; set; }
	public bool Visible { get; set; }
	public string Name { get; set; }
	public string Caption { get; set; }
	public int ExportWidth { get; set; }

	

	public virtual void RestoreGridViewColumn(GridViewColumn column) {
		column.Caption = Caption;
		column.Width = Unit.Parse(Width);
		column.Name = Name;
		column.ExportWidth = ExportWidth;
		column.VisibleIndex = VisibleIndex;
		column.Visible = Visible;
	}
}

public class DataColumnInfo : ColumnInfoBase {
	public DataColumnInfo() {
	}
	public DataColumnInfo(GridViewDataColumn column)
		: base(column) {
		RealTypeName = column.GetType().ToString();
		FieldName = column.FieldName;
		GroupIndex = column.GroupIndex;
		SortIndex = column.SortIndex;
		SortOrder = column.SortOrder;
	}

	public string RealTypeName { get; set; }
	public string FieldName { get; set; }
	public int GroupIndex { get; set; }
	public int SortIndex { get; set; }
	public ColumnSortOrder SortOrder { get; set; }

	public override void RestoreGridViewColumn(GridViewColumn column) {
		if (column == null)
			return;
		if (typeof(GridViewDataColumn).Assembly.GetType(RealTypeName) != column.GetType())
			return;

		base.RestoreGridViewColumn(column);
		GridViewDataColumn c = (GridViewDataColumn)column;		
		c.FieldName = FieldName;
		c.GroupIndex = GroupIndex;
		c.SortIndex = SortIndex;
		c.SortOrder = SortOrder;		
	}
}

public sealed class CommandColumnInfo : ColumnInfoBase {
	public CommandColumnInfo() {
	}
	public CommandColumnInfo(GridViewCommandColumn column)
		: base(column) {
		ShowEditButton = column.ShowEditButton;
		ShowNewButton = column.ShowSelectButton;
		ShowDeleteButton = column.ShowDeleteButton;
		ShowSelectCheckbox = column.ShowSelectCheckbox;
	}
		
	public bool ShowEditButton { get; set; }
	public bool ShowNewButton { get; set; }
	public bool ShowDeleteButton { get; set; }
	public bool ShowSelectCheckbox { get; set; }

	public override void RestoreGridViewColumn(GridViewColumn column) {
		if (column == null)
			return;
		base.RestoreGridViewColumn(column);
		GridViewCommandColumn c = (GridViewCommandColumn)column;		
		c.ShowEditButton = ShowEditButton;
		c.ShowNewButton = ShowNewButton;
		c.ShowDeleteButton = ShowDeleteButton;
		c.ShowSelectCheckbox = ShowSelectCheckbox;		
	}
}

public sealed class BandColumnInfo : ColumnInfoBase {
	public BandColumnInfo() {
	}
	public BandColumnInfo(GridViewBandColumn column)
		: base(column) {
	}

	public override void RestoreGridViewColumn(GridViewColumn column) {
		if (column == null)
			return;
		base.RestoreGridViewColumn(column);
		GridViewBandColumn c = (GridViewBandColumn)column;
		//To-Do: Save child column information		
	}
}