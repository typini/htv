<%--///////////////////////////////////////////////
// File:  ManagerApproval.aspx
// Program Name:  HTV_v2.0
// Programmer:  Tyree Pini
// Group:  Team D
// Course:  CIS470 Senior Project
// Date:  19 April 2017
// Website:  http://htvteamd.azurewebsites.net/
///////////////////////////////////////////////--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/HTV.Master" AutoEventWireup="true" CodeBehind="ManagerApproval.aspx.cs" Inherits="HTV.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHeader" runat="server">
    <br />Purchase Request Number 
    <asp:Label ID="lblPR" runat="server" Text="0"></asp:Label>
&nbsp;- Manager Approval 
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
    <asp:Button ID="btnManager" class="activeButtons" runat="server" Text="Manager Approval" PostBackUrl="~/ManagerApproval.aspx" />
    <asp:Button ID="btnCompleteSale" class="inactiveButtons" runat="server" Text="Sale Completion" PostBackUrl="~/CompleteSale.aspx" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="clears"></div>
    <asp:Label ID="Label4" class="lbls" runat="server" Text="Purchase Request Information for Purchase Request: 000001"></asp:Label><br />
    <asp:Label ID="Label25" class="lbls" runat="server" style="color: red; font-style:italic;" Text="Click on the buttons to the left for more detailed information"></asp:Label><br />
    <div class="clears"></div>
    <asp:Label ID="Label5" class="lbls" runat="server" Text="Lead Employee Name:"></asp:Label>
    <asp:Label ID="txtFirst" class="txts" runat="server" Text="John Jones"></asp:Label><br />
    <asp:Label ID="Label6" class="lbls" runat="server" Text="Customer Name:"></asp:Label>
    <asp:Label ID="txtLast" class="txts" runat="server" Text="Julie Childs"></asp:Label><br />
    <div class="clears"></div>
    <asp:Label ID="Label9" class="lbls" runat="server" Text="New Vehicle Details:"></asp:Label>
    <asp:Label ID="txtPosition" class="txts" runat="server" Text="Vehicle ID:  000002"></asp:Label><br />
    <div class="clears"></div>
    <asp:Label ID="Label12" class="lbls" runat="server" Text="Add-On Options:"></asp:Label>
    <asp:Label ID="txtDateHired" class="txts" runat="server" Text="Leather Furniture, Dish Washer"></asp:Label><br />
    <asp:Label ID="Label27" class="txts" runat="server" Text="Total Add-On Cost:  $2,800.00"></asp:Label><br />
    <div class="clears"></div>
    <asp:Label ID="Label11" class="lbls" runat="server" Text="Trade-In Details:"></asp:Label>
    <asp:Label ID="lblCommission" class="txts" runat="server" Text="Trade-In ID:  000002"></asp:Label><br />
    <asp:Label ID="Label22" class="txts" runat="server" Text="Title is Clear"></asp:Label><br />
    <asp:Label ID="Label21" class="txts" runat="server" Text="Trade-In Value:  $8,000.00"></asp:Label><br />
    <div class="clears"></div>
    <asp:Label ID="Label7" class="lbls" runat="server" Text="Financing Details:"></asp:Label>
    <asp:Label ID="Label8" class="txts" runat="server" Text="Total Down Payment: $4,000.00"></asp:Label><br />
    <asp:Label ID="Label17" class="txts" runat="server" Text="Remaining Financing Needed:  $13,450.00"></asp:Label><br />
    <asp:Label ID="Label18" class="txts" runat="server" Text="Credit Available at 3.00% APR"></asp:Label><br />
    <asp:Label ID="Label16" class="txts" runat="server" Text="12-Month Financing"></asp:Label><br />
    <asp:Label ID="Label23" class="txts" runat="server" Text="Estimated Monthly Payment: $1,154.46"></asp:Label><br />
    <div class="clears"></div>
    <asp:Label ID="Label10" class="lbls" runat="server" Text="Mechanic's Approval:"></asp:Label>
    <asp:Label ID="Label14" class="txts" runat="server" Text="Approved by Nicole Kidman"></asp:Label>
    <div class="clears"></div>
    <asp:Label ID="Label13" class="lbls" runat="server" Text="To be Filled Out By the Manager"></asp:Label>
    <asp:Label ID="lblRequired" class="txts" runat="server" style="color: red; font-size: 85%; font-style:italic;">* = Required Information</asp:Label>
    <div class="clears"></div>
    <asp:Label ID="Label1" class="lbls" runat="server" Text="Manager Employee ID:"></asp:Label>
    <asp:DropDownList ID="ddlCustomerID" class="txts" runat="server">
        <asp:ListItem Selected="True">0000001</asp:ListItem>
    </asp:DropDownList>
    <div class="clears"></div>
    <asp:Label ID="Label2" class="lbls" runat="server" Text="Sale Approved?*"></asp:Label>
    <asp:RadioButton ID="rabYes" runat="server" class="txts" GroupName="TitleAvailable" Checked="True" Text="Yes, Application Approved." /><br />
    <asp:RadioButton ID="rabNo" runat="server" class="txts" GroupName="TitleAvailable" Text="No, Not Approved." /><br />
    <div class="clears"></div>
    <asp:Label ID="Label3" class="lbls" runat="server" Text="Reason for Denial:"></asp:Label>
    <asp:TextBox ID="txtDenialDescription" class="txts" runat="server" style="height: 120px; white-space: normal;" TextMode="MultiLine"></asp:TextBox>
    <br /><br /><br /><br /><br /><br />
    <asp:Button ID="btnSave" class="contentButtons" runat="server" Text="Save" OnClick="btnSave_Click" />
    <asp:Button ID="btnClear" class="contentButtons" runat="server" Text="Clear" />
    <asp:Button ID="btnBack" class="contentButtons" runat="server" Text="Back to Main" PostBackUrl="~/MainMenu.aspx" />
    <div style="height: 120px;"></div>
    <br />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentFooter" runat="server">
    <asp:Label ID="Warnings" class="warning" runat="server" Text=""></asp:Label><br />Copyright &copy; 2017 Team D
</asp:Content>
