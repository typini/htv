///////////////////////////////////////////////
// File:  NewVehicleInformation.aspx.cs
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
    public partial class WebForm5 : System.Web.UI.Page
    {
        //business Layer object
        clsBusinessLayer myBusinessLayer = new clsBusinessLayer();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //attach the serverMapPath to the object
            myBusinessLayer = new clsBusinessLayer(Server.MapPath("~/"));
            int tPRO = (int)Session["PurchaseRequest"];
            lblPR.Text = tPRO.ToString();
            //only run these functions the first time the page is posted.
            if (!IsPostBack)
            {
                populateDropDownList(myBusinessLayer.getVehicleID(tPRO));
                updateAllFields();
                updateCustomerOffer();
            }
        }

        //populates the dropdown list with information from the Vehicle Table
        public void populateDropDownList(int sValue)
        {

            try
            {
                dsVehicle dsPopulate = new dsVehicle();
                string tempPath = Server.MapPath("~/HTVDatabase1.mdb");
                clsDataLayer dataLayerObj = new HTV.clsDataLayer(tempPath);
                dsPopulate = dataLayerObj.dsVehicleDropDown();

                
                ddlVehicleID.DataSource = dsPopulate;
                ddlVehicleID.DataTextField = "Vehicle";
                ddlVehicleID.DataValueField = "vehicleID";
                ddlVehicleID.DataBind();

                //re-selects the vehicle with the value of sValue one the dropdownmenu has been repopulated
                ddlVehicleID.SelectedValue = sValue.ToString();

            }
            catch (Exception error)
            {
                Warnings.Text = "Critical Error: " + error;
            }


        }

        
        //posts information from the database to the text fields on the screen
        public void updateAllFields()
        {
            //define a dsVehicle object
            dsVehicle dsSwitchVehicle;            
            
            string tempPath = Server.MapPath("~/HTVDatabase1.mdb");
            clsDataLayer dataLayerObj = new HTV.clsDataLayer(tempPath);

            try
            {
                //loads the vehicle dataset with information from the Vehicle Table
                dsSwitchVehicle = dataLayerObj.findVehicle(Int32.Parse(ddlVehicleID.Text));

                if (dsSwitchVehicle.Vehicle.Rows.Count > 0)
                {
                    //uses try/catch to eliminate errors from NULL items.
                    try { lblVIN.Text = dsSwitchVehicle.Vehicle[0].vin; }
                    catch (Exception error) { lblVIN.Text = ""; }

                    try { lblMSRP.Text = dsSwitchVehicle.Vehicle[0].price.ToString("$#,##0.00"); }
                    catch (Exception error) { lblMSRP.Text = ""; }

                    try { lblTaxes.Text = dsSwitchVehicle.Vehicle[0].taxes.ToString("$#,##0.00"); }
                    catch (Exception error) { lblTaxes.Text = ""; }

                    try { lblFees.Text = (dsSwitchVehicle.Vehicle[0].Licensefee.ToString("$#,##0.00")); }
                    catch (Exception error) { lblFees.Text = ""; }

                    try { lblLocation.Text = dsSwitchVehicle.Vehicle[0].VehicleLocation; }
                    catch (Exception error) { lblLocation.Text = ""; }

                    double TotalVCost = 0;
                    try {
                        TotalVCost = (double)dsSwitchVehicle.Vehicle[0].price + (double)dsSwitchVehicle.Vehicle[0].taxes + (double)dsSwitchVehicle.Vehicle[0].Licensefee;
                        lblTotalCost.Text = TotalVCost.ToString("$#,##0.00"); 
                    }
                    catch (Exception error)
                    { Warnings.Text = "Unable to calculate total cost."; }

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

        //there is only one field on this page to update, this method updates the customer's offer to the Purchase Request.
        public void updateCustomerOffer()
        {
            string tempPath = Server.MapPath("~/HTVDatabase1.mdb");
            clsDataLayer dataLayerObj = new HTV.clsDataLayer(tempPath);

            dsPurchaseRequest dsGetCustomerOffer;
            try
            {
                int tempPRID = (int)Session["PurchaseRequest"];
                dsGetCustomerOffer = dataLayerObj.findPurchaseRequest(tempPRID);

                if (dsGetCustomerOffer.PurchaseRequest.Rows.Count > 0)
                {
                    try { txtCustomerOffer.Text = dsGetCustomerOffer.PurchaseRequest[0].negotiatedPrice.ToString("#,##0.00"); }
                    catch (Exception error) { txtCustomerOffer.Text = ""; }
                }
            }
            catch (Exception error) { txtCustomerOffer.Text = "Error 2: " + error; }
        }

        public void clearWarnings()
        {
            //clears the red background from any invalid information
            txtCustomerOffer.BackColor = System.Drawing.Color.White;
            //clears the warnings in the footer
            Warnings.Text = "";
        }

        public Boolean validated()
        {
            //Boolean will stay true if it passes the validation test
            Boolean valid = true;

            //Ensures that valid text has been entered into the Customer's Offer field.
            if (txtCustomerOffer.Text == "" || !System.Text.RegularExpressions.Regex.IsMatch(txtCustomerOffer.Text, "^[+-]?[0-9]{1,3}(?:,?[0-9]{3})*(?:\\.[0-9]{2})?$"))
            {
                txtCustomerOffer.BackColor = System.Drawing.Color.Red;
                valid = false;
            }
            
            return valid;

        }

        //runs this function upon selecting a different vehicle
        protected void ddlVehicleID_SelectedIndexChanged(object sender, EventArgs e)
        {

            clearWarnings();
            //This line is included to enforce that when a different vehicle is selected, the user must re-enter the customer's offer.
            //This helps ensure that an offer for a different vehicle does not get associated with another vehicle by mistake.
            txtCustomerOffer.Text = "";
            //Reminder to the user that selected another vehicle does not save it to the databse.  To save, user must press "Save."
            Warnings.Text = "You changed Vehicle focus for this Purchase Request.  Change is not permanent until you press 'Save.'";
            updateAllFields();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            //clear all Warnings
            clearWarnings();
            //clears the textbox to be blank
            txtCustomerOffer.Text = "";
        }

        //Pressing save performs to saves
        //Save 1:  The selected vehicle is attached to the Purchase Request
        //Save 2:  The customer Offer is saved to the Purchase Request, if validated
        protected void btnSave_Click(object sender, EventArgs e)
        {
            clearWarnings();
            //Boolean will stay true if the data is valid and writes successfully
            Boolean saved = true;
            int tempPRID = (int)Session["PurchaseRequest"];

            //this functions attempts to associate the selected vehcile with the PurchaseRequest
            try { myBusinessLayer.attachVehicleToPurchaseRequest(Int32.Parse(ddlVehicleID.Text), tempPRID); }
            catch (Exception error) { Warnings.Text = "Error 1: " + error; saved = false; }

            //this next if statement will only run if the data in the text fields are valid
            //it will also only run if the the previous update was successful
            if (validated() && saved)
            {
                try { myBusinessLayer.updateVehicleNegotiatedPrice((Decimal.Parse(txtCustomerOffer.Text)).ToString(), tempPRID); }
                catch (Exception error) { Warnings.Text = "Error 3: " + error; }
            }
            else
            {
                Warnings.Text = "The Customer Offer did not save.  Careful not to enter the customer offer with a dollar sign.";
                txtCustomerOffer.BackColor = System.Drawing.Color.Red;
                saved = false;
            }

            //Give the user feedback if the save was succesful or not
            if (saved) { Warnings.Text = "Your data saved successfully."; }
            else
            {
                Warnings.Text = "Error.  The data did NOT save.";
            }

        }
    }
}
