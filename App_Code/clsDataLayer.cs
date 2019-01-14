///////////////////////////////////////////////
// File:  clsDataLayer.cs
// Program Name:  HTV_v2.0
// Programmer:  Tyree Pini
// Group:  Team D
// Course:  CIS470 Senior Project
// Date:  19 April 2017
// Website:  http://htvteamd.azurewebsites.net/
///////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace HTV
{
    public class clsDataLayer
    {
        //creates an object name for an OleDbConnection - to interact with a Microsoft Access File
        OleDbConnection dbConnection;

        //default constructor
        public clsDataLayer()
        {

        }

        //constructor that attaches a dataLayer object with the PROVIDER, requires a ServerMappedPath
        public clsDataLayer(string Path)
        {
            //initializes the connection with path to the database
            dbConnection = new OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" + Path);
        }

        //populates a dataset with information from the PurchaseRequest Table
        public dsPurchaseRequest findPurchaseRequest(int purchaseRequestID)
        {
            //the SQL statement filters the search by searching for a specific requestID
            string sqlStmt = "select * from PurchaseRequest where requestID like '" + purchaseRequestID + "'";
            OleDbDataAdapter sqlDataAdapter = new OleDbDataAdapter (sqlStmt, dbConnection);

            //fills the data to a temporary data set
            dsPurchaseRequest tempDataSet = new dsPurchaseRequest();
            sqlDataAdapter.Fill(tempDataSet.PurchaseRequest);

            //returns the resulting data set -- should be only 1 line because the requestID is Primary Key (Unique)
            return tempDataSet;
        }

        //populates a dataset with information from the Employee Table
        public dsEmployee findEmployee(int employeeID)
        {
            //create an SQL query that returns employees with a specific employeeID
            string sqlStmt = "select * from Employee where employeeID like '" + employeeID + "'";
            OleDbDataAdapter sqlDataAdapter = new OleDbDataAdapter(sqlStmt, dbConnection);

            dsEmployee tempDataSet = new dsEmployee();
            sqlDataAdapter.Fill(tempDataSet.Employee);

            //returns the resulting data set -- should be only up to 1 line
            return tempDataSet;
        }

        //populates a dataset with information from the Customer Table
        public dsCustomer findCustomer(int customerID)
        {
            //create an SQL query that returns customers with a specific customerID
            string sqlStmt = "select * from Customer where customerID like '" + customerID + "'";
            OleDbDataAdapter sqlDataAdapter = new OleDbDataAdapter(sqlStmt, dbConnection);

            dsCustomer tempDataSet = new dsCustomer();
            sqlDataAdapter.Fill(tempDataSet.Customer);

            //returns the resulting data set -- should be only up to 1 line
            return tempDataSet;
        }

        //populates a dateset with information from the Vehicle Table
        public dsVehicle findVehicle(int vehicleID)
        {
            //creates an SQL query that returns vehicles with a specific vehicleID
            string sqlStmt = "select * from Vehicle where vehicleID like '" + vehicleID + "'";
            OleDbDataAdapter sqlDataAdapter = new OleDbDataAdapter(sqlStmt, dbConnection);

            dsVehicle tempDataSet = new dsVehicle();
            sqlDataAdapter.Fill(tempDataSet.Vehicle);

            //returns the resulting data set -- should be only up to 1 line
            return tempDataSet;
        }

        //populates a dataset with information from the TradeIn Table
        public dsTradeIn findTradeIn(int tradeInID)
        {
            //create an SQL quety that returns trade-ins with a specific tradeInID
            string sqlStmt = "select * from TradeIn where tradeInID like '" + tradeInID + "'";
            OleDbDataAdapter sqlDataAdapter = new OleDbDataAdapter(sqlStmt, dbConnection);

            dsTradeIn tempDataSet = new dsTradeIn();
            sqlDataAdapter.Fill(tempDataSet.TradeIn);

            //returns the resulting data set -- should be only up to 1 line
            return tempDataSet;
        }

        //populates a dropDownMenu with all Customers from the Customer Table
        public dsCustomer dsCustomerDropDown()
        {
            //this SQL query creates a table called Customer with 2 columns.
            //Column 1: contains the customer's ID
            //Column 2: contains the customer Social Security Number: LastName, First Name
            string sqlStmt = "Select CustomerID, SocialSecurity & ': ' & lastName & ', ' & FirstName AS Customer FROM Customer";
            OleDbDataAdapter sqlDataAdapter = new OleDbDataAdapter(sqlStmt, dbConnection);

            dsCustomer tempDataSet = new dsCustomer();
            sqlDataAdapter.Fill(tempDataSet.Customer);

            //returns the resulting data set -- this list should be expected to have many rows
            return tempDataSet;
        }

        //populates a dropDownMenu with all Employees from the Employee Table
        public dsEmployee dsEmployeeDropDown()
        {
            //this SQL query creates a table called Employee with 2 columns
            //Column 1: contains the Employee's ID
            //Column 2: contains the Employee's ID number: LastName, and FirstName
            string sqlStmt = "Select EmployeeID, EmployeeID & ': ' & lastName & ', ' & FirstName AS Employee FROM Employee";
            OleDbDataAdapter sqlDataAdapter = new OleDbDataAdapter(sqlStmt, dbConnection);

            dsEmployee tempDataSet = new dsEmployee();
            sqlDataAdapter.Fill(tempDataSet.Employee);

            //returns the resulting data set -- this list should be expected to have many rows
            return tempDataSet;
        }

        //populates a dropDownMenu with all Purchase Requests from the PurchaseRequest Table
        public dsPurchaseRequest dsPurchaseRequestDropDown()
        {
            //This SQL statement only finds REQUESTIDs for all Purchase Request
            //(Future TO DO): Include more information in the DropDownMenu so it makes it easier to lookup a customer
            //(Future TO DO): Only include Purchase Requests that have not been finalized/Sale Completed
            string sqlStmt = "Select requestID FROM PurchaseRequest";
            OleDbDataAdapter sqlDataAdapter = new OleDbDataAdapter(sqlStmt, dbConnection);

            dsPurchaseRequest tempDataSet = new dsPurchaseRequest();
            sqlDataAdapter.Fill(tempDataSet.PurchaseRequest);

            //returns a resulting data set with only one colum -- this list should be expected to have multiple rows
            return tempDataSet;
        }

        //populates a dropDownMenu with all Vehicles for sale from the Vehicles Table
        public dsVehicle dsVehicleDropDown()
        {
            //This SQL query creates a dataset with two columns
            //Column 1:  Vehicle ID
            //Column 2:  Vehicle ID: VIN
            //(Future TO DO): Remove all vehicles that have sold
            //(Future TO DO): Include new vehicle Year/Make/Model Information for the dropDownMenu
            string sqlStmt = "Select vehicleID, vehicleID & ': ' & vin AS Vehicle FROM Vehicle";
            OleDbDataAdapter sqlDataAdapter = new OleDbDataAdapter(sqlStmt, dbConnection);

            dsVehicle tempDataSet = new dsVehicle();
            sqlDataAdapter.Fill(tempDataSet.Vehicle);

            //returns as resulting data set -- should expect multiple rows
            return tempDataSet;
        }


        //the data layer side that searches for duplicate Social Security Numbers
        public dsCustomer dsCheckForDuplicateSocials(string tSSN, string tCID)
        {
            //This SQL builds a data set with all similar SSN to the current customer selected
            //However, the data set will exclude the current customer.  Any SSN that appears on this list IS a duplicate
            string sqlStmt = "Select * FROM Customer WHERE socialSecurity like '" + tSSN + "' AND NOT customerID like '" + tCID + "'";
            OleDbDataAdapter sqlDataAdapter = new OleDbDataAdapter(sqlStmt, dbConnection);

            dsCustomer tempDataSet = new dsCustomer();
            sqlDataAdapter.Fill(tempDataSet.Customer);

            //if this returns any rows, that means another customer already uses that Social Security Number
            return tempDataSet;
        }

        //The Data Layer function to update the employee attached to the Purchase Request
        public void updateEmployee(int employeeID, int purchaseRequestID)
        {
            //open the connection to the database
            dbConnection.Open();

            //build the sql statement to execute
            string sqlStmt = "UPDATE PurchaseRequest SET EmployeeID = @eid WHERE (PurchaseRequest.requestID = @prid)";

            OleDbCommand dbCommand = new OleDbCommand(sqlStmt, dbConnection);

            //parse the sql statement with the data passed to this function
            OleDbParameter param = new OleDbParameter("@eid", employeeID);
            dbCommand.Parameters.Add(param);
            dbCommand.Parameters.Add(new OleDbParameter("@prid", purchaseRequestID));
            
            //execute the UPDATE statement/command
            dbCommand.ExecuteNonQuery();

            //clost the connection
            dbConnection.Close();
        }

        public void updateVehicle(int tempVID, int tempPRID)
        {
            //open the connection to the database
            dbConnection.Open();

            //build the sql statement to execute
            string sqlStmt = "UPDATE PurchaseRequest SET VehicleID = @vid WHERE (PurchaseRequest.requestID = @prid)";

            OleDbCommand dbCommand = new OleDbCommand(sqlStmt, dbConnection);

            //parse the sql statement with the data passed to this function
            OleDbParameter param = new OleDbParameter("@vid", tempVID);
            dbCommand.Parameters.Add(param);
            dbCommand.Parameters.Add(new OleDbParameter("@prid", tempPRID));

            //execute the UPDATE statement/command
            dbCommand.ExecuteNonQuery();

            //close the connection
            dbConnection.Close();
        }

        public void updateVehicleNegotiatedPrice (string tempPrice, int tempPRID)
        {
            //open the connection to the database
            dbConnection.Open();

            //build the sql statement to execute
            string sqlStmt = "UPDATE PurchaseRequest SET negotiatedPrice = @vPrice WHERE (PurchaseRequest.requestID = @prid)";

            OleDbCommand dbCommand = new OleDbCommand(sqlStmt, dbConnection);
            
            //parse the sql statement with the data passed to this function
            OleDbParameter param = new OleDbParameter("@vPrice", tempPrice);
            dbCommand.Parameters.Add(param);
            dbCommand.Parameters.Add(new OleDbParameter("@prid", tempPRID));

            //execute the UPDATE statement/command
            dbCommand.ExecuteNonQuery();

            //close the connection
            dbConnection.Close();
        }

        public void updateCustomer(int customerID, string fName, string lName, string a1, string a2, string city, string state, string zip, string email, string license, string phone, string social)
        {
            //open the connection to the database
            dbConnection.Open();

            //build the sql statement to execute
            string sqlStmt = "UPDATE Customer SET firstName = @fName, " +
                "lastName = @lName, " +
                "addressLine1 = @a1, " +
                "addressLine2 = @a2, " +
                "city = @city, " +
                "state = @state, " +
                "zipCode = @zip, " +
                "email = @email, " +
                "driversLicense = @license, " +
                "phoneNumber = @phone, " +
                "socialSecurity = @social " +
                "WHERE (Customer.customerID = @customerID)";

            OleDbCommand dbCommand = new OleDbCommand(sqlStmt, dbConnection);

            //parse the sql statement with the data passed to this function
            OleDbParameter param = new OleDbParameter("@fName", fName);
            dbCommand.Parameters.Add(param);
            dbCommand.Parameters.Add(new OleDbParameter("@lName", lName));
            dbCommand.Parameters.Add(new OleDbParameter("@a1", a1));
            dbCommand.Parameters.Add(new OleDbParameter("@a2", a2));
            dbCommand.Parameters.Add(new OleDbParameter("@city", city));
            dbCommand.Parameters.Add(new OleDbParameter("@state", state));
            dbCommand.Parameters.Add(new OleDbParameter("@zip", zip));
            dbCommand.Parameters.Add(new OleDbParameter("@email", email));
            dbCommand.Parameters.Add(new OleDbParameter("@license", license));
            dbCommand.Parameters.Add(new OleDbParameter("@phone", phone));
            dbCommand.Parameters.Add(new OleDbParameter("@social", social));
            dbCommand.Parameters.Add(new OleDbParameter("@customerID", customerID));
            
            //execute the UPDATE statement/command
            dbCommand.ExecuteNonQuery();

            //clost the connection
            dbConnection.Close();

        }

        public void updateFinancialDetails(string downPayment, int ficoScore, string ficoDate, string loanLength, int PRID)
        {
            //open the connection to the database
            dbConnection.Open();

            //build the sql statement to execute
            string sqlStmt = "UPDATE PurchaseRequest SET downPayment = @downPayment, " +
                "ficoScore = @ficoScore, " +
                "ficoScoreDate = @ficoDate, " +
                "financeLength = @loanLength " +
                "WHERE (PurchaseRequest.requestID = @PRID)";

            OleDbCommand dbCommand = new OleDbCommand(sqlStmt, dbConnection);

            //parse the sql statement with the data passed to this function
            OleDbParameter param = new OleDbParameter("@downPayment", downPayment);
            dbCommand.Parameters.Add(param);
            dbCommand.Parameters.Add(new OleDbParameter("@ficoScore", ficoScore));
            dbCommand.Parameters.Add(new OleDbParameter("@ficoDate", ficoDate));
            dbCommand.Parameters.Add(new OleDbParameter("@loanLength", loanLength));
            dbCommand.Parameters.Add(new OleDbParameter("@PRID", PRID));

            //execute the UPDATE statement/command
            dbCommand.ExecuteNonQuery();

            //clost the connection
            dbConnection.Close();
        }

        public void attachCustomerToPurchaseRequest (int customerID, int purchaseRequestID)
        {
            //open the connection to the database
            dbConnection.Open();

            //build the sql statement to execute
            string sqlStmt = "UPDATE PurchaseRequest SET CustomerID = @cid WHERE (PurchaseRequest.requestID = @prid)";

            OleDbCommand dbCommand = new OleDbCommand(sqlStmt, dbConnection);

            //parse the sql statement with the data passed to this function
            OleDbParameter param = new OleDbParameter("@cid", customerID);
            dbCommand.Parameters.Add(param);
            dbCommand.Parameters.Add(new OleDbParameter("@prid", purchaseRequestID));

            //execute the UPDATE statement/command
            dbCommand.ExecuteNonQuery();

            //clost the connection
            dbConnection.Close();
        }

        public bool validateEmployee(string employeeName, int employeeID)
        {
            //open the connection to the database
            dbConnection.Open();

            //create the sql command
            string sqlStmt = "Select * from Employee WHERE firstName = @fName AND employeeID = @employeeID";

            //create a command object
            OleDbCommand dbCommand = new OleDbCommand(sqlStmt, dbConnection);

            //parse the statement with actuall data passed to this function
            dbCommand.Parameters.Add(new OleDbParameter("@fName", employeeName));
            dbCommand.Parameters.Add(new OleDbParameter("@employeeID", employeeID));

            //execute the parsed sql statement
            OleDbDataReader dr = dbCommand.ExecuteReader();

            //assigns the result TRUE or FALSE to the Boolean isValid
            Boolean isValid = dr.Read();

            dbConnection.Close();

            return isValid;
        }

        public void createCustomer()
        {
            //open a connection to the database
            dbConnection.Open();

            //start an SQL statement string
            //string sqlStmt = "INSERT INTO Customer VALUES (NULL, 'Enter First Name', 'Enter Last Name', 'Enter Address', NULL, 'Enter City', 'ST', 1, 'Enter Email Address', 'Drivers License and State', 'Enter Phone Number', 'Enter SSN')";
            //trying a smaller sql statement.  I keep getting throw errors with the line above.
            string sqlStmt = "INSERT INTO Customer (socialSecurity) VALUES ('000-00-0000')";

            //create a command object
            OleDbCommand dbCommand = new OleDbCommand(sqlStmt, dbConnection);

            //nothing to parse

            //execute the command
            dbCommand.ExecuteNonQuery();

            //close the connection
            dbConnection.Close();
        }
    }
}
