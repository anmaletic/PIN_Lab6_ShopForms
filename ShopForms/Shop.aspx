<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Shop.aspx.cs" Inherits="ShopForms.Shop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<h2>Shop</h2>
    <asp:Label ID="Label1" runat="server" Text="Naziv:"></asp:Label>
    <asp:TextBox ID="tb_name" runat="server"></asp:TextBox><br />
    <asp:Label ID="Label2" runat="server" Text="Opis:"></asp:Label>
    <asp:TextBox ID="tb_desc" runat="server"></asp:TextBox>
    <br />

    <asp:Label ID="lbl_error" runat="server" Text=""></asp:Label>
    <br />
    <asp:Button ID="buttonSpremi" runat="server" Text="Spremi" OnClick="buttonSpremi_Click"/>

    <br />
    <br />

    <asp:GridView ID="gridProducts" runat="server">
    </asp:GridView>
</asp:Content>
