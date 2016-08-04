using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pgCheckout : System.Web.UI.Page
{
    clsBusinessLayer myBusinessLayer;

    protected void Page_Load(object sender, EventArgs e)
    {
        Master.UserFeedBack.Text = "Please review the forms and add to desired fields.";

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

        panelCart.Visible = true;
        panelOrder.Visible = false;

        try
        {
            if (PreviousPage.IsCrossPagePostBack)
            {
                txtUsername.Text = PreviousPage.CurrentCustomer.Text;
                lblCurrentUser.Text = txtUsername.Text;

                dsAccounts dsLoadUser = myBusinessLayer.FindCustomer(txtUsername.Text);
                dsAccounts dsLoadCredInfo = myBusinessLayer.FindCreditInformation(txtUsername.Text);
                dsAccounts dsLoadOrderInfo = myBusinessLayer.FindOrders(txtUsername.Text);

                // Checks session credentials with database
                bool isUser = myBusinessLayer.CheckUsername(Session, txtUsername.Text);

                if (isUser || dsLoadUser.tblCustomers.Rows.Count > 0 || dsLoadCredInfo.tblCreditInformation.Rows.Count > 0 || dsLoadOrderInfo.tblOrders.Rows.Count > 0)
                {
                    // If the Username and their data is found then it is pulled and user is informed the record has been found
                    txtUsername.Text = dsLoadUser.tblCustomers[0].UserID;
                    txtFirstName.Text = dsLoadUser.tblCustomers[0].FirstName;
                    txtLastName.Text = dsLoadUser.tblCustomers[0].LastName;
                    txtEmail.Text = dsLoadUser.tblCustomers[0].Email;
                    txtLine1.Text = dsLoadUser.tblCustomers[0].Address1;
                    txtLine2.Text = dsLoadUser.tblCustomers[0].Address2;
                    txtCity.Text = dsLoadUser.tblCustomers[0].City;
                    txtState.Text = dsLoadUser.tblCustomers[0].State;
                    txtPhone.Text = dsLoadUser.tblCustomers[0].PhoneNumber;
                    customerID.Text = dsLoadUser.tblCustomers[0].CustomerID.ToString();

                    txtCCNumber.Text = dsLoadCredInfo.tblCreditInformation[0].CCNumber;
                    rblCCType.SelectedValue = dsLoadCredInfo.tblCreditInformation[0].CCType;



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
                    Master.OrderReview.Enabled = true;

                    txtUsername.Enabled = false;

                    BindOrdersGridView();


                    if (txtUsername.Text.Contains("systemAdmin"))
                    {
                        Master.OrderReview.Visible = true;
                        Master.OrderReview.Enabled = true;

                        txtUsername.Enabled = true;
                    }

                    else
                    {
                        Response.Redirect("~/pgLogin.aspx");
                    }
                }
            }
        }

        catch (Exception error)
        {
            Master.UserFeedBack.Text = error.Message;
        }
    }

    public TextBox Username
    {
        get { return txtUsername; }
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

    private void ClearInputs(ControlCollection ctrls)
    {
        Username.Text = string.Empty;

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

    private void DisableInputs(ControlCollection ctrls)
    {
        customerID.Text = string.Empty;
        lblCurrentUser.Text = string.Empty;

        foreach (Control ctrl in ctrls)
        {
            if (ctrl is TextBox)
                ((TextBox)ctrl).Enabled = false;

            else if (ctrl is DropDownList)
                ((DropDownList)ctrl).Enabled = false;

            else if (ctrl is RadioButton)
                ((RadioButton)ctrl).Enabled = false;

            else if (ctrl is RadioButtonList)
                ((RadioButtonList)ctrl).Enabled = false;

            else
                DisableInputs(ctrl.Controls);
        }
    }

    private dsAccounts BindOrdersGridView()
    {
        // Pulls data from the database for use
        string tempPath = Server.MapPath("~/App_Data/Accounts.mdb");
        clsDataLayer myDataLayer = new clsDataLayer(tempPath);

        // Adds data from the first to the second
        dsAccounts orderListing = myDataLayer.FillOrders(Username.Text);

        // Adds data from the first to the second
        gvCart.DataSource = orderListing.tblOrders;

        // Caches data collected
        gvCart.DataBind();
        Cache.Insert("CustomerDataSet", orderListing);

        return orderListing;
    }

    public void btnClear_Click(object sender, EventArgs e)
    {
        ClearInputs(Page.Controls);
    }

    protected void btnCheckout_Click(object sender, EventArgs e)
    {
        lblCurrentUser.Text = lblCurrentUser.Text;

        DisableInputs(Page.Controls);

        panelCart.Visible = false;
        panelOrder.Visible = true;

        // Creates new database for use in click event
        dsAccounts dsFindOrders = myBusinessLayer.FindOrder(txtUsername.Text);
        dsAccounts dsFindOrder = myBusinessLayer.FindOrders(txtUsername.Text);

        // If applicable, gives one of the below outputs
            // If username on AccountDetails page matches UserID from tblUsers
            // Can update details for that user
        if (dsFindOrder.tblCart.Rows.Count > 0 || dsFindOrders.tblOrders.Rows.Count > 0)
        {
            // If the Username and their data is found then it is pulled and user is informed the record has been found
            dsFindOrders.tblOrders[0].Customer = dsFindOrder.tblCart[0].Customer;
            dsFindOrders.tblOrders[0].JobType = dsFindOrder.tblCart[0].JobType;
            dsFindOrders.tblOrders[0].MediaType = dsFindOrder.tblCart[0].MediaType;
            dsFindOrders.tblOrders[0].Message = dsFindOrder.tblCart[0].Message;
            dsFindOrders.tblOrders[0].PaymentOption = chkPaymentOption.Text;

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
}