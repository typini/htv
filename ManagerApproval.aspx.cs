///////////////////////////////////////////////
// File:  ManagerApproval.aspx.cs
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
    public partial class WebForm8 : System.Web.UI.Page
    {
        //TO DO:  Post All Information to Screen from Purchase Request & Associated Foreign Keys
        //TO DO:  Allow Manager to Update Information
        //TO DO:  Validate Input
        //TO DO:  Buttons to function
        //TO DO:  Store all fields to the database

        protected void Page_Load(object sender, EventArgs e)
        {
            int tPRO = (int)Session["PurchaseRequest"];
            lblPR.Text = tPRO.ToString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Warnings.Text = "The functions of this page have not been completed at this time.";
        }
    }
}
