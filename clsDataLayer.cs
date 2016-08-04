 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Net;
using System.Data;

public class clsDataLayer
{
    OleDbConnection dbConnection;
    
    public clsDataLayer(string Path)
    {
        dbConnection = new OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" + Path);
    }

    // FindCustomer Method
    public dsAccounts FindCustomer(string Search)
    {
        // Pulls Username data from database for use
        string sqlStmt = "SELECT * from tblCustomers where UserID like '" + Search + "'";
        OleDbDataAdapter sqlDataAdapter = new OleDbDataAdapter(sqlStmt, dbConnection);

        // Creates and fills new stored data info from tblCustomers
        dsAccounts myStoreDataSet = new dsAccounts();
        sqlDataAdapter.Fill(myStoreDataSet.tblCustomers);

        // Return new data
        return myStoreDataSet;
    }

    // Update new user data to the database
    public void UpdateCustomer(string userID, string firstName, string lastName, string email, string address1, string address2, string city, string state, string phoneNumber, int customerID)
    {
        // Opens data connection
        dbConnection.Open();

        // Create a string of new data
        string sqlStmt = "UPDATE tblCustomers SET UserID = @userID, " +
                                            "FirstName = @first, " +
                                            "LastName = @last, " +
                                            "Email = @email, " +
                                            "Address1 = @address1, " +
                                            "Address2 = @address2, " +
                                            "City = @city, " +
                                            "State = @state, " +
                                            "PhoneNumber = @phone " +
                                            "WHERE (tblCustomers.CustomerID = @id)";
        // Create new instance
        OleDbCommand dbCommand = new OleDbCommand(sqlStmt, dbConnection);

        // Add new parameters to update to the database
        OleDbParameter param = new OleDbParameter("@userID", userID);
        dbCommand.Parameters.Add(param);

        dbCommand.Parameters.Add(new OleDbParameter("@first", firstName));
        dbCommand.Parameters.Add(new OleDbParameter("@last", lastName));
        dbCommand.Parameters.Add(new OleDbParameter("@email", email));
        dbCommand.Parameters.Add(new OleDbParameter("@address1", address1));
        dbCommand.Parameters.Add(new OleDbParameter("@address2", address2));
        dbCommand.Parameters.Add(new OleDbParameter("@city", city));
        dbCommand.Parameters.Add(new OleDbParameter("@state", state));
        dbCommand.Parameters.Add(new OleDbParameter("@phone", phoneNumber));
        dbCommand.Parameters.Add(new OleDbParameter("@id", customerID));

        // Commit changes
        dbCommand.ExecuteNonQuery();

        // Close connection
        dbConnection.Close();
    }

    // Adds new user and their data to the database
    public void InsertCustomer(string userID, string firstName, string lastName, string email, string address1, string address2, string city, string state, string phoneNumber, int customerID)
    {
        // Opens data connection
        dbConnection.Open();

        // Create a string of new data
        string sqlStmt = "INSERT INTO tblCustomers(userID, firstName, lastName, email, address1, address2, city, state, phoneNumber) ";
                sqlStmt += "VALUES (@userID, @first, @last, @email, @address1, @address2, @city, @state, @phone)";

        // Create new instance
        OleDbCommand dbCommand = new OleDbCommand(sqlStmt, dbConnection);

        // Add new parameters with id and values to the database
        OleDbParameter param = new OleDbParameter("@userID", userID);
        dbCommand.Parameters.Add(param);

        dbCommand.Parameters.Add(new OleDbParameter("@first", firstName));
        dbCommand.Parameters.Add(new OleDbParameter("@last", lastName));
        dbCommand.Parameters.Add(new OleDbParameter("@email", email));
        dbCommand.Parameters.Add(new OleDbParameter("@address1", address1));
        dbCommand.Parameters.Add(new OleDbParameter("@address2", address2));
        dbCommand.Parameters.Add(new OleDbParameter("@city", city));
        dbCommand.Parameters.Add(new OleDbParameter("@state", state));
        dbCommand.Parameters.Add(new OleDbParameter("@phone", phoneNumber));

        // Commit changes
        dbCommand.ExecuteNonQuery();

        // Close connection
        dbConnection.Close();
    }

    // Delete user data to from the database
    public void DeleteCustomer(int customerID)
    {
        // Opens data connection
        dbConnection.Open();

        // Create a string of new data
        string sqlStmt = "DELETE FROM tblCustomers WHERE CustomerID = @id";
        // Create new instance
        OleDbCommand dbCommand = new OleDbCommand(sqlStmt, dbConnection);

        // Add new parameters to update to the database
        OleDbParameter param = new OleDbParameter("@id", customerID);
        dbCommand.Parameters.Add(param);

        // Commit changes
        dbCommand.ExecuteNonQuery();

        // Close connection
        dbConnection.Close();
    }

    public dsAccounts GetAllCustomers()
    {
        // Pulls all data from tblCustomers for use
        OleDbDataAdapter sqlDataAdapter = new OleDbDataAdapter("select * from tblCustomers;", dbConnection);
        
        // 
        dsAccounts myStoreDataSet = new dsAccounts();
        sqlDataAdapter.Fill(myStoreDataSet.tblCustomers);

        // Creates and fills new stored data info from tblCustomers
        return myStoreDataSet;
    }


    // ORDER RELATED THINGS
    // FindOrder Method
    public dsAccounts FindOrders(string Search)
    {
        // Pulls Customer data from database for use
        string sqlStmt = "SELECT * FROM tblOrders WHERE Customer like '" + Search + "'";
        OleDbDataAdapter sqlDataAdapter = new OleDbDataAdapter(sqlStmt, dbConnection);

        // Creates and fills new stored data info from tblCart
        dsAccounts myStoreDataSet = new dsAccounts();
        sqlDataAdapter.Fill(myStoreDataSet.tblOrders);

        // Return new data
        return myStoreDataSet;
    }

    // FillOrder Method
    public dsAccounts FillOrders(string Search)
    {
        // Pulls Customer data from database for use
        string sqlStmt = "SELECT * FROM tblOrders WHERE Customer like '" + Search + "'";
        OleDbDataAdapter sqlDataAdapter = new OleDbDataAdapter(sqlStmt, dbConnection);

        // Creates and fills new stored data info from tblOrders
        dsAccounts myStoreDataSet = new dsAccounts();
        sqlDataAdapter.Fill(myStoreDataSet.tblOrders);

        // Return new data
        return myStoreDataSet;
    }

    // Update new user data to the database
    public void UpdateOrders(string customer, string jobType, string mediaType, string message, string approval, string completion, string reason, string completionDate, string paymentOption, string itemInStock, int orderNumber)
    {
        // Opens data connection
        dbConnection.Open();

        // Create a string of new data
        string sqlStmt = "UPDATE tblOrders SET Customer = @customer, JobType = @jobType, MediaType = @mediaType, Message = @message, Approval = @approval, Completion = @completion, Reason = @reason, CompletionDate = @completionDate, PaymentOption = @paymentOption, ItemInStock = @itemInStock WHERE (tblOrders.OrderNumber = @id)";

        // Create new instance
        OleDbCommand dbCommand = new OleDbCommand(sqlStmt, dbConnection);

        // Add new parameters to update to the database
        OleDbParameter param = new OleDbParameter("@customer", customer);
        dbCommand.Parameters.Add(param);

        dbCommand.Parameters.Add(new OleDbParameter("@jobType", jobType));
        dbCommand.Parameters.Add(new OleDbParameter("@media", mediaType));
        dbCommand.Parameters.Add(new OleDbParameter("@message", message));
        dbCommand.Parameters.Add(new OleDbParameter("@approval", approval));
        dbCommand.Parameters.Add(new OleDbParameter("@completion", completion));
        dbCommand.Parameters.Add(new OleDbParameter("@reason", reason));
        dbCommand.Parameters.Add(new OleDbParameter("@completionDate", completionDate));
        dbCommand.Parameters.Add(new OleDbParameter("@paymentOption", paymentOption));
        dbCommand.Parameters.Add(new OleDbParameter("@itemInStock", itemInStock));
        dbCommand.Parameters.Add(new OleDbParameter("@id", orderNumber));

        // Commit changes
        dbCommand.ExecuteNonQuery();

        // Close connection
        dbConnection.Close();
    }

    // Adds new user and their data to the database
    public void InsertOrders(string customer, string jobType, string mediaType, string message, string approval, string completion, string reason, string completionDate, string paymentOption, string itemInStock, int orderNumber)
    {
        // Opens data connection
        dbConnection.Open();

        // Create a string of new data
        string sqlStmt = "INSERT INTO tblCart(Customer, JobType, MediaType, Message, Approval, Completion, Reason, CompletionDate, PaymentOption, ItemInStock) ";
        sqlStmt += "VALUES (@customer, @jobType, @mediaType, @message, @approval, @completion, @reason, @completionDate, @paymentOption, @itemInStock)";

        // Create new instance
        OleDbCommand dbCommand = new OleDbCommand(sqlStmt, dbConnection);

        // Add new parameters with id and values to the database
        OleDbParameter param = new OleDbParameter("@customer", customer);
        dbCommand.Parameters.Add(param);

        dbCommand.Parameters.Add(new OleDbParameter("@jobType", jobType));
        dbCommand.Parameters.Add(new OleDbParameter("@media", mediaType));
        dbCommand.Parameters.Add(new OleDbParameter("@message", message));
        dbCommand.Parameters.Add(new OleDbParameter("@approval", approval));
        dbCommand.Parameters.Add(new OleDbParameter("@completion", completion));
        dbCommand.Parameters.Add(new OleDbParameter("@reason", reason));
        dbCommand.Parameters.Add(new OleDbParameter("@completionDate", completionDate));
        dbCommand.Parameters.Add(new OleDbParameter("@paymentOption", paymentOption));
        dbCommand.Parameters.Add(new OleDbParameter("@itemInStock", itemInStock));

        // Commit changes
        dbCommand.ExecuteNonQuery();

        // Close connection
        dbConnection.Close();
    }

    // Adds new user and their data to the database
    public void DeleteOrders(int orderNumber)
    {
        // Opens data connection
        dbConnection.Open();

        // Create a string of new data
        string sqlStmt = "DELETE * FROM tblOrders WHERE orderNumber = @id";

        // Create new instance
        OleDbCommand dbCommand = new OleDbCommand(sqlStmt, dbConnection);

        // Add new parameters with id and values to the database
        OleDbParameter param = new OleDbParameter("@id", orderNumber);
        dbCommand.Parameters.Add(param);

        // Commit changes
        dbCommand.ExecuteNonQuery();

        // Close connection
        dbConnection.Close();
    }

    public dsAccounts GetAllOrders()
    {
        // Pulls all data from tblCart for use
        OleDbDataAdapter sqlDataAdapter = new OleDbDataAdapter("SELECT * FROM tblOrders;", dbConnection);

        // 
        dsAccounts myStoreDataSet = new dsAccounts();
        sqlDataAdapter.Fill(myStoreDataSet.tblOrders);

        // Creates and fills new stored data info from tblOrders
        return myStoreDataSet;
    }

    public dsAccounts GetAllUserOrders()
    {
        // Pulls all data from tblCart for use
        OleDbDataAdapter sqlDataAdapter = new OleDbDataAdapter("SELECT * FROM tblOrders WHERE Customer = @customer;", dbConnection);

        // 
        dsAccounts myStoreDataSet = new dsAccounts();
        sqlDataAdapter.Fill(myStoreDataSet.tblOrders);

        // Creates and fills new stored data info from tblOrders
        return myStoreDataSet;
    }
    // END OF ORDER RELATED THINGS


    // CART RELATED THINGS
    // FindOrder Method
    public dsAccounts FindOrder(string Search)
    {
        // Pulls Customer data from database for use
        string sqlStmt = "SELECT * FROM tblCart WHERE Customer like '" + Search + "'";
        OleDbDataAdapter sqlDataAdapter = new OleDbDataAdapter(sqlStmt, dbConnection);

        // Creates and fills new stored data info from tblCart
        dsAccounts myStoreDataSet = new dsAccounts();
        sqlDataAdapter.Fill(myStoreDataSet.tblCart);

        // Return new data
        return myStoreDataSet;
    }

    // FindOrder Method
    public dsAccounts FillCart(string Search)
    {
        // Pulls Customer data from database for use
        string sqlStmt = "SELECT * FROM tblCart WHERE Customer like '" + Search + "'";
        OleDbDataAdapter sqlDataAdapter = new OleDbDataAdapter(sqlStmt, dbConnection);

        // Creates and fills new stored data info from tblCart
        dsAccounts myStoreDataSet = new dsAccounts();
        sqlDataAdapter.Fill(myStoreDataSet.tblCart);

        // Return new data
        return myStoreDataSet;
    }

    // Update new user data to the database
    public void UpdateCart(string customer, string jobType, string media, string message, int orderNumber)
    {
        // Opens data connection
        dbConnection.Open();

        // Create a string of new data
        string sqlStmt = "UPDATE tblCart SET Customer = @customer, JobType = @jobType, Media = @media, Message = @message WHERE (tblCart.OrderNumber = @id)";

        // Create new instance
        OleDbCommand dbCommand = new OleDbCommand(sqlStmt, dbConnection);

        // Add new parameters to update to the database
        OleDbParameter param = new OleDbParameter("@customer", customer);
        dbCommand.Parameters.Add(param);

        dbCommand.Parameters.Add(new OleDbParameter("@jobType", jobType));
        dbCommand.Parameters.Add(new OleDbParameter("@media", media));
        dbCommand.Parameters.Add(new OleDbParameter("@message", message));
        dbCommand.Parameters.Add(new OleDbParameter("@id", orderNumber));

        // Commit changes
        dbCommand.ExecuteNonQuery();

        // Close connection
        dbConnection.Close();
    }

    // Adds new user and their data to the database
    public void AddToCart(string customer, string jobType, string media, string message, int orderNumber)
    {
        // Opens data connection
        dbConnection.Open();

        // Create a string of new data
        string sqlStmt = "INSERT INTO tblCart(Customer, JobType, Media, Message) ";
        sqlStmt += "VALUES (@customer, @jobType, @media, @message)";

        // Create new instance
        OleDbCommand dbCommand = new OleDbCommand(sqlStmt, dbConnection);

        // Add new parameters with id and values to the database
        OleDbParameter param = new OleDbParameter("@customer", customer);
        dbCommand.Parameters.Add(param);

        dbCommand.Parameters.Add(new OleDbParameter("@jobType", jobType));
        dbCommand.Parameters.Add(new OleDbParameter("@media", media));
        dbCommand.Parameters.Add(new OleDbParameter("@message", message));

        // Commit changes
        dbCommand.ExecuteNonQuery();

        // Close connection
        dbConnection.Close();
    }

    // Adds new user and their data to the database
    public void DeleteCart(int orderNumber)
    {
        // Opens data connection
        dbConnection.Open();

        // Create a string of new data
        string sqlStmt = "DELETE * FROM tblCart WHERE orderNumber = @id";

        // Create new instance
        OleDbCommand dbCommand = new OleDbCommand(sqlStmt, dbConnection);

        // Add new parameters with id and values to the database
        OleDbParameter param = new OleDbParameter("@id", orderNumber);
        dbCommand.Parameters.Add(param);

        // Commit changes
        dbCommand.ExecuteNonQuery();

        // Close connection
        dbConnection.Close();
    }

    public dsAccounts GetAllOrderInCart()
    {
        // Pulls all data from tblCart for use
        OleDbDataAdapter sqlDataAdapter = new OleDbDataAdapter("SELECT * FROM tblCart;", dbConnection);

        // 
        dsAccounts myStoreDataSet = new dsAccounts();
        sqlDataAdapter.Fill(myStoreDataSet.tblCart);

        // Creates and fills new stored data info from tblCart
        return myStoreDataSet;
    }

    public dsAccounts GetAllUserCart()
    {
        // Pulls all data from tblCart for use
        OleDbDataAdapter sqlDataAdapter = new OleDbDataAdapter("SELECT * FROM tblCart WHERE Customer = @customer;", dbConnection);

        // 
        dsAccounts myStoreDataSet = new dsAccounts();
        sqlDataAdapter.Fill(myStoreDataSet.tblCart);

        // Creates and fills new stored data info from tblCart
        return myStoreDataSet;
    }
    // END OF CART RELATED THINGS


    // CC RELATED THINGS
    // FindCreditInformation Method
    public dsAccounts FindCreditInformation(string Search)
    {
        // Pulls Customer data from database for use
        string sqlStmt = "SELECT * FROM tblCreditInformation WHERE Customer like '" + Search + "'";
        OleDbDataAdapter sqlDataAdapter = new OleDbDataAdapter(sqlStmt, dbConnection);

        // Creates and fills new stored data info from tblCreditInformation
        dsAccounts myStoreDataSet = new dsAccounts();
        sqlDataAdapter.Fill(myStoreDataSet.tblCreditInformation);

        // Return new data
        return myStoreDataSet;
    }

    // Fill CreditInformation Method
    public dsAccounts FillCreditInformation(string Search)
    {
        // Pulls Customer data from database for use
        string sqlStmt = "SELECT * FROM tblCreditInformation WHERE Customer like '" + Search + "'";
        OleDbDataAdapter sqlDataAdapter = new OleDbDataAdapter(sqlStmt, dbConnection);

        // Creates and fills new stored data info from tblCreditInformation
        dsAccounts myStoreDataSet = new dsAccounts();
        sqlDataAdapter.Fill(myStoreDataSet.tblCreditInformation);

        // Return new data
        return myStoreDataSet;
    }

    // Update new user data to the database
    public void UpdateCreditInformation(string customer, string ccNumber, string ccType, int ID)
    {
        // Opens data connection
        dbConnection.Open();

        // Create a string of new data
        string sqlStmt = "UPDATE tblCreditInformation SET Customer = @customer, CCNumber = @ccNumber, CCType = @ccType WHERE (tblCreditInformation.ID = @id)";

        // Create new instance
        OleDbCommand dbCommand = new OleDbCommand(sqlStmt, dbConnection);

        // Add new parameters to update to the database
        OleDbParameter param = new OleDbParameter("@customer", customer);
        dbCommand.Parameters.Add(param);

        dbCommand.Parameters.Add(new OleDbParameter("@ccNumber", ccNumber));
        dbCommand.Parameters.Add(new OleDbParameter("@cctype", ccType));
        dbCommand.Parameters.Add(new OleDbParameter("@id", ID));

        // Commit changes
        dbCommand.ExecuteNonQuery();

        // Close connection
        dbConnection.Close();
    }

    // Adds new user and their data to the database
    public void InsertCreditInformation(string customer, string ccNumber, string ccType, int ID)
    {
        // Opens data connection
        dbConnection.Open();

        // Create a string of new data
        string sqlStmt = "INSERT INTO tblCreditInformation(Customer, ccNumber, ccType) ";
        sqlStmt += "VALUES (@customer, @ccNumber, @ccType)";

        // Create new instance
        OleDbCommand dbCommand = new OleDbCommand(sqlStmt, dbConnection);

        // Add new parameters with id and values to the database
        OleDbParameter param = new OleDbParameter("@customer", customer);
        dbCommand.Parameters.Add(param);

        dbCommand.Parameters.Add(new OleDbParameter("@ccNumber", ccNumber));
        dbCommand.Parameters.Add(new OleDbParameter("@cctype", ccType));
        dbCommand.Parameters.Add(new OleDbParameter("@id", ID));

        // Commit changes
        dbCommand.ExecuteNonQuery();

        // Close connection
        dbConnection.Close();
    }

    // Adds new user and their data to the database
    public void DeleteCreditInformation(int ID)
    {
        // Opens data connection
        dbConnection.Open();

        // Create a string of new data
        string sqlStmt = "DELETE * FROM tblCreditInformation WHERE ID = @id";

        // Create new instance
        OleDbCommand dbCommand = new OleDbCommand(sqlStmt, dbConnection);

        // Add new parameters with id and values to the database
        OleDbParameter param = new OleDbParameter("@id", ID);
        dbCommand.Parameters.Add(param);

        // Commit changes
        dbCommand.ExecuteNonQuery();

        // Close connection
        dbConnection.Close();
    }

    public dsAccounts GetAllCreditInformation()
    {
        // Pulls all data from tblCart for use
        OleDbDataAdapter sqlDataAdapter = new OleDbDataAdapter("SELECT * FROM tblCreditInformation;", dbConnection);

        // 
        dsAccounts myStoreDataSet = new dsAccounts();
        sqlDataAdapter.Fill(myStoreDataSet.tblCreditInformation);

        // Creates and fills new stored data info from tblCreditInformation
        return myStoreDataSet;
    }

    public dsAccounts GetAllUserCreditInformation()
    {
        // Pulls all data from tblCreditInformation for use
        OleDbDataAdapter sqlDataAdapter = new OleDbDataAdapter("SELECT * FROM tblCreditInformation WHERE Customer = @customer;", dbConnection);

        // 
        dsAccounts myStoreDataSet = new dsAccounts();
        sqlDataAdapter.Fill(myStoreDataSet.tblCreditInformation);

        // Creates and fills new stored data info from tblCreditInformation
        return myStoreDataSet;
    }
    // END OF CC RELATED THINGS


    // tblUsers RELATED THINGS
    // FindCustomer Method
    public dsAccounts FindUser(string Username)
    {
        // Pulls Username data from database for use
        string sqlStmt = "SELECT * from tblUsers where UserID like '" + Username + "'";
        OleDbDataAdapter sqlDataAdapter = new OleDbDataAdapter(sqlStmt, dbConnection);

        // Creates and fills new stored data info from tblCustomers
        dsAccounts myStoreDataSet = new dsAccounts();
        sqlDataAdapter.Fill(myStoreDataSet.tblUsers);

        // Return new data
        return myStoreDataSet;
    }

    // Adds new user and their data to the database
    public void InsertUser(string userID, string password, int ID)
    {
        // Opens data connection
        dbConnection.Open();

        // Create a string of new data
        string sqlStmt = "INSERT INTO tblUsers(UserID, Password, ID) ";
        sqlStmt += "VALUES (@userID, @password, @id)";

        // Create new instance
        OleDbCommand dbCommand = new OleDbCommand(sqlStmt, dbConnection);

        // Add new parameters with id and values to the database
        OleDbParameter param = new OleDbParameter("@userID", userID);
        dbCommand.Parameters.Add(param);

        dbCommand.Parameters.Add(new OleDbParameter("@ccNumber", password));
        dbCommand.Parameters.Add(new OleDbParameter("@id", ID));

        // Commit changes
        dbCommand.ExecuteNonQuery();

        // Close connection
        dbConnection.Close();
    }

    // Adds new user and their data to the database
    public void DeleteUser(int ID)
    {
        // Opens data connection
        dbConnection.Open();

        // Create a string of new data
        string sqlStmt = "DELETE * FROM tblUsers WHERE ID = @id";

        // Create new instance
        OleDbCommand dbCommand = new OleDbCommand(sqlStmt, dbConnection);

        // Add new parameters with id and values to the database
        OleDbParameter param = new OleDbParameter("@id", ID);
        dbCommand.Parameters.Add(param);

        // Commit changes
        dbCommand.ExecuteNonQuery();

        // Close connection
        dbConnection.Close();
    }

    public dsAccounts GetAllUsers()
    {
        // Pulls all data from tblCart for use
        OleDbDataAdapter sqlDataAdapter = new OleDbDataAdapter("SELECT * FROM tblUsers;", dbConnection);

        // 
        dsAccounts myStoreDataSet = new dsAccounts();
        sqlDataAdapter.Fill(myStoreDataSet.tblCreditInformation);

        // Creates and fills new stored data info from tblCreditInformation
        return myStoreDataSet;
    }

    public dsAccounts GetUser()
    {
        // Pulls all data from tblUsers for use
        OleDbDataAdapter sqlDataAdapter = new OleDbDataAdapter("SELECT * FROM tblUsers WHERE UserID = @id;", dbConnection);

        // 
        dsAccounts myStoreDataSet = new dsAccounts();
        sqlDataAdapter.Fill(myStoreDataSet.tblUsers);

        // Creates and fills new stored data info from tblUsers
        return myStoreDataSet;
    }

    public bool ValidateUser(string username, string password)
    {
        // 
        dbConnection.Open();

        // 
        string sqlStmt = "SELECT * FROM tblUsers WHERE UserID = @id AND Password = @password AND Locked = FALSE";

        // 
        OleDbCommand dbCommand = new OleDbCommand(sqlStmt, dbConnection);

        // 
        dbCommand.Parameters.Add(new OleDbParameter("@id", username));
        dbCommand.Parameters.Add(new OleDbParameter("@password", password));

        // 
        OleDbDataReader dr = dbCommand.ExecuteReader();

        // 
        Boolean isValidAccount = dr.Read();

        // 
        dbConnection.Close();

        return isValidAccount;
    }

    public bool CheckUsername(string username)
    {
        // 
        dbConnection.Open();

        // 
        string sqlStmt = "SELECT * FROM tblUsers WHERE UserID = @id";

        // 
        OleDbCommand dbCommand = new OleDbCommand(sqlStmt, dbConnection);

        // 
        dbCommand.Parameters.Add(new OleDbParameter("@id", username));

        // 
        OleDbDataReader dr = dbCommand.ExecuteReader();

        // 
        Boolean isUsernameMatch = dr.Read();

        // 
        dbConnection.Close();

        return isUsernameMatch;
    }

    public void LockUserAccount(string username)
    {
        // 
        dbConnection.Open();

        // 
        string sqlStmt = "UPDATE tblUsers SET Locked = True WHERE UserID = @id";

        // 
        OleDbCommand dbCommand = new OleDbCommand(sqlStmt, dbConnection);

        // 
        dbCommand.Parameters.Add(new OleDbParameter("@id", username));

        // 
        dbCommand.ExecuteNonQuery();

        // 
        dbConnection.Close();
    }
    // END OF tblCart RELATED THINGS
}