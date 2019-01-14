///////////////////////////////////////////////
// File:  PurchaseOverview.aspx.cs
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
    public partial class WebForm9 : System.Web.UI.Page
    {
        //business layer object
        clsBusinessLayer myBusinessLayer = new clsBusinessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            //associate the business object with a serverMapPath
            myBusinessLayer = new clsBusinessLayer(Server.MapPath("~/"));

            //temporarily save the Session data to an integer
            int tPRO = (int)Session["PurchaseRequest"];
            lblPR.Text = tPRO.ToString();
            
            //populate the dropdown list the first time the page is opened
            if (!IsPostBack) { populateDropDownList(tPRO); }
            updateAllFields();
        }

        protected void ddlPurchaseRequestID_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateAllFields();
        }

        public void updateAllFields()
        {
            //instantiate a dataset object for each database that will supply information
            dsPurchaseRequest dsPROPurchaseRequest;            
            dsCustomer dsPROCustomer;
            dsEmployee dsPROEmployee;            
            dsTradeIn dsPROTradeIn;
            dsVehicle dsPROVehicle;

            //create a general dataLayerObject that will serve to populate with datasets as needed
            string tempPath = Server.MapPath("~/HTVDatabase1.mdb");
            clsDataLayer dataLayerObj = new HTV.clsDataLayer(tempPath);

            try
            {
                //populate the PurchaseRequest information. This will also help to link to other Tables using foreign keys
                dsPROPurchaseRequest = dataLayerObj.findPurchaseRequest(Int32.Parse(ddlPurchaseRequestID.Text));

                //only proceeds if there is data in the data set
                if (dsPROPurchaseRequest.PurchaseRequest.Rows.Count > 0)
                {

                    Session["PurchaseRequest"] = dsPROPurchaseRequest.PurchaseRequest[0].requestID;
                    lblPR.Text = ((int)Session["PurchaseRequest"]).ToString();

                    //Retreive Information about the Employee using a DataSet for the Employee information
                    try
                    {
                        dsPROEmployee = dataLayerObj.findEmployee(dsPROPurchaseRequest.PurchaseRequest[0].employeeID);
                        try { lblEmployee.Text = "ID: " + dsPROPurchaseRequest.PurchaseRequest[0].employeeID.ToString() + " - " + dsPROEmployee.Employee[0].lastName + ", " + dsPROEmployee.Employee[0].firstName; }
                        catch (Exception error) { lblEmployee.Text = ""; }
                    }
                    catch (Exception error) { lblEmployee.Text = "No Employee Assigned."; }


                    //Retreive Information about the Customer using a DataSet for the Customer Informaiton
                    try
                    {
                        dsPROCustomer = dataLayerObj.findCustomer(dsPROPurchaseRequest.PurchaseRequest[0].customerID);
                        try { lblCustomer.Text = "SSN: " + dsPROCustomer.Customer[0].socialSecurity + " - " + dsPROCustomer.Customer[0].lastName + ", " + dsPROCustomer.Customer[0].firstName; }
                        catch (Exception error) { lblCustomer.Text = ""; }
                        try { lblCustomer.Text = "SSN: " + dsPROCustomer.Customer[0].socialSecurity + " - " + dsPROCustomer.Customer[0].lastName + ", " + dsPROCustomer.Customer[0].firstName; }
                        catch (Exception error) { lblCustomer.Text = ""; }
                    }
                    catch (Exception error)
                    {
                        lblCustomer.Text = "No Customer Assigned.";
                    }

                    try { lblFICO.Text = "FICO: " + dsPROPurchaseRequest.PurchaseRequest[0].ficoScore.ToString(); }
                    catch (Exception error) { lblFICO.Text = ""; }

                    //Retrieve Information about the Vehicle using a DataSet for the Vehicle Database
                    try
                    {
                        dsPROVehicle = dataLayerObj.findVehicle(dsPROPurchaseRequest.PurchaseRequest[0].vehicleID);
                        try { lblVehicleID.Text = "Vehicle ID: " + dsPROPurchaseRequest.PurchaseRequest[0].vehicleID.ToString() + " - " + dsPROVehicle.Vehicle[0].vin; }
                        catch (Exception error) { lblVehicleID.Text = ""; }
                        try { lblMSRP.Text = string.Format("Vehicle MSRP: {0,000:C2}", dsPROVehicle.Vehicle[0].price); }
                        catch (Exception error) { lblMSRP.Text = ""; }
                        try { lblCustomerOffer.Text = "Customer's Offer: " + dsPROPurchaseRequest.PurchaseRequest[0].negotiatedPrice.ToString("$#,##0.00"); }
                        catch (Exception error) { lblCustomerOffer.Text = ""; }
                        try { lblVehicleLocation.Text = "Location: " + dsPROVehicle.Vehicle[0].VehicleLocation; }
                        catch (Exception error) { lblVehicleLocation.Text = ""; }

                        //This portion fills in the Financing Details of the Overview
                        try { lblDownPayment.Text = string.Format("Total Down Payment: ${0,000:C2}", dsPROPurchaseRequest.PurchaseRequest[0].downPayment); }
                        catch (Exception error) { lblDownPayment.Text = ""; }
                        try { lblCreditAmount.Text = "Remaining Financing Needed: $"+ dsPROPurchaseRequest.PurchaseRequest[0].creditAmount.ToString("0,000.00"); }
                        catch (Exception error) { lblCreditAmount.Text = ""; }
                        try { lblAPR.Text = "Credit Rate Available: " + myBusinessLayer.calculateAPR(dsPROPurchaseRequest.PurchaseRequest[0].ficoScore); }
                        catch (Exception error) { lblDownPayment.Text = ""; }
                        try { lblFinanceLength.Text = dsPROPurchaseRequest.PurchaseRequest[0].financeLength; }
                        catch (Exception error) { lblFinanceLength.Text = ""; }
                        try { lblMonthlyEstimate.Text = "Estimated Monthly Payment: " + myBusinessLayer.calculateMonthlyPayment(dsPROPurchaseRequest.PurchaseRequest[0].ficoScore, myBusinessLayer.calculateAmountToFinance((int)Session["PurchaseRequest"]), myBusinessLayer.convertLoanLengthToInt(dsPROPurchaseRequest.PurchaseRequest[0].financeLength)); }
                        catch (Exception error) { lblMonthlyEstimate.Text = ""; }
                    }
                    catch (Exception error)
                    {
                        //clears all text fields if there is an error, otherwise previous data may stay on the page
                        lblVehicleID.Text = "No Vehicle Assigned";
                        lblVehicleLocation.Text = "";
                        lblDownPayment.Text = "";
                        lblCreditAmount.Text = "";
                        lblAPR.Text = "";
                        lblFinanceLength.Text = "";
                        lblMonthlyEstimate.Text = "";
                    }


                    //TO DO:  This section is left to do.  This will describe the Add-Ons for the Vehicle.
                    try { lblAddOns.Text = dsPROPurchaseRequest.PurchaseRequest[0].requestID.ToString() + " Unfinished Code."; }
                    catch (Exception error) { lblAddOns.Text = ""; }

                    try { lblAddOnsCost.Text = dsPROPurchaseRequest.PurchaseRequest[0].requestID.ToString() + " Unfinished Code."; }
                    catch (Exception error) { lblAddOnsCost.Text = ""; }

                    //Retreive Information about the Trade In using a DataSet for the Trade In information
                    try
                    {
                        dsPROTradeIn = dataLayerObj.findTradeIn(dsPROPurchaseRequest.PurchaseRequest[0].tradeinID);
                        try { lblTradeInID.Text = "ID: " + dsPROPurchaseRequest.PurchaseRequest[0].tradeinID.ToString() + " - " + dsPROTradeIn.TradeIn[0].make + " / " + dsPROTradeIn.TradeIn[0].model + " / " + dsPROTradeIn.TradeIn[0].year; }
                        catch (Exception error) { lblTradeInID.Text = ""; }
                        try { lblTradeInTitle.Text = "Title is Clear. " + dsPROTradeIn.TradeIn[0].titleClear; }
                        catch (Exception error) { lblTradeInTitle.Text = ""; }
                        try { lblTradeInValue.Text = string.Format("Trade-In Value: {0:C2}", dsPROTradeIn.TradeIn[0].amount); }
                        catch (Exception error) { lblTradeInValue.Text = ""; }

                        //Retrieve the Mechanic's Name by using a DataSet that retrieves Employee Information using TradeIn Table FK
                        dsPROEmployee = dataLayerObj.findEmployee(dsPROTradeIn.TradeIn[0].inspectedID);
                        try { lblMechanicApproval.Text = "Approved By: ID " + dsPROTradeIn.TradeIn[0].inspectedID + " - " + dsPROEmployee.Employee[0].lastName + ", " + dsPROEmployee.Employee[0].firstName; }
                        catch (Exception error) { lblMechanicApproval.Text = ""; }

                    }
                    catch (Exception error)
                    {
                        lblTradeInID.Text = "No Trade-In Assigned.";
                        lblTradeInTitle.Text = "";
                        lblTradeInValue.Text = "";
                        lblMechanicApproval.Text = "No Trade-In to inspect.";
                    }

                    //Retrieve the Manager's Name by using a DataSet that retrieves Employee Information using the ManagerApproval Employee ID Number
                    try
                    {
                        dsPROEmployee = dataLayerObj.findEmployee(dsPROPurchaseRequest.PurchaseRequest[0].managerApproval);
                        try { lblManagerApproval.Text = dsPROPurchaseRequest.PurchaseRequest[0].approvalstatus + " by " + dsPROEmployee.Employee[0].lastName + ", " + dsPROEmployee.Employee[0].firstName; }
                        catch (Exception error) { lblManagerApproval.Text = "Unable to retrieve Manager Approval information."; }
                        try { lblDisapprovedDescription.Text = dsPROPurchaseRequest.PurchaseRequest[0].disapprovedDescription; }
                        catch (Exception error) { lblDisapprovedDescription.Text = ""; }
                    }
                    catch (Exception error)
                    {
                        lblManagerApproval.Text = "Pending Manager Approval.";
                        lblDisapprovedDescription.Text = "";
                    }

                    //posts information to the Purchase Request Date field
                    try { lblPurchaseRequestDate.Text = dsPROPurchaseRequest.PurchaseRequest[0].requestCreationDate.ToString(); }
                    catch (Exception error) { lblPurchaseRequestDate.Text = ""; }

                }
                else
                {
                    Warnings.Text = "Error Switching Purchase Requests.";
                }
            }
            catch (Exception error)
            {
                string message = "Error = ";
                Warnings.Text = message + error.Message;
            }

        }

        //this method populates the dropdown menu from PurchaseRequests
        public void populateDropDownList(int sValue)
        {

            try
            {
                dsPurchaseRequest dsPopulate = new dsPurchaseRequest();
                string tempPath = Server.MapPath("~/HTVDatabase1.mdb");
                clsDataLayer dataLayerObj = new HTV.clsDataLayer(tempPath);
                dsPopulate = dataLayerObj.dsPurchaseRequestDropDown();

                //The drop down menu is populated with information from the Purchase Request Table.
                //TO DO:  Make the Purchase ID more user friendly.  Right now, it only shows numbers.  This could show Names and Vehicles
                ddlPurchaseRequestID.DataSource = dsPopulate;
                ddlPurchaseRequestID.DataTextField = "requestID";
                ddlPurchaseRequestID.DataValueField = "requestID";
                ddlPurchaseRequestID.DataBind();
                
                //this line makes sure the last thing selected in the dropdown menu is selected again by default.
                ddlPurchaseRequestID.SelectedValue = sValue.ToString();
                
            }
            catch (Exception error)
            {
                Warnings.Text = "Critical Error: " + error;
            }


        }

        public void clearWarnings()
        {
            //clears the warnings in the footer
            Warnings.Text = "";
        }

    }
}
