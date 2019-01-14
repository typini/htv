///////////////////////////////////////////////
// File:  GenerateReports.aspx.cs
// Program Name:  HTV_v2.0
// Programmer:  Tyree Pini
// Group:  Team D
// Course:  CIS470 Senior Project
// Date:  19 April 2017
// Website:  http://htvteamd.azurewebsites.net/
///////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HTV
{
    public partial class WebForm10 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Warnings.Text will serve as a system output to display text to the user.
            Warnings.Text = "Welcome Traveler!";
            
            //Session["PurchaseRequest"] will keep track of which Purchase Request the user is currently working on.
            Session["PurchaseRequest"] = 1;
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
                /*The log out button will eventually provide functionality to various users.  As for now, the default user has
                 * unltimiated access to all working parts of this program. */
                Warnings.Text = "The Log Out Button has been disabled.  This application is for demonstration purposes only.";
        }

        
    }
}
