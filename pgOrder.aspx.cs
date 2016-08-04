using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pgOrder : System.Web.UI.Page
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

        lblOrderNum.Visible = false;
        lblOrderNum.Text = "0";
        lblCurrentUser.Visible = true;

        foreach (ListItem li in chkJobType.Items)
        {
            //add margin as css style
            li.Attributes.CssStyle.Add("margin-left", "75px");
        }

        foreach (ListItem li in chkMedia.Items)
        {
            //add margin as css style
            li.Attributes.CssStyle.Add("margin-left", "75px");
        }

        // Add data to myBusinessLayer
        myBusinessLayer = new clsBusinessLayer(Server.MapPath("~/App_Data/"));

        try
        {
            if (PreviousPage.IsCrossPagePostBack)
            {
                lblCurrentUser.Text = PreviousPage.CurrentUser.Text;
            }
        }
        catch (Exception error)
        {
            Master.UserFeedBack.Text = error.Message;
        }

    }

    public Label CurrentCustomer
    {
        get { return lblCurrentCustomer; }
    }

    public Label OrderNum
    {
        get { return lblOrderNum; }
    }

    public TextBox Message
    {
        get { return txtMessage; }
    }

    public GridView Cart
    {
        get { return gvCart; }
    }

    public Label JobType
    {
        get { return lblJobTypeOutput; }
    }

    public Label Media
    {
        get { return lblMediaOutput; }
    }

    private void ClearInputs(ControlCollection ctrls)
    {
        lblOrderNum.Text = string.Empty;
        lblJobTypeOutput.Text = string.Empty;
        lblMediaOutput.Text = string.Empty;

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

    private dsAccounts BindCartGridView()
    {
        // Pulls data from the database for use
        string tempPath = Server.MapPath("~/App_Data/Accounts.mdb");
        clsDataLayer myDataLayer = new clsDataLayer(tempPath);

        // Adds data from the first to the second
        dsAccounts cartListing = myDataLayer.FillCart(lblCurrentCustomer.Text);

        // Adds data from the first to the second
        gvCart.DataSource = cartListing.tblCart;

        // Caches data collected
        gvCart.DataBind();
        Cache.Insert("CustomerDataSet", cartListing);

        return cartListing;
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        // Create the list to store.
        List<String> chkJobTypeList = new List<string>();
        List<String> chkMediaList = new List<string>();

        // Loop through each item.
        foreach (ListItem item in chkJobType.Items)
        {
            if (item.Selected)
            {
                // If the item is selected, add the value to the list.
                chkJobTypeList.Add(item.Value);
            }
        }

        // Loop through each item.
        foreach (ListItem item in chkMedia.Items)
        {
            if (item.Selected)
            {
                // If the item is selected, add the value to the list.
                chkMediaList.Add(item.Value);
            }
        }

        // Join the string together using the , delimiter.
        lblJobTypeOutput.Text = String.Join(", ", chkJobTypeList.ToArray());

        // Join the string together using the , delimiter.
        lblMediaOutput.Text = String.Join(", ", chkMediaList.ToArray());

        panelOrder.Enabled = false;

        }

    protected void btnEmpty_Click(object sender, EventArgs e)
    {
        myBusinessLayer.DeleteCart(Convert.ToInt32(lblOrderNum.Text));
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearInputs(Page.Controls);

        panelOrder.Enabled = true;
    }

    protected void btnConfirm_Click(object sender, EventArgs e)
    {
         myBusinessLayer.AddToCart(lblCurrentCustomer.Text, lblJobTypeOutput.Text, lblMediaOutput.Text, txtMessage.Text, Convert.ToInt32(lblOrderNum.Text));

        panelOrder.Enabled = true;
        lblMediaOutput.Text = "";
        lblJobTypeOutput.Text = "";
        txtMessage.Text = "";

        BindCartGridView();

    }

    protected void btnCheckout_Click(object sender, EventArgs e)
    {
        lblCurrentUser.Text = lblCurrentUser.Text;
    }
}