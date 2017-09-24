<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainPage.Master" AutoEventWireup="true" CodeBehind="Statistics.aspx.cs" Inherits="ABC.Users.Statistics" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphGreetings" runat="server">    
    Statistic's page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <asp:Table ID="tblStatistic" runat="server"></asp:Table>
</asp:Content>
