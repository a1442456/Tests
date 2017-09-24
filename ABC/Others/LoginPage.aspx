<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainPage.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="ABC.Else.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="server">
    <asp:Table runat="server" ID="tblLogin">
        <asp:TableRow>
            <asp:TableCell>
                <asp:label id="lblLogin" Text="Login" runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtbxLogin" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:label id="lblPassword" Text="Password" runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtbxPassword" runat="server" Text="Password" TextMode="Password"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2" HorizontalAlign="Center" BackColor="#ffffff">
             <asp:Button id="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click"/>
            </asp:TableCell>            
        </asp:TableRow>
    </asp:Table>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphGreetings" runat="server">

    <asp:Label ID="lblGreetings" runat="server" CssClass="lblGreetings">Welcome to ABC-Tests<br/>Login Page</asp:Label>

</asp:Content>