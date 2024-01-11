<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registracija.aspx.cs" Inherits="ShopForms.Registracija" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h4>Registriraj se</h4>
    <asp:Label ID="Label1" runat="server" Text="Korisničko ime:"></asp:Label>
    <asp:TextBox ID="tb_username" runat="server"></asp:TextBox><br />
    <asp:Label ID="Label4" runat="server" Text="Puno ime:"></asp:Label>
    <asp:TextBox ID="tb_fullname" runat="server"></asp:TextBox><br />
    <asp:Label ID="Label2" runat="server" Text="Lozinka:"></asp:Label>
    <asp:TextBox ID="tb_pass" runat="server" TextMode="Password"></asp:TextBox><br />
    <asp:Label ID="Label3" runat="server" Text="Ponovljena lozinka:"></asp:Label>
    <asp:TextBox ID="tb_passrepeat" runat="server" TextMode="Password"></asp:TextBox><br />
    <asp:Button ID="buttonReg" runat="server" Text="Registriraj" OnClick="buttonReg_Click"/>

    <br />
    <br />
        
    <asp:Label ID="lbl_error" runat="server" Text=""></asp:Label>
</asp:Content>
