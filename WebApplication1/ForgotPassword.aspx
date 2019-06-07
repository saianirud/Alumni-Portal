<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="WebApplication1.ForgotPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="App_Themes/ForgotPassword/ForgotPassword.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="maindiv" runat="server">
    <div runat="server" class="maindiv-content">
    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/closebutton.png" OnClick="ImageButton1_Click" CssClass="imageButton" CausesValidation="false"/>
    <div id="id1" class="container" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Registration No." Font-Bold="true"></asp:Label><asp:Label ID="Label2" runat="server" Text=" *" CssClass="star"></asp:Label><br/>
    <asp:TextBox ID="TextBox1" runat="server" CssClass="input"></asp:TextBox><br/>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RegNo Required" ControlToValidate="TextBox1" CssClass="validator"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter only Numbers" ControlToValidate="TextBox1" ValidationExpression="[0-9]{9}" CssClass="validator"></asp:RegularExpressionValidator>
    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="No such RegNo." ControlToValidate="TextBox1" OnServerValidate="CustomValidator1_ServerValidate" CssClass="validator"></asp:CustomValidator><br/><br/>
    <asp:Button ID="Button1" runat="server" Text="Next" CssClass="button" OnClick="Button1_Click" CausesValidation="false"/>
    </div>

    <div id="id2" class="container" runat="server">
    <asp:Label ID="Label5" runat="server" Text="Secret Question" Font-Bold="true"></asp:Label><asp:Label ID="Label6" runat="server" Text=" *" CssClass="star"></asp:Label><br/>
    <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem Text="Where were you born?" Value="0"/>
        <asp:ListItem Text="What was your first car?" Value="1"/>
        <asp:ListItem Text="What was the name of your first school?" Value="2"/>
        <asp:ListItem Text="What is the mother's maiden name?" Value="3"/>
        <asp:ListItem Text="What is your pet name?" Value="4"/>
    </asp:DropDownList><br/><br/>
    <asp:Label ID="Label3" runat="server" Text="Answer" Font-Bold="true"></asp:Label><asp:Label ID="Label4" runat="server" Text=" *" CssClass="star"></asp:Label><br/>
    <asp:TextBox ID="TextBox2" runat="server" CssClass="input"></asp:TextBox><br/>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Asnwer Required" ControlToValidate="TextBox2" CssClass="validator"></asp:RequiredFieldValidator>
    <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="Incorrect Question/Answer" ControlToValidate="TextBox2" OnServerValidate="CustomValidator2_ServerValidate" CssClass="validator"></asp:CustomValidator><br/><br/>
    <asp:Button ID="Button2" runat="server" Text="Next" CssClass="button" OnClick="Button2_Click" CausesValidation="false"/>
    </div>

    <div id="id3" class="container" runat="server">
    <asp:Label ID="Label7" runat="server" Text="Password" Font-Bold="true"></asp:Label><asp:Label ID="Label8" runat="server" Text=" *" CssClass="star"></asp:Label><br/>
    <asp:TextBox ID="TextBox3" runat="server" CssClass="input" TextMode="Password"></asp:TextBox><br/>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Password Required" ControlToValidate="TextBox3" CssClass="validator"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Minimum Password length is 4 characters" ControlToValidate="TextBox2" ValidationExpression="\S{4,20}" CssClass="validator"></asp:RegularExpressionValidator><br/><br/><br/><br/>
    <asp:Label ID="Label9" runat="server" Text=" Confirm Password" Font-Bold="true"></asp:Label><asp:Label ID="Label10" runat="server" Text=" *" CssClass="star"></asp:Label><br/>
    <asp:TextBox ID="TextBox4" runat="server" CssClass="input" TextMode="Password"></asp:TextBox><br/>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Retype Password" ControlToValidate="TextBox4" CssClass="validator"></asp:RequiredFieldValidator>
    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password Mismatch" ControlToValidate="TextBox4" ControlToCompare="TextBox3" Operator="Equal" type="String" CssClass="validator"></asp:CompareValidator><br/><br/>
    <asp:Button ID="Button3" runat="server" Text="Submit" CssClass="button" OnClick="Button3_Click" CausesValidation="false"/>
    </div>
    </div>
    </div>
</asp:Content>
