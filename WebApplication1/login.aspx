<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebApplication1.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="App_Themes/LoginRegister/LoginRegister.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="id1" class="maindiv" runat="server">
    <div id="id2" class="maindiv-content animate" runat="server">
    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/closebutton.png" OnClick="ImageButton1_Click" CssClass="imageButton" CausesValidation="false"/>
    <div class="container" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Registartion No." Font-Bold="true"></asp:Label><asp:Label ID="Label4" runat="server" Text=" *" CssClass="star"></asp:Label><br/>
    <asp:TextBox ID="TextBox1" runat="server" CssClass="input"></asp:TextBox><br/>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RegNo Required" ControlToValidate="TextBox1" CssClass="validator"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Incorrect Format" ControlToValidate="TextBox1" ValidationExpression="[0-9]{9}" CssClass="validator"></asp:RegularExpressionValidator><br/><br/>
    <asp:Label ID="Label2" runat="server" Text="Password" Font-Bold="true"></asp:Label><asp:Label ID="Label5" runat="server" Text=" *" CssClass="star"></asp:Label><br/>
    <asp:TextBox ID="TextBox2" runat="server" CssClass="input" TextMode="Password"></asp:TextBox><br/>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Password Required" ControlToValidate="TextBox2" CssClass="validator"></asp:RequiredFieldValidator>
    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Incorrect RegNo/Password" ControlToValidate="TextBox2" OnServerValidate="CustomValidator1_ServerValidate" CssClass="validator"></asp:CustomValidator><br/>
    <asp:Button ID="Button1" runat="server" Text="Login" CssClass="button" OnClick="Button1_Click" CausesValidation="false"/>
    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CssClass="forgotpassword" CausesValidation="false">Forgot Password?</asp:LinkButton>
    </div>
    </div>
    </div>
</asp:Content>
