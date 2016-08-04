<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Web470WSC.master" CodeFile="pgOrder.aspx.cs" Inherits="pgOrder" %>
<%@ PreviousPageType VirtualPath="~/pgCatalog.aspx" %>
<%@ MasterType VirtualPath ="~/Web470WSC.master" %>

<asp:Content ID="ContentArea1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:Panel ID="panelOrder" runat="server">
            <br />
            <br /><asp:Label ID="lblJob" runat="server" Text="Select Job Type:" />
            <br />
            <asp:CheckBoxList ID="chkJobType" runat="server"  >
                <asp:ListItem>Print</asp:ListItem>
                <asp:ListItem>Engraving</asp:ListItem>
            </asp:CheckBoxList>
            <br />
            <asp:Label ID="lblMediaType" runat="server" Text="Select Media:" />
            <br />
            <asp:CheckBoxList ID="chkMedia" runat="server"  >
                <asp:ListItem>Clothing</asp:ListItem>
                <asp:ListItem>Plaque</asp:ListItem>
                <asp:ListItem>Trophy</asp:ListItem>
            </asp:CheckBoxList>
            <br />
            <br />
            <asp:Button ID="btnAdd" runat="server" Text="Add to Cart" OnClick="btnAdd_Click" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnClear" runat="server" Text="Clear Form" OnClick="btnClear_Click" />
            <br />
            <br />
        </asp:Panel>
        <asp:Panel ID="panelCurrentOrder" runat="server">
            <br />
            <asp:Label ID="lblOrderNumber" runat="server" Text="Order Number" />
            <br />
            <asp:Label ID="lblOrderNum" runat="server" Text="" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Media:" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblMediaOutput" runat="server" />
            <br />
            <asp:Label ID="Label" runat="server" Text="Job Type:" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblJobTypeOutput" runat="server" />
            <br />
            <br />
            <asp:Label ID="lblMessage" runat="server" Text="Enter job message text or request notes here:" />
            <br />
            <asp:TextBox ID="txtMessage" runat="server" Text="" Height="164px" Width="293px" />
            <br />
            <br />
            <asp:Label ID="lblCurrentCustomer" runat="server" Text="" />
            <br />
            <br />
            <asp:Button ID="btnConfirm" runat="server" Text="Confirm" OnClick="btnConfirm_Click" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnEmpty" runat="server" Text="Empty Cart" OnClick="btnEmpty_Click" />
            <br />
            <br />
        </asp:Panel>
    </asp:Content>
    <asp:Content ID="ContentArea2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
        
        <asp:Panel ID="panelCart" runat="server">
            <br />
            <asp:Label ID="lblCart" runat="server" Text="Cart:" />
            <br />
            <asp:GridView ID="gvCart" runat="server" />
            <br />
            <br />
            <asp:Button ID="btnCheckout" runat="server" Text="Checkout" PostBackUrl="~/pgCheckout.aspx" OnClick="btnCheckout_Click" />
            <br />
            <br />
            <asp:Label ID="lblCurrentUser" runat="server" Text="" />
        </asp:Panel>
    </asp:Content>