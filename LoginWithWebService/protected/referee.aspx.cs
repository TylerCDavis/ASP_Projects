using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration; // Added for WebConfigurationManager
using System.Data.SqlClient; // Added for SqlConnection, SqlCommand and SqlDataReader
using System.Data;

public partial class referee : System.Web.UI.Page
{
    /// <summary>
    /// checks the access level then redirects if necessary.
    /// Get the first name and last name from the HASC database by using the person ID session variable
    /// </summary>
    /// <param name="sender">Page Load</param>
    /// <param name="e">event data</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Session["access"].ToString() == "player" || Session["access"].ToString() == "coach")
        {
            Response.Redirect("../unauthorized.aspx");
        }
        try
        {
            string con_string = WebConfigurationManager.ConnectionStrings["HASCConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(con_string);
            SqlCommand cmd = new SqlCommand("use HASC; Select FirstName, LastName from Persons Where PersonID = '" + Session["personID"] + "';");
            cmd.Connection = con;
            con.Open();

            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                string name = rdr.GetValue(0).ToString() + " " + rdr.GetValue(1).ToString();

                lblRef.Text = "Greetings " + Session["access"] + " " + name;
            }
            con.Close();

        }
        catch { }

    }

}