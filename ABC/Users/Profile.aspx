<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainPage.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="ABC.User.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphGreetings" runat="server">    
    Profile Page
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <asp:Table ID="tblMain" runat="server">
        <asp:TableRow>
            <asp:TableCell ColumnSpan ="2">Choose style</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Button ID="btnGrayStyle" runat="server" Text="Gray Style" OnClick="btnGrayStyle_Click"/>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnBlueStyle" runat="server" Text="Blue Style" OnClick="btnBlueStyle_Click"/>
            </asp:TableCell>
        </asp:TableRow>       
    </asp:Table>
    <asp:button ID="btnStatistic" runat="server" text="Statistic" OnClick="btnStatistic_Click"/>
    
    
    
</asp:Content>
