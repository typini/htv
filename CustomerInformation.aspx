<%--///////////////////////////////////////////////
// File:  CustomerInformation.aspx
// Program Name:  HTV_v2.0
// Programmer:  Tyree Pini
// Group:  Team D
// Course:  CIS470 Senior Project
// Date:  19 April 2017
// Website:  http://htvteamd.azurewebsites.net/
///////////////////////////////////////////////--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/HTV.Master" AutoEventWireup="true" CodeBehind="CustomerInformation.aspx.cs" Inherits="HTV.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHeader" runat="server">
    <br />Purchase Request Number 
    <asp:Label ID="lblPR" runat="server" Text="0"></asp:Label>
&nbsp;- Customer Information 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: 75px;"></div>
    <asp:Button ID="btnOverview" class="buttons" runat="server" Text="Purchase Overview" PostBackUrl="~/PurchaseOverview.aspx" /><br />
    <asp:Button ID="btnEmployee" class="buttons" runat="server" Text="Lead Employee Info" PostBackUrl="~/EmployeeInformation.aspx" /><br />
    <asp:Button ID="btnCustomer" class="activeButtons" runat="server" Text="Customer Info" PostBackUrl="~/CustomerInformation.aspx" /><br />
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
    <asp:Label ID="Label1" class="lbls" runat="server" Text="Select a Customer:"></asp:Label>
    <asp:DropDownList ID="ddlCustomerID" class="txts" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCustomerID_SelectedIndexChanged">
        <asp:ListItem Selected="True">1</asp:ListItem>
    </asp:DropDownList>
    <div class="clears"></div>
    <asp:Label ID="Label13" class="lbls" runat="server" Text="Enter Customer Information"></asp:Label>
    <asp:Label ID="lblRequired" class="txts" runat="server" style="color: red; font-size: 85%; font-style:italic;">* = Required Information</asp:Label>
    <div class="clears"></div>
    <asp:Label ID="Label14" class="lbls" runat="server" Text="Social Security Number:*"></asp:Label>
    <asp:TextBox ID="txtSocial" class="txts" runat="server" Text="321-12-5446"></asp:TextBox>
    <div class="clears"></div>
    <asp:Label ID="Label15" class="lbls" runat="server" Text="Driver's License Number:*"></asp:Label>
    <asp:TextBox ID="txtLicense" class="txts" runat="server" Text="8900251CA"></asp:TextBox>
    <div class="clears"></div>
    <asp:Label ID="Label2" class="lbls" runat="server" Text="First Name:*"></asp:Label>
    <asp:TextBox ID="txtFirst" class="txts" runat="server" Text="Julie"></asp:TextBox>
    <div class="clears"></div>
    <asp:Label ID="Label3" class="lbls" runat="server" Text="Last Name:*"></asp:Label>
    <asp:TextBox ID="txtLast" class="txts" runat="server" Text="Childs"></asp:TextBox>
    <div class="clears"></div>
    <asp:Label ID="Label4" class="lbls" runat="server" Text="Address:*"></asp:Label>
    <asp:TextBox ID="txtAddress1" class="txts" runat="server" Text="433 Silver Stream Ln."></asp:TextBox>
    <div class="clears"></div>
    <asp:Label ID="Label5" class="lbls" runat="server" Text="Address Line 2:"></asp:Label>
    <asp:TextBox ID="txtAddress2" class="txts" runat="server"></asp:TextBox>
    <div class="clears"></div>
    <asp:Label ID="Label6" class="lbls" runat="server" Text="City:*"></asp:Label>
    <asp:TextBox ID="txtCity" class="txts" runat="server" Text="Huntington Beach"></asp:TextBox>
    <div class="clears"></div>
    <asp:Label ID="Label7" class="lbls" runat="server" Text="State:*"></asp:Label>
    <asp:TextBox ID="txtState" class="txts" runat="server" Text="CA"></asp:TextBox>
    <div class="clears"></div>
    <asp:Label ID="Label8" class="lbls" runat="server" Text="Zip Code:*"></asp:Label>
    <asp:TextBox ID="txtZip" class="txts" runat="server" Text="92646"></asp:TextBox>
    <div class="clears"></div>
    <asp:Label ID="Label9" class="lbls" runat="server" Text="Phone Number:"></asp:Label>
    <asp:TextBox ID="txtPhone" class="txts" runat="server" Text="657-555-1212"></asp:TextBox>
    <div class="clears"></div>
    <asp:Label ID="Label10" class="lbls" runat="server" Text="Email:"></asp:Label>
    <asp:TextBox ID="txtEmail" class="txts" runat="server" Text="jchilds@juliechilds.com"></asp:TextBox>
    <br />
    <br />
    <br />
    <asp:Button ID="btnSave" class="contentButtons" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="vg1" />
    <asp:Button ID="btnClear" class="contentButtons" runat="server" Text="Clear" OnClick="btnClear_Click" />
    <asp:Button ID="btnNewCustomer" class="contentButtons" runat="server" Text="New Customer" OnClick="btnNewCustomer_Click" />
    <asp:Button ID="btnBack" class="contentButtons" runat="server" Text="Back to Main" PostBackUrl="~/MainMenu.aspx" />
    <br />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentFooter" runat="server">
    <asp:Label ID="Warnings" class="warning" runat="server" Text=""></asp:Label><br />Copyright &copy; 2017 Team D
</asp:Content>
