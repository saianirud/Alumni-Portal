<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="CompanyDetails.aspx.cs" Inherits="WebApplication1.CompanyDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="App_Themes/CompanyDetails/CompanyDetails.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DetailsView ID="DetailsView1" runat="server" CssClass="gridview" AutoGenerateRows="false" AutoGenerateEditButton="true" OnModeChanging="DetailsView1_ModeChanging" OnItemUpdating="DetailsView1_ItemUpdating">
        <Fields>
            <asp:BoundField DataField="companyname" HeaderText="Company Name" NullDisplayText="NA"/>
            <asp:BoundField DataField="companylocation" HeaderText="Company Location" NullDisplayText="NA"/>
            <asp:BoundField DataField="companywebsite" HeaderText="Company Website" NullDisplayText="NA"/>
            <asp:BoundField DataField="companyphone" HeaderText="Company Number" NullDisplayText="NA"/>
        </Fields>
    </asp:DetailsView>
</asp:Content>
