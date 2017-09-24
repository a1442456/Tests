<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainPage.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="ABC.Else.Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="server">
    <%--I set id to cells to change their visible state--%>
    <asp:Table runat="server" ID="tblMain" Width="500" >
        <asp:TableRow>
            <asp:TableCell>
                <asp:label text="Login" ID="lblLogin" runat="server" />
            </asp:TableCell>
            <asp:TableCell HorizontalAlign ="Center">
                <asp:TextBox ID="txtbxLogin" runat="server" Text="Login" ></asp:TextBox>
            </asp:TableCell>

        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:label text="Password" ID="lblPassword" runat="server"  />
            </asp:TableCell>
            <asp:TableCell HorizontalAlign ="Center">
                <asp:TextBox ID="txtbxPassword" runat="server" Text="Password"></asp:TextBox>
            </asp:TableCell>

        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>
                <asp:label text="Mail" ID="lblMail" runat="server" />
            </asp:TableCell>
            <asp:TableCell HorizontalAlign ="Center">
                <asp:TextBox ID="txtbxMail" runat="server" Text="Mail"></asp:TextBox>
            </asp:TableCell>

        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>
                <asp:label text="Question" ID="lblQuestion" runat="server" />
            </asp:TableCell>
            <asp:TableCell HorizontalAlign ="Center">
                <asp:TextBox ID="txtbxQuestion" runat="server" Text="SecretQuestion"></asp:TextBox>
            </asp:TableCell>

        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>
                <asp:label text="Answer" ID="lblAnswer" runat="server" />
            </asp:TableCell>
            <asp:TableCell HorizontalAlign ="Center">
                <asp:TextBox ID="txtbxAnswer" runat="server" Text="SecretAnswer"></asp:TextBox>
            </asp:TableCell>

        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell HorizontalAlign ="Center" ColumnSpan="2">
               <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />  
                <asp:Button ID="btnGoBack" runat="server" Text="Go Back" OnClick="btnGoBack_Click" />
                <asp:Label ID="lblStatus" runat="server" Visible="false" Text=""></asp:Label>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                <asp:Label ID="lblValidateInfo" runat="server" Text="Errors:"></asp:Label>                
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            
            <asp:TableCell ColumnSpan ="2">                
                <asp:Label Text="Login errors:" ID="lblValidateLogin" runat="server" />
                <asp:RequiredFieldValidator ID="rfvLogin" runat="server" ErrorMessage="*field should be filled"
                    ControlToValidate="txtbxLogin" Text="*field should be filled" ForeColor="#760c0f"></asp:RequiredFieldValidator>
                <br />
                <asp:Label Text="Password errors:" ID="lblValidatePassword" runat="server" />
                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="*field should be filled"
                    ControlToValidate="txtbxPassword" Text="*field should be filled" ForeColor="#760c0f"></asp:RequiredFieldValidator>
                <br />
                <asp:RegularExpressionValidator ID="revPassword" ControlToValidate="txtbxPassword"
                    runat="server" ValidationExpression="(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{6,})$"
                    ErrorMessage="The password should contain atleast 6 chars and atleast one letter and digit and shouldn't contain special signs"
                    ForeColor="#760c0f" Display="Dynamic"></asp:RegularExpressionValidator>
                <br />
                <asp:Label Text="Mail errors:" ID="lblValidateMail" runat="server" />
                <asp:RequiredFieldValidator ID="rfvMail" runat="server" ErrorMessage="*field should be filled"
                    ControlToValidate="txtbxMail" Text="*field should be filled" ForeColor="#760c0f"></asp:RequiredFieldValidator>
                <br />
                <asp:Label Text="Secret Qestion errors:" ID="lblValidateQestion" runat="server" />
                <asp:RequiredFieldValidator ID="rfvQuestion" runat="server" ErrorMessage="*field should be filled"
                    ControlToValidate="txtbxQuestion" Text="*field should be filled" ForeColor="#760c0f"></asp:RequiredFieldValidator>
                <br />
                <asp:Label Text="Secret Answer errors:" ID="lblValidateAnswer" runat="server" />
                <asp:RequiredFieldValidator ID="rfvAnswer" runat="server" ErrorMessage="*field should be filled"
                    ControlToValidate="txtbxAnswer" Text="*field should be filled" ForeColor="#760c0f"></asp:RequiredFieldValidator>                
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphGreetings" runat="server">

    <asp:Label ID="lblGreetings" runat="server" CssClass="lblGreetings">Welcome to ABC-Tests<br/>Registration</asp:Label>

</asp:Content>