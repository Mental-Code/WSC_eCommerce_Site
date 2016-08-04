<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Web470WSC.master" CodeFile="pgLogin.aspx.cs" Inherits="pgLogin" %>
<%@ MasterType VirtualPath ="~/Web470WSC.master" %>


    <asp:Content ID="ContentArea1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
        <asp:LinkButton id="lbtnForgot" runat="server" Text="Forgot username and/or login?" />
        <br />
        <asp:LinkButton id="lbtnCreate" runat="server" Text="Don't have an account yet? Create one!" OnClick="lbtnCreate_Click" PostBackUrl="~/pgAccountDetails.aspx" />
        <br />
        <br />
        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" PostBackUrl="~/pgAccountDetails.aspx" Width="150px" />
        <br />
        <br />
        <asp:Label ID="lblCurrentUser" runat="server" />
    </asp:Content>