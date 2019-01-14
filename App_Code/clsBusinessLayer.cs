///////////////////////////////////////////////
// File:  clsBusinessLayer.cs
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
using HTV;

namespace HTV
{
    public class clsBusinessLayer
    {
        //string is used to create the map path to the database
        string dataPath;
        //creates an object to access all methods in the data layer
        clsDataLayer myDataLayer;
        
        //default constructor
        public clsBusinessLayer()
        {

        }

        //this is a constructor that attaches the datapath the clsBusinessObjects when they are instantiated with a serverMappedPath
        public clsBusinessLayer(string serverMappedPath)
        {
            //the path to the access file NAME.mdb will confingured here as a method
            dataPath = serverMappedPath;
            myDataLayer = new clsDataLayer(dataPath + "HTVDatabase1.mdb");
        }

        //this method to be used at log-in to validate log-in credentials
        public bool checkUserCredentials(System.Web.SessionState.HttpSessionState currentSession, string employeeName, int employeeID)
        {
            //this statement clears any previous session data for CurrentUser.
            currentSession["CurrentUser"] = "Nobody";

            //if log in validates, then the employeeName will be written as session data
            if (myDataLayer.validateEmployee(employeeName, employeeID))
            {
                currentSession["CurrentUser"] = employeeName;
                return true;
            }
            else
            {
                return false;
            }

        }

        //this method connects the business layer to the data layer in order to INSERT a new customer into the database.
        public void addNewCustomer()
        {
            myDataLayer.createCustomer();
        }

        //this method connects the business layer to the data layer to verify that no Social Security Numbers will be duplicated.
        public Boolean isDuplicateSocial(string tSSN, string tCID)
        {
            //this will fill a dataset with customer information
            dsCustomer tempDataSet = myDataLayer.dsCheckForDuplicateSocials(tSSN, tCID);

            //if the SSN is already in use, the tempDataSet will have entries, otherwise, this method will return false.
            if (tempDataSet.Customer.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //this method returns the employeeID number by passing a purchase request REQUESTID number
        public int getEmployeeID(int tPRID)
        {
            int tEID = 0;
            dsPurchaseRequest tempPRDataSet = myDataLayer.findPurchaseRequest(tPRID);
            tEID = tempPRDataSet.PurchaseRequest[0].employeeID;
            return tEID;
        }

        //this method returns the customerID number by passing a purchase request REQUESTID number
        public int getCustomerID(int tPRID)
        {
            int tCID = 0;
            dsPurchaseRequest tempPRDataSet = myDataLayer.findPurchaseRequest(tPRID);
            tCID = tempPRDataSet.PurchaseRequest[0].customerID;
            return tCID;
        }

        //this method returns the vehicleID number by passing a purchase requestion REQUESTID number
        public int getVehicleID(int tPRID)
        {
            int tVID = 0;
            dsPurchaseRequest tempPRDataSet = myDataLayer.findPurchaseRequest(tPRID);
            tVID = tempPRDataSet.PurchaseRequest[0].vehicleID;
            return tVID;
        }

        //this method connects the business layer to the data layer to update user input as Customer Information in the Customer table
        public void updateCustomer(int customerID, string fName, string lName, string a1, string a2, string city, string state, string zip, string email, string license, string phone, string social, int tPRID)
        {
            //this line updates the information for CustomerID in the customer table
            myDataLayer.updateCustomer(customerID, fName, lName, a1, a2, city, state, zip, email, license, phone, social);
            //this line updates the CustomerID on the Purchase Request as the purchaser
            myDataLayer.attachCustomerToPurchaseRequest(customerID, tPRID);
        }

        //this method connects the business layer to the data layer to update user input as the financial details in the PurchaseRequest table
        public void updateFinancialDetails(string downPayment, int FICO, string FICODate, string loanLength, int PRID)
        {
            myDataLayer.updateFinancialDetails(downPayment, FICO, FICODate, loanLength, PRID);
        }

        //this method connects the business layer to the data layer to update the customer's offer price
        public void updateVehicleNegotiatedPrice(string vPrice, int PRID)
        {
            myDataLayer.updateVehicleNegotiatedPrice(vPrice, PRID);
        }

        //calculate an interest rate based on the customer's fico score
        //Note:  A score of less than 600 returns, "Financing Not Available."
        public string calculateAPR(int fico)
        {
            string formatRate = "Financing Not Available.";
            if (fico > 600 ) { formatRate = "4.00% APR"; }
            if (fico > 800 ) { formatRate = "3.00% APR"; }
            return formatRate;
            
        }

        //this method accepts a PurchaseRequest REQUESTID and returns how much the customer would need to finance.
        //NOTE:  This method does not currently include Add-On Options (Future TO DO)
        public double calculateAmountToFinance(int tempPRID)
        {

            //create variables
            double customerOffer = 0, licenseFee = 0, taxes = 0, addOnCosts = 0, tradeInValue = 0, downPayment = 0, amountToFinance = 0;
            //creates data sets for all the information that will be needed
            dsPurchaseRequest dsPRInfo;
            dsVehicle dsVInfo;
            dsTradeIn dsTInfo;

            //use the dataLayer object to use private methods in the data layer
            dsPRInfo = myDataLayer.findPurchaseRequest(tempPRID);
            //Important:  Use the Purchase Request ID to locate with which vehicle to read -- acts similar to a table join
            dsVInfo = myDataLayer.findVehicle(dsPRInfo.PurchaseRequest[0].vehicleID);
            dsTInfo = myDataLayer.findTradeIn(dsPRInfo.PurchaseRequest[0].tradeinID);

            //casts a currency data field to a double variable
            customerOffer = (double)dsPRInfo.PurchaseRequest[0].negotiatedPrice;
            licenseFee = (double)dsVInfo.Vehicle[0].Licensefee;
            taxes = (double)dsVInfo.Vehicle[0].taxes;
                //Missing the cost of the add-ons
                //TO DO: Calculate the Cost of the Add-Ons
            tradeInValue = (double)dsTInfo.TradeIn[0].amount;
            downPayment = Double.Parse(dsPRInfo.PurchaseRequest[0].downPayment);
            //uses all previous sources to calculate the total amountToFinance
            amountToFinance = (customerOffer + licenseFee + taxes + addOnCosts) - tradeInValue - downPayment;

            return amountToFinance;
        }

        //returns a string that indicates how much the estimated monthly payment would be, based on a simple interest formula.
        //NOTE:  If the FICO is less than 600, than the string will return "Not Availalbe"
        public string calculateMonthlyPayment(int fico, double amount, int months)
        {
            string formatReturn = "Not Available.";
            if (fico > 600 ) { formatReturn = "$" + (Math.Round((amount * ((0.04 * (months/12))+1)) / months)).ToString("#,##0.00"); }
            if (fico > 800 ) { formatReturn = "$" + (Math.Round((amount * ((0.03 * (months/12))+1)) / months)).ToString("#,##0.00"); }
            return formatReturn;
        }

        //exchanges the string financeLength from the Purchase Request Data Tables for an integer
        //NOTE: default value will be 48
        public int convertLoanLengthToInt(string tS)
        {
            if (tS.Equals("12-Months")) return 12;
            if (tS.Equals("24-Months")) return 24;
            if (tS.Equals("36-Months")) return 36;
            if (tS.Equals("48-Months")) return 48;
            return 48;
        }

        //this methods returns the Commission Rate string based on the employee's integer commissionRate
        public string calculateCommissionRate(int tRate)
        {
            string formatedRate = "Four Percent (4.00%)";
            if (tRate == 7) { formatedRate = "Seven Percent (7.00%)"; }
            return formatedRate;
        }

        //this method updates the PurchaseRequest field to match the selected Employee with id eEID
        public void attachEmployeeToPurchaseRequest (int tEID, int tPRID)
        {
            //this method will update the employee ID number to the - Current Session - Purchase Request
            myDataLayer.updateEmployee(tEID, tPRID);            
        }

        public void attachVehicleToPurchaseRequest (int tVID, int tPRID)
        {
            //this method will update the vehicle ID number to the current Purchase Request - Session Data
            myDataLayer.updateVehicle(tVID, tPRID);
        }

    }
}
