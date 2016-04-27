using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration; // Added for WebConfigurationManager
using System.Data.SqlClient; // Added for SQL classes
using System.Web.UI.DataVisualization.Charting; // Added for Chart classes

public partial class patients : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string NursingUnitId = Request.QueryString.ToString();
        NursingUnitId = NursingUnitId.Substring(NursingUnitId.IndexOf("=") + 1);

        h1.Text = "Current Patients - " + NursingUnitId;

    }
}