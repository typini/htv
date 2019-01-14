<%--///////////////////////////////////////////////
// File:  EmployeeInformation.aspx
// Program Name:  HTV_v2.0
// Programmer:  Tyree Pini
// Group:  Team D
// Course:  CIS470 Senior Project
// Date:  19 April 2017
// Website:  http://htvteamd.azurewebsites.net/
///////////////////////////////////////////////--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/HTV.Master" AutoEventWireup="true" CodeBehind="EmployeeInformation.aspx.cs" Inherits="HTV.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHeader" runat="server">
    <br />Purchase Request Number 
    <asp:Label ID="lblPR" runat="server" Text="0"></asp:Label>
&nbsp;- Lead Employee Information 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: 75px;"></div>
    <asp:Button ID="btnOverview" class="buttons" runat="server" Text="Purchase Overview" PostBackUrl="~/PurchaseOverview.aspx" /><br />
    <asp:Button ID="btnEmployee" class="activeButtons" runat="server" Text="Lead Employee Info" PostBackUrl="~/EmployeeInformation.aspx" /><br />
    <asp:Button ID="btnCustomer" class="buttons" runat="server" Text="Customer Info" PostBackUrl="~/CustomerInformation.aspx" /><br />
    <asp:Button ID="btnNewVehicle" class="buttons" runat="server" Text="New Vehicle Details" PostBackUrl="~/NewVehicleInformation.aspx" /><br />
    <asp:Button ID="btnAddOns" class="buttons" runat="server" Text="Add-On Options" PostBackUrl="~/AddOns.aspx" /><br />
    <asp:Button ID="btnTradeIn" class="buttons" runat="server" Text="Trade-In Details" PostBackUrl="~/TradeIns.aspx" /><br />
    <asp:Button ID="btnFinancing" class="buttons" runat="server" Text="Financing Details" PostBackUrl="~/Financing.aspx" /><br />
    <asp:Button ID="btnMechanic" class="inactiveButtons" runat="server" Text="Mechanic's Approval" PostBackUrl="~/MechanicApproval.aspx" /><br />
    <asp:Button ID="btnManager" class="inactiveButtons" runat="server" Text="Manager Approval" PostBackUrl="~/ManagerApproval.aspx" />
    <asp:Button ID="btnCompleteSale" class="inactiveButtons" runat="server" Text="Sale Completion" PostBackUrl="~/CompleteSale.aspx" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="clears"></div>
    <asp:Label ID="Label1" class="lbls" runat="server" Text="Employee ID Number:*"></asp:Label>
    <asp:DropDownList ID="ddlEmployeeID" class="txts" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEmployeeID_SelectedIndexChanged">
        <asp:ListItem Selected="True">0000001</asp:ListItem>
    </asp:DropDownList>
    <div class="clears"></div>
    <asp:Label ID="Label13" class="lbls" runat="server" Text="Enter Employee Information"></asp:Label>
    <asp:Label ID="lblRequired" class="txts" runat="server" style="color: red; font-size: 85%; font-style:italic;">* = Required Information</asp:Label>
    <div class="clears"></div>
    <asp:Label ID="Label2" class="lbls" runat="server" Text="First Name:"></asp:Label>
    <asp:Label ID="lblFirst" class="txts" runat="server" Text="John"></asp:Label>
    <div class="clears"></div>
    <asp:Label ID="Label3" class="lbls" runat="server" Text="Last Name:"></asp:Label>
    <asp:Label ID="lblLast" class="txts" runat="server" Text="Jones"></asp:Label>
    <div class="clears"></div>
    <asp:Label ID="Label9" class="lbls" runat="server" Text="Position:"></asp:Label>
    <asp:Label ID="lblPosition" class="txts" runat="server" Text="Sales Person"></asp:Label>
    <div class="clears"></div>
    <asp:Label ID="Label12" class="lbls" runat="server" Text="Date Hired:"></asp:Label>
    <asp:Label ID="lblDateHired" class="txts" runat="server" Text="29 September 2015"></asp:Label>
    <div class="clears"></div>
    <asp:Label ID="Label11" class="lbls" runat="server" Text="Commission Rate:"></asp:Label>
    <asp:Label ID="lblCommission" class="txts" runat="server" Text="Four Percent (4.00%)"></asp:Label>
    <br />
    <br />
    <br />
    <asp:Button ID="btnSave" class="contentButtons" runat="server" Text="Save" OnClick="btnSave_Click" />
    <asp:Button ID="btnBack" class="contentButtons" runat="server" Text="Back to Main" PostBackUrl="~/MainMenu.aspx" />
    <br />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentFooter" runat="server">
    <asp:Label ID="Warnings" class="warning" runat="server" Text=""></asp:Label><br />Copyright &copy; 2017 Team D
</asp:Content>
