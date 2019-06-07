<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="WebApplication1.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="App_Themes/ContactUs/ContactUs.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div runat="server" class="maindiv">
        <div runat="server" class="div">
            <asp:Label ID="Label1" runat="server" Text="Name: Sai Anirud"></asp:Label><br/>
            <asp:Label ID="Label2" runat="server" Text="Phone Number: 9591966940"></asp:Label><br/>
            <asp:Label ID="Label3" runat="server" Text="Email ID: saianirudh1000@gmail.com"></asp:Label>
        </div>
        <div runat="server" class="div" style="border-top:2px solid">
            <asp:Label ID="Label4" runat="server" Text="Name: Dheeraj Reddy"></asp:Label><br/>
            <asp:Label ID="Label5" runat="server" Text="Phone Number: 7760699210"></asp:Label><br/>
            <asp:Label ID="Label6" runat="server" Text="Email ID: dheerajcool77@gmail.com"></asp:Label>
        </div>
    </div>
</asp:Content>
