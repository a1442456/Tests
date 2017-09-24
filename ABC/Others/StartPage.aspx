<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainPage.Master" AutoEventWireup="true" CodeBehind="StartPage.aspx.cs" Inherits="ABC.test" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
   
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="cphGreetings" runat="server">
    <asp:Label ID="lblGreetings" runat="server" CssClass="lblGreetings">Welcome to ABC-Tests</asp:Label>
</asp:Content>
