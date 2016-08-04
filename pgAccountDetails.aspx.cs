using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Net;
using System.Data;

public partial class pgAccountDetails : System.Web.UI.Page
{
    clsBusinessLayer myBusinessLayer;

    protected void Page_Load(object sender, EventArgs e)
    {
        Master.AboutUs.Visible = false;
        Master.AccountDetails.Visible = false;
        Master.Checkout.Visible = false;
        Master.FAQ.Visible = false;
        Master.HomePage.Visible = false;
        Master.Login.Visible = false;
        Master.OrderReview.Visible = false;

        Master.AboutUs.Enabled = false;
        Master.AccountDetails.Enabled = false;
        Master.Checkout.Enabled = false;
        Master.FAQ.Enabled = false;
        Master.HomePage.Enabled = false;
        Master.Login.Enabled = false;
        Master.OrderReview.Enabled = false;

        Master.UserFeedBack.Text = "Fill out the form below to create your account.";

        // Update GridView
        BindCustomerGridView();

        // Add data to myBusinessLayer
        myBusinessLayer = new clsBusinessLayer(Server.MapPath("~/App_Data/"));

        lblCustID.Visible = false;
        customerID.Visible = false;
        ID.Visible = false;

        lblCustList.Visible = false;
        gvCustomerList.Visible = false;

        txtUsername.Enabled = true;
        txtSearch.Enabled = false;
        btnFindUsername.Enabled = false;

        btnDelete.Enabled = false;
        btnDelete.Visible = false;

        lblSearch.Visible = false;
        txtSearch.Visible = false;
        btnFindUsername.Visible = false;

        // If applicable, gives one of the below outputs
        // If username on AccountDetails page matches UserID from tblUsers
        // Can update details for that user
        try
        {
            if (PreviousPage.IsCrossPagePostBack)
            {
                lblCurrentUser.Text = PreviousPage.CurrentUser.Text;
                txtUsername.Text = PreviousPage.User.Text;

                // Creates new database for use in click event
                dsAccounts dsLoadDetails = myBusinessLayer.FindCustomer(txtUsername.Text);
                dsAccounts dsLoadUser = myBusinessLayer.FindUser(txtUsername.Text);

                // Checks session credentials with database
                bool isUser = myBusinessLayer.CheckUsername(Session, txtUsername.Text);

                if (isUser || dsLoadDetails.tblCustomers.Rows.Count > 0 || dsLoadUser.tblUsers.Rows.Count > 0)
                {
                    // If the Username and their data is found then it is pulled and user is informed the record has been found
                    txtUsername.Text = dsLoadDetails.tblCustomers[0].UserID;
                    txtFirstName.Text = dsLoadDetails.tblCustomers[0].FirstName;
                    txtLastName.Text = dsLoadDetails.tblCustomers[0].LastName;
                    txtEmail.Text = dsLoadDetails.tblCustomers[0].Email;
                    txtLine1.Text = dsLoadDetails.tblCustomers[0].Address1;
                    txtLine2.Text = dsLoadDetails.tblCustomers[0].Address2;
                    txtCity.Text = dsLoadDetails.tblCustomers[0].City;
                    txtState.Text = dsLoadDetails.tblCustomers[0].State;
                    txtPhone.Text = dsLoadDetails.tblCustomers[0].PhoneNumber;
                    customerID.Text = dsLoadDetails.tblCustomers[0].CustomerID.ToString();
                    
                    ID.Text = dsLoadUser.tblUsers[0].ID.ToString();

                    Master.AboutUs.Visible = true;
                    Master.AccountDetails.Visible = true;
                    Master.Checkout.Visible = true;
                    Master.FAQ.Visible = true;
                    Master.HomePage.Visible = true;
                    Master.Login.Visible = true;
                    Master.OrderReview.Visible = false;

                    Master.AboutUs.Enabled = true;
                    Master.AccountDetails.Enabled = true;
                    Master.Checkout.Enabled = true;
                    Master.FAQ.Enabled = true;
                    Master.HomePage.Enabled = true;
                    Master.Login.Enabled = true;
                    Master.OrderReview.Enabled = false; 
                    
                    txtUsername.Enabled = false;
                    txtSearch.Enabled = false;
                    btnFindUsername.Enabled = false;

                    lblCustList.Visible = false;
                    gvCustomerList.Visible = false;

                    lblSearch.Visible = false;
                    txtSearch.Visible = false;
                    btnFindUsername.Visible = false;

                    btnDelete.Enabled = true;
                    btnDelete.Visible = true;

                    // Output message if match data is found
                    Master.UserFeedBack.Text = "Welcome back " + txtUsername.Text + "!";


                    if (PreviousPage.User.Text.Contains("systemAdmin"))
                    {
                        lblCustList.Visible = true;
                        gvCustomerList.Visible = true;

                        lblSearch.Visible = true;
                        txtSearch.Visible = true;
                        btnFindUsername.Visible = true;

                        txtUsername.Enabled = false;
                        txtSearch.Enabled = true;
                        btnFindUsername.Enabled = true;

                        btnDelete.Enabled = false;
                        btnDelete.Visible = false;

                        Master.OrderReview.Visible = true;

                        lblCurrentUser.Text = "systemAdmin";

                        // Output message if match data is found
                        Master.UserFeedBack.Text = "Welcome back " + txtUsername.Text + "!";

                        if (txtSearch.Text.Contains("Create") || txtSearch.Text.Contains("create"))
                        {
                            Master.OrderReview.Visible = true;

                            lblCurrentUser.Text = "systemAdmin";

                            // Output message if match data is found
                            Master.UserFeedBack.Text = "Welcome back " + txtUsername.Text + "!";
                        }
                    }
                }

                else
                {
                    ID.Text = "0";

                    // Output message if no matching data is found
                    Master.UserFeedBack.Text = "Fill out the form below to create your account.";
                }
            }
        }

        catch (Exception error)
        {
            Master.UserFeedBack.Text = error.Message;
        }

        foreach (ListItem li in rblCCType.Items)
        {
            //add margin as css style
            li.Attributes.CssStyle.Add("margin-left", "75px");
        }

    }

    public Label CurrentUser
    {
        get { return lblCurrentUser; }
    }

    public Label UsersID
    {
        get { return ID; }
    }

    public TextBox Username
    {
        get { return txtUsername; }
    }

    public TextBox PasswordConfirm
    {
        get { return txtPasswordConfirm; }
    }

    public Label CustID
    {
        get { return customerID; }
    }

    public TextBox FirstName
    {
        get { return txtFirstName; }
    }

    public TextBox LastName
    {
        get { return txtLastName; }
    }

    public TextBox Email
    {
        get { return txtEmail; }
    }

    public TextBox Address1
    {
        get { return txtLine1; }
    }

    public TextBox Address2
    {
        get { return txtLine2; }
    }

    public TextBox City
    {
        get { return txtCity; }
    }

    public TextBox State
    {
        get { return txtState; }
    }

    public TextBox PhoneNumber
    {
        get { return txtPhone; }
    }

    public RadioButtonList CCType
    {
        get { return rblCCType; }
    }

    public TextBox CCNumber
    {
        get { return txtCCNumber; }
    }

    public TextBox Search
    {
        get { return txtSearch; }
    }

    private void ClearInputs(ControlCollection ctrls)
    {
        customerID.Text = string.Empty;

        foreach (Control ctrl in ctrls)
        {
            if (ctrl is TextBox)
                ((TextBox)ctrl).Text = string.Empty;

            else if (ctrl is DropDownList)
                ((DropDownList)ctrl).ClearSelection();

            else if (ctrl is RadioButton)
                ((RadioButton)ctrl).Checked = false;

            else if (ctrl is RadioButtonList)
                ((RadioButtonList)ctrl).ClearSelection();

            else
                ClearInputs(ctrl.Controls);
        }
    }

    private dsAccounts BindCustomerGridView()
    {
        // Pulls data from the database for use
        string tempPath = Server.MapPath("~/App_Data/Accounts.mdb");
        clsDataLayer myDataLayer = new clsDataLayer(tempPath);

        // Adds data from the first to the second
        dsAccounts customerListing = myDataLayer.GetAllCustomers();

        // Adds data from the first to the second
        gvCustomerList.DataSource = customerListing.tblCustomers;

        // Caches data collected
        gvCustomerList.DataBind();
        Cache.Insert("CustomerDataSet", customerListing);

        return customerListing;
    }

    private void updateForm(string results)
    {
        // Clear fields
        ClearInputs(Page.Controls);

        // Update UserFeedBack message
        Master.UserFeedBack.Text = results;

        // Update GridView
        BindCustomerGridView();
    }

    public void btnClearForm_Click(object sender, EventArgs e)
    {
        ClearInputs(Page.Controls);
    }

    // Pull data from table associated with selected Username
    protected void btnFindUsername_Click(object sender, EventArgs e)
    {
        // Creates new database for use in click event
        dsAccounts dsFindUsername = myBusinessLayer.FindCustomer(txtSearch.Text);
        dsAccounts dsFindUser = myBusinessLayer.FindUser(txtSearch.Text);

        // If applicable, gives one of the below outputs
            // If username on AccountDetails page matches UserID from tblUsers
            // Can update details for that user
        if (dsFindUsername.tblCustomers.Rows.Count > 0 || dsFindUser.tblUsers.Rows.Count > 0 || lblCurrentUser.Text.Contains("systemAdmin"))
        {
            // If the Username and their data is found then it is pulled and user is informed the record has been found
            txtUsername.Text = dsFindUsername.tblCustomers[0].UserID;
            txtFirstName.Text = dsFindUsername.tblCustomers[0].FirstName;
            txtLastName.Text = dsFindUsername.tblCustomers[0].LastName;
            txtEmail.Text = dsFindUsername.tblCustomers[0].Email;
            txtLine1.Text = dsFindUsername.tblCustomers[0].Address1;
            txtLine2.Text = dsFindUsername.tblCustomers[0].Address2;
            txtCity.Text = dsFindUsername.tblCustomers[0].City;
            txtState.Text = dsFindUsername.tblCustomers[0].State;
            txtPhone.Text = dsFindUsername.tblCustomers[0].PhoneNumber;
            customerID.Text = dsFindUsername.tblCustomers[0].CustomerID.ToString();

            IDforUserID.Text = dsFindUser.tblUsers[0].ID.ToString();

            Master.UserFeedBack.Text = "Found " + txtUsername.Text + ", " + lblCurrentUser.Text + "!";

            lblCurrentUser.Text = "systemAdmin";

            lblCustList.Visible = true;
            gvCustomerList.Visible = true;

            lblSearch.Visible = true;
            txtSearch.Visible = true;
            btnFindUsername.Visible = true;

            txtUsername.Enabled = false;
            txtSearch.Enabled = true;
            btnFindUsername.Enabled = true;

            btnDelete.Enabled = true;
            btnDelete.Visible = true;

            if (txtUsername.Text.Contains("systemAdmin"))
            {
                // If the Username and their data is found then it is pulled and user is informed the record has been found
                txtUsername.Text = dsFindUsername.tblCustomers[0].UserID;
                txtFirstName.Text = dsFindUsername.tblCustomers[0].FirstName;
                txtLastName.Text = dsFindUsername.tblCustomers[0].LastName;
                txtEmail.Text = dsFindUsername.tblCustomers[0].Email;
                txtLine1.Text = dsFindUsername.tblCustomers[0].Address1;
                txtLine2.Text = dsFindUsername.tblCustomers[0].Address2;
                txtCity.Text = dsFindUsername.tblCustomers[0].City;
                txtState.Text = dsFindUsername.tblCustomers[0].State;
                txtPhone.Text = dsFindUsername.tblCustomers[0].PhoneNumber;
                customerID.Text = dsFindUsername.tblCustomers[0].CustomerID.ToString();

                IDforUserID.Text = dsFindUser.tblUsers[0].ID.ToString();

                Master.UserFeedBack.Text = "Found admin " + txtUsername.Text + ", " + lblCurrentUser.Text + "!";

                lblCustList.Visible = true;
                gvCustomerList.Visible = true;

                lblSearch.Visible = true;
                txtSearch.Visible = true;
                btnFindUsername.Visible = true;

                txtUsername.Enabled = false;
                txtSearch.Enabled = true;
                btnFindUsername.Enabled = true;

                btnDelete.Enabled = false;
                btnDelete.Visible = false;
            }
        }

        else
        {
            // Output message if no matching data is found
            Master.UserFeedBack.Text = "No records were found.";

            lblCustList.Visible = true;
            gvCustomerList.Visible = true;

            lblSearch.Visible = true;
            txtSearch.Visible = true;
            btnFindUsername.Visible = true;

            txtUsername.Enabled = false;
            txtSearch.Enabled = true;
            btnFindUsername.Enabled = true;

            btnDelete.Enabled = false;
            btnDelete.Visible = false;
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        // Remove data from results
        string results = myBusinessLayer.DeleteCustomer(Convert.ToInt32(customerID.Text));

        // Remove data to results
        myBusinessLayer.DeleteUser(Convert.ToInt32(IDforUserID.Text));

        // Calle updateForm method
        updateForm(results);
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        lblCurrentUser.Text = lblCurrentUser.Text;
    }
}