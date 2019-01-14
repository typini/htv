<%--///////////////////////////////////////////////
// File:  CompleteSale.aspx
// Program Name:  HTV_v2.0
// Programmer:  Tyree Pini
// Group:  Team D
// Course:  CIS470 Senior Project
// Date:  19 April 2017
// Website:  http://htvteamd.azurewebsites.net/
///////////////////////////////////////////////--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/HTV.Master" AutoEventWireup="true" CodeBehind="CompleteSale.aspx.cs" Inherits="HTV.WebForm11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHeader" runat="server">
    <br />Purchase Request Number 
    <asp:Label ID="lblPR" runat="server" Text="0"></asp:Label>
&nbsp;- Sale Completion 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: 75px;"></div>
    <asp:Button ID="btnOverview" class="buttons" runat="server" Text="Purchase Overview" PostBackUrl="~/PurchaseOverview.aspx" /><br />
    <asp:Button ID="btnEmployee" class="buttons" runat="server" Text="Lead Employee Info" PostBackUrl="~/EmployeeInformation.aspx" /><br />
    <asp:Button ID="btnCustomer" class="buttons" runat="server" Text="Customer Info" PostBackUrl="~/CustomerInformation.aspx" /><br />
    <asp:Button ID="btnNewVehicle" class="buttons" runat="server" Text="New Vehicle Details" PostBackUrl="~/NewVehicleInformation.aspx" /><br />
    <asp:Button ID="btnAddOns" class="buttons" runat="server" Text="Add-On Options" PostBackUrl="~/AddOns.aspx" /><br />
    <asp:Button ID="btnTradeIn" class="buttons" runat="server" Text="Trade-In Details" PostBackUrl="~/TradeIns.aspx" /><br />
    <asp:Button ID="btnFinancing" class="buttons" runat="server" Text="Financing Details" PostBackUrl="~/Financing.aspx" /><br />
    <asp:Button ID="btnMechanic" class="inactiveButtons" runat="server" Text="Mechanic's Approval" PostBackUrl="~/MechanicApproval.aspx" /><br />
    <asp:Button ID="btnManager" class="inactiveButtons" runat="server" Text="Manager Approval" PostBackUrl="~/ManagerApproval.aspx" />
    <asp:Button ID="btnCompleteSale" class="activeButtons" runat="server" Text="Sale Completion" PostBackUrl="~/CompleteSale.aspx" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="clears"></div>
    <asp:Label ID="Label1" class="lbls" runat="server" Text="Switch View to Purchase Request ID:"></asp:Label>
    <asp:DropDownList ID="ddlCustomerID" class="txts" runat="server">
        <asp:ListItem Selected="True">000001</asp:ListItem>
    </asp:DropDownList>
    <div class="clears"></div>
    <asp:Label ID="Label13" class="lbls" runat="server" Text="Purchase Request Information for Purchase Request: 000001"></asp:Label><br />
    <asp:Label ID="Label25" class="lbls" runat="server" style="color: red; font-style:italic;" Text="Click on the buttons to the left for more detailed information"></asp:Label><br />
    <div class="clears"></div>
    <asp:Label ID="Label2" class="lbls" runat="server" Text="Lead Employee Info:"></asp:Label>
    <asp:Label ID="txtFirst" class="txts" runat="server" Text="John Jones"></asp:Label><br />
    <asp:Label ID="Label19" class="txts" runat="server" Text="Commission: $1,018.00 @ 4.00%"></asp:Label><br />
    <div class="clears"></div>
    <asp:Label ID="Label3" class="lbls" runat="server" Text="Customer Info:"></asp:Label>
    <asp:Label ID="txtLast" class="txts" runat="server" Text="Julie Childs"></asp:Label><br />
    <div class="clears"></div>
    <asp:Label ID="Label9" class="lbls" runat="server" Text="New Vehicle Details:"></asp:Label>
    <asp:Label ID="txtPosition" class="txts" runat="server" Text="Vehicle ID:  000002"></asp:Label><br />
    <asp:RadioButton ID="RadioButton3" class="txts" runat="server" Text="Vehicle On Lot" Checked="True" GroupName="OrderVehicle"/><br />
    <asp:RadioButton ID="RadioButton4" class="txts" runat="server" Text="Order Vehicle from Factory" GroupName="OrderVehicle"/><br />
    <div class="clears"></div>
    <asp:Label ID="Label12" class="lbls" runat="server" Text="Add-On Options:"></asp:Label>
    <asp:Label ID="Label6" class="txts" runat="server" Text="In Stock:  Leather Furniture"></asp:Label><br />
    <asp:Label ID="Label7" class="txts" runat="server" Text="Not In Stock:  Dishwasher"></asp:Label><br />
    <asp:RadioButton ID="RadioButton6" class="txts" runat="server" Text="All Items In Stock, No Order Necessary" Checked="False" GroupName="OrderAddOns"/><br />
    <asp:RadioButton ID="RadioButton5" class="txts" runat="server" Text="Order Vehicle Add-Ons Not In Stock" Checked="True" GroupName="OrderAddOns"/><br />
    <div class="clears"></div>
    <asp:Label ID="Label11" class="lbls" runat="server" Text="Trade-In Details:"></asp:Label>
    <asp:Label ID="lblCommission" class="txts" runat="server" Text="Trade-In ID:  000002"></asp:Label><br />
    <asp:Label ID="Label21" class="txts" runat="server" Text="Trade-In Condition:  Good."></asp:Label><br />
    <asp:RadioButton ID="RadioButton1" class="txts" runat="server" Text="Add to Inventory" Checked="True" GroupName="TradeInCondition"/><br />
    <asp:RadioButton ID="RadioButton2" class="txts" runat="server" Text="Sell to Third Party" GroupName="TradeInCondition"/><br />
    <asp:RadioButton ID="RadioButton9" class="txts" runat="server" Text="No Trade-In Vehicle" GroupName="TradeInCondition"/><br />
    <div class="clears"></div>
    <asp:Label ID="Label4" class="lbls" runat="server" Text="Total Amount Financed:"></asp:Label>
    <asp:Label ID="Label5" class="txts" runat="server" Text="$13,450.00 @ 3.00%APR"></asp:Label><br />
    <asp:Label ID="Label16" class="txts" runat="server" Text="12-Month Financing"></asp:Label><br />
    <asp:Label ID="Label23" class="txts" runat="server" Text="Estimated Monthly Payment: $1,154.46"></asp:Label><br />
    <div class="clears"></div>
    <asp:Label ID="Label14" class="lbls" runat="server" Text="Complete Sale:"></asp:Label>
    <asp:RadioButton ID="RadioButton7" class="txts" runat="server" Text="Finalize Sale Today:  10 April 2017" GroupName="Completion"/><br />
    <asp:RadioButton ID="RadioButton8" class="txts" runat="server" Text="Set Completion Date:  " Checked="True" GroupName="Completion"/>
    <asp:TextBox ID="txtCompletionDate" class="txts" style="margin-left: 160px;" runat="server" Text="1 May 2017"></asp:TextBox><br />
    <br />
    <br />
    <asp:Button ID="btnSave" class="contentButtons" runat="server" Text="Complete Sale" OnClick="btnSave_Click" />
    <asp:Button ID="btnClear" class="contentButtons" runat="server" Text="Clear" />
    <asp:Button ID="btnBack" class="contentButtons" runat="server" Text="Back to Main" PostBackUrl="~/MainMenu.aspx" />
    <br />
    <div style="height:90px;"></div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentFooter" runat="server">
    <asp:Label ID="Warnings" class="warning" runat="server" Text=""></asp:Label><br />Copyright &copy; 2017 Team D
</asp:Content>
