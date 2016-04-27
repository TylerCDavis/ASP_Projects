// I, Firstname Lastname, student number 123456789, certify that this material is my
// original work. No other person's work has been used without due
// acknowledgement and I have not made my work available to anyone else.

//Test Plan

//Click the player, coach, and referee link
//all 3 should redirect to the login page
//click the login link
// should still be on the login page.
//login as the admin
//should link to the player page as admin
// click all the links again. 
//all links should work, access level should be admin,
//and all pages should show admins first and last name.
//click logout
//login as player
//page should redirect to player page with access level player.
//page should also show player name
//click the coach and referee links
//page should redirect to unauthorized and show access level player
//logout
//login as coach
//redirect to coach page
//show coach access level and coach name
//click player and referee links
//redirect to unauthorized page and display access level coach


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
}