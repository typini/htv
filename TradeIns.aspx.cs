///////////////////////////////////////////////
// File:  TradeIns.aspx.cs
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
    public partial class WebForm6 : System.Web.UI.Page
    {
        //TO DO:  Radio Buttons function
        //TO DO:  Read information from Databases
        //TO DO:  Populate DropDown Menu with information from Trade-Ins
        //TO DO:  Create Validation for inputs
        //TO DO:  Allow the user to save the data, pending validation
        //TO DO:  Create processes that will add a Trade-In row to the Trade-In Table in the Database

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
