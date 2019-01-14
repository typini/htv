<%--///////////////////////////////////////////////
// File:  NewVehicleInformation.aspx
// Program Name:  HTV_v2.0
// Programmer:  Tyree Pini
// Group:  Team D
// Course:  CIS470 Senior Project
// Date:  19 April 2017
// Website:  http://htvteamd.azurewebsites.net/
///////////////////////////////////////////////--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/HTV.Master" AutoEventWireup="true" CodeBehind="NewVehicleInformation.aspx.cs" Inherits="HTV.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHeader" runat="server">
    <br />Purchase Request Number 
    <asp:Label ID="lblPR" runat="server" Text="0"></asp:Label>
&nbsp;- New Vehicle Details 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: 75px;"></div>
    <asp:Button ID="btnOverview" class="buttons" runat="server" Text="Purchase Overview" PostBackUrl="~/PurchaseOverview.aspx" /><br />
    <asp:Button ID="btnEmployee" class="buttons" runat="server" Text="Lead Employee Info" PostBackUrl="~/EmployeeInformation.aspx" /><br />
    <asp:Button ID="btnCustomer" class="buttons" runat="server" Text="Customer Info" PostBackUrl="~/CustomerInformation.aspx" /><br />
    <asp:Button ID="btnNewVehicle" class="activeButtons" runat="server" Text="New Vehicle Details" PostBackUrl="~/NewVehicleInformation.aspx" /><br />
    <asp:Button ID="btnAddOns" class="buttons" runat="server" Text="Add-On Options" PostBackUrl="~/AddOns.aspx" /><br />
    <asp:Button ID="btnTradeIn" class="buttons" runat="server" Text="Trade-In Details" PostBackUrl="~/TradeIns.aspx" /><br />
    <asp:Button ID="btnFinancing" class="buttons" runat="server" Text="Financing Details" PostBackUrl="~/Financing.aspx" /><br />
    <asp:Button ID="btnMechanic" class="inactiveButtons" runat="server" Text="Mechanic's Approval" PostBackUrl="~/MechanicApproval.aspx" /><br />
    <asp:Button ID="btnManager" class="inactiveButtons" runat="server" Text="Manager Approval" PostBackUrl="~/ManagerApproval.aspx" />
    <asp:Button ID="btnCompleteSale" class="inactiveButtons" runat="server" Text="Sale Completion" PostBackUrl="~/CompleteSale.aspx" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="clears"></div>
    <asp:Label ID="Label1" class="lbls" runat="server" Text="Select Vehicle ID:"></asp:Label>
    
    <asp:DropDownList ID="ddlVehicleID" class="txts" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlVehicleID_SelectedIndexChanged">
        <asp:ListItem>000001</asp:ListItem>
        <asp:ListItem>000002</asp:ListItem>
    </asp:DropDownList>
    
    <div class="clears"></div>
    <asp:Label ID="Label13" class="lbls" runat="server" Text="Vehicle Information"></asp:Label>
    <div class="clears"></div>
    <asp:Label ID="Label2" class="lbls" runat="server" Text="Vehicle Identification Number:"></asp:Label>
    <asp:Label ID="lblVIN" class="txts" runat="server" Text="VIN0000000000"></asp:Label>
    <div class="clears"></div>
    <asp:Label ID="Label4" class="lbls" runat="server" Text="MSRP:"></asp:Label>
    <asp:Label ID="lblMSRP" class="txts" runat="server" Text="$24,950.00"></asp:Label>
    <div class="clears"></div>
    <asp:Label ID="Label3" class="lbls" runat="server" Text="Customer's Offer:"></asp:Label>
    <asp:TextBox ID="txtCustomerOffer" class="txts" runat="server">23,000.00</asp:TextBox>
    <div class="clears"></div>
    <asp:Label ID="Label15" class="lbls" runat="server" Text="Taxes:"></asp:Label>
    <asp:Label ID="lblTaxes" class="txts" runat="server" Text="$350.00"></asp:Label>
    <div class="clears"></div>
    <asp:Label ID="Label11" class="lbls" runat="server" Text="License Fees:"></asp:Label>
    <asp:Label ID="lblFees" class="txts" runat="server" Text="$125.00"></asp:Label>
    <div class="clears"></div>
    <asp:Label ID="Label16" class="lbls" runat="server" Text="Total Cost before Upgrades:"></asp:Label>
    <asp:Label ID="lblTotalCost" class="txts" runat="server" Text="$25,425.00"></asp:Label>
    <div class="clears"></div>
    <asp:Label ID="Label9" class="lbls" runat="server" Text="Vehicle Location:"></asp:Label>
    <asp:Label ID="lblLocation" class="txts" runat="server" Text="On Lot"></asp:Label>
    <br />
    <br />
    <br />
    <asp:Button ID="btnSave" class="contentButtons" runat="server" Text="Save" CausesValidation="False" OnClick="btnSave_Click" UseSubmitBehavior="False" />
    <asp:Button ID="btnClear" class="contentButtons" runat="server" Text="Clear" OnClick="btnClear_Click" />
    <asp:Button ID="btnBack" class="contentButtons" runat="server" Text="Back to Main" PostBackUrl="~/MainMenu.aspx" />
    <br />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentFooter" runat="server">
    <asp:Label ID="Warnings" class="warning" runat="server" Text=""></asp:Label><br />Copyright &copy; 2017 Team D
</asp:Content>
