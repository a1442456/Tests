<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainPage.Master" AutoEventWireup="true" CodeBehind="AddingTestPage.aspx.cs" Inherits="ABC.Admin.AddingTestPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="server">

   
    <asp:Table ID="tblMain" runat="server">
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="lblTheme" runat="server" Text ="Theme"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:DropDownList ID="ddlTheme" runat="server" OnSelectedIndexChanged="ddlTheme_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="txtbxTheme"  runat="server" OnTextChanged="txtbxTheme_TextChanged" ></asp:TextBox></asp:TableCell>
            <asp:TableCell BackColor="#ffffff"><asp:Button ID="btnAddTheme"  runat="server" Text="Add Theme" OnClick="btnAddTheme_Click" /></asp:TableCell>
            <asp:TableCell BackColor="#ffffff"><asp:Button ID="btnDeleteTheme"  runat="server" Text="Delete Theme" OnClick="btnDeleteTheme_Click" Width="200" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="lblSubTheme" runat="server" Text ="SubTheme"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:DropDownList ID="ddlSubTheme" runat="server" OnSelectedIndexChanged="ddlSubTheme_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="txtbxSubTheme" runat="server" OnTextChanged="txtbxSubTheme_TextChanged" ></asp:TextBox></asp:TableCell>
            <asp:TableCell BackColor="#ffffff"><asp:Button ID="btnAddSubTheme" runat="server" Text="Add SubTheme" OnClick="btnAddSubTheme_Click" /></asp:TableCell>
            <asp:TableCell BackColor="#ffffff"><asp:Button ID="btnDeleteSubTheme"  runat="server" Text="Delete SubTheme" OnClick="btnDeleteSubTheme_Click" Width="200" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="lblQuestion" runat="server" Text="Questions"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:DropDownList ID="ddlQuestion" runat="server" OnSelectedIndexChanged="ddlQuestion_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="txtbxQuestion" runat="server" OnTextChanged="txtbxQuestion_TextChanged"></asp:TextBox></asp:TableCell>
            <asp:TableCell BackColor="#ffffff"><asp:Button ID="btnAddQuestion" runat="server" Text="Add Question" OnClick="btnAddQuestion_Click" /></asp:TableCell>
            <asp:TableCell BackColor="#ffffff"><asp:Button ID="btnDeleteQuestion"  runat="server" Text="Delete Question" OnClick="btnDeleteQuestion_Click" Width="200" /></asp:TableCell>
        </asp:TableRow>
        
         <asp:TableRow>             
             <asp:TableCell RowSpan="2">
                 <asp:label text="Answers" runat="server" ID="lblAnswer" />                 
             </asp:TableCell>
           <asp:TableCell ColumnSpan="2">               
                 <asp:Label ID="lblAnswerNote"   runat="server" Text="✓ - Answer is Right"></asp:Label>
           </asp:TableCell>
             <asp:TableCell BackColor="#ffffff">
               
             </asp:TableCell>
             <asp:TableCell BackColor="#ffffff" RowSpan="2">
                 
             </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign ="Left">                
                <asp:Table ID="tblAnswers" runat="server"></asp:Table>
                <asp:button text="Save Changes" ID="btnSaveChanges" runat="server" OnClick="btnSaveChanges_Click" />                                               
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtbxAnswer" runat="server"></asp:TextBox><asp:CheckBox ID="chbxIsRightAnswer" runat="server" />
            </asp:TableCell>
            <asp:TableCell BackColor="#ffffff">
                <asp:Button ID="btnAddAnnwer" runat="server" Text="Add Answer" OnClick="btnAddAnnwer_Click" />
            </asp:TableCell>
        </asp:TableRow>        
    </asp:Table>

    <asp:Label runat="server" ID="lblTester" />

    
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphGreetings" runat="server">

    <asp:Label ID="lblGreetings" runat="server" CssClass="lblGreetings">Welcome to ABC-Tests<br/>Add test</asp:Label>

</asp:Content>
