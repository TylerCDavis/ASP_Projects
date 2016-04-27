<%@ Page Title="Unauthorized" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="unauthorized.aspx.cs" Inherits="unauthorized" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>You Are Unauthorized to View This Page</h2>
    <asp:label ID="lblUnauth" runat="server" text="Label"></asp:label>
</asp:Content>

