using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Configuration; // Added for WebConfigurationManager
using System.Data.SqlClient; // Added for SQL classes
using System.Web.UI.DataVisualization.Charting; // Added for Chart classes

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string floor = Request.QueryString.ToString();
        floor = floor.Substring(floor.IndexOf("=") + 1);

        if (floor == "1")
        {
            chtFloor.Titles["Title1"].Text = "Number of Patients on the " + floor + "st floor";
        }
        else if (floor == "2")
        {
            chtFloor.Titles["Title1"].Text ="Number of Patients on the " + floor + "nd floor";
        }
        else if (floor == "3")
        {
            chtFloor.Titles["Title1"].Text ="Number of Patients on the " + floor + "rd floor";
        }
        

        string con_string = WebConfigurationManager.ConnectionStrings["CHDBConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(con_string);
        SqlCommand cmd = new SqlCommand("Select NursingUnitID, Count(*) as Patients from Admissions where SUBSTRING(NursingUnitID, 1, 1) = '" + floor + "' AND DischargeDate IS NULL Group By NursingUnitID", con);

        try
        {
            using (con)
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                chtFloor.Series["Series1"].Name = "patientsFloor";
                chtFloor.Series["patientsFloor"].Points.DataBindXY(reader, "NursingUnitID", reader, "Patients");

                chtFloor.Height = 600;
                chtFloor.Width = 600;

                chtFloor.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;

                chtFloor.ChartAreas["ChartArea1"].AxisX.Title = "Nursing Unit";
                chtFloor.ChartAreas["ChartArea1"].AxisX.LabelStyle.Font = new System.Drawing.Font("Times New Roman", 12, System.Drawing.FontStyle.Bold);

                foreach (Series series in chtFloor.Series)
                {
                    for(int pointIndex = 0; pointIndex < series.Points.Count; pointIndex++){
                        series.Points[pointIndex].Url = "patients.aspx?nursing_unit_id=" + series.Points[pointIndex].AxisLabel;
                    }
                    
                }

            }
        }catch { }
        

        
    }
}