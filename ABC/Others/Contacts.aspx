<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainPage.Master" AutoEventWireup="true" CodeBehind="Contacts.aspx.cs" Inherits="ABC.Else.Contacts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="server">
    This is ContactPage
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphGreetings" runat="server">

    <asp:Label ID="lblGreetings" runat="server" CssClass="lblGreetings">Welcome to ABC-Tests<br/>Contacts</asp:Label>

</asp:Content>