<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebApplication1.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="App_Themes/LoginRegister/LoginRegister.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="id1" class="maindiv" runat="server">
    <div id="id2" runat="server" class="maindiv-content animate">
    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/closebutton.png" OnClick="ImageButton1_Click" CssClass="imageButton" CausesValidation="false"/>
    <div class="container" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Registration No." Font-Bold="true"></asp:Label><asp:Label ID="Label2" runat="server" Text=" *" CssClass="star"></asp:Label><br/>
    <asp:TextBox ID="TextBox1" runat="server" CssClass="input"></asp:TextBox><br/>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RegNo Required" ControlToValidate="TextBox1" CssClass="validator"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Incorrect Format" ControlToValidate="TextBox1" ValidationExpression="[0-9]{9}" CssClass="validator"></asp:RegularExpressionValidator>
    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="RegNo already exists" ControlToValidate="TextBox1" OnServerValidate="CustomValidator1_ServerValidate" CssClass="validator"></asp:CustomValidator><br/><br/>
    <asp:Label ID="Label3" runat="server" Text="Password" Font-Bold="true"></asp:Label><asp:Label ID="Label4" runat="server" Text=" *" CssClass="star"></asp:Label><br/>
    <asp:TextBox ID="TextBox2" runat="server" CssClass="input" TextMode="Password"></asp:TextBox><br/>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Password Required" ControlToValidate="TextBox2" CssClass="validator"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Minimum Password length is 4 characters" ControlToValidate="TextBox2" ValidationExpression="\S{4,20}" CssClass="validator"></asp:RegularExpressionValidator><br/><br/>
    <asp:Label ID="Label5" runat="server" Text=" Confirm Password" Font-Bold="true"></asp:Label><asp:Label ID="Label6" runat="server" Text=" *" CssClass="star"></asp:Label><br/>
    <asp:TextBox ID="TextBox3" runat="server" CssClass="input" TextMode="Password"></asp:TextBox><br/>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Retype Password" ControlToValidate="TextBox3" CssClass="validator"></asp:RequiredFieldValidator>
    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password Mismatch" ControlToValidate="TextBox3" ControlToCompare="TextBox2" Operator="Equal" type="String" CssClass="validator"></asp:CompareValidator><br/><br/>
    <asp:Button ID="Button1" runat="server" Text="Register" CssClass="button" OnClick="Button1_Click" CausesValidation="false"/>
    </div>
    </div>
    </div>
</asp:Content>
