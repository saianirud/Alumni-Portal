<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="FurtherRegistration.aspx.cs" Inherits="WebApplication1.FurtherRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="App_Themes/FurtherRegistration/FurtherRegistration.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="maindiv" runat="server">
        <div class="divbar" runat="server">
            <div id="id1" class="divbarcontent" runat="server">
                <asp:Label ID="Label1" runat="server" Text="1" CssClass="number"></asp:Label><asp:Label ID="Label2" runat="server" Text="Personal Details"></asp:Label>
            </div>
            <div id="id2" class="divbarcontent" runat="server">
                <asp:Label ID="Label3" runat="server" Text="2" CssClass="number"></asp:Label><asp:Label ID="Label4" runat="server" Text="Company Details"></asp:Label>
            </div>
            <div id="id3" class="divbarcontent" runat="server" style="padding-left:30px">
                <asp:Label ID="Label5" runat="server" Text="3" CssClass="number"></asp:Label><asp:Label ID="Label6" runat="server" Text="Secret Question"></asp:Label>
            </div>
        </div>
        <div id="id4" class="detailsdiv1" runat="server">
            <div class="subdetailsdiv" runat="server">
                <asp:Label ID="Label7" runat="server" Text="Name" CssClass="labels" Font-Bold="true"></asp:Label><asp:Label ID="Label8" runat="server" Text=" *" CssClass="star"></asp:Label><br/>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="input"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Name Required" ControlToValidate="TextBox1" CssClass="validator"></asp:RequiredFieldValidator><br/><br/>
                <asp:Label ID="Label9" runat="server" Text="Email ID" CssClass="labels" Font-Bold="true"></asp:Label><br/>
                <asp:TextBox ID="TextBox2" runat="server" CssClass="input"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Incorrect Format" CssClass="validator" ControlToValidate="TextBox2" ValidationExpression="\S+@\S+\.\S+"></asp:RegularExpressionValidator><br/><br/>
                <asp:Label ID="Label10" runat="server" Text="Branch" CssClass="labels" Font-Bold="true"></asp:Label><asp:Label ID="Label11" runat="server" Text=" *" CssClass="star"></asp:Label><br/>
                <asp:DropDownList ID="DropDownList3" CssClass="input" runat="server">
                    <asp:ListItem Text="Select"></asp:ListItem>
                    <asp:ListItem Text="Aeronautical"></asp:ListItem>
                    <asp:ListItem Text="Automobile"></asp:ListItem>
                    <asp:ListItem Text="Biomedical"></asp:ListItem>
                    <asp:ListItem Text="Biotechnology"></asp:ListItem>
                    <asp:ListItem Text="Chemical"></asp:ListItem>
                    <asp:ListItem Text="Civil"></asp:ListItem>
                    <asp:ListItem Text="CCE"></asp:ListItem>
                    <asp:ListItem Text="CSE"></asp:ListItem>
                    <asp:ListItem Text="EEE"></asp:ListItem>
                    <asp:ListItem Text="ECE"></asp:ListItem>
                    <asp:ListItem Text="IPE"></asp:ListItem>
                    <asp:ListItem Text="IT"></asp:ListItem>
                    <asp:ListItem Text="Mechanical"></asp:ListItem>
                    <asp:ListItem Text="Mechatronics"></asp:ListItem>
                </asp:DropDownList>
                <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Branch Required" CssClass="validator" ControlToValidate="DropDownList3" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator><br/><br/>
                <asp:Label ID="Label12" runat="server" Text="Gender" CssClass="labels" Font-Bold="true"></asp:Label><br/>
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="input">
                    <asp:ListItem Text="Select" />
                    <asp:ListItem Text="Male" Value="0"/>
                    <asp:ListItem Text="Female" Value="1"/>
                </asp:DropDownList>
            </div>
            <div class="subdetailsdiv" runat="server">
                <asp:Label ID="Label13" runat="server" Text="CGPA" CssClass="labels" Font-Bold="true"></asp:Label><br/>
                <asp:TextBox ID="TextBox4" runat="server" CssClass="input"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Incorrect Format" ControlToValidate="TextBox4" ValidationExpression="\d\.\d+" CssClass="validator"></asp:RegularExpressionValidator><br/><br/>
                <asp:Label ID="Label14" runat="server" Text="Mobile No" CssClass="labels" Font-Bold="true"></asp:Label><br/>
                <asp:TextBox ID="TextBox5" runat="server" CssClass="input"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Incorrect Format" CssClass="validator" ControlToValidate="TextBox5" ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator><br/><br/>
                <asp:Label ID="Label15" runat="server" Text="Passing Year" CssClass="labels" Font-Bold="true"><asp:Label ID="Label16" runat="server" Text=" *" CssClass="star"></asp:Label></asp:Label><br/>
                <asp:TextBox ID="TextBox6" runat="server" CssClass="input"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Passing Year Required" ControlToValidate="TextBox6" CssClass="validator"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Incorrect Year Format" ControlToValidate="TextBox6" ValidationExpression="[0-9]{4}" CssClass="validator"></asp:RegularExpressionValidator><br/>
                <asp:Label ID="Label17" runat="server" Text="Date of Birth" CssClass="labels" Font-Bold="true"></asp:Label><br/>
                <asp:TextBox ID="TextBox7" runat="server" CssClass="input" TextMode="Date"></asp:TextBox><br/><br/>
                <asp:Button ID="Button1" runat="server" Text="Next" CssClass="button" OnClick="Button1_Click" CausesValidation="false"/>
            </div>
        </div>

        <div id="id5" class="detailsdiv2" runat="server">
            <div class="subdetailsdiv" runat="server">
                <asp:Label ID="Label18" runat="server" Text="Company Name" CssClass="labels" Font-Bold="true"></asp:Label><asp:Label ID="Label19" runat="server" Text=" *" CssClass="star"></asp:Label><br/>
                <asp:TextBox ID="TextBox8" runat="server" CssClass="input"></asp:TextBox><br/>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Company Name Required" ControlToValidate="TextBox8" CssClass="validator"></asp:RequiredFieldValidator><br/><br/>
                <asp:Label ID="Label20" runat="server" Text="Website" CssClass="labels" Font-Bold="true"></asp:Label><br/>
                <asp:TextBox ID="TextBox9" runat="server" CssClass="input"></asp:TextBox><br/><br/>
            </div>
            <div class="subdetailsdiv" runat="server">
                <asp:Label ID="Label21" runat="server" Text="Company Location" CssClass="labels" Font-Bold="true"></asp:Label><br/>
                <asp:TextBox ID="TextBox10" runat="server" CssClass="input"></asp:TextBox><br/><br/>
                <asp:Label ID="Label22" runat="server" Text="Company Number" CssClass="labels" Font-Bold="true"></asp:Label><br/>
                <asp:TextBox ID="TextBox11" runat="server" CssClass="input"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Incorrect Format" ControlToValidate="TextBox11" ValidationExpression="[0-9]{10,11}"></asp:RegularExpressionValidator><br/><br/>
                <asp:Button ID="Button2" runat="server" Text="Next" CssClass="button" OnClick="Button2_Click" CausesValidation="false"/>
                <asp:Button ID="Button3" runat="server" Text="Back" CssClass="button" OnClick="Button3_Click" CausesValidation="false"/>
            </div>
        </div>

        <div id="id6" class="detailsdiv3" runat="server">
            <div class="subdetailsdiv" runat="server">
                <asp:Label ID="Label23" runat="server" Text="Secret Question" CssClass="labels" Font-Bold="true"></asp:Label><asp:Label ID="Label24" runat="server" Text=" *" CssClass="star"></asp:Label><br/>
                <asp:DropDownList ID="DropDownList2" runat="server" CssClass="input">
                    <asp:ListItem Text="Where were you born?" Value="0"/>
                    <asp:ListItem Text="What was your first car?" Value="1"/>
                    <asp:ListItem Text="What was the name of your first school?" Value="2"/>
                    <asp:ListItem Text="What is the mother's maiden name?" Value="3"/>
                    <asp:ListItem Text="What is your pet name?" Value="4"/>
                </asp:DropDownList>
            </div>
            <div class="subdetailsdiv" runat="server">
                <asp:Label ID="Label25" runat="server" Text="Answer" CssClass="labels" Font-Bold="true"></asp:Label><asp:Label ID="Label26" runat="server" Text=" *" CssClass="star"></asp:Label><br/>
                <asp:TextBox ID="TextBox12" runat="server" CssClass="input"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Answer Required" ControlToValidate="TextBox12" CssClass="validator"></asp:RequiredFieldValidator><br/><br/>
                <asp:Button ID="Button4" runat="server" Text="Submit" CssClass="button" OnClick="Button4_Click" CausesValidation="false"/>
                <asp:Button ID="Button5" runat="server" Text="Back" CssClass="button" OnClick="Button5_Click" CausesValidation="false"/>
            </div>
        </div>
    </div>
</asp:Content>
