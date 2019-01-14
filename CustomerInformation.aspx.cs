///////////////////////////////////////////////
// File:  CustomerInformation.aspx.cs
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
    public partial class WebForm1 : System.Web.UI.Page
    {

        //Business Layer Object
        clsBusinessLayer myBusinessLayer;

        protected void Page_Load(object sender, EventArgs e)
        {
            myBusinessLayer = new clsBusinessLayer(Server.MapPath("~/"));
            int tPRO = (int)Session["PurchaseRequest"];
            lblPR.Text = tPRO.ToString();

            //Whenever the page loads for a first time, populate the dropdownlist from the database
            if (!IsPostBack)
            {
                populateDropDownList(myBusinessLayer.getCustomerID(tPRO).ToString());
                updateAllFields();
            }
            //updateAllFields will populate information based on the session Purchase Request data
            
        }

        protected void btnEmployee_Click(object sender, EventArgs e)
        {

        }

        //this function creates a new customer in the database
        protected void btnNewCustomer_Click(object sender, EventArgs e)
        {
            //business layer will link to the data layer and create a new customer row in the Customer database
            myBusinessLayer.addNewCustomer();

            //After the customer is added, the drop down menu jumps to the last Index (on old field)
            ddlCustomerID.SelectedIndex = (ddlCustomerID.Items.Count-1);
            
            //For Troubleshooting Only:  txtEmail.Text = ddlCustomerID.SelectedValue;
            
            //re-populate the dropdown menu, and select the Customer one higher than the previous last entry
            populateDropDownList(((Int32.Parse(ddlCustomerID.SelectedValue))+1).ToString());
            clearAllEntries();
        }

        //this method automatically executes when a different customer is chosen from the drop down list.
        protected void ddlCustomerID_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearWarnings();
            Warnings.Text = "You changed Customer Focus on this Purchase Request.  Change is not permanent until you press 'Save.'";
            updateAllFields();
        }

        //this method copies data fields from the Customer Database Table to the screen
        public void updateAllFields()
        {
            //define a dsCustomer object
            dsCustomer dsSwitchCustomer;

            string tempPath = Server.MapPath("~/HTVDatabase1.mdb");
            clsDataLayer dataLayerObj = new HTV.clsDataLayer(tempPath);
            
            try
            {
                //populates the dsSwitchCustome dataset with customer information
                dsSwitchCustomer = dataLayerObj.findCustomer(Int32.Parse(ddlCustomerID.Text));

                if (dsSwitchCustomer.Customer.Rows.Count > 0)
                {

                    //post information about the customer to the text boxes on the screen
                    //try/catch is used to prevent NULL errors
                    try { txtSocial.Text = dsSwitchCustomer.Customer[0].socialSecurity; }
                    catch (Exception error) { txtSocial.Text = ""; }

                    try { txtLicense.Text = dsSwitchCustomer.Customer[0].driversLicense; }
                    catch (Exception error) { txtLicense.Text = ""; }

                    try { txtFirst.Text = dsSwitchCustomer.Customer[0].firstName; }
                    catch (Exception error) { txtFirst.Text = ""; }

                    try { txtLast.Text = dsSwitchCustomer.Customer[0].lastName; }
                    catch (Exception error) { txtLast.Text = ""; }

                    try { txtAddress1.Text = dsSwitchCustomer.Customer[0].addressLine1; }
                    catch (Exception error) { txtAddress1.Text = ""; }

                    try { txtAddress2.Text = dsSwitchCustomer.Customer[0].addressLine2; }
                    catch (Exception error) { txtAddress2.Text = ""; }

                    try { txtCity.Text = dsSwitchCustomer.Customer[0].city; }
                    catch (Exception error) { txtCity.Text = ""; }

                    try { txtState.Text = dsSwitchCustomer.Customer[0].state; }
                    catch (Exception error) { txtState.Text = ""; }

                    try { txtZip.Text = dsSwitchCustomer.Customer[0].zipCode; }
                    catch (Exception error) { txtZip.Text = ""; }

                    try { txtEmail.Text = dsSwitchCustomer.Customer[0].email; }
                    catch (Exception error) { txtEmail.Text = ""; }

                    try { txtPhone.Text = dsSwitchCustomer.Customer[0].phoneNumber; }
                    catch (Exception error) { txtPhone.Text = ""; }
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

            //validateRequired highlights any fields that contain erros that will not allow for a re-save
            if (validateRequired()) { } else { Warnings.Text = "Errors on Page."; }

        }
        
        public void clearWarnings()
        {
            //clears the red backgrounds for any text boxes that aren't valid
            txtSocial.BackColor = System.Drawing.Color.White;
            txtLicense.BackColor = System.Drawing.Color.White;
            txtFirst.BackColor = System.Drawing.Color.White;
            txtLast.BackColor = System.Drawing.Color.White;
            txtAddress1.BackColor = System.Drawing.Color.White;
            txtCity.BackColor = System.Drawing.Color.White;
            txtState.BackColor = System.Drawing.Color.White;
            txtZip.BackColor = System.Drawing.Color.White;
            //it also clears the Warnings.Text label in the footer
            Warnings.Text = "";
        }

        public Boolean validateRequired()
        {
            Boolean valid = true;

            //Validate the Social Security.  This code checks to ensure the SSN is not in use by another customer.
            if (txtSocial.Text == "") { txtSocial.BackColor = System.Drawing.Color.Red; valid = false; }
            else if (checkSocial())
            {
                Warnings.Text = "This Social Security Number is already in use.";
                txtSocial.BackColor = System.Drawing.Color.Red;
                valid = false;
            }

            //validation rules/expressions using REGEX
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtSocial.Text, "^\\d{3}-\\d{2}-\\d{4}$")) { txtSocial.BackColor = System.Drawing.Color.Red; valid = false; }
            if (txtLicense.Text == "") { txtLicense.BackColor = System.Drawing.Color.Red; valid = false; }
            if (txtFirst.Text == "" || !System.Text.RegularExpressions.Regex.IsMatch(txtFirst.Text, "^[a-zA-Z''-'\\s]{1,40}$")) { txtFirst.BackColor = System.Drawing.Color.Red; valid = false; }
            if (txtLast.Text == "" || !System.Text.RegularExpressions.Regex.IsMatch(txtLast.Text, "^[a-zA-Z''-'\\s]{1,40}$")) { txtLast.BackColor = System.Drawing.Color.Red; valid = false; }
            if (txtAddress1.Text == "") { txtAddress1.BackColor = System.Drawing.Color.Red; valid = false; }
            if (txtCity.Text == "" || !System.Text.RegularExpressions.Regex.IsMatch(txtCity.Text, "^[a-zA-Z''-'\\s]{1,40}$")) { txtCity.BackColor = System.Drawing.Color.Red; valid = false; }
            if (txtState.Text == "" || !System.Text.RegularExpressions.Regex.IsMatch(txtState.Text, "^[A-Z]{2}$")) { txtState.BackColor = System.Drawing.Color.Red; valid = false; }
            if (txtZip.Text == "" || !System.Text.RegularExpressions.Regex.IsMatch(txtZip.Text, "^(\\d{5}-\\d{4}|\\d{5}|\\d{9})$|^([a-zA-Z]\\d[a-zA-Z] \\d[a-zA-Z]\\d)$")) { txtZip.BackColor = System.Drawing.Color.Red; valid = false; }

            //validation for email.  Email field is okay to be left blank.
            if (txtEmail.Text == "") { }
            else
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text, "^(?(\"\")(\"\".+?\"\"@)|(([0-9a-zA-Z]((\\.(?!\\.))|[-!#\\$%&'\\*\\+/=\\?\\^`\\{\\}\\|~\\w])*)(?<=[0-9a-zA-Z])@))(?(\\[)(\\[(\\d{1,3}\\.){3}\\d{1,3}\\])|(([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,6}))$"))
                { txtEmail.BackColor = System.Drawing.Color.Red; valid = false; }
            }

            //validation rules for the text fields

            return valid;

        }

        public Boolean checkSocial()
        {
            //initial value is set to false.  It will only become true is there is a duplicate SSN listed under another customer
            Boolean isDuplicate = false;

            try {
                //returns a Boolean value that becomes isDuplicate.
                isDuplicate = myBusinessLayer.isDuplicateSocial(txtSocial.Text, ddlCustomerID.SelectedValue);
                }
            catch (Exception error)
            {
                Warnings.Text = ("Error with SSN Lookup: " + error);
            }

            return isDuplicate;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            clearWarnings();
            //all info needs to be validated before updating the database.
            if (validateRequired())
            {
                int tempPRID = (int)Session["PurchaseRequest"];
                //this is the step where all data is sent to the database.
                try {
                    myBusinessLayer.updateCustomer(Int32.Parse(ddlCustomerID.Text), txtFirst.Text, txtLast.Text, txtAddress1.Text, txtAddress2.Text, txtCity.Text, txtState.Text, txtZip.Text, txtEmail.Text, txtLicense.Text, txtPhone.Text, txtSocial.Text, tempPRID);
                    //lets the user know the data was saved
                    Warnings.Text = "Data Updated Successfully!";
                    //rewrites the dropdown menu with the updated data
                    populateDropDownList(ddlCustomerID.SelectedValue);
                }
                catch (Exception Error)
                { Warnings.Text = "Error on Page: " + Error; }
                
            }
            else
            {
                if (Warnings.Text == "") { Warnings.Text = "Errors on Page:  Data to write to database is incomplete or incorrect."; }
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clearAllEntries();
        }

        public void clearAllEntries()
        {
            //clears red backgrounds and warnings.Text message in footer
            clearWarnings();
            //clears all informaiton in text boxes to blanks
            txtSocial.Text = "";
            txtLicense.Text = "";
            txtFirst.Text = "";
            txtLast.Text = "";
            txtAddress1.Text = "";
            txtAddress2.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtZip.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
        }

        public void populateDropDownList(string sValue)
        {
                                    
            try
            {
                dsCustomer dsPopulate = new dsCustomer();
                string tempPath = Server.MapPath("~/HTVDatabase1.mdb");
                clsDataLayer dataLayerObj = new HTV.clsDataLayer(tempPath);
                dsPopulate = dataLayerObj.dsCustomerDropDown();

                //these codes bind the data from the dataset to the drop down menu
                //the TextField shows the Text in the dropdownlist
                //the ValueField holds the values
                ddlCustomerID.DataSource = dsPopulate;
                ddlCustomerID.DataTextField = "Customer";
                ddlCustomerID.DataValueField = "CustomerID";
                ddlCustomerID.DataBind();

                //ddlCustomerID.Items.FindByValue(storeFieldtemp).Selected = true;
                ddlCustomerID.SelectedValue = sValue;
                //ddlCustomerID.Items.Insert(0, new ListItem("<Select CustomerID", "0"));
            }
            catch(Exception error)
            {
                Warnings.Text = "Critical Error: " + error;
            }
            
            
        }
    }
}
