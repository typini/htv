<%--///////////////////////////////////////////////
// File:  MainMenu.aspx
// Program Name:  HTV_v2.0
// Programmer:  Tyree Pini
// Group:  Team D
// Course:  CIS470 Senior Project
// Date:  19 April 2017
// Website:  http://htvteamd.azurewebsites.net/
///////////////////////////////////////////////--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/HTV.Master" AutoEventWireup="true" CodeBehind="MainMenu.aspx.cs" Inherits="HTV.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHeader" runat="server">
           <br />Main Menu
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: 70px;"></div>
    <div>
        <asp:Label ID="Label3" runat="server" Text="You are logged in."></asp:Label><br />
        <asp:Label ID="Label1" runat="server" Text="Employee:  John Jones"></asp:Label><br />
        <asp:Label ID="Label2" runat="server" Text="Position:  Sales Person"></asp:Label><br />
    </div>
    <asp:Button ID="btnLogOut" runat="server" class="mainLabels" Text="Log Out" OnClick="btnLogOut_Click"></asp:Button><br />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Button ID="btnNewSale" runat="server" class="mainButtons" Text="Start a New Sale" PostBackUrl="~/EmployeeInformation.aspx" />
    <asp:Button ID="btnContinueSale" runat="server" class="mainButtons" Text="Continue a Sale" PostBackUrl="~/PurchaseOverview.aspx" />
    <asp:Button ID="GenerateReports" runat="server" class="mainButtons" Text="Generate Reports" PostBackUrl="~/GenerateReports.aspx" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentFooter" runat="server">
    <asp:Label ID="Warnings" class="warning" runat="server" Text=""></asp:Label><br />Copyright &copy; 2017 Team D
</asp:Content>
