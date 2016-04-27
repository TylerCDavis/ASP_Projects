using System;
// I, Tyler Davis, student number 000348496, certify that this material is my
// original work. No other person's work has been used without due
// acknowledgement and I have not made my work available to anyone else.
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration; // Added for WebConfigurationManager
using System.Data.SqlClient; // Added for SQL classes
using System.Web.UI.DataVisualization.Charting; // Added for Chart classes

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string con_string = WebConfigurationManager.ConnectionStrings["CHDBConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(con_string);
            SqlCommand cmd = new SqlCommand("SELECT SUBSTRING(NursingUnitID, 1, 1) AS Floor, COUNT(*) AS Patients FROM Admissions WHERE SUBSTRING(NursingUnitID, 1, 1) IN ('1', '2', '3') AND DischargeDate IS NULL GROUP BY SUBSTRING(NursingUnitID, 1, 1)", con);

            try
            {
                using (con)
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    chtPatients.Series["Series1"].Name = "Patients";

                    chtPatients.Series["Patients"].Points.DataBindXY(reader, "Floor", reader, "Patients");

                    chtPatients.Height = 600;
                    chtPatients.Width = 600;

                    chtPatients.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;

                   // chtPatients.Titles.Add("Number of Current Patients on Each Floor");
                    
                   // chtPatients.Titles["Title"].DockedToChartArea = null;
                   //chtPatients.Titles["Title"].Text = "Number of Current Patients on Each Floor";
                    chtPatients.ChartAreas["ChartArea1"].AxisX.Title = "Floor";
                    chtPatients.ChartAreas["ChartArea1"].AxisX.LabelStyle.Font = new System.Drawing.Font("Times New Roman", 12, System.Drawing.FontStyle.Bold);

                    foreach (Series series in chtPatients.Series)
                    {
                        for (int pointIndex = 0; pointIndex < series.Points.Count; pointIndex++)
                        {
                            string toolTip = "<img src=nursing_units.aspx?floor=" + series.Points[pointIndex].AxisLabel + " />";
                            series.Points[pointIndex].MapAreaAttributes = "onmouseover=\"DisplayTooltip('" + toolTip + "');\" onmouseout=\"DisplayTooltip('');\"";
                            series.Points[pointIndex].Url = "nursing_units.aspx?floor=" + series.Points[pointIndex].AxisLabel;
                        }
                    }
                }}
            catch { }
        }
    }
   
}
