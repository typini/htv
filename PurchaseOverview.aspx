<%--///////////////////////////////////////////////
// File:  PurchaseOverview.aspx
// Program Name:  HTV_v2.0
// Programmer:  Tyree Pini
// Group:  Team D
// Course:  CIS470 Senior Project
// Date:  19 April 2017
// Website:  http://htvteamd.azurewebsites.net/
///////////////////////////////////////////////--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/HTV.Master" AutoEventWireup="true" CodeBehind="PurchaseOverview.aspx.cs" Inherits="HTV.WebForm9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHeader" runat="server">
    <br />Purchase Request Number 
    <asp:Label ID="lblPR" runat="server" Text="0"></asp:Label>
&nbsp;- Purchase Overview 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: 75px;"></div>
    <asp:Button ID="btnOverview" class="activeButtons" runat="server" Text="Purchase Overview" PostBackUrl="~/PurchaseOverview.aspx" /><br />
    <asp:Button ID="btnEmployee" class="buttons" runat="server" Text="Lead Employee Info" PostBackUrl="~/EmployeeInformation.aspx" /><br />
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
    <asp:Label ID="Label1" class="lbls" runat="server" Text="Switch View to Purchase Request #:"></asp:Label>
    <asp:DropDownList ID="ddlPurchaseRequestID" class="txts" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPurchaseRequestID_SelectedIndexChanged">
        <asp:ListItem Selected="True" Value="1">000001</asp:ListItem>
        <asp:ListItem Value="2">000002</asp:ListItem>
    </asp:DropDownList>
    <div class="clears"></div>
    <asp:Label ID="Label13" class="lbls" runat="server" Text="Purchase Request Information for Purchase Request: 000001"></asp:Label><br />
    <asp:Label ID="Label25" class="lbls" runat="server" style="color: red; font-style:italic;" Text="Click on the buttons to the left for more detailed information"></asp:Label><br />
    <div class="clears"></div>
    <asp:Label ID="Label2" class="lbls" runat="server" Text="Lead Employee Info:"></asp:Label>
    <asp:Label ID="lblEmployee" class="txts" runat="server" Text="John Jones"></asp:Label>
    <div class="clears"></div>
    <asp:Label ID="Label3" class="lbls" runat="server" Text="Customer Info:"></asp:Label>
    <asp:Label ID="lblCustomer" class="txts" runat="server" Text="Julie Childs"></asp:Label><br />
    <asp:Label ID="lblFICO" class="txts" runat="server" Text="FICO: 803"></asp:Label><br />
    <div class="clears"></div>
    <asp:Label ID="Label9" class="lbls" runat="server" Text="New Vehicle Details:"></asp:Label>
    <asp:Label ID="lblVehicleID" class="txts" runat="server" Text="Vehicle ID:  000002"></asp:Label><br />
    <asp:Label ID="lblMSRP" class="txts" runat="server" Text="$"></asp:Label><br />
    <asp:Label ID="lblCustomerOffer" class="txts" runat="server" Text="$"></asp:Label><br />
    <asp:Label ID="lblVehicleLocation" class="txts" runat="server" Text="On Lot"></asp:Label><br />
    <div class="clears"></div>
    <asp:Label ID="Label12" class="lbls" runat="server" Text="Add-On Options:"></asp:Label>
    <asp:Label ID="lblAddOns" class="txts" runat="server" Text="Leather Furniture, Dish Washer"></asp:Label><br />
    <asp:Label ID="lblAddOnsCost" class="txts" runat="server" Text="Total Add-On Cost:  $2,800.00"></asp:Label><br />
    <div class="clears"></div>
    <asp:Label ID="Label11" class="lbls" runat="server" Text="Trade-In Details:"></asp:Label>
    <asp:Label ID="lblTradeInID" class="txts" runat="server" Text="Trade-In ID:  000002"></asp:Label><br />
    <asp:Label ID="lblTradeInTitle" class="txts" runat="server" Text="Title is Clear"></asp:Label><br />
    <asp:Label ID="lblTradeInValue" class="txts" runat="server" Text="Trade-In Value:  $8,000.00"></asp:Label><br />
    <div class="clears"></div>
    <asp:Label ID="Label4" class="lbls" runat="server" Text="Financing Details:"></asp:Label>
    <asp:Label ID="lblDownPayment" class="txts" runat="server" Text="Total Down Payment: $4,000.00"></asp:Label><br />
    <asp:Label ID="lblCreditAmount" class="txts" runat="server" Text="Remaining Financing Needed:  $13,450.00"></asp:Label><br />
    <asp:Label ID="lblAPR" class="txts" runat="server" Text="Credit Available at 3.00% APR"></asp:Label><br />
    <asp:Label ID="lblFinanceLength" class="txts" runat="server" Text="12-Month Financing"></asp:Label><br />
    <asp:Label ID="lblMonthlyEstimate" class="txts" runat="server" Text="Estimated Monthly Payment: $1,154.46"></asp:Label><br />
    <div class="clears"></div>
    <asp:Label ID="Label6" class="lbls" runat="server" Text="Mechanic's Approval:"></asp:Label>
    <asp:Label ID="lblMechanicApproval" class="txts" runat="server" Text="Approved by Nicole Kidman"></asp:Label>
    <div class="clears"></div>
    <asp:Label ID="Label8" class="lbls" runat="server" Text="Manager Approval:"></asp:Label>
    <asp:Label ID="lblManagerApproval" class="txts" runat="server" Text="Approved by James Cavisel"></asp:Label><br />
    <asp:Label ID="lblDisapprovedDescription" class="txts" runat="server" Text="No Description."></asp:Label><br />
    <div class="clears"></div>
    <asp:Label ID="Label14" class="lbls" runat="server" Text="Purchase Request created on:"></asp:Label>
    <asp:Label ID="lblPurchaseRequestDate" class="txts" runat="server" Text="10 April 2017"></asp:Label><br />
    <br />
    <br />
    <asp:Button ID="btnBack" class="contentButtons" runat="server" Text="Back to Main" PostBackUrl="~/MainMenu.aspx" />
    <br />
    <div style="height:90px;"></div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentFooter" runat="server">
    <asp:Label ID="Warnings" class="warning" runat="server" Text=""></asp:Label><br />Copyright &copy; 2017 Team D
</asp:Content>
