using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Configuration; // Added for WebConfigurationManager
using System.Data.SqlClient; // Added for SqlConnection, SqlCommand and SqlDataReader
using System.Data;

/// <summary>
/// Summary description for HASC_Authentication
/// </summary>
[WebService(Description = "Hamilton Adult Soccer Club Database", Namespace = "http://mohawkcollege.ca/hasc")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class HASC_Authentication : System.Web.Services.WebService
{

    public HASC_Authentication()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    /// <summary>
    /// takes 2 parameters and uses them in a where clause in the sql database.
    /// if the database returns a line, it found the person.
    /// save the person ID to a variable.
    /// next it gets the values from coloumn indexes to check if the person is a 
    ///     ref, player, coach or admin
    ///return both the access level and the person id
    /// </summary>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <returns>accesslevel,personID</returns>
    [WebMethod (Description ="Input your user name and password. This will return your accesslevel and person id")]
    public string authenticate(string email, string password)
    {
        string con_string = WebConfigurationManager.ConnectionStrings["HASCConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(con_string);
        SqlCommand cmd = new SqlCommand("use HASC; Select * from Persons Where Email='" + email + "' AND UserPassword ='" + password +"';");
        cmd.Connection = con;

        
        try

        {
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();            

            if (rdr.Read())
            {                
                string ID =  rdr.GetValue(0).ToString();
 
               // cmd.CommandText="select Player from "
                string player = rdr.GetValue(13).ToString();
                string coach = rdr.GetValue(17).ToString();
                string referee = rdr.GetValue(19).ToString();
                string administrator = rdr.GetValue(21).ToString();
                
                if(player == "True")
                {
                    con.Close();
                    return "player," + ID;
                }
                 if(coach == "True")
                {
                    con.Close();
                    return "coach," + ID;
                }
                 if(referee == "True")
                {
                    con.Close();
                    return "referee," + ID;
                }
                 if(administrator == "True")
                {
                    con.Close();
                    return "admin," + ID;
                }
                else
                {
                    con.Close();
                    return "noaccess";
                }
                
            }
            else
                {
                con.Close();
                return "noaccess";
                }
            
        }
        catch
        {
            return "noaccess";
        }

        
    }
 
}
