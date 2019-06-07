<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="AdminHomePage.aspx.cs" Inherits="WebApplication1.AdminHomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="App_Themes/AdminHomePage/AdminHomePage.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div runat="server" class="maindiv">
    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/filter.jpg" CssClass="filterbutton" ToolTip="Filter" OnClick="ImageButton1_Click"/>
    <div id="id1" runat="server" class="filterdiv animate">
        <div class="ddldiv" runat="server">
            <asp:Label ID="Label1" runat="server" Text="Year: "></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server" DataTextField="passingyear" DataValueField="passingyear">
            </asp:DropDownList>
        </div>
        <div class="ddldiv" runat="server">
            <asp:Label ID="Label2" runat="server" Text="Branch: "></asp:Label>
            <asp:DropDownList ID="DropDownList2" runat="server" DataTextField="branch"></asp:DropDownList>
        </div>
        <div class="ddldiv" runat="server">
            <asp:Label ID="Label3" runat="server" Text="Company: "></asp:Label>
            <asp:DropDownList ID="DropDownList3" runat="server" DataTextField="companyname"></asp:DropDownList>
        </div>
        <div runat="server" style="float:left;padding-left:10px">
            <asp:Button ID="Button1" runat="server" Text="Apply" BackColor="Green" CssClass="button" OnClick="Button1_Click"/><br/>
            <asp:Button ID="Button2" runat="server" Text="Clear" BackColor="Black" CssClass="button" OnClick="Button2_Click"/>
        </div>
    </div>
    <asp:GridView ID="GridView1" runat="server" CssClass="gridview" AutoGenerateColumns="false" CellPadding="10" EmptyDataText="No records to display.">
        <columns>
            <asp:HyperLinkField DataTextField="regno" HeaderText="Registration Number" DataNavigateUrlFields="regno" DataNavigateUrlFormatString="AdminStudentDetails.aspx?regno={0}"/>
            <asp:BoundField DataField="name" HeaderText="Name"/>
            <asp:BoundField DataField="branch" HeaderText="Branch"/>
            <asp:BoundField DataField="companyname" HeaderText="Company"/>
            <asp:BoundField DataField="passingyear" HeaderText="Passing Year"/>
            <asp:HyperLinkField Text="Exit Survey Form" HeaderText="Exit Survey Form" DataNavigateUrlFields="regno" DataNavigateUrlFormatString="AdminStudentSurveyForm.aspx?regno={0}"/>
        </columns>
    </asp:GridView>
    </div>
</asp:Content>
