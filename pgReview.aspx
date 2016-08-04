<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Web470WSC.master" CodeFile="pgReview.aspx.cs" Inherits="pgReview" %>
<%@ MasterType VirtualPath ="~/Web470WSC.master" %>


    <asp:Content ID="ContentArea1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:Panel ID="panelReLogin" runat="server">
            <br />
            <br />
            <asp:Label ID="lblUserID" runat="server" Text="Username:" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:textbox ID="txtUserID" runat="server" Width="130px" />
            <br />
            <asp:Label ID="lblPassword" runat="server" Text="Password:" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:textbox ID="txtPassword" runat="server" TextMode="Password" Width="130px" />
            <br />
            <br />
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" Width="150px" />
            <br />
            <br />
        </asp:Panel>
        
        <asp:Panel ID="panelReview" runat="server">
            <br />
            <asp:Label ID="lblOrderSearch" runat="server" Text="Order Number:" />
            <br />
            <asp:TextBox ID="txtOrderNumber" runat="server" Text="" />
            <br />
            <asp:Button ID="btnScan" runat="server" Text="Scan" />
            <br />
            <br />
            <asp:Label ID="lblCustomerList" runat="server" Text="Full Customer List:" />
            <br />
            <asp:GridView ID="gvCustomerList" runat="server" />
            <br />
            <br />
            <asp:Label ID="lblOrderListings" runat="server" Text="Full Order List:" />
            <br />
            <asp:GridView ID="gvOrderListings" runat="server" />
        </asp:Panel>
        <br />
        <br />
    </asp:Content>
    <asp:Content ID="ContentArea2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
        <asp:Panel ID="panelReview2" runat="server">
            <br />
            <asp:Label ID="lblApproval" runat="server" Text="Order Approval:" />
            <br />
            <asp:CheckBoxList ID="chkApproval" runat="server" RepeatDirection="Horizontal"  >
                <asp:ListItem>Approved</asp:ListItem>
                <asp:ListItem>Rejected</asp:ListItem>
                </asp:CheckBoxList>

            <br />
            <asp:Label ID="lblQuality" runat="server" Text="Quality Assurance Check" />
            <br />
            <asp:CheckBoxList ID="chkQuality" runat="server" RepeatDirection="Horizontal"  >
                <asp:ListItem>Complete</asp:ListItem>
                <asp:ListItem>Incomplete</asp:ListItem>
                </asp:CheckBoxList>
            <br />
            <asp:Label ID="lblIncompleteReason" runat="server" Text="Reason:" />
            <br />
            <asp:TextBox ID="txtReason" runat="server" Text="" />
            <br />
            <br />
            <asp:Button ID="btnUpdate" runat="server" Text="Update" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
            <br />
            <br />
            <asp:Label ID="lblCurrentUser" runat="server" Text="" />
        </asp:Panel>
        <br />
        <br />
    </asp:Content>