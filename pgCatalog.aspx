<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Web470WSC.master" CodeFile="pgCatalog.aspx.cs" Inherits="pgCatalog" %>
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
        
        <asp:Panel ID="panelCatalog" runat="server">
            <br />
            <br />
            <asp:Label ID="lblIntro" runat="server" Text="Welcome to Williams Specialty Company; here for all your engraving and printing needs. We hope that you find what you came for and will come again sometime! Feel free to continue exploring the catalog or place an order by pressing the Place an Order button below." />
            <br />
            &nbsp;&nbsp;&nbsp;
            <br />
            <asp:Button ID="btnPlaceOrder" runat="server" Text="Place an Order" PostBackUrl="~/pgOrder.aspx" OnClick="btnPlaceOrder_Click" />
            <br />
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;
            <img src="Images/Pisanello,_Medaglia_di_Cecilia_Gonzaga,_2011.JPG" width="250" height="250" />
            &nbsp;&nbsp;&nbsp;
            <img src="Images/Commander_in_Chief's_Trophy.jpg" width="250" height="250" />
            &nbsp;&nbsp;&nbsp;
            <img src="Images/engravingprintingpress.jpg" width="250" height="250" />&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;
            <img src="Images/Norblin_Ecce_Homo_02.jpg" width="250" height="250" />
            &nbsp;&nbsp;&nbsp;
            <img src="Images/WWEplaque_700.jpg" width="250" height="250" />&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
        <asp:Label ID="lblCurrentUser" runat="server" Text="" />
        </asp:Panel>
    </asp:Content>
