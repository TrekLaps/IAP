using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.DataVisualization.Charting;

public partial class PieDashboard : System.Web.UI.Page
{
    Operations Obj = new Operations();

    private void FillSectorChart()
    {
        ////// Fill Charts
        if (Admins.SelectedValue != "0")
        {
            Chart3.Series[0].Points.Clear();
            Chart3.Legends[0].CustomItems.Clear();

            Chart4.Series[0].Points.Clear();
            Chart4.Legends[0].CustomItems.Clear();

            NoRep.Visible = false;
            var Vall = Obj.ExecuteProcedureID("GetReportCountBySection", Convert.ToInt32(Admins.SelectedValue));
            if (Vall != 0)
            {
                NoRep.Visible = false;
                Chart3.DataSource = Obj.GetDataSetByID("GetChartBySection", Convert.ToInt32(Admins.SelectedValue));

                Chart3.Series[0].XValueMember = "Importance";
                Chart3.Series[0].YValueMembers = "Counts";
                Chart3.DataBind();

                Chart3.ChartAreas[0].AxisX.Title = "مستوى الأهمية";
                Chart3.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
                Chart3.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
                Chart3.Series[0]["PieLabelStyle"] = "Outside";

                Chart3.Series[0].BorderColor = System.Drawing.Color.Transparent;
                Chart3.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;

                LegendItem ItmHigh = new LegendItem();
                ItmHigh.ImageStyle = LegendImageStyle.Rectangle;
                ItmHigh.BorderColor = System.Drawing.Color.Transparent;
                ItmHigh.Color = System.Drawing.Color.DarkRed;
                ItmHigh.Cells.Add(LegendCellType.Text, "مرتفغة", System.Drawing.ContentAlignment.MiddleCenter);
                ItmHigh.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);

                Chart3.Legends[0].CustomItems.Add(ItmHigh);

                LegendItem ItmMedium = new LegendItem();
                ItmMedium.ImageStyle = LegendImageStyle.Rectangle;
                ItmMedium.BorderColor = System.Drawing.Color.Transparent;
                ItmMedium.Color = System.Drawing.Color.Orange;
                ItmMedium.Cells.Add(LegendCellType.Text, "متوسطة", System.Drawing.ContentAlignment.MiddleCenter);
                ItmMedium.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);


                Chart3.Legends[0].CustomItems.Add(ItmMedium);
                LegendItem ItmLow = new LegendItem();
                ItmLow.ImageStyle = LegendImageStyle.Rectangle;
                ItmLow.BorderColor = System.Drawing.Color.Transparent;
                ItmLow.Color = System.Drawing.Color.LightGreen;
                ItmLow.Cells.Add(LegendCellType.Text, "منخفضة", System.Drawing.ContentAlignment.MiddleCenter);
                ItmLow.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);

                Chart3.Legends[0].CustomItems.Add(ItmLow);
                DataSet GetCountsData = Obj.GetDataSetByID("GetRepCountByStatSec01", Convert.ToInt32(Admins.SelectedValue));


                foreach (var item in Chart3.Series[0].Points)
                {
                    var DSCounts = GetCountsData.Tables[0].AsEnumerable().Where(x => x.Field<int>("Importance") == Convert.ToInt32(item.XValue)).FirstOrDefault();

                    if (DSCounts != null)
                    {

                        item.ToolTip = " المعالج " + " [" + DSCounts["Status3"].ToString() + "] %" + DSCounts["PercDone"].ToString() + Environment.NewLine + "المتبقى " + string.Concat("[", DSCounts["NotDoneAll"].ToString()) + "] %" + DSCounts["PercNotDone"].ToString();


                    }
                    if (Convert.ToInt32(item.XValue) == 3)
                    {
                        var a = ((item.YValues[0]) * 100 / Vall);
                        item.PostBackValue = "3";

                        item.Color = System.Drawing.Color.DarkRed;
                        item.Label = Math.Round(a, 2, MidpointRounding.ToEven).ToString() + "%" + "[" + item.YValues[0].ToString() + "]";

                        item.IsVisibleInLegend = false;
                    }

                    else if (Convert.ToInt32(item.XValue) == 2)
                    {
                        var a = ((item.YValues[0]) * 100 / Vall);
                        item.PostBackValue = "2";

                        item.Color = System.Drawing.Color.Orange;
                        item.Label = Math.Round(a, 2, MidpointRounding.ToEven).ToString() + "%" + "[" + item.YValues[0].ToString() + "]";
                        item.IsVisibleInLegend = false;
                    }
                    else if (Convert.ToInt32(item.XValue) == 1)
                    {
                        var a = ((item.YValues[0]) * 100 / Vall);
                        item.PostBackValue = "1";

                        item.Color = System.Drawing.Color.LightGreen;
                        item.Label = Math.Round(a, 2, MidpointRounding.ToEven).ToString() + "%" + "[" + item.YValues[0].ToString() + "]";
                        item.IsVisibleInLegend = false;
                    }
                }

                ////// Chart4 ////

                Chart4.DataSource = Obj.GetDataSetByID("GetChartBySectionStat", Convert.ToInt32(Admins.SelectedValue));

                Chart4.Series[0].XValueMember = "Stat";
                Chart4.Series[0].YValueMembers = "Counts";
                Chart4.DataBind();
                Chart4.ChartAreas[0].AxisX.Title = "مستوى التنفيذ ";


                Chart4.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
                Chart4.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
                Chart4.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = true;
                Chart4.Series[0]["PieLabelStyle"] = "Outside";
                Chart4.Series[0].BorderColor = System.Drawing.Color.Transparent;
                Chart4.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;

                LegendItem itemNotNow = new LegendItem();
                itemNotNow.ImageStyle = LegendImageStyle.Rectangle;
                itemNotNow.BorderColor = System.Drawing.Color.Transparent;
                itemNotNow.Color = System.Drawing.ColorTranslator.FromHtml("#5b9092");
                itemNotNow.Cells.Add(LegendCellType.Text, "لم يحن وقت التنفيذ", System.Drawing.ContentAlignment.MiddleCenter);
                itemNotNow.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);
                itemNotNow.ToolTip = "لم يحن تاريخ تنفيذ التوصية/ الملاحظة المتفق عليه مع الإدارة متوسطة";

                Chart4.Legends[0].CustomItems.Add(itemNotNow);



                LegendItem itemClosed = new LegendItem();
                itemClosed.ImageStyle = LegendImageStyle.Rectangle;
                itemClosed.BorderColor = System.Drawing.Color.Transparent;
                itemClosed.Color = System.Drawing.ColorTranslator.FromHtml("#cccccc");
                itemClosed.Cells.Add(LegendCellType.Text, "مغلقة", System.Drawing.ContentAlignment.MiddleCenter);
                itemClosed.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);
                itemClosed.ToolTip = "لعدم مناسبة تطبيقها في الوقت الحالي ، لتكرارها في تقرير آخر";

                Chart4.Legends[0].CustomItems.Add(itemClosed);

                LegendItem itemNotDone = new LegendItem();
                itemNotDone.ImageStyle = LegendImageStyle.Rectangle;
                itemNotDone.BorderColor = System.Drawing.Color.Transparent;
                itemNotDone.Color = System.Drawing.Color.DarkRed;
                itemNotDone.Cells.Add(LegendCellType.Text, "متأخرة", System.Drawing.ContentAlignment.MiddleCenter);
                itemNotDone.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);
                itemNotDone.ToolTip = "لم يتم معالجة التوصية / الملاحظة وفقا لتاريخ الانتهاء المقدم من قبل الإدارة متوسطة";
                Chart4.Legends[0].CustomItems.Add(itemNotDone);

                LegendItem itemSemiDone = new LegendItem();
                itemSemiDone.ImageStyle = LegendImageStyle.Rectangle;
                itemSemiDone.BorderColor = System.Drawing.Color.Transparent;
                itemSemiDone.Color = System.Drawing.ColorTranslator.FromHtml("#e7ea56");

                itemSemiDone.Cells.Add(LegendCellType.Text, "جارى التنفيذ", System.Drawing.ContentAlignment.MiddleCenter);
                itemSemiDone.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);
                itemSemiDone.ToolTip = "تم تنفيذ جزء من التوصية فقط / جزء من الملاحظة";

                Chart4.Legends[0].CustomItems.Add(itemSemiDone);


                LegendItem itemDone = new LegendItem();
                itemDone.ImageStyle = LegendImageStyle.Rectangle;
                itemDone.BorderColor = System.Drawing.Color.Transparent;
                itemDone.Color = System.Drawing.Color.LightGreen;
                itemDone.Cells.Add(LegendCellType.Text, "معالجة", System.Drawing.ContentAlignment.MiddleCenter);
                itemDone.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);
                itemDone.ToolTip = "تم معالجة وتنفيذ جميع التوصيات";
                Chart4.Legends[0].CustomItems.Add(itemDone);
                foreach (var item2 in Chart4.Series[0].Points)
                {
                    var a = ((item2.YValues[0]) * 100 / Vall);

                    item2.PostBackValue = "#Index";
                    item2.ToolTip = item2.Label = Math.Round(a, 2, MidpointRounding.ToEven).ToString() + "%" + "[" + item2.YValues[0].ToString() + "]";

                    if (Convert.ToInt32(item2.XValue) == 3)
                    {
                        item2.PostBackValue = "3";

                        item2.Color = System.Drawing.Color.LightGreen;
                        item2.IsVisibleInLegend = false;


                    }

                    else if (Convert.ToInt32(item2.XValue) == 2)
                    {
                        item2.ToolTip = item2.Label = Math.Round(a, 2, MidpointRounding.ToEven).ToString() + "%" + "[" + item2.YValues[0].ToString() + "]";

                        item2.PostBackValue = "2";
                        item2.Color = System.Drawing.ColorTranslator.FromHtml("#e7ea56");
                        item2.IsVisibleInLegend = false;


                    }
                    else if (Convert.ToInt32(item2.XValue) == 1)
                    {
                        item2.PostBackValue = "1";

                        item2.Color = System.Drawing.Color.DarkRed;
                        item2.IsVisibleInLegend = false;

                    }
                    else if (Convert.ToInt32(item2.XValue) == 5)
                    {
                        item2.PostBackValue = "5";

                        item2.Color = System.Drawing.ColorTranslator.FromHtml("#cccccc");
                        item2.IsVisibleInLegend = false;

                    }
                    else if (Convert.ToInt32(item2.XValue) == 4)
                    {
                        item2.PostBackValue = "4";

                        item2.Color = System.Drawing.ColorTranslator.FromHtml("#5b9092");

                        item2.IsVisibleInLegend = false;
                    }

                }

            }
            else { NoRep.Visible = true; }

            //RepData.DataSource = Obj.GetDataSetByID("GetSectionCounts", Convert.ToInt32(Admins.SelectedValue));
            //RepData.DataBind();
        }

    }



    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Session["UData"] != null)
            {
                DataSet MyRecDataSet = (DataSet)Session["UData"];


                // if (Obj.ExecuteProcedureID("CheckSectionManger", Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["EmpID"])) == 1)
                // {
                DataSet DSSections = Obj.GetDataSetByID("GetSectionsByManager", Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["EmpID"]));
                if (DSSections.Tables[0].Rows.Count > 0)
                {
                    Admins.Items.Clear();
                    Admins.DataSource = DSSections;
                    Admins.DataTextField = "SectionName";
                    Admins.DataValueField = "SectionID";
                    Admins.DataBind();
                    Admins.Items.Insert(0, "");

                }
                //    else
                //    {
                //        Admins.Items.Clear();
                //        Admins.DataSource = DSSections;
                //        Admins.DataTextField = "SectionName";
                //        Admins.DataValueField = "SectionID";
                //        Admins.DataBind();
                //        Admins.SelectedValue = DSSections.Tables[0].Rows[0]["SectionID"].ToString();
                //        Admins.Enabled = false;

            //        PrntView.Attributes.Remove("style");
                //        PrntView.Style.Add("display", "block");

            //        PrevAll.Attributes.Remove("style");
                //        PrevAll.Style.Add("display", "block");

            //        RepYears.DataSource = Obj.GetDataSetByID("GetPlansBySection", Convert.ToInt32(Admins.SelectedValue));
                //        RepYears.DataBind();

            //        FillSectorChart();
                //    }
                //}
                else if (Convert.ToBoolean(MyRecDataSet.Tables[0].Rows[0]["SystemAdmin"]) == true)
                {
                    Admins.Items.Clear();
                    Admins.DataSource = Obj.GetDataSet("GetSectionsDashboard");
                    Admins.DataTextField = "SectionName";
                    Admins.DataValueField = "SectionID";
                    Admins.DataBind();
                    Admins.Items.Insert(0, "");

                }
                else
                {
                    Response.Redirect("NoPermissions.aspx");
                }
            }
        }
    }
    protected void Chart1_Click(object sender, ImageMapEventArgs e)
    {
        ChartImportByAdm.DataSource = null;
        ChartImportByAdm.DataBind();
        ChartImportByAdm.Legends[0].CustomItems.Clear();
        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "GetDetails();", true);

        DataSet Ds = null;

        string PostVal = e.PostBackValue.ToString();

        string[] splitString = PostVal.Split(',');

        string Case = "";
        if (splitString[0] == "3")
        {
            Case = "المعالجة";
        }
        else if (splitString[0] == "2")
        {
            Case = "جارى التنفيذ";
        } if (splitString[0] == "4")
        {
            Case = "لم يحن وقت تنفيذها";
        }
        if (splitString[0] == "5")
        {
            Case = "مغلقة";
        }
        if (splitString[0] == "1")
        {
            Case = "متأخرة";
        }
        LbelPup.Text = "مستوى الأهمية'" + Case + "' للملاحظات التى تخص";
        LbelPup.Text += " " + Convert.ToString(splitString[3].Trim());
        Ds = Obj.GetChartBySectionAdminStat(Convert.ToInt32(Admins.SelectedValue), Convert.ToInt32(splitString[1].Trim()), Convert.ToInt32(splitString[0].Trim()));


        var Vall = Obj.GetReportCountBySecAdmStat(Convert.ToInt32(Admins.SelectedValue), Convert.ToInt32(splitString[1].Trim()), Convert.ToInt32(splitString[0].Trim()));

        if (Vall != 0)
        {

            ChartImportByAdm.DataSource = Ds;
            ChartImportByAdm.Series[0].XValueMember = "Importance";
            ChartImportByAdm.Series[0].YValueMembers = "Counts";
            ChartImportByAdm.DataBind();

            ChartImportByAdm.ChartAreas[0].AxisX.Title = "مستوى الأهمية";
            ChartImportByAdm.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            ChartImportByAdm.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            ChartImportByAdm.Series[0]["PieLabelStyle"] = "Outside";

            ChartImportByAdm.Series[0].BorderColor = System.Drawing.Color.Transparent;
            ChartImportByAdm.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;

            LegendItem ItmHigh = new LegendItem();
            ItmHigh.ImageStyle = LegendImageStyle.Rectangle;
            ItmHigh.BorderColor = System.Drawing.Color.Transparent;
            ItmHigh.Color = System.Drawing.Color.DarkRed;
            ItmHigh.Cells.Add(LegendCellType.Text, "مرتفغة", System.Drawing.ContentAlignment.MiddleCenter);
            ItmHigh.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);

            ChartImportByAdm.Legends[0].CustomItems.Add(ItmHigh);

            LegendItem ItmMedium = new LegendItem();
            ItmMedium.ImageStyle = LegendImageStyle.Rectangle;
            ItmMedium.BorderColor = System.Drawing.Color.Transparent;
            ItmMedium.Color = System.Drawing.Color.Orange;
            ItmMedium.Cells.Add(LegendCellType.Text, "متوسطة", System.Drawing.ContentAlignment.MiddleCenter);
            ItmMedium.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);


            ChartImportByAdm.Legends[0].CustomItems.Add(ItmMedium);

            LegendItem ItmLow = new LegendItem();
            ItmLow.ImageStyle = LegendImageStyle.Rectangle;
            ItmLow.BorderColor = System.Drawing.Color.Transparent;
            ItmLow.Color = System.Drawing.Color.LightGreen;
            ItmLow.Cells.Add(LegendCellType.Text, "منخفضة", System.Drawing.ContentAlignment.MiddleCenter);
            ItmLow.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);

            ChartImportByAdm.Legends[0].CustomItems.Add(ItmLow);





            foreach (var item in ChartImportByAdm.Series[0].Points)
            {
                if (Convert.ToInt32(item.XValue) == 3)
                {
                    var a = ((item.YValues[0]) * 100 / Vall);
                    item.PostBackValue = "3";

                    item.Color = System.Drawing.Color.DarkRed;
                    item.Label = Math.Round(a, 2, MidpointRounding.ToEven).ToString() + "%" + "[" + item.YValues[0].ToString() + "]";
                    item.IsVisibleInLegend = false;

                }

                else if (Convert.ToInt32(item.XValue) == 2)
                {
                    var a = ((item.YValues[0]) * 100 / Vall);
                    item.PostBackValue = "2";

                    item.Color = System.Drawing.Color.Orange;
                    item.Label = Math.Round(a, 2, MidpointRounding.ToEven).ToString() + "%" + "[" + item.YValues[0].ToString() + "]";
                    item.IsVisibleInLegend = false;
                }
                else if (Convert.ToInt32(item.XValue) == 1)
                {
                    var a = ((item.YValues[0]) * 100 / Vall);
                    item.PostBackValue = "1";

                    item.Color = System.Drawing.Color.LightGreen;
                    item.Label = Math.Round(a, 2, MidpointRounding.ToEven).ToString() + "%" + "[" + item.YValues[0].ToString() + "]";
                    item.IsVisibleInLegend = false;
                }
            }
        }

        //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "GetDetails();", true);

        //string PostVal = e.PostBackValue;

        //string[] splitString = PostVal.Split(',');


        //DataSet ds = Obj.GetImportByAdminStat(Convert.ToInt32(splitString[1].Trim()), Convert.ToInt32(splitString[0].Trim()));

        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //    {
        //        ChartStatus.Series["HighStat"].Points.Add(new DataPoint(i, ds.Tables[0].Rows[i]["Status3"].ToString().Trim()));
        //        ChartStatus.Series["IntermedStat"].Points.Add(new DataPoint(i, ds.Tables[0].Rows[i]["Status2"].ToString().Trim()));
        //        ChartStatus.Series["LowStat"].Points.Add(new DataPoint(i, ds.Tables[0].Rows[i]["Status1"].ToString().Trim()));

        //        ChartStatus.Series[0].Points[i].AxisLabel = ds.Tables[0].Rows[i]["AdmName"].ToString() + " [ " + ds.Tables[0].Rows[i]["TotalCount"] + " ]  ";

        //        ChartStatus.Series["HighStat"].Points[i].ToolTip = " [ " + ds.Tables[0].Rows[i]["Status3"] + "] " + Math.Round(((Convert.ToDouble(ds.Tables[0].Rows[i]["Status3"]) / Convert.ToDouble(ds.Tables[0].Rows[i]["TotalCount"])) * 100), 1).ToString() + "%";

        //        ChartStatus.Series["IntermedStat"].Points[i].ToolTip = " [ " + ds.Tables[0].Rows[i]["Status2"] + "] " + Math.Round(((Convert.ToDouble(ds.Tables[0].Rows[i]["Status2"]) / Convert.ToDouble(ds.Tables[0].Rows[i]["TotalCount"])) * 100), 1).ToString() + "%";

        //        ChartStatus.Series["LowStat"].Points[i].ToolTip = " [ " + ds.Tables[0].Rows[i]["Status1"] + "] " + Math.Round(((Convert.ToDouble(ds.Tables[0].Rows[i]["Status1"]) / Convert.ToDouble(ds.Tables[0].Rows[i]["TotalCount"])) * 100), 1).ToString() + "%";

        //        ChartStatus.Series["HighStat"].LegendText = "مرتفعة [ " + ds.Tables[0].Rows[i]["Status3"] + "] " + Math.Round(((Convert.ToDouble(ds.Tables[0].Rows[i]["Status3"]) / Convert.ToDouble(ds.Tables[0].Rows[i]["TotalCount"])) * 100), 1).ToString() + "%";

        //        ChartStatus.Series["IntermedStat"].LegendText = "متوسطة [ " + ds.Tables[0].Rows[i]["Status2"] + "] " + Math.Round(((Convert.ToDouble(ds.Tables[0].Rows[i]["Status2"]) / Convert.ToDouble(ds.Tables[0].Rows[i]["TotalCount"])) * 100), 1).ToString() + "%";

        //        ChartStatus.Series["LowStat"].LegendText = "منخفضة [ " + ds.Tables[0].Rows[i]["Status1"] + "] " + Math.Round(((Convert.ToDouble(ds.Tables[0].Rows[i]["Status1"]) / Convert.ToDouble(ds.Tables[0].Rows[i]["TotalCount"])) * 100), 1).ToString() + "%";


        //    }

        //}


        //ChartStatus.ChartAreas[0].InnerPlotPosition.Auto = true;
        //ChartStatus.ChartAreas[0].InnerPlotPosition.Width = 97;
        //ChartStatus.ChartAreas[0].InnerPlotPosition.Height = 45;

        //ChartStatus.Series["HighStat"].SetCustomProperty("PixelPointWidth", "100");
        //ChartStatus.Series["IntermedStat"].SetCustomProperty("PixelPointWidth", "100");
        //ChartStatus.Series["LowStat"].SetCustomProperty("PixelPointWidth", "100");

    }


    protected void Admins_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Admins.SelectedValue != "")
        {


            Chart1.Series["Done"].Points.Clear();
            Chart1.Series["SimyDone"].Points.Clear();
            Chart1.Series["NotNow"].Points.Clear();
            Chart1.Series["NotDone"].Points.Clear();
            Chart1.Series["Closed"].Points.Clear();
            Chart1.Legends[0].CustomItems.Clear();

            Chart4.Series[0].Points.Clear();
            Chart4.Legends[0].CustomItems.Clear();
            Chart3.Series[0].Points.Clear();
            Chart3.Legends[0].CustomItems.Clear();
            DataSet ds = Obj.GetDataSetByID("GetAllAdminsBySection", Convert.ToInt32(Admins.SelectedValue));
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    Chart1.Series["Done"].Points.Add(new DataPoint(i, ds.Tables[0].Rows[i]["Status3"].ToString().Trim()));
                    Chart1.Series["SimyDone"].Points.Add(new DataPoint(i, ds.Tables[0].Rows[i]["Status2"].ToString().Trim()));
                    Chart1.Series["NotNow"].Points.Add(new DataPoint(i, ds.Tables[0].Rows[i]["Status4"].ToString().Trim()));
                    Chart1.Series["NotDone"].Points.Add(new DataPoint(i, ds.Tables[0].Rows[i]["Status1"].ToString().Trim()));
                    Chart1.Series["Closed"].Points.Add(new DataPoint(i, ds.Tables[0].Rows[i]["Status5"].ToString().Trim()));
                    Chart1.Series[0].Points[i].AxisLabel = ds.Tables[0].Rows[i]["AdmName"].ToString() + " [ " + ds.Tables[0].Rows[i]["TotalCount"] + " ]  ";

                    Chart1.Series["Done"].Points[i].ToolTip = "[" + ds.Tables[0].Rows[i]["Status3"].ToString() + "] " + Math.Round(((Convert.ToDouble(ds.Tables[0].Rows[i]["Status3"]) / Convert.ToDouble(ds.Tables[0].Rows[i]["TotalCount"])) * 100), 1).ToString() + "%";
                    Chart1.Series["Done"].Points[i].PostBackValue = "3" + "," + ds.Tables[0].Rows[i]["RepAdms"].ToString().Trim() + "," + ds.Tables[0].Rows[i]["AdmName"].ToString() + "," + ds.Tables[0].Rows[i]["AdmName"].ToString();


                    Chart1.Series["SimyDone"].Points[i].ToolTip = "[" + ds.Tables[0].Rows[i]["Status2"].ToString() + "] " + Math.Round(((Convert.ToDouble(ds.Tables[0].Rows[i]["Status2"]) / Convert.ToDouble(ds.Tables[0].Rows[i]["TotalCount"])) * 100), 1).ToString() + "%";
                    Chart1.Series["SimyDone"].Points[i].PostBackValue = "2" + "," + ds.Tables[0].Rows[i]["RepAdms"].ToString().Trim() + "," + ds.Tables[0].Rows[i]["AdmName"].ToString() + "," + ds.Tables[0].Rows[i]["AdmName"].ToString();

                    Chart1.Series["NotNow"].Points[i].ToolTip = "[" + ds.Tables[0].Rows[i]["Status4"].ToString() + "] " + Math.Round(((Convert.ToDouble(ds.Tables[0].Rows[i]["Status4"]) / Convert.ToDouble(ds.Tables[0].Rows[i]["TotalCount"])) * 100), 1).ToString() + "%";
                    Chart1.Series["NotNow"].Points[i].PostBackValue = "4" + "," + ds.Tables[0].Rows[i]["RepAdms"].ToString().Trim() + "," + ds.Tables[0].Rows[i]["AdmName"].ToString() + "," + ds.Tables[0].Rows[i]["AdmName"].ToString();


                    Chart1.Series["NotDone"].Points[i].ToolTip = "[" + ds.Tables[0].Rows[i]["Status1"].ToString() + "] " + Math.Round(((Convert.ToDouble(ds.Tables[0].Rows[i]["Status1"]) / Convert.ToDouble(ds.Tables[0].Rows[i]["TotalCount"])) * 100), 1).ToString() + "%";
                    Chart1.Series["NotDone"].Points[i].PostBackValue = "1" + "," + ds.Tables[0].Rows[i]["RepAdms"].ToString().Trim() + "," + ds.Tables[0].Rows[i]["AdmName"].ToString() + "," + ds.Tables[0].Rows[i]["AdmName"].ToString();

                    Chart1.Series["Closed"].Points[i].ToolTip = "[" + ds.Tables[0].Rows[i]["Status5"].ToString() + "] " + Math.Round(((Convert.ToDouble(ds.Tables[0].Rows[i]["Status5"]) / Convert.ToDouble(ds.Tables[0].Rows[i]["TotalCount"])) * 100), 1).ToString() + "%";
                    Chart1.Series["Closed"].Points[i].PostBackValue = "5" + "," + ds.Tables[0].Rows[i]["RepAdms"].ToString().Trim() + "," + ds.Tables[0].Rows[i]["AdmName"].ToString() + "," + ds.Tables[0].Rows[i]["AdmName"].ToString();

                }



                Chart1.Series["Done"].SetCustomProperty("PixelPointWidth", "30");
                Chart1.Series["SimyDone"].SetCustomProperty("PixelPointWidth", "30");
                Chart1.Series["NotNow"].SetCustomProperty("PixelPointWidth", "30");
                Chart1.Series["NotDone"].SetCustomProperty("PixelPointWidth", "30");
                Chart1.Series["Closed"].SetCustomProperty("PixelPointWidth", "30");

                LegendItem itemNotNow = new LegendItem();
                itemNotNow.ImageStyle = LegendImageStyle.Rectangle;
                itemNotNow.BorderColor = System.Drawing.Color.Transparent;
                itemNotNow.Color = System.Drawing.ColorTranslator.FromHtml("#5b9092");
                itemNotNow.Cells.Add(LegendCellType.Text, "لم يحن وقت التنفيذ", System.Drawing.ContentAlignment.MiddleCenter);
                itemNotNow.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);
                itemNotNow.ToolTip = "لم يحن تاريخ تنفيذ التوصية/ الملاحظة المتفق عليه مع الإدارة متوسطة";

                Chart1.Legends[0].CustomItems.Add(itemNotNow);



                LegendItem itemClosed = new LegendItem();
                itemClosed.ImageStyle = LegendImageStyle.Rectangle;
                itemClosed.BorderColor = System.Drawing.Color.Transparent;
                itemClosed.Color = System.Drawing.ColorTranslator.FromHtml("#cccccc");
                itemClosed.Cells.Add(LegendCellType.Text, "مغلقة", System.Drawing.ContentAlignment.MiddleCenter);
                itemClosed.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);
                itemClosed.ToolTip = "لعدم مناسبة تطبيقها في الوقت الحالي ، لتكرارها في تقرير آخر";

                Chart1.Legends[0].CustomItems.Add(itemClosed);

                LegendItem itemNotDone = new LegendItem();
                itemNotDone.ImageStyle = LegendImageStyle.Rectangle;
                itemNotDone.BorderColor = System.Drawing.Color.Transparent;
                itemNotDone.Color = System.Drawing.Color.DarkRed;
                itemNotDone.Cells.Add(LegendCellType.Text, "متأخرة", System.Drawing.ContentAlignment.MiddleCenter);
                itemNotDone.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);
                itemNotDone.ToolTip = "لم يتم معالجة التوصية / الملاحظة وفقا لتاريخ الانتهاء المقدم من قبل الإدارة متوسطة";
                Chart1.Legends[0].CustomItems.Add(itemNotDone);

                LegendItem itemSemiDone = new LegendItem();
                itemSemiDone.ImageStyle = LegendImageStyle.Rectangle;
                itemSemiDone.BorderColor = System.Drawing.Color.Transparent;
                itemSemiDone.Color = System.Drawing.ColorTranslator.FromHtml("#e7ea56");

                itemSemiDone.Cells.Add(LegendCellType.Text, "جارى التنفيذ", System.Drawing.ContentAlignment.MiddleCenter);
                itemSemiDone.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);
                itemSemiDone.ToolTip = "تم تنفيذ جزء من التوصية فقط / جزء من الملاحظة";

                Chart1.Legends[0].CustomItems.Add(itemSemiDone);


                LegendItem itemDone = new LegendItem();
                itemDone.ImageStyle = LegendImageStyle.Rectangle;
                itemDone.BorderColor = System.Drawing.Color.Transparent;
                itemDone.Color = System.Drawing.Color.LightGreen;
                itemDone.Cells.Add(LegendCellType.Text, "معالجة", System.Drawing.ContentAlignment.MiddleCenter);
                itemDone.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);
                itemDone.ToolTip = "تم معالجة وتنفيذ جميع التوصيات";
                Chart1.Legends[0].CustomItems.Add(itemDone);

                Chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -30;
                Chart1.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount;
                Chart1.ChartAreas[0].AxisX.IsLabelAutoFit = false;



                for (int j = 0; j < Chart1.Series.Count; j++)
                {
                    Chart1.Series[j].SmartLabelStyle.CalloutLineAnchorCapStyle = LineAnchorCapStyle.None;
                    Chart1.Series[j].SmartLabelStyle.CalloutLineColor = System.Drawing.Color.Transparent;

                    foreach (DataPoint point in Chart1.Series[j].Points)
                    {
                        if (point.YValues.Length > 0 && (double)point.YValues.GetValue(0) == 0)
                        {

                            point.IsEmpty = true;
                        }
                        else
                        {
                            point.IsEmpty = false;
                        }
                    }
                }
                PrntView.Attributes.Remove("style");
                PrntView.Style.Add("display", "block");

                PrevAll.Attributes.Remove("style");
                PrevAll.Style.Add("display", "block");

                NoRep.Visible = false;

                RepYears.DataSource = Obj.GetDataSetByID("GetPlansBySection", Convert.ToInt32(Admins.SelectedValue));
                RepYears.DataBind();
                FillSectorChart();
                RepTotals.DataSource = Obj.GetDataSetByID("GetRepSectionCounts", Convert.ToInt32(Admins.SelectedValue));
                RepTotals.DataBind();


                Repeater2.DataSource = EmployeesData.DataSource = ds;
                EmployeesData.DataBind();

                Repeater2.DataBind();
            }
            else
            {
                PrntView.Attributes.Remove("style");
                PrntView.Style.Add("display", "none");

                PrevAll.Attributes.Remove("style");
                PrevAll.Style.Add("display", "none");

                NoRep.Visible = true;
            }

        }
    }
    protected void RepYears_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        if ((((Label)e.Item.FindControl("PlanID")).Text != "") && Admins.SelectedValue != "")
        {
            ((Repeater)e.Item.FindControl("RepTotalsYears")).DataSource = Obj.GetDataSetBy2ID("GetRepSectionAllPlansBySec", Convert.ToInt32(Admins.SelectedValue), Convert.ToInt32(((Label)e.Item.FindControl("PlanID")).Text));
            ((Repeater)e.Item.FindControl("RepTotalsYears")).DataBind();

            ((Repeater)e.Item.FindControl("EmployeesDataYears")).DataSource = ((Repeater)e.Item.FindControl("Repeater2Years")).DataSource = Obj.GetDataSetBy2ID("GetAllSectionsChartPlanSEC", Convert.ToInt32(Admins.SelectedValue), Convert.ToInt32(((Label)e.Item.FindControl("PlanID")).Text));
            ((Repeater)e.Item.FindControl("Repeater2Years")).DataBind();
            ((Repeater)e.Item.FindControl("EmployeesDataYears")).DataBind();
            DataSet ds = Obj.GetAllAdminsByPlan(Convert.ToInt32(((Label)e.Item.FindControl("PlanID")).Text), Convert.ToInt32(Admins.SelectedValue));

            if (ds.Tables[0].Rows.Count > 0)
            {

                //////////////////////////////////////////////////////////////////////////////////////////

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ((Chart)e.Item.FindControl("DataTotal")).Series["Done"].Points.Add(new DataPoint(i, ds.Tables[0].Rows[i]["Status3"].ToString().Trim()));
                    ((Chart)e.Item.FindControl("DataTotal")).Series["SimyDone"].Points.Add(new DataPoint(i, ds.Tables[0].Rows[i]["Status2"].ToString().Trim()));
                    ((Chart)e.Item.FindControl("DataTotal")).Series["NotNow"].Points.Add(new DataPoint(i, ds.Tables[0].Rows[i]["Status4"].ToString().Trim()));
                    ((Chart)e.Item.FindControl("DataTotal")).Series["NotDone"].Points.Add(new DataPoint(i, ds.Tables[0].Rows[i]["Status1"].ToString().Trim()));
                    ((Chart)e.Item.FindControl("DataTotal")).Series["Closed"].Points.Add(new DataPoint(i, ds.Tables[0].Rows[i]["Status5"].ToString().Trim()));

                    ((Chart)e.Item.FindControl("DataTotal")).Series[0].Points[i].AxisLabel = ds.Tables[0].Rows[i]["AdmName"].ToString() + " [ " + ds.Tables[0].Rows[i]["TotalCount"] + " ]  ";
                    ((Chart)e.Item.FindControl("DataTotal")).Series["Done"].Points[i].ToolTip = "[" + ds.Tables[0].Rows[i]["Status3"] + "] " + Math.Round(((Convert.ToDouble(ds.Tables[0].Rows[i]["Status3"]) / Convert.ToDouble(ds.Tables[0].Rows[i]["TotalCount"])) * 100), 1).ToString() + "%";
                    ((Chart)e.Item.FindControl("DataTotal")).Series["Done"].Points[i].PostBackValue = "3" + "," + ds.Tables[0].Rows[i]["RepAdms"].ToString().Trim() + "," + ((Label)e.Item.FindControl("PlanID")).Text + "," + ds.Tables[0].Rows[i]["AdmName"].ToString();
                    for (int j = 0; j < ((Chart)e.Item.FindControl("DataTotal")).Series.Count; j++)
                    {
                        ((Chart)e.Item.FindControl("DataTotal")).Series[j].SmartLabelStyle.CalloutLineAnchorCapStyle = LineAnchorCapStyle.None;
                        ((Chart)e.Item.FindControl("DataTotal")).Series[j].SmartLabelStyle.CalloutLineColor = System.Drawing.Color.Transparent;

                        foreach (DataPoint point in ((Chart)e.Item.FindControl("DataTotal")).Series[j].Points)
                        {
                            if (point.YValues.Length > 0 && (double)point.YValues.GetValue(0) == 0)
                            {

                                point.IsEmpty = true;
                            }
                            else
                            {
                                point.IsEmpty = false;
                            }
                        }
                    }



                    ((Chart)e.Item.FindControl("DataTotal")).Series["SimyDone"].Points[i].ToolTip = "[" + ds.Tables[0].Rows[i]["Status2"] + "] " + Math.Round(((Convert.ToDouble(ds.Tables[0].Rows[i]["Status2"]) / Convert.ToDouble(ds.Tables[0].Rows[i]["TotalCount"])) * 100), 1).ToString() + "%";
                    ((Chart)e.Item.FindControl("DataTotal")).Series["SimyDone"].Points[i].PostBackValue = "2" + "," + ds.Tables[0].Rows[i]["RepAdms"].ToString().Trim() + "," + ((Label)e.Item.FindControl("PlanID")).Text + "," + ds.Tables[0].Rows[i]["AdmName"].ToString();

                    ((Chart)e.Item.FindControl("DataTotal")).Series["NotNow"].Points[i].ToolTip = "[" + ds.Tables[0].Rows[i]["Status4"] + "] " + Math.Round(((Convert.ToDouble(ds.Tables[0].Rows[i]["Status4"]) / Convert.ToDouble(ds.Tables[0].Rows[i]["TotalCount"])) * 100), 1).ToString() + "%";
                    ((Chart)e.Item.FindControl("DataTotal")).Series["NotNow"].Points[i].PostBackValue = "4" + "," + ds.Tables[0].Rows[i]["RepAdms"].ToString().Trim() + "," + ((Label)e.Item.FindControl("PlanID")).Text + "," + ds.Tables[0].Rows[i]["AdmName"].ToString();


                    ((Chart)e.Item.FindControl("DataTotal")).Series["NotDone"].Points[i].ToolTip = "[" + ds.Tables[0].Rows[i]["Status1"] + "] " + Math.Round(((Convert.ToDouble(ds.Tables[0].Rows[i]["Status1"]) / Convert.ToDouble(ds.Tables[0].Rows[i]["TotalCount"])) * 100), 1).ToString() + "%";
                    ((Chart)e.Item.FindControl("DataTotal")).Series["NotDone"].Points[i].PostBackValue = "1" + "," + ds.Tables[0].Rows[i]["RepAdms"].ToString().Trim() + "," + ((Label)e.Item.FindControl("PlanID")).Text + "," + ds.Tables[0].Rows[i]["AdmName"].ToString();

                    ((Chart)e.Item.FindControl("DataTotal")).Series["Closed"].Points[i].ToolTip = "[" + ds.Tables[0].Rows[i]["Status5"] + "] " + Math.Round(((Convert.ToDouble(ds.Tables[0].Rows[i]["Status5"]) / Convert.ToDouble(ds.Tables[0].Rows[i]["TotalCount"])) * 100), 1).ToString() + "%";
                    ((Chart)e.Item.FindControl("DataTotal")).Series["Closed"].Points[i].PostBackValue = "5" + "," + ds.Tables[0].Rows[i]["RepAdms"].ToString().Trim() + "," + ((Label)e.Item.FindControl("PlanID")).Text + "," + ds.Tables[0].Rows[i]["AdmName"].ToString();

                    // ((Chart)e.Item.FindControl("DataTotal")).Series["Totalcount"].Points[i].PostBackValue = "All" + "," + ds.Tables[0].Rows[i]["RepAdms"].ToString().Trim() + "," + ((Label)e.Item.FindControl("PlanID")).Text;

                    ((Chart)e.Item.FindControl("DataTotal")).Series["Done"].SetCustomProperty("PixelPointWidth", "45");
                    ((Chart)e.Item.FindControl("DataTotal")).Series["SimyDone"].SetCustomProperty("PixelPointWidth", "45");
                    ((Chart)e.Item.FindControl("DataTotal")).Series["NotNow"].SetCustomProperty("PixelPointWidth", "45");
                    ((Chart)e.Item.FindControl("DataTotal")).Series["NotDone"].SetCustomProperty("PixelPointWidth", "45");
                    ((Chart)e.Item.FindControl("DataTotal")).Series["Closed"].SetCustomProperty("PixelPointWidth", "45");
                }



                ((Chart)e.Item.FindControl("DataTotal")).ChartAreas[0].AxisX.LabelStyle.Angle = -40;
                ((Chart)e.Item.FindControl("DataTotal")).ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount;
                ((Chart)e.Item.FindControl("DataTotal")).ChartAreas[0].AxisX.IsLabelAutoFit = false;
                LegendItem itemNotNow = new LegendItem();
                itemNotNow.ImageStyle = LegendImageStyle.Rectangle;
                itemNotNow.BorderColor = System.Drawing.Color.Transparent;
                itemNotNow.Color = System.Drawing.ColorTranslator.FromHtml("#5b9092");
                itemNotNow.Cells.Add(LegendCellType.Text, "لم يحن وقت التنفيذ", System.Drawing.ContentAlignment.MiddleCenter);
                itemNotNow.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);
                itemNotNow.ToolTip = "لم يحن تاريخ تنفيذ التوصية/ الملاحظة المتفق عليه مع الإدارة متوسطة";

                ((Chart)e.Item.FindControl("DataTotal")).Legends[0].CustomItems.Add(itemNotNow);



                LegendItem itemClosed = new LegendItem();
                itemClosed.ImageStyle = LegendImageStyle.Rectangle;
                itemClosed.BorderColor = System.Drawing.Color.Transparent;
                itemClosed.Color = System.Drawing.ColorTranslator.FromHtml("#cccccc");
                itemClosed.Cells.Add(LegendCellType.Text, "مغلقة", System.Drawing.ContentAlignment.MiddleCenter);
                itemClosed.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);
                itemClosed.ToolTip = "لعدم مناسبة تطبيقها في الوقت الحالي ، لتكرارها في تقرير آخر";

                ((Chart)e.Item.FindControl("DataTotal")).Legends[0].CustomItems.Add(itemClosed);

                LegendItem itemNotDone = new LegendItem();
                itemNotDone.ImageStyle = LegendImageStyle.Rectangle;
                itemNotDone.BorderColor = System.Drawing.Color.Transparent;
                itemNotDone.Color = System.Drawing.Color.DarkRed;
                itemNotDone.Cells.Add(LegendCellType.Text, "متأخرة", System.Drawing.ContentAlignment.MiddleCenter);
                itemNotDone.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);
                itemNotDone.ToolTip = "لم يتم معالجة التوصية / الملاحظة وفقا لتاريخ الانتهاء المقدم من قبل الإدارة متوسطة";
                ((Chart)e.Item.FindControl("DataTotal")).Legends[0].CustomItems.Add(itemNotDone);

                LegendItem itemSemiDone = new LegendItem();
                itemSemiDone.ImageStyle = LegendImageStyle.Rectangle;
                itemSemiDone.BorderColor = System.Drawing.Color.Transparent;
                itemSemiDone.Color = System.Drawing.ColorTranslator.FromHtml("#e7ea56");

                itemSemiDone.Cells.Add(LegendCellType.Text, "جارى التنفيذ", System.Drawing.ContentAlignment.MiddleCenter);
                itemSemiDone.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);
                itemSemiDone.ToolTip = "تم تنفيذ جزء من التوصية فقط / جزء من الملاحظة";

                ((Chart)e.Item.FindControl("DataTotal")).Legends[0].CustomItems.Add(itemSemiDone);


                LegendItem itemDone = new LegendItem();
                itemDone.ImageStyle = LegendImageStyle.Rectangle;
                itemDone.BorderColor = System.Drawing.Color.Transparent;
                itemDone.Color = System.Drawing.Color.LightGreen;
                itemDone.Cells.Add(LegendCellType.Text, "معالجة", System.Drawing.ContentAlignment.MiddleCenter);
                itemDone.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);
                itemDone.ToolTip = "تم معالجة وتنفيذ جميع التوصيات";
                ((Chart)e.Item.FindControl("DataTotal")).Legends[0].CustomItems.Add(itemDone);
            }





            DataSet Ds = Obj.GetStatusByYear(Convert.ToInt32(((Label)e.Item.FindControl("PlanID")).Text), Convert.ToInt32(Admins.SelectedValue));
            if (Ds.Tables[0].Rows.Count > 0)
            {
                //((Repeater)e.Item.FindControl("RepAdmDetails")).DataSource = Ds;

                //((Repeater)e.Item.FindControl("RepAdmDetails")).DataBind();
                ((Label)e.Item.FindControl("NoData")).Visible = false;

                var Vall = Obj.GetChartByPlanTotal(Convert.ToInt32(((Label)e.Item.FindControl("PlanID")).Text), Convert.ToInt32(Admins.SelectedValue));

                if (Vall != 0)
                {
                    ((Chart)e.Item.FindControl("Chart4")).DataSource = null;
                    ((Chart)e.Item.FindControl("Chart4")).DataBind();
                    ((Chart)e.Item.FindControl("Chart4")).Legends[0].CustomItems.Clear();
                    ////// Chart4 ////
                    DataSet DsChart = Obj.GetChartByPlan(Convert.ToInt32(((Label)e.Item.FindControl("PlanID")).Text), Convert.ToInt32(Admins.SelectedValue));

                    if (DsChart.Tables[0].Rows.Count > 0)
                    {
                        ((Chart)e.Item.FindControl("Chart4")).DataSource = DsChart;

                        ((Chart)e.Item.FindControl("Chart4")).Series[0].XValueMember = "Stat";
                        ((Chart)e.Item.FindControl("Chart4")).Series[0].YValueMembers = "Counts";
                        ((Chart)e.Item.FindControl("Chart4")).DataBind();
                        ((Chart)e.Item.FindControl("Chart4")).ChartAreas[0].AxisX.Title = "مستوى التنفيذ ";


                        ((Chart)e.Item.FindControl("Chart4")).ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
                        ((Chart)e.Item.FindControl("Chart4")).ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
                        ((Chart)e.Item.FindControl("Chart4")).ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = true;

                        ((Chart)e.Item.FindControl("Chart4")).Series[0]["PieLabelStyle"] = "Outside";
                        ((Chart)e.Item.FindControl("Chart4")).Series[0].BorderColor = System.Drawing.Color.Transparent;
                        ((Chart)e.Item.FindControl("Chart4")).ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;

                        LegendItem itemNotNow = new LegendItem();
                        itemNotNow.ImageStyle = LegendImageStyle.Rectangle;
                        itemNotNow.BorderColor = System.Drawing.Color.Transparent;
                        itemNotNow.Color = System.Drawing.ColorTranslator.FromHtml("#5b9092");
                        itemNotNow.Cells.Add(LegendCellType.Text, "لم يحن وقت التنفيذ", System.Drawing.ContentAlignment.MiddleCenter);
                        itemNotNow.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);
                        itemNotNow.ToolTip = "لم يحن تاريخ تنفيذ التوصية/ الملاحظة المتفق عليه مع الإدارة متوسطة";

                        ((Chart)e.Item.FindControl("Chart4")).Legends[0].CustomItems.Add(itemNotNow);



                        LegendItem itemClosed = new LegendItem();
                        itemClosed.ImageStyle = LegendImageStyle.Rectangle;
                        itemClosed.BorderColor = System.Drawing.Color.Transparent;
                        itemClosed.Color = System.Drawing.ColorTranslator.FromHtml("#cccccc");
                        itemClosed.Cells.Add(LegendCellType.Text, "مغلقة", System.Drawing.ContentAlignment.MiddleCenter);
                        itemClosed.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);
                        itemClosed.ToolTip = "لعدم مناسبة تطبيقها في الوقت الحالي ، لتكرارها في تقرير آخر";

                        ((Chart)e.Item.FindControl("Chart4")).Legends[0].CustomItems.Add(itemClosed);

                        LegendItem itemNotDone = new LegendItem();
                        itemNotDone.ImageStyle = LegendImageStyle.Rectangle;
                        itemNotDone.BorderColor = System.Drawing.Color.Transparent;
                        itemNotDone.Color = System.Drawing.Color.DarkRed;
                        itemNotDone.Cells.Add(LegendCellType.Text, "متأخرة", System.Drawing.ContentAlignment.MiddleCenter);
                        itemNotDone.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);
                        itemNotDone.ToolTip = "لم يتم معالجة التوصية / الملاحظة وفقا لتاريخ الانتهاء المقدم من قبل الإدارة متوسطة";
                        ((Chart)e.Item.FindControl("Chart4")).Legends[0].CustomItems.Add(itemNotDone);

                        LegendItem itemSemiDone = new LegendItem();
                        itemSemiDone.ImageStyle = LegendImageStyle.Rectangle;
                        itemSemiDone.BorderColor = System.Drawing.Color.Transparent;
                        itemSemiDone.Color = System.Drawing.ColorTranslator.FromHtml("#e7ea56");

                        itemSemiDone.Cells.Add(LegendCellType.Text, "جارى التنفيذ", System.Drawing.ContentAlignment.MiddleCenter);
                        itemSemiDone.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);
                        itemSemiDone.ToolTip = "تم تنفيذ جزء من التوصية فقط / جزء من الملاحظة";

                        ((Chart)e.Item.FindControl("Chart4")).Legends[0].CustomItems.Add(itemSemiDone);


                        LegendItem itemDone = new LegendItem();
                        itemDone.ImageStyle = LegendImageStyle.Rectangle;
                        itemDone.BorderColor = System.Drawing.Color.Transparent;
                        itemDone.Color = System.Drawing.Color.LightGreen;
                        itemDone.Cells.Add(LegendCellType.Text, "معالجة", System.Drawing.ContentAlignment.MiddleCenter);
                        itemDone.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);
                        itemDone.ToolTip = "تم معالجة وتنفيذ جميع التوصيات";
                        ((Chart)e.Item.FindControl("Chart4")).Legends[0].CustomItems.Add(itemDone);


                        foreach (var item2 in ((Chart)e.Item.FindControl("Chart4")).Series[0].Points)
                        {
                            var a = ((item2.YValues[0]) * 100 / Vall);

                            item2.PostBackValue = "#Index";

                            item2.ToolTip = item2.Label = Math.Round(a, 2, MidpointRounding.ToEven).ToString() + "%" + "[" + item2.YValues[0].ToString() + "]";

                            if (Convert.ToInt32(item2.XValue) == 3)
                            {
                                item2.PostBackValue = "3";

                                item2.Color = System.Drawing.Color.LightGreen;
                                item2.IsVisibleInLegend = false;


                            }

                            else if (Convert.ToInt32(item2.XValue) == 2)
                            {
                                item2.PostBackValue = "2";
                                item2.Color = System.Drawing.ColorTranslator.FromHtml("#e7ea56");
                                item2.IsVisibleInLegend = false;

                            }
                            else if (Convert.ToInt32(item2.XValue) == 1)
                            {
                                item2.PostBackValue = "1";

                                item2.Color = System.Drawing.Color.DarkRed;
                                item2.IsVisibleInLegend = false;
                            }
                            else if (Convert.ToInt32(item2.XValue) == 5)
                            {
                                item2.PostBackValue = "5";

                                item2.Color = System.Drawing.ColorTranslator.FromHtml("#cccccc");
                                item2.IsVisibleInLegend = false;
                            }
                            else if (Convert.ToInt32(item2.XValue) == 4)
                            {
                                item2.PostBackValue = "4";

                                item2.Color = System.Drawing.ColorTranslator.FromHtml("#5b9092");
                                item2.IsVisibleInLegend = false;
                            }

                        }

                        ////
                        ((Chart)e.Item.FindControl("ChartImport")).DataSource = Obj.GetChartByPlanImport(Convert.ToInt32(((Label)e.Item.FindControl("PlanID")).Text), Convert.ToInt32(Admins.SelectedValue));

                        ((Chart)e.Item.FindControl("ChartImport")).Series[0].XValueMember = "Importance";
                        ((Chart)e.Item.FindControl("ChartImport")).Series[0].YValueMembers = "Counts";
                        ((Chart)e.Item.FindControl("ChartImport")).DataBind();

                        ((Chart)e.Item.FindControl("ChartImport")).ChartAreas[0].AxisX.Title = "مستوى الأهمية";
                        ((Chart)e.Item.FindControl("ChartImport")).ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
                        ((Chart)e.Item.FindControl("ChartImport")).ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
                        ((Chart)e.Item.FindControl("ChartImport")).Series[0]["PieLabelStyle"] = "Outside";
                        ((Chart)e.Item.FindControl("ChartImport")).Series[0].BorderColor = System.Drawing.Color.Transparent;
                        ((Chart)e.Item.FindControl("ChartImport")).ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;

                        LegendItem ItmHigh = new LegendItem();
                        ItmHigh.ImageStyle = LegendImageStyle.Rectangle;
                        ItmHigh.BorderColor = System.Drawing.Color.Transparent;
                        ItmHigh.Color = System.Drawing.Color.DarkRed;
                        ItmHigh.Cells.Add(LegendCellType.Text, "مرتفغة", System.Drawing.ContentAlignment.MiddleCenter);
                        ItmHigh.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);

                        ((Chart)e.Item.FindControl("ChartImport")).Legends[0].CustomItems.Add(ItmHigh);

                        LegendItem ItmMedium = new LegendItem();
                        ItmMedium.ImageStyle = LegendImageStyle.Rectangle;
                        ItmMedium.BorderColor = System.Drawing.Color.Transparent;
                        ItmMedium.Color = System.Drawing.Color.Orange;
                        ItmMedium.Cells.Add(LegendCellType.Text, "متوسطة", System.Drawing.ContentAlignment.MiddleCenter);
                        ItmMedium.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);


                        ((Chart)e.Item.FindControl("ChartImport")).Legends[0].CustomItems.Add(ItmMedium);

                        LegendItem ItmLow = new LegendItem();
                        ItmLow.ImageStyle = LegendImageStyle.Rectangle;
                        ItmLow.BorderColor = System.Drawing.Color.Transparent;
                        ItmLow.Color = System.Drawing.Color.LightGreen;
                        ItmLow.Cells.Add(LegendCellType.Text, "منخفضة", System.Drawing.ContentAlignment.MiddleCenter);
                        ItmLow.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);

                        ((Chart)e.Item.FindControl("ChartImport")).Legends[0].CustomItems.Add(ItmLow);


                        ((Chart)e.Item.FindControl("ChartImport")).ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;
                        DataSet GetCountsData = Obj.GetDataSetByID("GetRepCountByStatSec01", Convert.ToInt32(Admins.SelectedValue));

                        foreach (var item in ((Chart)e.Item.FindControl("ChartImport")).Series[0].Points)
                        {
                            var DSCounts = GetCountsData.Tables[0].AsEnumerable().Where(x => x.Field<int>("Importance") == Convert.ToInt32(item.XValue)).FirstOrDefault();

                            if (DSCounts != null)
                            {

                                item.ToolTip = " المعالج " + " [" + DSCounts["Status3"].ToString() + "] %" + DSCounts["PercDone"].ToString() + Environment.NewLine + "المتبقى " + string.Concat("[", DSCounts["NotDoneAll"].ToString()) + "] %" + DSCounts["PercNotDone"].ToString();


                            }
                            if (Convert.ToInt32(item.XValue) == 3)
                            {
                                var a = ((item.YValues[0]) * 100 / Vall);
                                item.PostBackValue = "3";

                                item.Color = System.Drawing.Color.DarkRed;
                                item.Label = Math.Round(a, 2, MidpointRounding.ToEven).ToString() + "%" + "[" + item.YValues[0].ToString() + "]";
                                item.IsVisibleInLegend = false;

                            }

                            else if (Convert.ToInt32(item.XValue) == 2)
                            {
                                var a = ((item.YValues[0]) * 100 / Vall);
                                item.PostBackValue = "2";

                                item.Color = System.Drawing.Color.Orange;
                                item.Label = Math.Round(a, 2, MidpointRounding.ToEven).ToString() + "%" + "[" + item.YValues[0].ToString() + "]";
                                item.IsVisibleInLegend = false;
                            }
                            else if (Convert.ToInt32(item.XValue) == 1)
                            {
                                var a = ((item.YValues[0]) * 100 / Vall);
                                item.PostBackValue = "1";

                                item.Color = System.Drawing.Color.LightGreen;
                                item.Label = Math.Round(a, 2, MidpointRounding.ToEven).ToString() + "%" + "[" + item.YValues[0].ToString() + "]";
                                item.IsVisibleInLegend = false;
                            }
                        }
                    }
                    else
                    {
                        ((Chart)e.Item.FindControl("Chart4")).Dispose();
                        ((Chart)e.Item.FindControl("Chart4")).DataSource = null;
                        ((Chart)e.Item.FindControl("Chart4")).DataBind();
                        ((Chart)e.Item.FindControl("Chart4")).Legends[0].CustomItems.Clear();
                        ((Label)e.Item.FindControl("NoData")).Visible = true;
                    }

                }



            }
        }
    }


    protected void DataTotal_Click(object sender, ImageMapEventArgs e)
    {

        ChartImportByAdm.DataSource = null;
        ChartImportByAdm.DataBind();
        ChartImportByAdm.Legends[0].CustomItems.Clear();
        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "GetDetails();", true);

        DataSet Ds = null;

        string PostVal = e.PostBackValue.ToString();

        string[] splitString = PostVal.Split(',');

        string Case = "";
        if (splitString[0] == "3")
        {
            Case = "المعالجة";
        }
        else if (splitString[0] == "2")
        {
            Case = "جارى التنفيذ";
        } if (splitString[0] == "4")
        {
            Case = "لم يحن وقت تنفيذها";
        }
        if (splitString[0] == "5")
        {
            Case = "مغلقة";
        }
        if (splitString[0] == "1")
        {
            Case = "متأخرة";
        }
        LbelPup.Text = "مستوى الأهمية'" + Case + "' للملاحظات التى تخص";
        LbelPup.Text += " " + Convert.ToString(splitString[3].Trim());
        var Vall = 0;
        if (splitString[0] == "All")
        {
            Ds = Obj.GetChartBySectionAdminPlan(Convert.ToInt32(splitString[2].Trim()), Convert.ToInt32(Admins.SelectedValue), Convert.ToInt32(splitString[1].Trim()));
            Vall = Obj.GetReportCountBySecAdmPlan(Convert.ToInt32(splitString[2].Trim()), Convert.ToInt32(Admins.SelectedValue), Convert.ToInt32(splitString[1].Trim()));
        }
        else
        {
            Ds = Obj.GetChartBySectionAdminPlanStat(Convert.ToInt32(splitString[2].Trim()), Convert.ToInt32(Admins.SelectedValue), Convert.ToInt32(splitString[1].Trim()), Convert.ToInt32(splitString[0].Trim()));

            Vall = Obj.GetReportCountBySecAdmPlanStat(Convert.ToInt32(splitString[2].Trim()), Convert.ToInt32(Admins.SelectedValue), Convert.ToInt32(splitString[1].Trim()), Convert.ToInt32(splitString[0].Trim()));

        }





        if (Vall != 0)
        {

            ChartImportByAdm.DataSource = Ds;
            ChartImportByAdm.Series[0].XValueMember = "Importance";
            ChartImportByAdm.Series[0].YValueMembers = "Counts";
            ChartImportByAdm.DataBind();

            ChartImportByAdm.ChartAreas[0].AxisX.Title = "مستوى الأهمية";
            ChartImportByAdm.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            ChartImportByAdm.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            ChartImportByAdm.Series[0]["PieLabelStyle"] = "Outside";

            ChartImportByAdm.Series[0].BorderColor = System.Drawing.Color.Transparent;
            ChartImportByAdm.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;

            LegendItem ItmHigh = new LegendItem();
            ItmHigh.ImageStyle = LegendImageStyle.Rectangle;
            ItmHigh.BorderColor = System.Drawing.Color.Transparent;
            ItmHigh.Color = System.Drawing.Color.DarkRed;
            ItmHigh.Cells.Add(LegendCellType.Text, "مرتفغة", System.Drawing.ContentAlignment.MiddleCenter);
            ItmHigh.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);

            ChartImportByAdm.Legends[0].CustomItems.Add(ItmHigh);

            LegendItem ItmMedium = new LegendItem();
            ItmMedium.ImageStyle = LegendImageStyle.Rectangle;
            ItmMedium.BorderColor = System.Drawing.Color.Transparent;
            ItmMedium.Color = System.Drawing.Color.Orange;
            ItmMedium.Cells.Add(LegendCellType.Text, "متوسطة", System.Drawing.ContentAlignment.MiddleCenter);
            ItmMedium.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);


            ChartImportByAdm.Legends[0].CustomItems.Add(ItmMedium);

            LegendItem ItmLow = new LegendItem();
            ItmLow.ImageStyle = LegendImageStyle.Rectangle;
            ItmLow.BorderColor = System.Drawing.Color.Transparent;
            ItmLow.Color = System.Drawing.Color.LightGreen;
            ItmLow.Cells.Add(LegendCellType.Text, "منخفضة", System.Drawing.ContentAlignment.MiddleCenter);
            ItmLow.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);

            ChartImportByAdm.Legends[0].CustomItems.Add(ItmLow);





            foreach (var item in ChartImportByAdm.Series[0].Points)
            {
                if (Convert.ToInt32(item.XValue) == 3)
                {
                    var a = ((item.YValues[0]) * 100 / Vall);
                    item.PostBackValue = "3";

                    item.Color = System.Drawing.Color.DarkRed;
                    item.Label = Math.Round(a, 2, MidpointRounding.ToEven).ToString() + "%" + "[" + item.YValues[0].ToString() + "]";
                    item.IsVisibleInLegend = false;

                }

                else if (Convert.ToInt32(item.XValue) == 2)
                {
                    var a = ((item.YValues[0]) * 100 / Vall);
                    item.PostBackValue = "2";

                    item.Color = System.Drawing.Color.Orange;
                    item.Label = Math.Round(a, 2, MidpointRounding.ToEven).ToString() + "%" + "[" + item.YValues[0].ToString() + "]";
                    item.IsVisibleInLegend = false;
                }
                else if (Convert.ToInt32(item.XValue) == 1)
                {
                    var a = ((item.YValues[0]) * 100 / Vall);
                    item.PostBackValue = "1";

                    item.Color = System.Drawing.Color.LightGreen;
                    item.Label = Math.Round(a, 2, MidpointRounding.ToEven).ToString() + "%" + "[" + item.YValues[0].ToString() + "]";
                    item.IsVisibleInLegend = false;
                }
            }
        }
    }
    protected void PreviewTotal_Command(object sender, CommandEventArgs e)
    {
        ChartImportByAdm.DataSource = null;
        ChartImportByAdm.DataBind();
        ChartImportByAdm.Legends[0].CustomItems.Clear();
        ShowAdminImp.Text = "A";
        DataSet Ds = null;
             var Vall =0;
        string PostVal = e.CommandArgument.ToString();

        if (e.CommandArgument.ToString().Contains(","))
        {

            
            string[] splitString = PostVal.Split(',');
            LbelPup.Text = "مستوى التنفيذ تبعا ل";
            LbelPup.Text += splitString[3];
            Ds = Obj.GetChartBySectionAdminPlan(Convert.ToInt32(splitString[0]), Convert.ToInt32(Admins.SelectedValue), Convert.ToInt32(splitString[1]));
            Vall=Convert.ToInt32(splitString[2]);
        }
        else
        {
            string[] splitString = PostVal.Split('/');

            LbelPup.Text = "مستوى التنفيذ تبعا ل";
            LbelPup.Text += splitString[1];

            Ds = Obj.GetChartBySectionAdmin(Convert.ToInt32(Admins.SelectedValue), Convert.ToInt32(splitString[0]));


            Vall = Obj.ExecuteProcedureID("GetReportCountByAdmin", Convert.ToInt32(splitString[0]));
        }
        if (Vall != 0)
        {

            ChartImportByAdm.DataSource = Ds;
            ChartImportByAdm.Series[0].XValueMember = "Importance";
            ChartImportByAdm.Series[0].YValueMembers = "Counts";
            ChartImportByAdm.DataBind();

            ChartImportByAdm.ChartAreas[0].AxisX.Title = "مستوى الأهمية";
            ChartImportByAdm.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            ChartImportByAdm.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            ChartImportByAdm.Series[0]["PieLabelStyle"] = "Outside";

            ChartImportByAdm.Series[0].BorderColor = System.Drawing.Color.Transparent;
            ChartImportByAdm.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;

            LegendItem ItmHigh = new LegendItem();
            ItmHigh.ImageStyle = LegendImageStyle.Rectangle;
            ItmHigh.BorderColor = System.Drawing.Color.Transparent;
            ItmHigh.Color = System.Drawing.Color.DarkRed;
            ItmHigh.Cells.Add(LegendCellType.Text, "مرتفغة", System.Drawing.ContentAlignment.MiddleCenter);
            ItmHigh.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);

            ChartImportByAdm.Legends[0].CustomItems.Add(ItmHigh);

            LegendItem ItmMedium = new LegendItem();
            ItmMedium.ImageStyle = LegendImageStyle.Rectangle;
            ItmMedium.BorderColor = System.Drawing.Color.Transparent;
            ItmMedium.Color = System.Drawing.Color.Orange;
            ItmMedium.Cells.Add(LegendCellType.Text, "متوسطة", System.Drawing.ContentAlignment.MiddleCenter);
            ItmMedium.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);


            ChartImportByAdm.Legends[0].CustomItems.Add(ItmMedium);

            LegendItem ItmLow = new LegendItem();
            ItmLow.ImageStyle = LegendImageStyle.Rectangle;
            ItmLow.BorderColor = System.Drawing.Color.Transparent;
            ItmLow.Color = System.Drawing.Color.LightGreen;
            ItmLow.Cells.Add(LegendCellType.Text, "منخفضة", System.Drawing.ContentAlignment.MiddleCenter);
            ItmLow.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);

            ChartImportByAdm.Legends[0].CustomItems.Add(ItmLow);





            foreach (var item in ChartImportByAdm.Series[0].Points)
            {
                if (Convert.ToInt32(item.XValue) == 3)
                {
                    var a = ((item.YValues[0]) * 100 / Vall);
                    item.PostBackValue = "3";

                    item.Color = System.Drawing.Color.DarkRed;
                    item.Label = Math.Round(a, 2, MidpointRounding.ToEven).ToString() + "%" + "[" + item.YValues[0].ToString() + "]";
                    item.IsVisibleInLegend = false;

                }

                else if (Convert.ToInt32(item.XValue) == 2)
                {
                    var a = ((item.YValues[0]) * 100 / Vall);
                    item.PostBackValue = "2";

                    item.Color = System.Drawing.Color.Orange;
                    item.Label = Math.Round(a, 2, MidpointRounding.ToEven).ToString() + "%" + "[" + item.YValues[0].ToString() + "]";
                    item.IsVisibleInLegend = false;
                }
                else if (Convert.ToInt32(item.XValue) == 1)
                {
                    var a = ((item.YValues[0]) * 100 / Vall);
                    item.PostBackValue = "1";

                    item.Color = System.Drawing.Color.LightGreen;
                    item.Label = Math.Round(a, 2, MidpointRounding.ToEven).ToString() + "%" + "[" + item.YValues[0].ToString() + "]";
                    item.IsVisibleInLegend = false;
                }
            }
        }
    }

    protected void BackCharts_Click(object sender, EventArgs e)
    {
        DataChart.Attributes.Remove("style");
        DataChart.Style.Add("display", "none");

        MainsAll.Attributes.Remove("style");
        MainsAll.Style.Add("display", "block");


    }
    protected void BtnAdminAll_Click(object sender, EventArgs e)
    {
        DataChart.Attributes.Remove("style");
        DataChart.Style.Add("display", "block");


        MainsAll.Attributes.Remove("style");
        MainsAll.Style.Add("display", "none");

        DPlan.Attributes.Remove("style");
        DPlan.Style.Add("display", "none");

        DAll.Attributes.Remove("style");
        DAll.Style.Add("display", "block");

        AdminsListAll.DataSource = Obj.GetPlansAdmBySectionAll(Convert.ToInt32(Admins.SelectedValue));
        AdminsListAll.DataBind();

    }
    protected void BtnMainAllRiskSec_Command(object sender, CommandEventArgs e)
    {
        DataChart.Attributes.Remove("style");
        DataChart.Style.Add("display", "block");


        MainsAll.Attributes.Remove("style");
        MainsAll.Style.Add("display", "none");

        DPlan.Attributes.Remove("style");
        DPlan.Style.Add("display", "block");

        DAll.Attributes.Remove("style");
        DAll.Style.Add("display", "none");
        AdminsListBySec.DataSource = Obj.GetPlansAdmBySection(Convert.ToInt32(e.CommandArgument), Convert.ToInt32(Admins.SelectedValue));
        AdminsListBySec.DataBind();
    }
}