///////////////////////////////////////////////
// File:  AddOns.aspx.cs
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
    public partial class WebForm3 : System.Web.UI.Page
    {
        //This Code has yet to be completed.
        //To Do:
        //Create a Data Set that would accept information from the association table
        //Pull data for the Session PurchaseRequest
        //Calculate the Cost of all Add-Ons
        //Update Information on screen
        //Validate User Input
        //Write functions for Buttons
        //Save Data to Database

        protected void Page_Load(object sender, EventArgs e)
        {
            //Display the session Purchase Request variable in the page's main header line.
            int tPRO = (int)Session["PurchaseRequest"];
            lblPR.Text = tPRO.ToString();
        }

        protected void btnCustomer_Click(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Warnings.Text = "The functions of this page have not been completed at this time.";
        }
    }
}
