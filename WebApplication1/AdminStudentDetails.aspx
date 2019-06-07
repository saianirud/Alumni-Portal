<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="AdminStudentDetails.aspx.cs" Inherits="WebApplication1.AdminStudentDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="App_Themes/StudentHomePage/StudentHomePage.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true">
        <asp:ListItem Text="LightGrey"></asp:ListItem>
        <asp:ListItem Text="Ivory"></asp:ListItem>
    </asp:DropDownList>
    <asp:DetailsView ID="DetailsView1" runat="server" CssClass="gridview" AutoGenerateRows="false" DataSourceID="SqlDataSource1">
        <Fields>
            <asp:BoundField DataField="regno" HeaderText="Registration Number"/>
            <asp:BoundField DataField="name" HeaderText="Name"/>
            <asp:BoundField DataField="gender" HeaderText="Gender" NullDisplayText="NA"/>
            <asp:BoundField DataField="email" HeaderText="Email ID" NullDisplayText="NA"/>
            <asp:BoundField DataField="phoneno" HeaderText="Phone Number" NullDisplayText="NA" />
            <asp:BoundField DataField="dob" HeaderText="Date of Birth" NullDisplayText="NA" />
            <asp:BoundField DataField="branch" HeaderText="Branch" />
            <asp:BoundField DataField="cgpa" HeaderText="CGPA" NullDisplayText="NA" />
            <asp:BoundField DataField="passingyear" HeaderText="Passing Year" />
            <asp:BoundField DataField="companyname" HeaderText="Company Name" />
            <asp:BoundField DataField="companylocation" HeaderText="Company Location" NullDisplayText="NA" />
            <asp:BoundField DataField="companywebsite" HeaderText="Company Website" NullDisplayText="NA" />
            <asp:BoundField DataField="companyphone" HeaderText="Company Number" NullDisplayText="NA" />
        </Fields>
    </asp:DetailsView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StudentData %>" SelectCommand="SELECT * FROM student WHERE regno=@regno">
        <SelectParameters>
            <asp:QueryStringParameter Name="regno" QueryStringField="regno" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
