using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pgLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.UserFeedBack.Text = "Please enter your username and password.";

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
    }

    public TextBox User
    {
        get { return txtUserID; }
    }

    public Label CurrentUser
    {
        get { return lblCurrentUser; }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        // Create new instant of the BusinessLayer
        clsBusinessLayer myBusinessLayer = new clsBusinessLayer(Server.MapPath("~/App_Data/"));

        // Checks session credentials with database
        bool isValid = myBusinessLayer.CheckUserCredentials(Session, txtUserID.Text, txtPassword.Text);

        // Checks session credentials with database
        bool isValidUser = myBusinessLayer.CheckUsername(Session, txtUserID.Text);

        // If the user is in the database then they proceed
        if (txtUserID.Text == null || txtUserID.Text == String.Empty || txtPassword.Text == null || txtPassword.Text == String.Empty)
        {
            Response.Redirect("~/pgLogin.aspx");

            if (isValid)
            {
                lblCurrentUser.Text = User.Text;
            }
        }

        else if (Convert.ToBoolean(Session["LockedSession"]))
        {
            Master.UserFeedBack.Text = "Account is disabled. Contact System Administrator";

            // Hide login button
            btnLogin.Visible = false;
        }

        else
        {
            Master.UserFeedBack.Text = "The User ID and/or Password supplied is incorrect. Please try again!";
        }
    }

    private void ClearInputs(ControlCollection ctrls)
    {
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

    protected void lbtnCreate_Click(object sender, EventArgs e)
    {
        txtUserID.Text = "";
        txtPassword.Text = "";
    }
}