using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class unauthorized : System.Web.UI.Page
{
    /// <summary>
    /// display the access level from the login
    /// </summary>
    /// <param name="sender">Page Load</param>
    /// <param name="e">event data</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        lblUnauth.Text = "access level= " + Session["access"];
    }
}