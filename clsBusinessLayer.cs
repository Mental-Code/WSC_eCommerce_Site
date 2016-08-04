using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for clsBusinessLayer
/// </summary>
public class clsBusinessLayer
{
    // Declare string variable dataPath
    string dataPath;

    // Create an instance of clsDataLayer
    clsDataLayer myDataLayer;

    public clsBusinessLayer(string serverMappedPath)
    {
        // Populate declared variables
        dataPath = serverMappedPath;
        myDataLayer = new clsDataLayer(dataPath + "Accounts.mdb");
    }

    // tblCustomers Related
    public string UpdateCustomer(string userID, string firstName, string lastName, string email, string line1, string line2, string city, string state, string phoneNumber, int customerID)
    {
        // 
        string resultMessage = "Customer Updated Successfully!";

        // 
        try
        {
            myDataLayer.UpdateCustomer(userID, firstName, lastName, email, line1, line2, city, state, phoneNumber, customerID);
        }
        catch (Exception error)
        {
            resultMessage = "Error updating customer, please check form data.";
            resultMessage = resultMessage + error.Message;
        }

        return resultMessage;
    }

    public string InsertCustomer(string userID, string firstName, string lastName, string email, string line1, string line2, string city, string state, string phoneNumber, int customerID)
    {
        // 
        string resultMessage = "Customer Added Successfully!";

        // 
        try
        {
            // 
            myDataLayer.InsertCustomer(userID, firstName, lastName, email, line1, line2, city, state, phoneNumber, customerID);
        }
        catch (Exception error)
        {
            resultMessage = "Error adding customer, please check form data.";
            resultMessage = resultMessage + error.Message;
        }

        return resultMessage;
    }

    public string DeleteCustomer(int customerID)
    {
        // 
        string resultMessage = "Customer Deleted Successfully!";

        // 
        try
        {
            // 
            myDataLayer.DeleteCustomer(customerID);
        }
        catch (Exception error)
        {
            resultMessage = "Error deleting customer, please check form data.";
            resultMessage = resultMessage + error.Message;
        }

        return resultMessage;
    }

    public dsAccounts SelectAllCustomers()
    {
        return myDataLayer.GetAllCustomers();
    }

    public dsAccounts FindCustomer(string Search)
    {
        // Creates new database for use in click event
        dsAccounts dsFoundCustomer = myDataLayer.FindCustomer(Search);

        if (dsFoundCustomer.tblCustomers.Rows.Count > 0)
        {
            // Locates user with matching Username and determines if fields are null or not
            System.Data.DataRow customerRecord = dsFoundCustomer.tblCustomers.Rows[0];

            if (customerRecord["UserID"] == DBNull.Value)
                customerRecord["UserID"] = string.Empty;

            if (customerRecord["FirstName"] == DBNull.Value)
                customerRecord["FirstName"] = string.Empty;

            if (customerRecord["LastName"] == DBNull.Value)
                customerRecord["LastName"] = string.Empty;

            if (customerRecord["Email"] == DBNull.Value)
                customerRecord["Email"] = string.Empty;

            if (customerRecord["Address1"] == DBNull.Value)
                customerRecord["Address1"] = string.Empty;

            if (customerRecord["Address2"] == DBNull.Value)
                customerRecord["Address2"] = string.Empty;

            if (customerRecord["City"] == DBNull.Value)
                customerRecord["City"] = string.Empty;

            if (customerRecord["State"] == DBNull.Value)
                customerRecord["State"] = string.Empty;

            if (customerRecord["PhoneNumber"] == DBNull.Value)
                customerRecord["PhoneNumber"] = string.Empty;
        }

        return dsFoundCustomer;
    }

    
    // tblUser Related
    public string InsertUser(string userID, string password, int ID)
    {
        // 
        string resultMessage = "User Added Successfully!";

        // 
        try
        {
            myDataLayer.InsertUser(userID, password, ID);
        }
        catch (Exception error)
        {
            resultMessage = "Error adding user, please check form data.";
            resultMessage = resultMessage + error.Message;
        }

        return resultMessage;
    }

    public string DeleteUser(int ID)
    {
        // 
        string resultMessage = "User Deleted Successfully!";

        // 
        try
        {
            // 
            myDataLayer.DeleteUser(ID);
        }
        catch (Exception error)
        {
            resultMessage = "Error removing user, please check form data.";
            resultMessage = resultMessage + error.Message;
        }

        return resultMessage;
    }

    public dsAccounts SelectAllUsers()
    {
        return myDataLayer.GetAllUsers();
    }

    public dsAccounts FindUser(string Username)
    {
        // Creates new database for use in click event
        dsAccounts dsFoundUser = myDataLayer.FindUser(Username);

        if (dsFoundUser.tblOrders.Rows.Count > 0)
        {
            // Locates user with matching ID and determines if fields are null or not
            System.Data.DataRow userRecord = dsFoundUser.tblUsers.Rows[0];

            if (userRecord["UserID"] == DBNull.Value)
                userRecord["UserID"] = string.Empty;

            if (userRecord["Password"] == DBNull.Value)
                userRecord["Password"] = string.Empty;
        }

        return dsFoundUser;
    }


    // tblOrders Related
    public dsAccounts FindOrders(string Username)
    {
        // Creates new database for use in click event
        dsAccounts dsFoundOrder = myDataLayer.FindOrders(Username);

        if (dsFoundOrder.tblOrders.Rows.Count > 0)
        {
            // Locates user with matching ID and determines if fields are null or not
            System.Data.DataRow orderRecord = dsFoundOrder.tblOrders.Rows[0];

            if (orderRecord["Customer"] == DBNull.Value)
                orderRecord["Customer"] = string.Empty;

            if (orderRecord["JobType"] == DBNull.Value)
                orderRecord["JobType"] = string.Empty;

            if (orderRecord["Media"] == DBNull.Value)
                orderRecord["Media"] = string.Empty;

            if (orderRecord["Message"] == DBNull.Value)
                orderRecord["Message"] = string.Empty;
        }

        return dsFoundOrder;
    }

    public string UpdateOrders(string customer, string jobType, string mediaType, string message, string approval, string completion, string reason, string completionDate, string paymentOption, string itemInStock, int orderNumber)
    {
        // 
        string resultMessage = "Order Updated Successfully!";

        // 
        try
        {
            myDataLayer.UpdateOrders(customer, jobType, mediaType, message, approval, completion, reason, completionDate, paymentOption, itemInStock, orderNumber);
        }
        catch (Exception error)
        {
            resultMessage = "Error updating order, please check form data.";
            resultMessage = resultMessage + error.Message;
        }

        return resultMessage;
    }

    public string InsertOrders(string customer, string jobType, string mediaType, string message, string approval, string completion, string reason, string completionDate, string paymentOption, string itemInStock, int orderNumber)
    {
        // 
        string resultMessage = "Order Added Successfully!";

        // 
        try
        {
            // 
            myDataLayer.InsertOrders(customer, jobType, mediaType, message, approval, completion, reason, completionDate, paymentOption, itemInStock, orderNumber);
        }
        catch (Exception error)
        {
            resultMessage = "Error adding order, please check form data.";
            resultMessage = resultMessage + error.Message;
        }

        return resultMessage;
    }

    public string DeleteOrders(int orderNumber)
    {
        // 
        string resultMessage = "Order Deleted Successfully!";

        // 
        try
        {
            // 
            myDataLayer.DeleteOrders(orderNumber);
        }
        catch (Exception error)
        {
            resultMessage = "Error deleting order, please check form data.";
            resultMessage = resultMessage + error.Message;
        }

        return resultMessage;
    }


    // tblCart Related
    public string UpdateCart(string customer, string job, string media, string message, int orderNumber)
    {
        // 
        string resultMessage = "Cart Updated Successfully!";

        // 
        try
        {
            myDataLayer.UpdateCart(customer, job, media, message, orderNumber);
        }
        catch (Exception error)
        {
            resultMessage = "Error updating cart, please check form data.";
            resultMessage = resultMessage + error.Message;
        }

        return resultMessage;
    }

    public string AddToCart(string customer, string jobType, string media, string message, int orderNumber)
    {
        // 
        string resultMessage = "Cart Item Added Successfully!";

        // 
        try
        {
            // 
            myDataLayer.AddToCart(customer, jobType, media, message, orderNumber);
        }
        catch (Exception error)
        {
            resultMessage = "Error adding cart item, please check form data.";
            resultMessage = resultMessage + error.Message;
        }

        return resultMessage;
    }

    public string DeleteCart(int orderNumber)
    {
        // 
        string resultMessage = "Cart Emptied Successfully!";

        // 
        try
        {
            // 
            myDataLayer.DeleteCart(orderNumber);
        }
        catch (Exception error)
        {
            resultMessage = "Error emptying cart, please check form data.";
            resultMessage = resultMessage + error.Message;
        }

        return resultMessage;
    }

    public dsAccounts FindOrder(string Search)
    {
        // Creates new database for use in click event
        dsAccounts dsFoundOrder = myDataLayer.FindOrder(Search);

        if (dsFoundOrder.tblCart.Rows.Count > 0)
        {
            // Locates user with matching LastName and determines if fields are null or not
            System.Data.DataRow cartRecord = dsFoundOrder.tblCart.Rows[0];

            if (cartRecord["Customer"] == DBNull.Value)
                cartRecord["Customer"] = string.Empty;

            if (cartRecord["JobType"] == DBNull.Value)
                cartRecord["JobType"] = string.Empty;

            if (cartRecord["Media"] == DBNull.Value)
                cartRecord["Media"] = string.Empty;

            if (cartRecord["Message"] == DBNull.Value)
                cartRecord["Message"] = string.Empty;
        }

        return dsFoundOrder;
    }

    public dsAccounts FillCart(string Search)
    {
        // Creates new database for use in click event
        dsAccounts dsCartFill = myDataLayer.FillCart(Search);

        if (dsCartFill.tblCart.Rows.Count > 0)
        {
            // Locates user with matching LastName and determines if fields are null or not
            System.Data.DataRow cartRecord = dsCartFill.tblCart.Rows[0];

            if (cartRecord["Customer"] == DBNull.Value)
                cartRecord["Customer"] = string.Empty;

            if (cartRecord["JobType"] == DBNull.Value)
                cartRecord["JobType"] = string.Empty;

            if (cartRecord["Media"] == DBNull.Value)
                cartRecord["Media"] = string.Empty;

            if (cartRecord["Message"] == DBNull.Value)
                cartRecord["Message"] = string.Empty;
        }

        return dsCartFill;
    }

    public dsAccounts SelectAllCarts()
    {
        return myDataLayer.GetAllOrderInCart();
    }


    // tblCreditInformation Related
    public string UpdateCreditInformation(string customer, string ccNumber, string ccType, int ID)
    {
        // 
        string resultMessage = "Credit Information Updated Successfully!";

        // 
        try
        {
            myDataLayer.UpdateCreditInformation(customer, ccNumber, ccType, ID);
        }
        catch (Exception error)
        {
            resultMessage = "Error updating credit information, please check form data.";
            resultMessage = resultMessage + error.Message;
        }

        return resultMessage;
    }

    public string InsertCreditInformation(string customer, string ccNumber, string ccType, int ID)
    {
        // 
        string resultMessage = "Credit Information Added Successfully!";

        // 
        try
        {
            // 
            myDataLayer.InsertCreditInformation(customer, ccNumber, ccType, ID);
        }
        catch (Exception error)
        {
            resultMessage = "Error updating credit information, please check form data.";
            resultMessage = resultMessage + error.Message;
        }

        return resultMessage;
    }

    public string DeleteCreditInformation(int ID)
    {
        // 
        string resultMessage = "Credit Information Deleted Successfully!";

        // 
        try
        {
            // 
            myDataLayer.DeleteCreditInformation(ID);
        }
        catch (Exception error)
        {
            resultMessage = "Error deleting credit information cart, please check form data.";
            resultMessage = resultMessage + error.Message;
        }

        return resultMessage;
    }

    public dsAccounts FindCreditInformation(string Search)
    {
        // Creates new database for use in click event
        dsAccounts dsFoundCreditInformation = myDataLayer.FindCreditInformation(Search);

        if (dsFoundCreditInformation.tblCreditInformation.Rows.Count > 0)
        {
            // Locates user with matching LastName and determines if fields are null or not
            System.Data.DataRow creditInformationRecord = dsFoundCreditInformation.tblCreditInformation.Rows[0];

            if (creditInformationRecord["Customer"] == DBNull.Value)
                creditInformationRecord["Customer"] = string.Empty;

            if (creditInformationRecord["CCNumber"] == DBNull.Value)
                creditInformationRecord["CCNumber"] = string.Empty;

            if (creditInformationRecord["CCType"] == DBNull.Value)
                creditInformationRecord["CCType"] = string.Empty;
        }

        return dsFoundCreditInformation;
    }

    public dsAccounts FillCreditInformation(string Search)
    {
        // Creates new database for use in click event
        dsAccounts dsCreditInformationFill = myDataLayer.FillCreditInformation(Search);

        if (dsCreditInformationFill.tblCreditInformation.Rows.Count > 0)
        {
            // Locates user with matching identification and determines if fields are null or not
            System.Data.DataRow creditRecord = dsCreditInformationFill.tblCreditInformation.Rows[0];

            if (creditRecord["Customer"] == DBNull.Value)
                creditRecord["Customer"] = string.Empty;

            if (creditRecord["JobType"] == DBNull.Value)
                creditRecord["JobType"] = string.Empty;

            if (creditRecord["Media"] == DBNull.Value)
                creditRecord["Media"] = string.Empty;

            if (creditRecord["Message"] == DBNull.Value)
                creditRecord["Message"] = string.Empty;
        }

        return dsCreditInformationFill;
    }

    public dsAccounts GetAllUserCreditInformation()
    {
        return myDataLayer.GetAllUserCreditInformation();
    }


    public DataSet GetCustomerXMLFile()
    {
        // Create new DataSet
        DataSet xmlDataSet = new DataSet();

        try
        {
            // Read data from XML file
            xmlDataSet.ReadXml(dataPath + "customers.xml");
        }

        catch (System.IO.FileNotFoundException error)
        {
            // Write appropriate data in order to read it
            dsAccounts customerListing = myDataLayer.GetAllCustomers();
            customerListing.tblCustomers.WriteXml(dataPath + "customers.xml");
            xmlDataSet.ReadXml(dataPath + "customers.xml");
        }

        // Return new data
        return xmlDataSet;
    }

    public DataSet WriteCustomerXMLFile(System.Web.Caching.Cache appCache)
    {
        // Add data
        DataSet xmlDataSet = (DataSet)appCache["CustomerDataSet"];

        // Write data
        xmlDataSet.WriteXml(dataPath + "customers.xml");

        // Return new data
        return xmlDataSet;
    }

    public bool CheckUserCredentials(System.Web.SessionState.HttpSessionState currentSession, string username, string password)
    {
        // 
        bool isValid = myDataLayer.ValidateUser(username, password);

        // 
        currentSession["LockedSession"] = false;

        // 
        int totalAttempts = Convert.ToInt32(currentSession["AttemptCount"]) + 1;
        currentSession["AttemptCount"] = totalAttempts;

        // 
        int userAttempts = Convert.ToInt32(currentSession[username]) + 1;
        currentSession[username] = userAttempts;

        // 
        if ( (userAttempts >= 9) || (totalAttempts >= 12) )
        {
            currentSession["LockedSession"] = true;
            myDataLayer.LockUserAccount(username);
        }
        return isValid;
    }

    public bool CheckUsername(System.Web.SessionState.HttpSessionState currentSession, string username)
    {
        bool isMatching = myDataLayer.CheckUsername(username);
        return isMatching;
    }

}