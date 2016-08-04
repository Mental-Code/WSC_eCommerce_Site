using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web460Store : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /*lbtnAboutUs.Visible = false;
        lbtnAccountDetails.Visible = false;
        lbtnCheckout.Visible = false;
        lbtnFAQ.Visible = false;
        lbtnHome.Visible = false;
        lbtnHomePage.Visible = false;
        lbtnLogin.Visible = false;
        lbtnOrderReview.Visible = false;

        lbtnAboutUs.Enabled = false;
        lbtnAccountDetails.Enabled = false;
        lbtnCheckout.Enabled = false;
        lbtnFAQ.Enabled = false;
        lbtnHome.Enabled = false;
        lbtnHomePage.Enabled = false;
        lbtnLogin.Enabled = false;
        lbtnOrderReview.Enabled = false;*/
    }

    public Label UserFeedBack
    {
        get { return lblUserFeedback; }
        set { lblUserFeedback = value; }
    }

    public Label Tagline
    {
        get { return lblTagline; }
        set { lblTagline = value; }
    }

    public Label Footer
    {
        get { return lblFooter; }
        set { lblFooter = value; }
    }

    public LinkButton AboutUs
    {
        get { return lbtnAboutUs; }
        set { lbtnAboutUs = value; }
    }

    public LinkButton AccountDetails
    {
        get { return lbtnAccountDetails; }
        set { lbtnAccountDetails = value; }
    }

    public LinkButton Checkout
    {
        get { return lbtnCheckout; }
        set { lbtnCheckout = value; }
    }

    public LinkButton FAQ
    {
        get { return lbtnFAQ; }
        set { lbtnFAQ = value; }
    }

    public LinkButton HomePage
    {
        get { return lbtnHomePage; }
        set { lbtnHomePage = value; }
    }

    public LinkButton Login
    {
        get { return lbtnLogin; }
        set { lbtnLogin = value; }
    }

    public LinkButton OrderReview
    {
        get { return lbtnOrderReview; }
        set { lbtnOrderReview = value; }
    }
}
