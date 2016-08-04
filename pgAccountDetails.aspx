<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Web470WSC.master" CodeFile="pgAccountDetails.aspx.cs" Inherits="pgAccountDetails" %>
<%@ PreviousPageType VirtualPath="~/pgLogin.aspx" %>
<%@ MasterType VirtualPath ="~/Web470WSC.master" %>

    <asp:Content ID="ContentArea1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:Panel ID="panelAccountDetails" runat="server">
            <br />
            <asp:Label ID="Label" runat="server" Text="Username:" />
            <br />
            <asp:textbox ID="txtUsername" runat="server" Text="" />
            <br />
            <br />
            <asp:Label ID="Label10" runat="server" Text="Password:" />
            <br />
            <asp:textbox ID="txtPassword" runat="server" Width="130px" />
            <br />
            <asp:textbox ID="txtPasswordConfirm" runat="server" Width="130px" />
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
            <br />
            <br />
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" PostBackUrl="~/pgConfirm.aspx" />
            &nbsp;&nbsp;&nbsp; 
            <asp:Button ID="btnClearForm" runat="server" Text="Clear Form" OnClick="btnClearForm_Click" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" PostBackUrl="~/pgLogin.aspx" OnClick="btnClearForm_Click" />
            <br />
            <br />
        </asp:Panel>
        </asp:Content>
    <asp:Content ID="ContentArea2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
        <br />
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblSearch" runat="server" Text="Search Username:" />
        &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtSearch" runat="server" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnFindUsername" runat="server" Text="Find Username" OnClick="btnFindUsername_Click" />
        <br />
        <br />
        <asp:Label ID="lblCustID" runat="server" Text="User ID:" />
        <asp:Label ID="customerID" runat="server" Text="" />
        <br />
        <asp:Label ID="lblCustList" runat="server" Text="User List:" />
        <br />
        <asp:GridView ID="gvCustomerList" runat="server" Font-Size="9" />
        <br />
        <br />
        <asp:Button ID="btnDelete" runat="server" Text="Delete User" OnClick="btnDelete_Click" />
        <br />
        <br />
        <asp:Label ID="lblCurrentUser" runat="server" Text="" />
        <asp:Label ID="ID" runat="server" Text="" />
        <asp:Label ID="IDforUserID" runat="server" Text="" />
        </asp:Content>