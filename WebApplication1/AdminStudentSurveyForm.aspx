<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="AdminStudentSurveyForm.aspx.cs" Inherits="WebApplication1.AdminStudentSurveyForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="App_Themes/StudentHomePage/StudentHomePage.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" CssClass="label"></asp:Label>
    <asp:GridView ID="GridView1" runat="server" CssClass="gridview" ></asp:GridView>
</asp:Content>
