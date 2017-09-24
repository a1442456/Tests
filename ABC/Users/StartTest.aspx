<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainPage.Master" AutoEventWireup="true" CodeBehind="StartTest.aspx.cs" Inherits="ABC.User.StartTest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="server">  
    <asp:Table ID="tblTest" runat="server" CssClass="abc"></asp:Table>
           
    <asp:Button id="btnBack" runat="server"  Text="Go Back" OnClick="btnBack_Click"/>
            
    <asp:Button id="btnComplete" Text="Complete" runat="server" OnClick="btnComplete_Click" />
    <br/>
    <asp:Label id="lblResult" Text="" runat="server" />

    <asp:Label Text="text" runat="server" id="lblTester"/>
            
    
    
        
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphGreetings" runat="server">

    <asp:Label ID="lblGreetings" runat="server" CssClass="lblGreetings">Welcome to ABC-Tests<br/>Start Test</asp:Label>

</asp:Content>