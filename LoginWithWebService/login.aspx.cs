using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration; // Added for WebConfigurationManager
using System.Data.SqlClient; // Added for Sql objects
using System.Data; // Added for CommandType enumeration

public partial class login : System.Web.UI.Page
{
    /// <summary>
    /// On page load, set focus to the user name input. Declare session variables.
    /// </summary>
    /// <param name="sender">page load</param>
    /// <param name="e">event data</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        SetFocus(Login1.FindControl("UserName"));

        Session["access"] = "";
        Session["personID"] = "";
    }

    /// <summary>
    /// When the user tries to authenticate inputs,hold the email and the password in two variables. 
    /// Create and object of the Hasc authentication web service.
    ///Pass the email and pasword to the auhenticate routine in the object 
    ///if the return is valid, split the return into an array. Pass each array string into a session variable and authenticate = true
    /// </summary>
    /// <param name="sender"> login authentication</param>
    /// <param name="e">event data</param>
    protected void Login1_Authenticate1(object sender, AuthenticateEventArgs e)
    {
        String email= Login1.UserName.ToString();
        String password = Login1.Password.ToString();

        try
        {
            HASC_Authentication HASC = new HASC_Authentication();
            String authReturn = HASC.authenticate(email, password);

            if (authReturn != "noaccess")
            {

               String[] newData= authReturn.Split(',');

               Session["access"] = newData[0];
               Session["personID"] = newData[1];

                e.Authenticated = true;

            }
            else
            {
                e.Authenticated = false;
            }
        }
        catch
        {

        }        

        

        
    }

    /// <summary>
    /// redirect to the apropriate page based on the access level session variable
    /// </summary>
    /// <param name="sender">successful login</param>
    /// <param name="e">event data</param>
    protected void Login1_LoggedIn(object sender, EventArgs e)
    {
        if (Session["access"].ToString() == "referee")
        {
            Response.Redirect("~/protected/referee.aspx");
        }
        else if (Session["access"].ToString() == "coach")
        {
            Response.Redirect("~/protected/coach.aspx");
        }
        else
        {
            Response.Redirect("~/protected/player.aspx");
        }
    }



}