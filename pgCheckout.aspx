<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Web470WSC.master" CodeFile="pgCheckout.aspx.cs" Inherits="pgCheckout" %>
<%@ PreviousPageType VirtualPath="~/pgOrder.aspx" %>
<%@ MasterType VirtualPath ="~/Web470WSC.master" %>

<asp:Content ID="ContentArea1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:Panel ID="panelAccountDetails" runat="server">
            <br />
            <asp:Label ID="lblCustID" runat="server" Text="User ID:" />
            <asp:Label ID="customerID" runat="server" Text="" />
            <br />
            <asp:Label ID="Label" runat="server" Text="Username:" />
            <br />
            <asp:textbox ID="txtUsername" runat="server" Text="" />
            <br />
            <br />
            <asp:Label ID="Label10" runat="server" Text="Password:" />
            <br />
            <asp:textbox ID="txtPassword" runat="server" TextMode="Password" Width="130px" />
            <br />
            <asp:textbox ID="txtPasswordConfirm" runat="server" TextMode="Password" Width="130px" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="First Name:" />
            <br />
            <asp:textbox ID="txtFirstName" runat="server" Text="" />
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Last Name:" />
            <br />
            <asp:textbox ID="txtLastName" runat="server" Text="" />
            <br />
            <br />
            <asp:Label ID="Label9" runat="server" Text="Email Address:" />
            <br />
            <asp:textbox ID="txtEmail" runat="server" Text="" />
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Address:" />
            <br />
            <asp:textbox ID="txtLine1" runat="server" Text="" Width="270px" />
            <br />
            <asp:textbox ID="txtLine2" runat="server" Text="" Width="270px" />
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" Text="City:" />
            <br />
            <asp:textbox ID="txtCity" runat="server" Text="" />
            <br />
            <br />
            <asp:Label ID="Label6" runat="server" Text="State:" />
            <br />
            <asp:textbox ID="txtState" runat="server" Text="" />
            <br />
            <br />
            <asp:Label ID="Label17" runat="server" Text="Phone Number:" />
            <br />
            <asp:textbox ID="txtPhone" runat="server" Text="" />
            <br />
            <br />
            <asp:Label ID="Label7" runat="server" Text="Payment Method" />
            <br />
            <asp:RadioButtonList ID="rblCCType" runat="server" RepeatDirection="Vertical">
                <asp:ListItem>Visa</asp:ListItem>
                <asp:ListItem>Master Card</asp:ListItem>
                <asp:ListItem>Discover</asp:ListItem>
            </asp:RadioButtonList>
            <asp:Label ID="Label8" runat="server" Text="Credit Card Number" />
            <br />
            <asp:textbox ID="txtCCNumber" runat="server" Text="" Width="220px" />
        </asp:Panel>
            <br />
            <br />
        </asp:Content>

        <asp:Content ID="ContentArea2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
            <asp:Panel ID="panelCart" runat="server">
            <br />
            <asp:Label ID="lblCart" runat="server" Text="Cart:" />
            <br />
            <asp:GridView ID="gvCart" runat="server" />
            <br />
            <br />
        </asp:Panel>

        <asp:Panel ID="panelOrder" runat="server">
            <br />
            <asp:Label ID="lblOrder" runat="server" Text="Order:" />
            <br />
            <asp:GridView ID="gvOrder" runat="server" />
            <br />
            <br />
        </asp:Panel>
        <asp:Button ID="btnCheckout" runat="server" Text="Checkout" OnClick="btnCheckout_Click" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnClear_Click" PostBackUrl="~/pgCatalog.aspx" />
        <br />
        <br />
        <asp:Label ID="lblCurrentUser" runat="server" Text="" />
            <asp:Label ID="lblOrderNum" runat="server" Text="" />
        </asp:Content>