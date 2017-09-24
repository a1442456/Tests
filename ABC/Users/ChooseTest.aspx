<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainPage.Master" AutoEventWireup="true" CodeBehind="ChooseTest.aspx.cs" Inherits="ABC.User.ChooseTest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="server">
    <asp:Table runat="server" ID="tblMain">
        <asp:TableRow>
            <asp:TableCell><asp:DropDownList runat="server" ID="ddlTheme" OnSelectedIndexChanged="ddlTheme_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:DropDownList runat="server" ID="ddlSubTheme"></asp:DropDownList></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow >
            <asp:TableCell HorizontalAlign="Center" BackColor="#ffffff"><asp:Button runat="server" ID="btnNext" Text="Next" OnClick="btnNext_Click" /> </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    
    
       
    
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphGreetings" runat="server">

    <asp:Label ID="lblGreetings" runat="server" CssClass="lblGreetings">Welcome to ABC-Tests<br/>Choose Test</asp:Label>

</asp:Content>