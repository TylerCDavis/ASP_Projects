<%@ Page Title="Login" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    
    <asp:Login ID="Login1" runat="server" DisplayRememberMe="False" OnAuthenticate="Login1_Authenticate1" OnLoggedIn="Login1_LoggedIn" UserNameLabelText="Email Address:"></asp:Login>
    <br />
    <table border="1" style="border-collapse: collapse">
        <tr>
            <td>Admin</td>
            <td>ghouse@gmail.com</td>
            <td>cuddy</td>
            
        </tr>
        <tr>
            <td>Player</td>
            <td>drily@canada.ca</td>
            <td>bluebirds</td>
        </tr>
        <tr>
            <td>Coach</td>
            <td>oliviab@rogers.com</td>
            <td>seasiders</td>
        </tr>
        <tr>
            <td>Referee</td>
            <td>asmith@gmail.com</td>
            <td>brewers</td>
        </tr>
    </table>
    
    
    
</asp:Content>

