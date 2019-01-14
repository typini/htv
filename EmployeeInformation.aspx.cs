///////////////////////////////////////////////
// File:  EmployeeInformation.aspx.cs
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
    public partial class WebForm2 : System.Web.UI.Page
    {

        //instantiate a connection to the Business Layer
        clsBusinessLayer myBusinessLayer = new clsBusinessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            myBusinessLayer = new clsBusinessLayer(Server.MapPath("~/"));
            int tPRO = (int)Session["PurchaseRequest"];
            lblPR.Text = tPRO.ToString();
            //fills the dropdownlist upon loading the page for the first time
            if (!IsPostBack) { populateDropDownList(myBusinessLayer.getEmployeeID(tPRO)); }
            updateAllFields();
        }
        
        public void populateDropDownList(int sValue)
        {

            try
            {
                dsEmployee dsPopulate = new dsEmployee();
                string tempPath = Server.MapPath("~/HTVDatabase1.mdb");
                clsDataLayer dataLayerObj = new HTV.clsDataLayer(tempPath);
                dsPopulate = dataLayerObj.dsEmployeeDropDown();

                ddlEmployeeID.DataSource = dsPopulate;
                ddlEmployeeID.DataTextField = "Employee";
                ddlEmployeeID.DataValueField = "employeeID";
                ddlEmployeeID.DataBind();

                //this is the that selects the item that was passed to the method (by value)
                ddlEmployeeID.SelectedValue = sValue.ToString();

            }
            catch (Exception error)
            {
                Warnings.Text = "Critical Error: " + error;
            }


        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            clearWarnings();

            int tempPRID = (int)Session["PurchaseRequest"];
            try {
                myBusinessLayer.attachEmployeeToPurchaseRequest(Int32.Parse(ddlEmployeeID.Text), tempPRID);
                Warnings.Text = "Save successful.";
            }
            catch (Exception error) { Warnings.Text = "Error 1 - " + error; }
            
        }

        public void clearWarnings ()
        {
            //clears the warnings placed in the footer
            Warnings.Text = "";
        }

        protected void ddlEmployeeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Reminds the user that no data is automatically saved when an employee is selected.  Save must be clicked to save the data.
            Warnings.Text = "You changed Employee Focus on this Purchase Request.  Change is not permanent until you press 'Save.'";

            updateAllFields();  

        }

        //this function posts all information from the database to the screen
        public void updateAllFields()
        {
            
            //define a dsCustomer object
            dsEmployee dsSwitchEmployee;

            string tempPath = Server.MapPath("~/HTVDatabase1.mdb");
            clsDataLayer dataLayerObj = new HTV.clsDataLayer(tempPath);

            try
            {
                //retrieves information for a specific Employee and places it in a dataset
                dsSwitchEmployee = dataLayerObj.findEmployee(Int32.Parse(ddlEmployeeID.Text));

                if (dsSwitchEmployee.Employee.Rows.Count > 0)
                {
                    //try/catch are used to prevent errors reading NULL data fields
                    try { lblFirst.Text = dsSwitchEmployee.Employee[0].firstName; }
                    catch (Exception error) { lblFirst.Text = ""; }

                    try { lblLast.Text = dsSwitchEmployee.Employee[0].lastName; }
                    catch (Exception error) { lblLast.Text = ""; }

                    try { lblPosition.Text = dsSwitchEmployee.Employee[0].Position; }
                    catch (Exception error) { lblPosition.Text = ""; }

                    try { lblDateHired.Text = (dsSwitchEmployee.Employee[0].DateHire).ToString(); }
                    catch (Exception error) { lblDateHired.Text = ""; }

                    try { lblCommission.Text = myBusinessLayer.calculateCommissionRate(dsSwitchEmployee.Employee[0].CommisionRate); }
                    catch (Exception error) { lblCommission.Text = ""; }

                }
                else
                {
                    Warnings.Text = "Not Found.";
                }
            }
            catch (Exception error)
            {
                string message = "Error = ";
                Warnings.Text = message + error.Message;
            }

        }

    }

}
