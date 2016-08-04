<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Web470WSC.master" CodeFile="pgConfirm.aspx.cs" Inherits="pgConfirm" %> 
<%@ PreviousPageType VirtualPath="~/pgAccountDetails.aspx" %>
<%@ MasterType VirtualPath ="~/Web470WSC.master" %>


    <asp:Content ID="ContentArea1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <br />
        <asp:Label ID="lblUsername" runat="server" Text="Username:" />
        &nbsp;&nbsp;&nbsp;
        <br />
        <asp:textbox ID="txtUsername" runat="server" Text="" />
        <br />
        <br />
        <asp:Label ID="lblPassword" runat="server" Text="Password:" />
        <br />
        <asp:textbox ID="txtPassword" runat="server" Width="130px" />
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
        <asp:Label ID="Label5" runat="server" Text="Address Line 1" />
        <br />
        <asp:textbox ID="txtLine1" runat="server" Text="" Width="270px" />
        <br />
        <asp:textbox ID="txtLine2" runat="server" Text="" Width="270px" />
        <br />
        <br />
        <asp:Label ID="Label7" runat="server" Text="City:" />
        <br />
        <asp:textbox ID="txtCity" runat="server" Text="" />
        <br />
        <br />
        <asp:Label ID="Label8" runat="server" Text="State:" />
        <br />
        <asp:textbox ID="txtState" runat="server" Text="" />
        <br />
        <br />
        <asp:Label ID="Label17" runat="server" Text="Phone Number:" />
        <br />
        <asp:textbox ID="txtPhone" runat="server" Text="" />
        <br />
        <br />
        <br />
        <asp:Label ID="Label12" runat="server" Text="Payment Method" />
        <br />
        <asp:RadioButtonList ID="rblCCType" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem>Visa</asp:ListItem><asp:ListItem>Master Card</asp:ListItem><asp:ListItem>Discover</asp:ListItem>
        </asp:RadioButtonList>
        <asp:Label ID="Label13" runat="server" Text="Credit Card Number" />
        <br />
        <asp:textbox ID="txtCCNumber" runat="server" Text="" Width="220px" />
        <br />
        <br />
        <asp:Button ID="btnConfirm" runat="server" Text="Confirm" OnClick="btnConfirm_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" PostBackUrl="~/pgAccountDetails.aspx" />
        <br />
        <br />
        <asp:Label ID="lblProceed" runat="server" Text="" />
        <br />
        <br />
        <asp:LinkButton ID="lbtnProceed" runat="server" Text="Proceed" PostBackUrl="~/pgCatalog.aspx" />
        <br />
        <br />
        <asp:Label ID="lblCurrentUser" runat="server" Text="" />
        <asp:Label ID="ID" runat="server" Text="" />
        <asp:Label ID="IDforUserID" runat="server" Text="" />
        <asp:Label ID="customerID" runat="server" Text="" />
    </asp:Content>