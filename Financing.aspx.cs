///////////////////////////////////////////////
// File:  Financing.aspx.cs
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
    public partial class WebForm4 : System.Web.UI.Page
    {
        //business object that connects to business functions
        clsBusinessLayer myBusinessLayer = new clsBusinessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            myBusinessLayer = new clsBusinessLayer(Server.MapPath("~/"));
            int tPRO = (int)Session["PurchaseRequest"];
            lblPR.Text = tPRO.ToString();
            if (!IsPostBack)
            {
                updateAllFields();
            }
        }

        public void updateAllFields()
        {
            //define a dataset object for all the different kinds of information this page will need
            dsPurchaseRequest dsFinanceDetails;
            dsVehicle dsVehicleInfo;
            dsTradeIn dsTradeInInfo;

            string tempPath = Server.MapPath("~/HTVDatabase1.mdb");
            clsDataLayer dataLayerObj = new HTV.clsDataLayer(tempPath);

            try
            {
                int tPRO = (int)Session["PurchaseRequest"];
                dsFinanceDetails = dataLayerObj.findPurchaseRequest(tPRO);
                //uses information from the Purchase Request to locate information about Vehicle and TradeIn - similar to a Table JOIN
                dsVehicleInfo = dataLayerObj.findVehicle(dsFinanceDetails.PurchaseRequest[0].vehicleID);
                dsTradeInInfo = dataLayerObj.findTradeIn(dsFinanceDetails.PurchaseRequest[0].tradeinID);

                if (dsFinanceDetails.PurchaseRequest.Rows.Count > 0)
                {

                    double customerOffer=0, licenseFee=0, taxes=0, tradeInValue=0, downPayment = 0, amountToFinance=0;
                    try
                    {
                        //TO DO:  Turn this process into a function in the business layer.
                        //This code calculates the total cost of a vehicle (ie. adds CustomerOffer, LicenseFee, and Taxes)
                        //TO DO:  Include Add-Ons to the Total Cost
                        customerOffer = (double)dsFinanceDetails.PurchaseRequest[0].negotiatedPrice;
                        licenseFee = (double)dsVehicleInfo.Vehicle[0].Licensefee;
                        taxes = (double)dsVehicleInfo.Vehicle[0].taxes;
                        //Missing the cost of the add-ons
                        //TO DO: Calculate the Cost of the Add-Ons in the Business Layer
                        try { lblTotalCost.Text = (customerOffer + licenseFee + taxes).ToString("$#,##0.00"); }
                        catch (Exception error) { lblTotalCost.Text = ""; }



                    }
                    catch(Exception error) { Warnings.Text = "Unable to calculate Total Cost."; }

                    //Post Trade-In Information to the screen
                    try
                    {
                        tradeInValue = (double)dsTradeInInfo.TradeIn[0].amount;
                        try { lblTradeInValue.Text = tradeInValue.ToString("$#,##0.00"); }
                        catch (Exception error) { lblTradeInValue.Text = ""; }
                    }
                    catch (Exception error) { Warnings.Text = "Unable to calculate Trade-In Value."; }

                    //Post information about Finances to screen
                    try
                    {
                        downPayment = Double.Parse(dsFinanceDetails.PurchaseRequest[0].downPayment);

                        try { txtDownPayment.Text = string.Format("{0:C2}",dsFinanceDetails.PurchaseRequest[0].downPayment); }
                        catch (Exception error) { txtDownPayment.Text = ""; }

                        amountToFinance = (customerOffer + licenseFee + taxes) - tradeInValue - downPayment;
                        try { lblAmountToFinance.Text = amountToFinance.ToString("$#,##0.00"); }
                        catch (Exception error) { lblAmountToFinance.Text = ""; }

                        try { lblMonthlyPayment.Text = (myBusinessLayer.calculateMonthlyPayment(dsFinanceDetails.PurchaseRequest[0].ficoScore, amountToFinance, myBusinessLayer.convertLoanLengthToInt(dsFinanceDetails.PurchaseRequest[0].financeLength))); }
                        catch (Exception error) { lblMonthlyPayment.Text = ""; }
                    }
                    catch (Exception error) { Warnings.Text = "Unable to calculate Amount to Finance."; }

                    //post APR information to the screen
                    try { lblInterestRate.Text = myBusinessLayer.calculateAPR(dsFinanceDetails.PurchaseRequest[0].ficoScore); }
                    catch (Exception error) { lblInterestRate.Text = ""; }

                    //post FICO score to screen
                    try { txtFICO.Text = dsFinanceDetails.PurchaseRequest[0].ficoScore.ToString(); }
                    catch (Exception error) { txtFICO.Text = ""; }

                    //post the date the FICO scored was last updated to the screen
                    try { txtFICODate.Text = dsFinanceDetails.PurchaseRequest[0].ficoScoreDate.ToString(); }
                    catch (Exception error) { txtFICODate.Text = ""; }

                    //post the life-of-loan information to the screen
                    try { ddlFinanceLength.Text = dsFinanceDetails.PurchaseRequest[0].financeLength; }
                    catch (Exception error) { ddlFinanceLength.Text = "48-Months"; }
                    
                }
                else
                {
                    Warnings.Text = "Record Not Found.";
                }

            }
            catch (Exception error)
            {
                string message = "Error = ";
                Warnings.Text = message + error.Message;
            }
            
        }

        public void calculateNumberFields()
        {
            //TO DO.
            //-Or-Possible to Erase this function if not needed.
        }

        public void clearWarnings()
        {
            //clears the footer from any warnings.
            Warnings.Text = "";
        }

        public Boolean validated()
        {
            //TO DO: Validation tests on text boxes before they are submitted.
            //NOTE:  This function is essentially bypassed and only returns TRUE.

            return true;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //clear Warnings in the footer
            clearWarnings();
                        
            int tempPRID = (int)Session["PurchaseRequest"];

            if (validated())
            {
                try
                {
                    myBusinessLayer.updateFinancialDetails((Decimal.Parse(txtDownPayment.Text)).ToString(), Int32.Parse(txtFICO.Text), txtFICODate.Text, ddlFinanceLength.Text, tempPRID);
                    Warnings.Text = "Your data saved successfully.";
                    updateAllFields();
                }
                catch (Exception error)
                {
                    //For Troubleshooting:  Warnings.Text = "Error 1: " + (Decimal.Parse(txtDownPayment.Text)).ToString() + " / " + Int32.Parse(txtFICO.Text) + " / " + txtFICODate.Text + " / " + ddlFinanceLength.Text + " / " + tempPRID + " / " + error;
                    Warnings.Text = "Error.  The data did NOT save.";
                }
            }
            else
            {
                Warnings.Text = "Erro:  Check form for invalid information.";
            }
            
        }

        //This code changes the screen immediately to reflect the estimated monthly cost based on with loan-length term is selected.
        protected void ddlFinanceLength_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            int tPRID = (int)Session["PurchaseRequest"];
            int tFICO, tMonths;
            double s;
            tFICO = Int32.Parse(txtFICO.Text);
            s = myBusinessLayer.calculateAmountToFinance(tPRID);
            tMonths = myBusinessLayer.convertLoanLengthToInt(ddlFinanceLength.Text);
            //For Troubleshooting:  Verifying the information that was passing to the business layer in the following calls.
            //For Troubleshooting:  Warnings.Text = tFICO + " / " + s + " / " + tMonths;
            try { lblMonthlyPayment.Text = (myBusinessLayer.calculateMonthlyPayment(tFICO, s, tMonths)); }
            catch (Exception error) { lblMonthlyPayment.Text = "";}
            
        }
    }
}
