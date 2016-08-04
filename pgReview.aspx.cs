using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pgReview : System.Web.UI.Page
{
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

        panelReLogin.Enabled = true;
        panelReLogin.Visible = true;

        panelReview.Enabled = false;
        panelReview.Visible = false;

        panelReview2.Enabled = false;
        panelReview2.Visible = false;

        lblCurrentUser.Visible = false;
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

        try
        {
            // If the user is in the database then they proceed
            if (isValid)
            {
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

                panelReLogin.Enabled = false;
                panelReLogin.Visible = false;

                if (txtUserID.Text.Contains("systemAdmin"))
                {
                    lblCurrentUser.Text = txtUserID.Text;

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

                    panelReview.Enabled = true;
                    panelReview.Visible = true;

                    panelReview2.Enabled = true;
                    panelReview2.Visible = true;

                    panelReLogin.Enabled = false;
                    panelReLogin.Visible = false;

                    // Output message if match data is found
                    Master.UserFeedBack.Text = "Shall we " + lblCurrentUser.Text + "?";
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
        }

        catch (Exception error)
        {
            Master.UserFeedBack.Text = error.Message;
        }
    }
}