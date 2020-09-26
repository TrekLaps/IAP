using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.HtmlControls;

public partial class MainDashboard : System.Web.UI.Page
{
    Operations Obj = new Operations();



    private void MainDataYear()
    {
        ChartMain4.DataSource = null;
        ChartMain4.DataBind();
        ChartMain4.Legends[0].CustomItems.Clear();

        ChartMain3.DataSource = null;
        ChartMain3.DataBind();
        ChartMain3.Legends[0].CustomItems.Clear();

        // Bind Importance chart
        var Vall = Obj.ExecuteProcedureID("GetReportCountPlan", Convert.ToInt32(DropYear.SelectedValue));
        if (Vall != 0)
        {
            PrntViewMain.Attributes.Remove("style");
            PrntViewMain.Style.Add("display", "block");
            PrntViewSections.Attributes.Remove("style");
            PrntViewSections.Style.Add("display", "block");

            NoRep.Visible = false;
            ChartMain4.DataSource = Obj.GetDataSetByID("GetChartReportByStatID", Convert.ToInt32(DropYear.SelectedValue));

            ChartMain4.Series[0].XValueMember = "Stat";
            ChartMain4.Series[0].YValueMembers = "Counts";
            ChartMain4.DataBind();
            ChartMain4.ChartAreas[0].AxisX.Title = "مستوى التنفيذ ";


            ChartMain4.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            ChartMain4.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;



            ChartMain4.Series[0]["PieLabelStyle"] = "Outside";

            ChartMain4.Series[0].BorderColor = System.Drawing.Color.Transparent;
            ChartMain4.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;

            LegendItem itemNotNow = new LegendItem();
            itemNotNow.ImageStyle = LegendImageStyle.Rectangle;
            itemNotNow.BorderColor = System.Drawing.Color.Transparent;
            itemNotNow.Color = System.Drawing.ColorTranslator.FromHtml("#5b9092");
            itemNotNow.Cells.Add(LegendCellType.Text, "لم يحن وقت التنفيذ", System.Drawing.ContentAlignment.MiddleCenter);
            itemNotNow.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);
            itemNotNow.ToolTip = "لم يحن تاريخ تنفيذ التوصية/ الملاحظة المتفق عليه مع الإدارة متوسطة";

            ChartMain4.Legends[0].CustomItems.Add(itemNotNow);



            LegendItem itemClosed = new LegendItem();
            itemClosed.ImageStyle = LegendImageStyle.Rectangle;
            itemClosed.BorderColor = System.Drawing.Color.Transparent;
            itemClosed.Color = System.Drawing.ColorTranslator.FromHtml("#cccccc");
            itemClosed.Cells.Add(LegendCellType.Text, "مغلقة", System.Drawing.ContentAlignment.MiddleCenter);
            itemClosed.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);
            itemClosed.ToolTip = "لعدم مناسبة تطبيقها في الوقت الحالي ، لتكرارها في تقرير آخر";

            ChartMain4.Legends[0].CustomItems.Add(itemClosed);

            LegendItem itemNotDone = new LegendItem();
            itemNotDone.ImageStyle = LegendImageStyle.Rectangle;
            itemNotDone.BorderColor = System.Drawing.Color.Transparent;
            itemNotDone.Color = System.Drawing.Color.DarkRed;
            itemNotDone.Cells.Add(LegendCellType.Text, "متأخرة", System.Drawing.ContentAlignment.MiddleCenter);
            itemNotDone.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);
            itemNotDone.ToolTip = "لم يتم معالجة التوصية / الملاحظة وفقا لتاريخ الانتهاء المقدم من قبل الإدارة متوسطة";
            ChartMain4.Legends[0].CustomItems.Add(itemNotDone);

            LegendItem itemSemiDone = new LegendItem();
            itemSemiDone.ImageStyle = LegendImageStyle.Rectangle;
            itemSemiDone.BorderColor = System.Drawing.Color.Transparent;
            itemSemiDone.Color = System.Drawing.ColorTranslator.FromHtml("#e7ea56");

            itemSemiDone.Cells.Add(LegendCellType.Text, "جارى التنفيذ", System.Drawing.ContentAlignment.MiddleCenter);
            itemSemiDone.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);
            itemSemiDone.ToolTip = "تم تنفيذ جزء من التوصية فقط / جزء من الملاحظة";

            ChartMain4.Legends[0].CustomItems.Add(itemSemiDone);


            LegendItem itemDone = new LegendItem();
            itemDone.ImageStyle = LegendImageStyle.Rectangle;
            itemDone.BorderColor = System.Drawing.Color.Transparent;
            itemDone.Color = System.Drawing.Color.LightGreen;
            itemDone.Cells.Add(LegendCellType.Text, "معالجة", System.Drawing.ContentAlignment.MiddleCenter);
            itemDone.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);
            itemDone.ToolTip = "تم معالجة وتنفيذ جميع التوصيات";
            ChartMain4.Legends[0].CustomItems.Add(itemDone);


            foreach (var item2 in ChartMain4.Series[0].Points)
            {
                item2.PostBackValue = "#Index";
                if (Convert.ToInt32(item2.XValue) == 3)
                {
                    var a = ((item2.YValues[0]) * 100 / Vall);
                    item2.PostBackValue = "3";

                    item2.Color = System.Drawing.Color.LightGreen;
                    item2.ToolTip = item2.Label = Math.Round(a, 2, MidpointRounding.ToEven).ToString() + "%" + "[" + item2.YValues[0].ToString() + "]";
                    item2.IsVisibleInLegend = false;

                }

                else if (Convert.ToInt32(item2.XValue) == 2)
                {
                    var a = ((item2.YValues[0]) * 100 / Vall);
                    item2.PostBackValue = "2";
                    item2.Color = System.Drawing.ColorTranslator.FromHtml("#e7ea56");
                    item2.ToolTip = item2.Label = Math.Round(a, 2, MidpointRounding.ToEven).ToString() + "%" + "[" + item2.YValues[0].ToString() + "]";
                    item2.IsVisibleInLegend = false;

                }
                else if (Convert.ToInt32(item2.XValue) == 1)
                {
                    var a = ((item2.YValues[0]) * 100 / Vall);
                    item2.PostBackValue = "1";

                    item2.Color = System.Drawing.Color.DarkRed;
                    item2.ToolTip = item2.Label = Math.Round(a, 2, MidpointRounding.ToEven).ToString() + "%" + "[" + item2.YValues[0].ToString() + "]";
                    item2.IsVisibleInLegend = false;

                }
                else if (Convert.ToInt32(item2.XValue) == 4)
                {
                    var a = ((item2.YValues[0]) * 100 / Vall);
                    item2.PostBackValue = "4";

                    item2.Color = System.Drawing.ColorTranslator.FromHtml("#5b9092");
                    item2.ToolTip = item2.Label = Math.Round(a, 2, MidpointRounding.ToEven).ToString() + "%" + "[" + item2.YValues[0].ToString() + "]";
                    item2.IsVisibleInLegend = false;
                }
                else if (Convert.ToInt32(item2.XValue) == 5)
                {
                    var a = ((item2.YValues[0]) * 100 / Vall);
                    item2.PostBackValue = "5";

                    item2.Color = System.Drawing.ColorTranslator.FromHtml("#cccccc");
                    item2.ToolTip = item2.Label = Math.Round(a, 2, MidpointRounding.ToEven).ToString() + "%" + "[" + item2.YValues[0].ToString() + "]";
                    item2.IsVisibleInLegend = false;
                }


            }


            ChartMain3.DataSource = Obj.GetDataSetByID("GetChartByStatPlan", Convert.ToInt32(DropYear.SelectedValue));

            ChartMain3.Series[0].XValueMember = "Importance";
            ChartMain3.Series[0].YValueMembers = "Counts";
            ChartMain3.DataBind();

            ChartMain3.ChartAreas[0].AxisX.Title = "مستوى الأهمية";
            ChartMain3.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            ChartMain3.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            ChartMain3.Series[0]["PieLabelStyle"] = "Outside";

            ChartMain3.Series[0].BorderColor = System.Drawing.Color.Transparent;
            ChartMain3.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;

            LegendItem ItmHigh = new LegendItem();
            ItmHigh.ImageStyle = LegendImageStyle.Rectangle;
            ItmHigh.BorderColor = System.Drawing.Color.Transparent;
            ItmHigh.Color = System.Drawing.Color.DarkRed;
            ItmHigh.Cells.Add(LegendCellType.Text, "مرتفغة", System.Drawing.ContentAlignment.MiddleCenter);
            ItmHigh.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);

            ChartMain3.Legends[0].CustomItems.Add(ItmHigh);
            LegendItem ItmMedium = new LegendItem();
            ItmMedium.ImageStyle = LegendImageStyle.Rectangle;
            ItmMedium.BorderColor = System.Drawing.Color.Transparent;
            ItmMedium.Color = System.Drawing.Color.Orange;
            ItmMedium.Cells.Add(LegendCellType.Text, "متوسطة", System.Drawing.ContentAlignment.MiddleCenter);
            ItmMedium.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);


            ChartMain3.Legends[0].CustomItems.Add(ItmMedium);
            LegendItem ItmLow = new LegendItem();
            ItmLow.ImageStyle = LegendImageStyle.Rectangle;
            ItmLow.BorderColor = System.Drawing.Color.Transparent;
            ItmLow.Color = System.Drawing.Color.LightGreen;
            ItmLow.Cells.Add(LegendCellType.Text, "منخفضة", System.Drawing.ContentAlignment.MiddleCenter);
            ItmLow.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);

            ChartMain3.Legends[0].CustomItems.Add(ItmLow);






            foreach (var item in ChartMain3.Series[0].Points)
            {


                DataSet DSCounts = Obj.GetDataSetBy2ID("GetRepCountByStatPlan", Convert.ToInt32(item.XValue), Convert.ToInt32(DropYear.SelectedValue));
                if (DSCounts.Tables[0].Rows.Count > 0)
                {
                    for (int k = 0; k < DSCounts.Tables[0].Rows.Count; k++)
                    {
                        item.ToolTip = " المعالج " + " [" + DSCounts.Tables[0].Rows[k]["Status3"].ToString() + "] %" + DSCounts.Tables[0].Rows[k]["PercDone"].ToString() + Environment.NewLine + "المتبقى " + string.Concat("[", DSCounts.Tables[0].Rows[k]["NotDoneAll"].ToString()) + "] %" + DSCounts.Tables[0].Rows[k]["PercNotDone"].ToString();
                    }

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
            NoRep.Visible = true;
            PrntViewMain.Attributes.Remove("style");
            PrntViewMain.Style.Add("display", "none");
            PrntViewSections.Attributes.Remove("style");
            PrntViewSections.Style.Add("display", "none");
        }
    }

    private void GetDataYear()
    {
        ChartMain1.DataSource = null;
        ChartMain1.DataBind();
        ChartMain1.Legends[0].CustomItems.Clear();
        ChartMain1.Series["Done"].Points.Clear();
        ChartMain1.Series["SimyDone"].Points.Clear();
        ChartMain1.Series["NotNow"].Points.Clear();
        ChartMain1.Series["NotDone"].Points.Clear();
        ChartMain1.Series["Closed"].Points.Clear();
        ChartMain1.Series["Done"].Points.Clear();


        DataSet ds = Obj.GetDataSetByID("GetAllAdminsByPlanNoSec", Convert.ToInt32(DropYear.SelectedValue));
        Repeater2.DataSource = EmployeesData.DataSource = ds;
        EmployeesData.DataBind();

        Repeater2.DataBind();
        AdminsList.DataSource = ds;
        AdminsList.DataBind();
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                ChartMain1.Series["Done"].Points.Add(new DataPoint(i, ds.Tables[0].Rows[i]["Status3"].ToString().Trim()));
                ChartMain1.Series["SimyDone"].Points.Add(new DataPoint(i, ds.Tables[0].Rows[i]["Status2"].ToString().Trim()));
                ChartMain1.Series["NotNow"].Points.Add(new DataPoint(i, ds.Tables[0].Rows[i]["Status4"].ToString().Trim()));
                ChartMain1.Series["NotDone"].Points.Add(new DataPoint(i, ds.Tables[0].Rows[i]["Status1"].ToString().Trim()));
                ChartMain1.Series["Closed"].Points.Add(new DataPoint(i, ds.Tables[0].Rows[i]["Status5"].ToString().Trim()));
                ChartMain1.Series[0].Points[i].AxisLabel = ds.Tables[0].Rows[i]["AdmName"].ToString() + " [ " + ds.Tables[0].Rows[i]["TotalCount"] + " ]  ";

                ChartMain1.Series["Done"].Points[i].ToolTip = "[" + ds.Tables[0].Rows[i]["Status3"].ToString() + "] " + Math.Round(((Convert.ToDouble(ds.Tables[0].Rows[i]["Status3"]) / Convert.ToDouble(ds.Tables[0].Rows[i]["TotalCount"])) * 100), 1).ToString() + "%";
                ChartMain1.Series["Done"].Points[i].PostBackValue = "3," + ds.Tables[0].Rows[i]["RepAdms"].ToString().Trim() + "," + ds.Tables[0].Rows[i]["Status3"].ToString() + "," + ds.Tables[0].Rows[i]["AdmName"].ToString();


                ChartMain1.Series["SimyDone"].Points[i].ToolTip = "[" + ds.Tables[0].Rows[i]["Status2"].ToString() + "] " + Math.Round(((Convert.ToDouble(ds.Tables[0].Rows[i]["Status2"]) / Convert.ToDouble(ds.Tables[0].Rows[i]["TotalCount"])) * 100), 1).ToString() + "%";
                ChartMain1.Series["SimyDone"].Points[i].PostBackValue = "2," + ds.Tables[0].Rows[i]["RepAdms"].ToString().Trim() + "," + ds.Tables[0].Rows[i]["Status2"].ToString() + "," + ds.Tables[0].Rows[i]["AdmName"].ToString();

                ChartMain1.Series["NotNow"].Points[i].ToolTip = "[" + ds.Tables[0].Rows[i]["Status4"].ToString() + "] " + Math.Round(((Convert.ToDouble(ds.Tables[0].Rows[i]["Status4"]) / Convert.ToDouble(ds.Tables[0].Rows[i]["TotalCount"])) * 100), 1).ToString() + "%";
                ChartMain1.Series["NotNow"].Points[i].PostBackValue = "4," + ds.Tables[0].Rows[i]["RepAdms"].ToString().Trim() + "," + ds.Tables[0].Rows[i]["Status4"].ToString() + "," + ds.Tables[0].Rows[i]["AdmName"].ToString();


                ChartMain1.Series["NotDone"].Points[i].ToolTip = "[" + ds.Tables[0].Rows[i]["Status1"].ToString() + "] " + Math.Round(((Convert.ToDouble(ds.Tables[0].Rows[i]["Status1"]) / Convert.ToDouble(ds.Tables[0].Rows[i]["TotalCount"])) * 100), 1).ToString() + "%";
                ChartMain1.Series["NotDone"].Points[i].PostBackValue = "1," + ds.Tables[0].Rows[i]["RepAdms"].ToString().Trim() + "," + ds.Tables[0].Rows[i]["Status1"].ToString() + "," + ds.Tables[0].Rows[i]["AdmName"].ToString();

                ChartMain1.Series["Closed"].Points[i].ToolTip = "[" + ds.Tables[0].Rows[i]["Status5"].ToString() + "] " + Math.Round(((Convert.ToDouble(ds.Tables[0].Rows[i]["Status5"]) / Convert.ToDouble(ds.Tables[0].Rows[i]["TotalCount"])) * 100), 1).ToString() + "%";
                ChartMain1.Series["Closed"].Points[i].PostBackValue = "5," + ds.Tables[0].Rows[i]["RepAdms"].ToString().Trim() + "," + ds.Tables[0].Rows[i]["Status5"].ToString() + "," + ds.Tables[0].Rows[i]["AdmName"].ToString();

            }

        }

        ChartMain1.Series["Done"].SetCustomProperty("PixelPointWidth", "30");
        ChartMain1.Series["SimyDone"].SetCustomProperty("PixelPointWidth", "30");
        ChartMain1.Series["NotNow"].SetCustomProperty("PixelPointWidth", "30");
        ChartMain1.Series["NotDone"].SetCustomProperty("PixelPointWidth", "30");
        ChartMain1.Series["Closed"].SetCustomProperty("PixelPointWidth", "30");



        ChartMain1.ChartAreas[0].AxisX.LabelStyle.Angle = -30;
        ChartMain1.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount;
        ChartMain1.ChartAreas[0].AxisX.IsLabelAutoFit = false;

        LegendItem itemNotNow = new LegendItem();
        itemNotNow.ImageStyle = LegendImageStyle.Rectangle;
        itemNotNow.BorderColor = System.Drawing.Color.Transparent;
        itemNotNow.Color = System.Drawing.ColorTranslator.FromHtml("#5b9092");
        itemNotNow.Cells.Add(LegendCellType.Text, "لم يحن وقت التنفيذ", System.Drawing.ContentAlignment.MiddleCenter);
        itemNotNow.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);
        itemNotNow.ToolTip = "لم يحن تاريخ تنفيذ التوصية/ الملاحظة المتفق عليه مع الإدارة متوسطة";

        ChartMain1.Legends[0].CustomItems.Add(itemNotNow);



        LegendItem itemClosed = new LegendItem();
        itemClosed.ImageStyle = LegendImageStyle.Rectangle;
        itemClosed.BorderColor = System.Drawing.Color.Transparent;
        itemClosed.Color = System.Drawing.ColorTranslator.FromHtml("#cccccc");
        itemClosed.Cells.Add(LegendCellType.Text, "مغلقة", System.Drawing.ContentAlignment.MiddleCenter);
        itemClosed.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);
        itemClosed.ToolTip = "لعدم مناسبة تطبيقها في الوقت الحالي ، لتكرارها في تقرير آخر";

        ChartMain1.Legends[0].CustomItems.Add(itemClosed);

        LegendItem itemNotDone = new LegendItem();
        itemNotDone.ImageStyle = LegendImageStyle.Rectangle;
        itemNotDone.BorderColor = System.Drawing.Color.Transparent;
        itemNotDone.Color = System.Drawing.Color.DarkRed;
        itemNotDone.Cells.Add(LegendCellType.Text, "متأخرة", System.Drawing.ContentAlignment.MiddleCenter);
        itemNotDone.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);
        itemNotDone.ToolTip = "لم يتم معالجة التوصية / الملاحظة وفقا لتاريخ الانتهاء المقدم من قبل الإدارة متوسطة";
        ChartMain1.Legends[0].CustomItems.Add(itemNotDone);

        LegendItem itemSemiDone = new LegendItem();
        itemSemiDone.ImageStyle = LegendImageStyle.Rectangle;
        itemSemiDone.BorderColor = System.Drawing.Color.Transparent;
        itemSemiDone.Color = System.Drawing.ColorTranslator.FromHtml("#e7ea56");

        itemSemiDone.Cells.Add(LegendCellType.Text, "جارى التنفيذ", System.Drawing.ContentAlignment.MiddleCenter);
        itemSemiDone.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);
        itemSemiDone.ToolTip = "تم تنفيذ جزء من التوصية فقط / جزء من الملاحظة";

        ChartMain1.Legends[0].CustomItems.Add(itemSemiDone);


        LegendItem itemDone = new LegendItem();
        itemDone.ImageStyle = LegendImageStyle.Rectangle;
        itemDone.BorderColor = System.Drawing.Color.Transparent;
        itemDone.Color = System.Drawing.Color.LightGreen;
        itemDone.Cells.Add(LegendCellType.Text, "معالجة", System.Drawing.ContentAlignment.MiddleCenter);
        itemDone.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);
        itemDone.ToolTip = "تم معالجة وتنفيذ جميع التوصيات";
        ChartMain1.Legends[0].CustomItems.Add(itemDone);

        for (int j = 0; j < ChartMain1.Series.Count; j++)
        {
            ChartMain1.Series[j].SmartLabelStyle.CalloutLineAnchorCapStyle = LineAnchorCapStyle.None;
            ChartMain1.Series[j].SmartLabelStyle.CalloutLineColor = System.Drawing.Color.Transparent;

            foreach (DataPoint point in ChartMain1.Series[j].Points)
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

        RepTotals.DataSource = Obj.GetDataSetByID("GetYearCounts", Convert.ToInt32(DropYear.SelectedValue));
        RepTotals.DataBind();
    }

    private void MainData()
    {
        ChartMain4.DataSource = null;
        ChartMain4.DataBind();
        ChartMain4.Legends[0].CustomItems.Clear();

        ChartMain3.DataSource = null;
        ChartMain3.DataBind();
        ChartMain3.Legends[0].CustomItems.Clear();

        // Bind Importance chart
        var Vall = Obj.ExecuteProcedure("GetReportCount");
        if (Vall != 0)
        {

            NoRep.Visible = false;
            ChartMain4.DataSource = Obj.GetDataSet("GetChartReportByStat");

            ChartMain4.Series[0].XValueMember = "Stat";
            ChartMain4.Series[0].YValueMembers = "Counts";
            ChartMain4.DataBind();
            ChartMain4.ChartAreas[0].AxisX.Title = "مستوى التنفيذ ";


            ChartMain4.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            ChartMain4.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;



            ChartMain4.Series[0]["PieLabelStyle"] = "Outside";

            ChartMain4.Series[0].BorderColor = System.Drawing.Color.Transparent;
            ChartMain4.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;

            LegendItem itemNotNow = new LegendItem();
            itemNotNow.ImageStyle = LegendImageStyle.Rectangle;
            itemNotNow.BorderColor = System.Drawing.Color.Transparent;
            itemNotNow.Color = System.Drawing.ColorTranslator.FromHtml("#5b9092");
            itemNotNow.Cells.Add(LegendCellType.Text, "لم يحن وقت التنفيذ", System.Drawing.ContentAlignment.MiddleCenter);
            itemNotNow.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);
            itemNotNow.ToolTip = "لم يحن تاريخ تنفيذ التوصية/ الملاحظة المتفق عليه مع الإدارة متوسطة";

            ChartMain4.Legends[0].CustomItems.Add(itemNotNow);



            LegendItem itemClosed = new LegendItem();
            itemClosed.ImageStyle = LegendImageStyle.Rectangle;
            itemClosed.BorderColor = System.Drawing.Color.Transparent;
            itemClosed.Color = System.Drawing.ColorTranslator.FromHtml("#cccccc");
            itemClosed.Cells.Add(LegendCellType.Text, "مغلقة", System.Drawing.ContentAlignment.MiddleCenter);
            itemClosed.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);
            itemClosed.ToolTip = "لعدم مناسبة تطبيقها في الوقت الحالي ، لتكرارها في تقرير آخر";

            ChartMain4.Legends[0].CustomItems.Add(itemClosed);

            LegendItem itemNotDone = new LegendItem();
            itemNotDone.ImageStyle = LegendImageStyle.Rectangle;
            itemNotDone.BorderColor = System.Drawing.Color.Transparent;
            itemNotDone.Color = System.Drawing.Color.DarkRed;
            itemNotDone.Cells.Add(LegendCellType.Text, "متأخرة", System.Drawing.ContentAlignment.MiddleCenter);
            itemNotDone.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);
            itemNotDone.ToolTip = "لم يتم معالجة التوصية / الملاحظة وفقا لتاريخ الانتهاء المقدم من قبل الإدارة متوسطة";
            ChartMain4.Legends[0].CustomItems.Add(itemNotDone);

            LegendItem itemSemiDone = new LegendItem();
            itemSemiDone.ImageStyle = LegendImageStyle.Rectangle;
            itemSemiDone.BorderColor = System.Drawing.Color.Transparent;
            itemSemiDone.Color = System.Drawing.ColorTranslator.FromHtml("#e7ea56");

            itemSemiDone.Cells.Add(LegendCellType.Text, "جارى التنفيذ", System.Drawing.ContentAlignment.MiddleCenter);
            itemSemiDone.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);
            itemSemiDone.ToolTip = "تم تنفيذ جزء من التوصية فقط / جزء من الملاحظة";

            ChartMain4.Legends[0].CustomItems.Add(itemSemiDone);


            LegendItem itemDone = new LegendItem();
            itemDone.ImageStyle = LegendImageStyle.Rectangle;
            itemDone.BorderColor = System.Drawing.Color.Transparent;
            itemDone.Color = System.Drawing.Color.LightGreen;
            itemDone.Cells.Add(LegendCellType.Text, "معالجة", System.Drawing.ContentAlignment.MiddleCenter);
            itemDone.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);
            itemDone.ToolTip = "تم معالجة وتنفيذ جميع التوصيات";
            ChartMain4.Legends[0].CustomItems.Add(itemDone);


            foreach (var item2 in ChartMain4.Series[0].Points)
            {
                item2.PostBackValue = "#Index";
                if (Convert.ToInt32(item2.XValue) == 3)
                {
                    var a = ((item2.YValues[0]) * 100 / Vall);
                    item2.PostBackValue = "3";

                    item2.Color = System.Drawing.Color.LightGreen;
                    item2.ToolTip = item2.Label = Math.Round(a, 2, MidpointRounding.ToEven).ToString() + "%" + "[" + item2.YValues[0].ToString() + "]";
                    item2.IsVisibleInLegend = false;

                }

                else if (Convert.ToInt32(item2.XValue) == 2)
                {
                    var a = ((item2.YValues[0]) * 100 / Vall);
                    item2.PostBackValue = "2";
                    item2.Color = System.Drawing.ColorTranslator.FromHtml("#e7ea56");
                    item2.ToolTip = item2.Label = Math.Round(a, 2, MidpointRounding.ToEven).ToString() + "%" + "[" + item2.YValues[0].ToString() + "]";
                    item2.IsVisibleInLegend = false;

                }
                else if (Convert.ToInt32(item2.XValue) == 1)
                {
                    var a = ((item2.YValues[0]) * 100 / Vall);
                    item2.PostBackValue = "1";

                    item2.Color = System.Drawing.Color.DarkRed;
                    item2.ToolTip = item2.Label = Math.Round(a, 2, MidpointRounding.ToEven).ToString() + "%" + "[" + item2.YValues[0].ToString() + "]";
                    item2.IsVisibleInLegend = false;

                }
                else if (Convert.ToInt32(item2.XValue) == 4)
                {
                    var a = ((item2.YValues[0]) * 100 / Vall);
                    item2.PostBackValue = "4";

                    item2.Color = System.Drawing.ColorTranslator.FromHtml("#5b9092");
                    item2.ToolTip = item2.Label = Math.Round(a, 2, MidpointRounding.ToEven).ToString() + "%" + "[" + item2.YValues[0].ToString() + "]";
                    item2.IsVisibleInLegend = false;
                }
                else if (Convert.ToInt32(item2.XValue) == 5)
                {
                    var a = ((item2.YValues[0]) * 100 / Vall);
                    item2.PostBackValue = "5";

                    item2.Color = System.Drawing.ColorTranslator.FromHtml("#cccccc");
                    item2.ToolTip = item2.Label = Math.Round(a, 2, MidpointRounding.ToEven).ToString() + "%" + "[" + item2.YValues[0].ToString() + "]";
                    item2.IsVisibleInLegend = false;
                }


            }


            ChartMain3.DataSource = Obj.GetDataSet("GetChartByStat");

            ChartMain3.Series[0].XValueMember = "Importance";
            ChartMain3.Series[0].YValueMembers = "Counts";
            ChartMain3.DataBind();

            ChartMain3.ChartAreas[0].AxisX.Title = "مستوى الأهمية";
            ChartMain3.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            ChartMain3.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            ChartMain3.Series[0]["PieLabelStyle"] = "Outside";

            ChartMain3.Series[0].BorderColor = System.Drawing.Color.Transparent;
            ChartMain3.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;

            LegendItem ItmHigh = new LegendItem();
            ItmHigh.ImageStyle = LegendImageStyle.Rectangle;
            ItmHigh.BorderColor = System.Drawing.Color.Transparent;
            ItmHigh.Color = System.Drawing.Color.DarkRed;
            ItmHigh.Cells.Add(LegendCellType.Text, "مرتفغة", System.Drawing.ContentAlignment.MiddleCenter);
            ItmHigh.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);

            ChartMain3.Legends[0].CustomItems.Add(ItmHigh);
            LegendItem ItmMedium = new LegendItem();
            ItmMedium.ImageStyle = LegendImageStyle.Rectangle;
            ItmMedium.BorderColor = System.Drawing.Color.Transparent;
            ItmMedium.Color = System.Drawing.Color.Orange;
            ItmMedium.Cells.Add(LegendCellType.Text, "متوسطة", System.Drawing.ContentAlignment.MiddleCenter);
            ItmMedium.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);


            ChartMain3.Legends[0].CustomItems.Add(ItmMedium);
            LegendItem ItmLow = new LegendItem();
            ItmLow.ImageStyle = LegendImageStyle.Rectangle;
            ItmLow.BorderColor = System.Drawing.Color.Transparent;
            ItmLow.Color = System.Drawing.Color.LightGreen;
            ItmLow.Cells.Add(LegendCellType.Text, "منخفضة", System.Drawing.ContentAlignment.MiddleCenter);
            ItmLow.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);

            ChartMain3.Legends[0].CustomItems.Add(ItmLow);






            foreach (var item in ChartMain3.Series[0].Points)
            {


                DataSet DSCounts = Obj.GetDataSetByID("GetRepCountByStat", Convert.ToInt32(item.XValue));
                if (DSCounts.Tables[0].Rows.Count > 0)
                {
                    for (int k = 0; k < DSCounts.Tables[0].Rows.Count; k++)
                    {
                        item.ToolTip = " المعالج " + " [" + DSCounts.Tables[0].Rows[k]["Status3"].ToString() + "] %" + DSCounts.Tables[0].Rows[k]["PercDone"].ToString() + Environment.NewLine + "المتبقى " + string.Concat("[", DSCounts.Tables[0].Rows[k]["NotDoneAll"].ToString()) + "] %" + DSCounts.Tables[0].Rows[k]["PercNotDone"].ToString();
                    }

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
    }

    private void GetData()
    {
        ChartMain1.DataSource = null;
        ChartMain1.DataBind();
        ChartMain1.Legends[0].CustomItems.Clear();




        DataSet ds = Obj.GetDataSet("GetAllAdmins");
        Repeater2.DataSource = EmployeesData.DataSource = ds;
        EmployeesData.DataBind();
        Repeater2.DataBind();
        AdminsList.DataSource = ds;
        AdminsList.DataBind();
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                ChartMain1.Series["Done"].Points.Add(new DataPoint(i, ds.Tables[0].Rows[i]["Status3"].ToString().Trim()));
                ChartMain1.Series["SimyDone"].Points.Add(new DataPoint(i, ds.Tables[0].Rows[i]["Status2"].ToString().Trim()));
                ChartMain1.Series["NotNow"].Points.Add(new DataPoint(i, ds.Tables[0].Rows[i]["Status4"].ToString().Trim()));
                ChartMain1.Series["NotDone"].Points.Add(new DataPoint(i, ds.Tables[0].Rows[i]["Status1"].ToString().Trim()));
                ChartMain1.Series["Closed"].Points.Add(new DataPoint(i, ds.Tables[0].Rows[i]["Status5"].ToString().Trim()));
                ChartMain1.Series[0].Points[i].AxisLabel = ds.Tables[0].Rows[i]["AdmName"].ToString() + " [ " + ds.Tables[0].Rows[i]["TotalCount"] + " ]  ";

                ChartMain1.Series["Done"].Points[i].ToolTip = "[" + ds.Tables[0].Rows[i]["Status3"].ToString() + "] " + Math.Round(((Convert.ToDouble(ds.Tables[0].Rows[i]["Status3"]) / Convert.ToDouble(ds.Tables[0].Rows[i]["TotalCount"])) * 100), 1).ToString() + "%";
                ChartMain1.Series["Done"].Points[i].PostBackValue = "3," + ds.Tables[0].Rows[i]["RepAdms"].ToString().Trim() + "," + ds.Tables[0].Rows[i]["Status3"].ToString() + "," + ds.Tables[0].Rows[i]["AdmName"].ToString();


                ChartMain1.Series["SimyDone"].Points[i].ToolTip = "[" + ds.Tables[0].Rows[i]["Status2"].ToString() + "] " + Math.Round(((Convert.ToDouble(ds.Tables[0].Rows[i]["Status2"]) / Convert.ToDouble(ds.Tables[0].Rows[i]["TotalCount"])) * 100), 1).ToString() + "%";
                ChartMain1.Series["SimyDone"].Points[i].PostBackValue = "2," + ds.Tables[0].Rows[i]["RepAdms"].ToString().Trim() + "," + ds.Tables[0].Rows[i]["Status2"].ToString() + "," + ds.Tables[0].Rows[i]["AdmName"].ToString();

                ChartMain1.Series["NotNow"].Points[i].ToolTip = "[" + ds.Tables[0].Rows[i]["Status4"].ToString() + "] " + Math.Round(((Convert.ToDouble(ds.Tables[0].Rows[i]["Status4"]) / Convert.ToDouble(ds.Tables[0].Rows[i]["TotalCount"])) * 100), 1).ToString() + "%";
                ChartMain1.Series["NotNow"].Points[i].PostBackValue = "4," + ds.Tables[0].Rows[i]["RepAdms"].ToString().Trim() + "," + ds.Tables[0].Rows[i]["Status4"].ToString() + "," + ds.Tables[0].Rows[i]["AdmName"].ToString();


                ChartMain1.Series["NotDone"].Points[i].ToolTip = "[" + ds.Tables[0].Rows[i]["Status1"].ToString() + "] " + Math.Round(((Convert.ToDouble(ds.Tables[0].Rows[i]["Status1"]) / Convert.ToDouble(ds.Tables[0].Rows[i]["TotalCount"])) * 100), 1).ToString() + "%";
                ChartMain1.Series["NotDone"].Points[i].PostBackValue = "1," + ds.Tables[0].Rows[i]["RepAdms"].ToString().Trim() + "," + ds.Tables[0].Rows[i]["Status1"].ToString() + "," + ds.Tables[0].Rows[i]["AdmName"].ToString();

                ChartMain1.Series["Closed"].Points[i].ToolTip = "[" + ds.Tables[0].Rows[i]["Status5"].ToString() + "] " + Math.Round(((Convert.ToDouble(ds.Tables[0].Rows[i]["Status5"]) / Convert.ToDouble(ds.Tables[0].Rows[i]["TotalCount"])) * 100), 1).ToString() + "%";
                ChartMain1.Series["Closed"].Points[i].PostBackValue = "5," + ds.Tables[0].Rows[i]["RepAdms"].ToString().Trim() + "," + ds.Tables[0].Rows[i]["Status5"].ToString() + "," + ds.Tables[0].Rows[i]["AdmName"].ToString();

            }

        }

        ChartMain1.Series["Done"].SetCustomProperty("PixelPointWidth", "30");
        ChartMain1.Series["SimyDone"].SetCustomProperty("PixelPointWidth", "30");
        ChartMain1.Series["NotNow"].SetCustomProperty("PixelPointWidth", "30");
        ChartMain1.Series["NotDone"].SetCustomProperty("PixelPointWidth", "30");
        ChartMain1.Series["Closed"].SetCustomProperty("PixelPointWidth", "30");



        ChartMain1.ChartAreas[0].AxisX.LabelStyle.Angle = -30;
        ChartMain1.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount;
        ChartMain1.ChartAreas[0].AxisX.IsLabelAutoFit = false;

        LegendItem itemNotNow = new LegendItem();
        itemNotNow.ImageStyle = LegendImageStyle.Rectangle;
        itemNotNow.BorderColor = System.Drawing.Color.Transparent;
        itemNotNow.Color = System.Drawing.ColorTranslator.FromHtml("#5b9092");
        itemNotNow.Cells.Add(LegendCellType.Text, "لم يحن وقت التنفيذ", System.Drawing.ContentAlignment.MiddleCenter);
        itemNotNow.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);
        itemNotNow.ToolTip = "لم يحن تاريخ تنفيذ التوصية/ الملاحظة المتفق عليه مع الإدارة متوسطة";

        ChartMain1.Legends[0].CustomItems.Add(itemNotNow);



        LegendItem itemClosed = new LegendItem();
        itemClosed.ImageStyle = LegendImageStyle.Rectangle;
        itemClosed.BorderColor = System.Drawing.Color.Transparent;
        itemClosed.Color = System.Drawing.ColorTranslator.FromHtml("#cccccc");
        itemClosed.Cells.Add(LegendCellType.Text, "مغلقة", System.Drawing.ContentAlignment.MiddleCenter);
        itemClosed.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);
        itemClosed.ToolTip = "لعدم مناسبة تطبيقها في الوقت الحالي ، لتكرارها في تقرير آخر";

        ChartMain1.Legends[0].CustomItems.Add(itemClosed);

        LegendItem itemNotDone = new LegendItem();
        itemNotDone.ImageStyle = LegendImageStyle.Rectangle;
        itemNotDone.BorderColor = System.Drawing.Color.Transparent;
        itemNotDone.Color = System.Drawing.Color.DarkRed;
        itemNotDone.Cells.Add(LegendCellType.Text, "متأخرة", System.Drawing.ContentAlignment.MiddleCenter);
        itemNotDone.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);
        itemNotDone.ToolTip = "لم يتم معالجة التوصية / الملاحظة وفقا لتاريخ الانتهاء المقدم من قبل الإدارة متوسطة";
        ChartMain1.Legends[0].CustomItems.Add(itemNotDone);

        LegendItem itemSemiDone = new LegendItem();
        itemSemiDone.ImageStyle = LegendImageStyle.Rectangle;
        itemSemiDone.BorderColor = System.Drawing.Color.Transparent;
        itemSemiDone.Color = System.Drawing.ColorTranslator.FromHtml("#e7ea56");

        itemSemiDone.Cells.Add(LegendCellType.Text, "جارى التنفيذ", System.Drawing.ContentAlignment.MiddleCenter);
        itemSemiDone.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);
        itemSemiDone.ToolTip = "تم تنفيذ جزء من التوصية فقط / جزء من الملاحظة";

        ChartMain1.Legends[0].CustomItems.Add(itemSemiDone);


        LegendItem itemDone = new LegendItem();
        itemDone.ImageStyle = LegendImageStyle.Rectangle;
        itemDone.BorderColor = System.Drawing.Color.Transparent;
        itemDone.Color = System.Drawing.Color.LightGreen;
        itemDone.Cells.Add(LegendCellType.Text, "معالجة", System.Drawing.ContentAlignment.MiddleCenter);
        itemDone.Cells.Add(LegendCellType.SeriesSymbol, "", System.Drawing.ContentAlignment.MiddleRight);
        itemDone.ToolTip = "تم معالجة وتنفيذ جميع التوصيات";
        ChartMain1.Legends[0].CustomItems.Add(itemDone);

        for (int j = 0; j < ChartMain1.Series.Count; j++)
        {
            ChartMain1.Series[j].SmartLabelStyle.CalloutLineAnchorCapStyle = LineAnchorCapStyle.None;
            ChartMain1.Series[j].SmartLabelStyle.CalloutLineColor = System.Drawing.Color.Transparent;

            foreach (DataPoint point in ChartMain1.Series[j].Points)
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

        RepTotals.DataSource = Obj.GetDataSet("GetReportsCounts");
        RepTotals.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UData"] != null)
            {
                DataSet MyRecDataSet = (DataSet)Session["UData"];

                if (Convert.ToBoolean(MyRecDataSet.Tables[0].Rows[0]["Gov"]) == true || Convert.ToBoolean(MyRecDataSet.Tables[0].Rows[0]["SystemAdmin"]) == true)
                {
                    if (DropYear.SelectedValue == "" || DropYear.SelectedValue == "0")
                    {
                        DropYear.Items.Clear();


                        DropYear.DataSource = Obj.GetDataSet("GetPlans");
                        DropYear.DataTextField = "YearName";
                        DropYear.DataValueField = "ID";
                        DropYear.DataBind();

                        ListItem aa = new ListItem("جميع السنوات", "0");

                        DropYear.Items.Insert(0, aa);
                        DropYear.SelectedItem.Value = "0";
                        Chart1.DataSource = null;
                        Chart1.DataBind();
                        Chart1.Legends[0].CustomItems.Clear();

                        DataSet ds = Obj.GetDataSet("GetAllSectionsChart");

                        AdminsListAll.DataSource = ds;
                        AdminsListAll.DataBind();
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {

                                Chart1.Series["Done"].Points.Add(new DataPoint(i, ds.Tables[0].Rows[i]["Status3"].ToString().Trim()));
                                Chart1.Series["SimyDone"].Points.Add(new DataPoint(i, ds.Tables[0].Rows[i]["Status2"].ToString().Trim()));
                                Chart1.Series["NotNow"].Points.Add(new DataPoint(i, ds.Tables[0].Rows[i]["Status4"].ToString().Trim()));
                                Chart1.Series["NotDone"].Points.Add(new DataPoint(i, ds.Tables[0].Rows[i]["Status1"].ToString().Trim()));
                                Chart1.Series["Closed"].Points.Add(new DataPoint(i, ds.Tables[0].Rows[i]["Status5"].ToString().Trim()));
                                Chart1.Series[0].Points[i].AxisLabel = ds.Tables[0].Rows[i]["SectionName"].ToString() + " [ " + ds.Tables[0].Rows[i]["TotalCount"] + " ]  ";

                                Chart1.Series["Done"].Points[i].ToolTip = "[" + ds.Tables[0].Rows[i]["Status3"].ToString() + "] " + Math.Round(((Convert.ToDouble(ds.Tables[0].Rows[i]["Status3"]) / Convert.ToDouble(ds.Tables[0].Rows[i]["TotalCount"])) * 100), 1).ToString() + "%";
                                Chart1.Series["Done"].Points[i].PostBackValue = "3," + ds.Tables[0].Rows[i]["RepSection"].ToString().Trim() + "," + ds.Tables[0].Rows[i]["Status3"].ToString() + "," + ds.Tables[0].Rows[i]["SectionName"].ToString();


                                Chart1.Series["SimyDone"].Points[i].ToolTip = "[" + ds.Tables[0].Rows[i]["Status2"].ToString() + "] " + Math.Round(((Convert.ToDouble(ds.Tables[0].Rows[i]["Status2"]) / Convert.ToDouble(ds.Tables[0].Rows[i]["TotalCount"])) * 100), 1).ToString() + "%";
                                Chart1.Series["SimyDone"].Points[i].PostBackValue = "2," + ds.Tables[0].Rows[i]["RepSection"].ToString().Trim() + "," + ds.Tables[0].Rows[i]["Status2"].ToString() + "," + ds.Tables[0].Rows[i]["SectionName"].ToString();

                                Chart1.Series["NotNow"].Points[i].ToolTip = "[" + ds.Tables[0].Rows[i]["Status4"].ToString() + "] " + Math.Round(((Convert.ToDouble(ds.Tables[0].Rows[i]["Status4"]) / Convert.ToDouble(ds.Tables[0].Rows[i]["TotalCount"])) * 100), 1).ToString() + "%";
                                Chart1.Series["NotNow"].Points[i].PostBackValue = "4," + ds.Tables[0].Rows[i]["RepSection"].ToString().Trim() + "," + ds.Tables[0].Rows[i]["Status4"].ToString() + "," + ds.Tables[0].Rows[i]["SectionName"].ToString();


                                Chart1.Series["NotDone"].Points[i].ToolTip = "[" + ds.Tables[0].Rows[i]["Status1"].ToString() + "] " + Math.Round(((Convert.ToDouble(ds.Tables[0].Rows[i]["Status1"]) / Convert.ToDouble(ds.Tables[0].Rows[i]["TotalCount"])) * 100), 1).ToString() + "%";
                                Chart1.Series["NotDone"].Points[i].PostBackValue = "1," + ds.Tables[0].Rows[i]["RepSection"].ToString().Trim() + "," + ds.Tables[0].Rows[i]["Status1"].ToString() + "," + ds.Tables[0].Rows[i]["SectionName"].ToString();

                                Chart1.Series["Closed"].Points[i].ToolTip = "[" + ds.Tables[0].Rows[i]["Status5"].ToString() + "] " + Math.Round(((Convert.ToDouble(ds.Tables[0].Rows[i]["Status5"]) / Convert.ToDouble(ds.Tables[0].Rows[i]["TotalCount"])) * 100), 1).ToString() + "%";
                                Chart1.Series["Closed"].Points[i].PostBackValue = "5," + ds.Tables[0].Rows[i]["RepSection"].ToString().Trim() + "," + ds.Tables[0].Rows[i]["Status5"].ToString() + "," + ds.Tables[0].Rows[i]["SectionName"].ToString();

                            }

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




                        RepTotalsYears.DataSource = Obj.GetDataSet("GetRepSectionAll");
                        RepTotalsYears.DataBind();


                        Repeater2Years.DataSource = EmployeesDataYears.DataSource = ds;
                        EmployeesDataYears.DataBind();

                        Repeater2Years.DataBind();

                        GetData();

                        MainData();
                    }
                }

                else
                {
                    Response.Redirect("NoPermissions.aspx");
                }
            }
        }
    }

    //&Plans 
    protected void PreviewTotal_Command(object sender, CommandEventArgs e)
    {
       
        ChartImportByAdm.Series[0].Points.Clear();
        ChartImportByAdm.Legends[0].CustomItems.Clear();
        ShowAdminImp.Text = "A";
        DataSet Ds = null;
        var Vall = 0;
        string PostVal = e.CommandArgument.ToString();

        string[] splitString = PostVal.Split('/');

        LbelPup.Text = "مستوى الأهمية للملاحظات تبعا ل";
        LbelPup.Text += splitString[1];

        if (DropYear.SelectedValue != "" && DropYear.SelectedValue != "0")
        {
            Ds = Obj.GetDataSetBy2ID("GetChartBySectionPlan", Convert.ToInt32(Convert.ToInt32(splitString[0])), Convert.ToInt32(DropYear.SelectedValue));


            Vall = Obj.ExecuteProcedure2ID("GetReportCountBySecPlan", Convert.ToInt32(Convert.ToInt32(splitString[0])), Convert.ToInt32(DropYear.SelectedValue));
        }
        else
        {
            Ds = Obj.GetDataSetByID("GetChartBySection", Convert.ToInt32(Convert.ToInt32(splitString[0])));


            Vall = Obj.ExecuteProcedureID("GetReportCountBySection", Convert.ToInt32(Convert.ToInt32(splitString[0])));
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

    //&plans
    protected void Chart1_Click(object sender, ImageMapEventArgs e)
    {
        ChartImportByAdm.DataSource = null;
        ChartImportByAdm.DataBind();
        ChartImportByAdm.Legends[0].CustomItems.Clear();
        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "GetDetails();", true);
        string PostVal = e.PostBackValue.ToString();

        string[] splitString = PostVal.Split(',');

        string Case = "";
        if(splitString[0]=="3")
        {
            Case="المعالجة";
        }
        else if(splitString[0]=="2")
        {
            Case="جارى التنفيذ";
        }if(splitString[0]=="4")
        {
            Case="لم يحن وقت تنفيذها";
        }
        if(splitString[0]=="5")
        {
            Case="مغلقة";
        }
        if(splitString[0]=="1")
        {
            Case="متأخرة";
        }
        LbelPup.Text = "مستوى الأهمية'"+Case+"' للملاحظات الخاصة بإدارة عليا";
        LbelPup.Text += " " + Convert.ToString(splitString[3].Trim());
        DataSet Ds = null;
        var Vall = 0;
        if (DropYear.SelectedValue != "" && DropYear.SelectedValue != "0")
        {

            Ds = Obj.GetChartImportBySecPlan(Convert.ToInt32(splitString[1].Trim()), Convert.ToInt32(splitString[0].Trim()), Convert.ToInt32(DropYear.SelectedValue));


            Vall = Convert.ToInt32(splitString[2].Trim());


        }
        else
        {
            Ds = Obj.GetChartImportBySec(Convert.ToInt32(splitString[1].Trim()), Convert.ToInt32(splitString[0].Trim()));


            Vall = Convert.ToInt32(splitString[2].Trim());

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
    //&Plan

    protected void ChartMain1_Click(object sender, ImageMapEventArgs e)
    {
        ChartImportByAdm.DataSource = null;
        ChartImportByAdm.DataBind();
        ChartImportByAdm.Legends[0].CustomItems.Clear();
        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "GetDetails();", true);

        DataSet Ds = null;
        var Vall = 0;

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
        LbelPup.Text = "مستوى الأهمية'" + Case + "' للملاحظات الخاصة بادارة";
        LbelPup.Text += " " + Convert.ToString(splitString[3].Trim());
        if (DropYear.SelectedValue != "" && DropYear.SelectedValue != "0")
        {
            Ds = Obj.GetChartByPlansStatus(Convert.ToInt32(DropYear.SelectedValue), Convert.ToInt32(splitString[0].Trim()), Convert.ToInt32(splitString[1].Trim()));

            Vall = Convert.ToInt32(splitString[2].Trim());

        }
        else
        {

            Ds = Obj.GetChartImportnace(Convert.ToInt32(splitString[1].Trim()), Convert.ToInt32(splitString[0].Trim()));

            Vall = Convert.ToInt32(splitString[2].Trim());
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

        if (DropYear.SelectedValue != "" && DropYear.SelectedValue != "0")
        {

            GetDataYear();
        }
        else { GetData(); }

    }



    protected void BtnAllRisk_Click(object sender, EventArgs e)
    {
        DataChart.Attributes.Remove("style");
        DataChart.Style.Add("display", "block");

        MainsAll.Attributes.Remove("style");
        MainsAll.Style.Add("display", "none");

        AdAll.Attributes.Remove("style");
        AdAll.Style.Add("display", "none");

        Ad1.Attributes.Remove("style");
        Ad1.Style.Add("display", "block");

    }
    protected void BackCharts_Click(object sender, EventArgs e)
    {

        DataChart.Attributes.Remove("style");
        DataChart.Style.Add("display", "none");

        MainsAll.Attributes.Remove("style");
        MainsAll.Style.Add("display", "block");

        AdminsList.Visible = true;
        AdminsListAll.Visible = false;


    }
    protected void BtnAdminAll_Click(object sender, EventArgs e)
    {
        DataChart.Attributes.Remove("style");
        DataChart.Style.Add("display", "block");

        Ad1.Attributes.Remove("style");
        Ad1.Style.Add("display", "none");

        AdAll.Attributes.Remove("style");
        AdAll.Style.Add("display", "block");

        MainsAll.Attributes.Remove("style");
        MainsAll.Style.Add("display", "none");

        AdminsList.Visible = false;
        AdminsListAll.Visible = true;


    }

    //&plan
    protected void PreviewTotalAdmin_Command(object sender, CommandEventArgs e)
    {
        ChartImportByAdm.Series[0].Points.Clear();
        ChartImportByAdm.Legends[0].CustomItems.Clear();
        ShowAdminImp.Text = "A";
        DataSet Ds = null;
        var Vall = 0; string PostVal = e.CommandArgument.ToString();

        string[] splitString = PostVal.Split('/'); 
        LbelPup.Text = "مستوى الأهمية للملاحظات تبعا ل";

        LbelPup.Text += splitString[1];

        if (DropYear.SelectedValue != "" && DropYear.SelectedValue != "0")
        {
            Vall = Obj.GetReportCountByAdminPlan(Convert.ToInt32(splitString[0]), Convert.ToInt32(DropYear.SelectedValue));
            Ds = Obj.GetChartByAdminPlanImport(Convert.ToInt32(DropYear.SelectedValue), Convert.ToInt32(splitString[0]));

        }
        else
        {
            Ds = Obj.GetDataSetByID("GetChartByAdmin", Convert.ToInt32(splitString[0]));


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
    protected void DropYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropYear.SelectedValue != "" && DropYear.SelectedValue != "0")
        {
            ChartMain4.DataSource = null;
            ChartMain4.DataBind();
            ChartMain4.Legends[0].CustomItems.Clear();

            ChartMain3.DataSource = null;
            ChartMain3.DataBind();
            ChartMain3.Legends[0].CustomItems.Clear();
            Chart1.DataSource = null;
            Chart1.DataBind();
            Chart1.Legends[0].CustomItems.Clear();
            Chart1.Series["Done"].Points.Clear();

            Chart1.Series["SimyDone"].Points.Clear();
            Chart1.Series["NotNow"].Points.Clear();
            Chart1.Series["NotDone"].Points.Clear();
            Chart1.Series["Closed"].Points.Clear();
            Chart1.Series["Done"].Points.Clear();


            DataSet ds = Obj.GetDataSetByID("GetAllSectionsChartPlans", Convert.ToInt32(DropYear.SelectedValue));

            AdminsListAll.DataSource = ds;
            AdminsListAll.DataBind();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    Chart1.Series["Done"].Points.Add(new DataPoint(i, ds.Tables[0].Rows[i]["Status3"].ToString().Trim()));
                    Chart1.Series["SimyDone"].Points.Add(new DataPoint(i, ds.Tables[0].Rows[i]["Status2"].ToString().Trim()));
                    Chart1.Series["NotNow"].Points.Add(new DataPoint(i, ds.Tables[0].Rows[i]["Status4"].ToString().Trim()));
                    Chart1.Series["NotDone"].Points.Add(new DataPoint(i, ds.Tables[0].Rows[i]["Status1"].ToString().Trim()));
                    Chart1.Series["Closed"].Points.Add(new DataPoint(i, ds.Tables[0].Rows[i]["Status5"].ToString().Trim()));
                    Chart1.Series[0].Points[i].AxisLabel = ds.Tables[0].Rows[i]["SectionName"].ToString() + " [ " + ds.Tables[0].Rows[i]["TotalCount"] + " ]  ";

                    Chart1.Series["Done"].Points[i].ToolTip = "[" + ds.Tables[0].Rows[i]["Status3"].ToString() + "] " + Math.Round(((Convert.ToDouble(ds.Tables[0].Rows[i]["Status3"]) / Convert.ToDouble(ds.Tables[0].Rows[i]["TotalCount"])) * 100), 1).ToString() + "%";
                    Chart1.Series["Done"].Points[i].PostBackValue = "3," + ds.Tables[0].Rows[i]["RepSection"].ToString().Trim() + "," + ds.Tables[0].Rows[i]["Status3"].ToString() + "," + ds.Tables[0].Rows[i]["SectionName"].ToString();


                    Chart1.Series["SimyDone"].Points[i].ToolTip = "[" + ds.Tables[0].Rows[i]["Status2"].ToString() + "] " + Math.Round(((Convert.ToDouble(ds.Tables[0].Rows[i]["Status2"]) / Convert.ToDouble(ds.Tables[0].Rows[i]["TotalCount"])) * 100), 1).ToString() + "%";
                    Chart1.Series["SimyDone"].Points[i].PostBackValue = "2," + ds.Tables[0].Rows[i]["RepSection"].ToString().Trim() + "," + ds.Tables[0].Rows[i]["Status2"].ToString() + "," + ds.Tables[0].Rows[i]["SectionName"].ToString();

                    Chart1.Series["NotNow"].Points[i].ToolTip = "[" + ds.Tables[0].Rows[i]["Status4"].ToString() + "] " + Math.Round(((Convert.ToDouble(ds.Tables[0].Rows[i]["Status4"]) / Convert.ToDouble(ds.Tables[0].Rows[i]["TotalCount"])) * 100), 1).ToString() + "%";
                    Chart1.Series["NotNow"].Points[i].PostBackValue = "4," + ds.Tables[0].Rows[i]["RepSection"].ToString().Trim() + "," + ds.Tables[0].Rows[i]["Status4"].ToString() + "," + ds.Tables[0].Rows[i]["SectionName"].ToString();


                    Chart1.Series["NotDone"].Points[i].ToolTip = "[" + ds.Tables[0].Rows[i]["Status1"].ToString() + "] " + Math.Round(((Convert.ToDouble(ds.Tables[0].Rows[i]["Status1"]) / Convert.ToDouble(ds.Tables[0].Rows[i]["TotalCount"])) * 100), 1).ToString() + "%";
                    Chart1.Series["NotDone"].Points[i].PostBackValue = "1," + ds.Tables[0].Rows[i]["RepSection"].ToString().Trim() + "," + ds.Tables[0].Rows[i]["Status1"].ToString() + "," + ds.Tables[0].Rows[i]["SectionName"].ToString();

                    Chart1.Series["Closed"].Points[i].ToolTip = "[" + ds.Tables[0].Rows[i]["Status5"].ToString() + "] " + Math.Round(((Convert.ToDouble(ds.Tables[0].Rows[i]["Status5"]) / Convert.ToDouble(ds.Tables[0].Rows[i]["TotalCount"])) * 100), 1).ToString() + "%";
                    Chart1.Series["Closed"].Points[i].PostBackValue = "5," + ds.Tables[0].Rows[i]["RepSection"].ToString().Trim() + "," + ds.Tables[0].Rows[i]["Status5"].ToString() + "," + ds.Tables[0].Rows[i]["SectionName"].ToString();

                }

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




            RepTotalsYears.DataSource = Obj.GetDataSetByID("GetRepSectionAllPlans", Convert.ToInt32(DropYear.SelectedValue));
            RepTotalsYears.DataBind();


            Repeater2Years.DataSource = EmployeesDataYears.DataSource = ds;
            EmployeesDataYears.DataBind();

            Repeater2Years.DataBind();

            GetDataYear();

            MainDataYear();
        }
        else
        {

            Chart1.DataSource = null;
            Chart1.DataBind();
            Chart1.Legends[0].CustomItems.Clear();
            Chart1.Series["Done"].Points.Clear();
            Chart1.Series["SimyDone"].Points.Clear();
            Chart1.Series["NotNow"].Points.Clear();
            Chart1.Series["NotDone"].Points.Clear();
            Chart1.Series["Closed"].Points.Clear();
            Chart1.Series["Done"].Points.Clear();


            DataSet ds = Obj.GetDataSet("GetAllSectionsChart");

            AdminsListAll.DataSource = ds;
            AdminsListAll.DataBind();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    Chart1.Series["Done"].Points.Add(new DataPoint(i, ds.Tables[0].Rows[i]["Status3"].ToString().Trim()));
                    Chart1.Series["SimyDone"].Points.Add(new DataPoint(i, ds.Tables[0].Rows[i]["Status2"].ToString().Trim()));
                    Chart1.Series["NotNow"].Points.Add(new DataPoint(i, ds.Tables[0].Rows[i]["Status4"].ToString().Trim()));
                    Chart1.Series["NotDone"].Points.Add(new DataPoint(i, ds.Tables[0].Rows[i]["Status1"].ToString().Trim()));
                    Chart1.Series["Closed"].Points.Add(new DataPoint(i, ds.Tables[0].Rows[i]["Status5"].ToString().Trim()));
                    Chart1.Series[0].Points[i].AxisLabel = ds.Tables[0].Rows[i]["SectionName"].ToString() + " [ " + ds.Tables[0].Rows[i]["TotalCount"] + " ]  ";

                    Chart1.Series["Done"].Points[i].ToolTip = "[" + ds.Tables[0].Rows[i]["Status3"].ToString() + "] " + Math.Round(((Convert.ToDouble(ds.Tables[0].Rows[i]["Status3"]) / Convert.ToDouble(ds.Tables[0].Rows[i]["TotalCount"])) * 100), 1).ToString() + "%";
                    Chart1.Series["Done"].Points[i].PostBackValue = "3," + ds.Tables[0].Rows[i]["RepSection"].ToString().Trim() + "," + ds.Tables[0].Rows[i]["Status3"].ToString() + "," + ds.Tables[0].Rows[i]["SectionName"].ToString();


                    Chart1.Series["SimyDone"].Points[i].ToolTip = "[" + ds.Tables[0].Rows[i]["Status2"].ToString() + "] " + Math.Round(((Convert.ToDouble(ds.Tables[0].Rows[i]["Status2"]) / Convert.ToDouble(ds.Tables[0].Rows[i]["TotalCount"])) * 100), 1).ToString() + "%";
                    Chart1.Series["SimyDone"].Points[i].PostBackValue = "2," + ds.Tables[0].Rows[i]["RepSection"].ToString().Trim() + "," + ds.Tables[0].Rows[i]["Status2"].ToString() + "," + ds.Tables[0].Rows[i]["SectionName"].ToString();

                    Chart1.Series["NotNow"].Points[i].ToolTip = "[" + ds.Tables[0].Rows[i]["Status4"].ToString() + "] " + Math.Round(((Convert.ToDouble(ds.Tables[0].Rows[i]["Status4"]) / Convert.ToDouble(ds.Tables[0].Rows[i]["TotalCount"])) * 100), 1).ToString() + "%";
                    Chart1.Series["NotNow"].Points[i].PostBackValue = "4," + ds.Tables[0].Rows[i]["RepSection"].ToString().Trim() + "," + ds.Tables[0].Rows[i]["Status4"].ToString() + "," + ds.Tables[0].Rows[i]["SectionName"].ToString();


                    Chart1.Series["NotDone"].Points[i].ToolTip = "[" + ds.Tables[0].Rows[i]["Status1"].ToString() + "] " + Math.Round(((Convert.ToDouble(ds.Tables[0].Rows[i]["Status1"]) / Convert.ToDouble(ds.Tables[0].Rows[i]["TotalCount"])) * 100), 1).ToString() + "%";
                    Chart1.Series["NotDone"].Points[i].PostBackValue = "1," + ds.Tables[0].Rows[i]["RepSection"].ToString().Trim() + "," + ds.Tables[0].Rows[i]["Status1"].ToString() + "," + ds.Tables[0].Rows[i]["SectionName"].ToString();

                    Chart1.Series["Closed"].Points[i].ToolTip = "[" + ds.Tables[0].Rows[i]["Status5"].ToString() + "] " + Math.Round(((Convert.ToDouble(ds.Tables[0].Rows[i]["Status5"]) / Convert.ToDouble(ds.Tables[0].Rows[i]["TotalCount"])) * 100), 1).ToString() + "%";
                    Chart1.Series["Closed"].Points[i].PostBackValue = "5," + ds.Tables[0].Rows[i]["RepSection"].ToString().Trim() + "," + ds.Tables[0].Rows[i]["Status5"].ToString() + "," + ds.Tables[0].Rows[i]["SectionName"].ToString();

                }

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




            RepTotalsYears.DataSource = Obj.GetDataSet("GetRepSectionAll");
            RepTotalsYears.DataBind();


            Repeater2Years.DataSource = EmployeesDataYears.DataSource = ds;
            EmployeesDataYears.DataBind();

            Repeater2Years.DataBind();

            GetData();

            MainData();
        }
    }
    protected void ButtonViewAdmins_Click(object sender, EventArgs e)
    {
        DataChart.Attributes.Remove("style");
        DataChart.Style.Add("display", "block");

        Ad1.Attributes.Remove("style");
        Ad1.Style.Add("display", "block");

        AdAll.Attributes.Remove("style");
        AdAll.Style.Add("display", "none");

        MainsAll.Attributes.Remove("style");
        MainsAll.Style.Add("display", "none");

        AdminsList.Visible = true;
        AdminsListAll.Visible = false;
    }
}