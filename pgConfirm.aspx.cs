using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pgConfirm : System.Web.UI.Page
{
    clsBusinessLayer myBusinessLayer;

    protected void Page_Load(object sender, EventArgs e)
    {
        Master.UserFeedBack.Text = "Please confirm your information.";

        lblCurrentUser.Text = "";

        lblProceed.Visible = false;
        lblProceed.Text = "Click the link below to proceed to the landing page.";
        lbtnProceed.Visible = false;
        lbtnProceed.Enabled = false;

        // Add data to myBusinessLayer
        myBusinessLayer = new clsBusinessLayer(Server.MapPath("~/App_Data/"));

        try
        {
            if (PreviousPage.IsCrossPagePostBack)
            {
                lblCurrentUser.Text = PreviousPage.CurrentUser.Text;

                txtUsername.Text = PreviousPage.Username.Text;
                txtPassword.Text = PreviousPage.PasswordConfirm.Text;
                txtUsername.Enabled = false;

                txtFirstName.Text = PreviousPage.FirstName.Text;
                txtLastName.Text = PreviousPage.LastName.Text;
                txtEmail.Text = PreviousPage.Email.Text;
                txtLine1.Text = PreviousPage.Address1.Text;
                txtLine2.Text = PreviousPage.Address2.Text;
                txtCity.Text = PreviousPage.City.Text;
                txtState.Text = PreviousPage.State.Text;
                txtPhone.Text = PreviousPage.PhoneNumber.Text;
                customerID.Text = PreviousPage.CustID.Text;
                ID.Text = PreviousPage.UsersID.Text;
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

    private void ClearInputs(ControlCollection ctrls)
    {
        customerID.Text = string.Empty;
        ID.Text = string.Empty;

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
        ID.Text = string.Empty;

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

    private void updateForm(string results)
    {
        // Disable fields
        DisableInputs(Page.Controls);

        // Update UserFeedBack message
        Master.UserFeedBack.Text = results;
    }

    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        lblCurrentUser.Text = lblCurrentUser.Text;

        // Checks session credentials with database
        bool isUser = myBusinessLayer.CheckUsername(Session, txtUsername.Text);

        if (isUser)
        {
            // Updates data to results
            string results = myBusinessLayer.UpdateCustomer(txtUsername.Text, txtFirstName.Text, txtLastName.Text, txtEmail.Text, txtLine1.Text, txtLine2.Text, txtCity.Text, txtState.Text, txtPhone.Text, Convert.ToInt32(customerID.Text));

            // Update the results for the updateForm method
            updateForm(results);

            lblProceed.Visible = true;
            lblProceed.Text = "Click the link below to proceed to the landing page.";
            lbtnProceed.Visible = true;
            lbtnProceed.Enabled = true;

            btnConfirm.Visible = false;
            btnConfirm.Enabled = false;
            btnCancel.Visible = false;
            btnCancel.Enabled = false;
        }

        else
        {
            // Add data to results
            myBusinessLayer.InsertCustomer(txtUsername.Text, txtFirstName.Text, txtLastName.Text, txtEmail.Text, txtLine1.Text, txtLine2.Text, txtCity.Text, txtState.Text, txtPhone.Text, Convert.ToInt32(ID.Text));

            IDforUserID.Text = "0";
            ID.Text = "0";

            // Add data to results
            myBusinessLayer.InsertUser(txtUsername.Text, txtPassword.Text, Convert.ToInt32(IDforUserID.Text));
            
            // Output message if no matching data is found
            Master.UserFeedBack.Text = "Welcome to the family, " + txtUsername.Text + "!";

            // Clear fields
            ClearInputs(Page.Controls);

            lblProceed.Visible = true;
            lblProceed.Text = "Click the link below to proceed to the landing page.";
            lbtnProceed.Visible = true;
            lbtnProceed.Enabled = true;

            btnConfirm.Visible = false;
            btnConfirm.Enabled = false;
            btnCancel.Visible = false;
            btnCancel.Enabled = false;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        lblCurrentUser.Text = lblCurrentUser.Text;
    }
}