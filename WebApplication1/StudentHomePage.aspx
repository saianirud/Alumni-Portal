<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="StudentHomePage.aspx.cs" Inherits="WebApplication1.studenthomepage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="App_Themes/StudentHomePage/StudentHomePage.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DetailsView ID="DetailsView1" runat="server" CssClass="gridview" AutoGenerateRows="false" AutoGenerateEditButton="true" OnModeChanging="DetailsView1_ModeChanging" OnItemUpdating="DetailsView1_ItemUpdating">
        <Fields>
            <asp:BoundField DataField="regno" HeaderText="Registration Number" ReadOnly="true"/>
            <asp:BoundField DataField="name" HeaderText="Name" NullDisplayText="NA"/>
            <asp:BoundField DataField="gender" HeaderText="Gender" NullDisplayText="NA"/>
            <asp:BoundField DataField="email" HeaderText="Email ID" NullDisplayText="NA"/>
            <asp:BoundField DataField="phoneno" HeaderText="Phone Number" NullDisplayText="NA" />
            <asp:BoundField DataField="dob" HeaderText="Date of Birth" NullDisplayText="NA" />
            <asp:BoundField DataField="branch" HeaderText="Branch" NullDisplayText="NA" />
            <asp:BoundField DataField="cgpa" HeaderText="CGPA" NullDisplayText="NA" />
            <asp:BoundField DataField="passingyear" HeaderText="Passing Year" NullDisplayText="NA" />
        </Fields>
    </asp:DetailsView>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</asp:Content>
