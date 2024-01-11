<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ShopForms.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h4>Login</h4>
    <asp:Label ID="Label1" runat="server" Text="Korisničko ime:"></asp:Label>
    <asp:TextBox ID="tb_username" runat="server"></asp:TextBox><br />
    <asp:Label ID="Label2" runat="server" Text="Lozinka:"></asp:Label>
    <asp:TextBox ID="tb_pass" runat="server" TextMode="Password"></asp:TextBox><br />
    <asp:Button ID="buttonLogin" runat="server" Text="Prijava" OnClick="buttonLogin_Click"/>

    <br />
    <br />
        
    <asp:Label ID="lbl_error" runat="server" Text=""></asp:Label>
</asp:Content>
