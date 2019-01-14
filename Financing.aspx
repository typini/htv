<%--///////////////////////////////////////////////
// File:  Financing.aspx
// Program Name:  HTV_v2.0
// Programmer:  Tyree Pini
// Group:  Team D
// Course:  CIS470 Senior Project
// Date:  19 April 2017
// Website:  http://htvteamd.azurewebsites.net/
///////////////////////////////////////////////--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/HTV.Master" AutoEventWireup="true" CodeBehind="Financing.aspx.cs" Inherits="HTV.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHeader" runat="server">
    <br />Purchase Request Number 
    <asp:Label ID="lblPR" runat="server" Text="0"></asp:Label>
&nbsp;- Financing Details 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: 75px;"></div>
    <asp:Button ID="btnOverview" class="buttons" runat="server" Text="Purchase Overview" PostBackUrl="~/PurchaseOverview.aspx" /><br />
    <asp:Button ID="btnEmployee" class="buttons" runat="server" Text="Lead Employee Info" PostBackUrl="~/EmployeeInformation.aspx" /><br />
    <asp:Button ID="btnCustomer" class="buttons" runat="server" Text="Customer Info" PostBackUrl="~/CustomerInformation.aspx" /><br />
    <asp:Button ID="btnNewVehicle" class="buttons" runat="server" Text="New Vehicle Details" PostBackUrl="~/NewVehicleInformation.aspx" /><br />
    <asp:Button ID="btnAddOns" class="buttons" runat="server" Text="Add-On Options" PostBackUrl="~/AddOns.aspx" /><br />
    <asp:Button ID="btnTradeIn" class="buttons" runat="server" Text="Trade-In Details" PostBackUrl="~/TradeIns.aspx" /><br />
    <asp:Button ID="btnFinancing" class="activeButtons" runat="server" Text="Financing Details" PostBackUrl="~/Financing.aspx" /><br />
    <asp:Button ID="btnMechanic" class="inactiveButtons" runat="server" Text="Mechanic's Approval" PostBackUrl="~/MechanicApproval.aspx" /><br />
    <asp:Button ID="btnManager" class="inactiveButtons" runat="server" Text="Manager Approval" PostBackUrl="~/ManagerApproval.aspx" />
    <asp:Button ID="btnCompleteSale" class="inactiveButtons" runat="server" Text="Sale Completion" PostBackUrl="~/CompleteSale.aspx" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="clears"></div>
    <asp:Label ID="Label1" class="lbls" runat="server" Text="Total Cost:"></asp:Label>
    <asp:Label ID="lblTotalCost" class="txts" style="color:gray;" runat="server" Text="$25,450.00"></asp:Label>
    <div class="clears"></div>
    <asp:Label ID="Label13" class="lbls" runat="server" Text="Purchasing Options"></asp:Label>
    <asp:Label ID="lblRequired" class="txts" runat="server" style="color: red; font-size: 85%; font-style:italic;">* = Required Information</asp:Label>
    <div class="clears"></div>
    <asp:Label ID="Label2" class="lbls" runat="server" Text="Down Payment:*"></asp:Label>
    <asp:TextBox ID="txtDownPayment" class="txts" runat="server" Text="$4,000.00"></asp:TextBox>
    <div class="clears"></div>
    <asp:Label ID="Label3" class="lbls" runat="server" Text="Trade-In Value:"></asp:Label>
    <asp:Label ID="lblTradeInValue" class="txts" runat="server" style="color:gray;" Text="$8,000.00"></asp:Label>
    <div class="clears"></div>
    <asp:Label ID="Label9" class="lbls" runat="server" Text="Amount Required to Finance:"></asp:Label>
    <asp:Label ID="lblAmountToFinance" class="txts" style="color:gray;" runat="server" Text="$13,450.00"></asp:Label>
    <div class="clears"></div>
    <asp:Label ID="Label4" class="lbls" runat="server" Text="FICO Score:*"></asp:Label>
    <asp:TextBox ID="txtFICO" class="txts" runat="server" Text="803"></asp:TextBox>
    <div class="clears"></div>
    <asp:Label ID="Label5" class="lbls" runat="server" Text="FICO Score Date:*"></asp:Label>
    <asp:TextBox ID="txtFICODate" class="txts" runat="server" Text="15 April 2017"></asp:TextBox>
    <div class="clears"></div>
    <asp:Label ID="Label12" class="lbls" runat="server" Text="Qualifying Interest Rate:"></asp:Label>
    <asp:Label ID="lblInterestRate" class="txts" runat="server" Text="Three Percent (3.00%)"></asp:Label>
    <div class="clears"></div>
    <asp:Label ID="Label14" class="lbls" runat="server" Text="Months Financed:*"></asp:Label>
    <asp:DropDownList ID="ddlFinanceLength" class="txts" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlFinanceLength_SelectedIndexChanged">
        <asp:ListItem>12-Months</asp:ListItem>
        <asp:ListItem>24-Months</asp:ListItem>
        <asp:ListItem>36-Months</asp:ListItem>
        <asp:ListItem>48-Months</asp:ListItem>
        <asp:ListItem>Not Financing</asp:ListItem>
    </asp:DropDownList>
    <div class="clears"></div>
    <asp:Label ID="Label11" class="lbls" runat="server" Text="Expected Monthly Payment:"></asp:Label>
    <asp:Label ID="lblMonthlyPayment" class="txts" runat="server" Text="$1,154.46"></asp:Label>
    <br />
    <br />
    <br />
    <asp:Button ID="btnSave" class="contentButtons" runat="server" Text="Save" OnClick="btnSave_Click" />
    <asp:Button ID="btnClear" class="contentButtons" runat="server" Text="Clear" />
    <asp:Button ID="btnBack" class="contentButtons" runat="server" Text="Back to Main" PostBackUrl="~/MainMenu.aspx" />
    <br />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentFooter" runat="server">
    <asp:Label ID="Warnings" class="warning" runat="server" Text=""></asp:Label><br />Copyright &copy; 2017 Team D
</asp:Content>
