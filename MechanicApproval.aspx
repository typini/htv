<%--///////////////////////////////////////////////
// File:  MechanicApproval.aspx
// Program Name:  HTV_v2.0
// Programmer:  Tyree Pini
// Group:  Team D
// Course:  CIS470 Senior Project
// Date:  19 April 2017
// Website:  http://htvteamd.azurewebsites.net/
///////////////////////////////////////////////--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/HTV.Master" AutoEventWireup="true" CodeBehind="MechanicApproval.aspx.cs" Inherits="HTV.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHeader" runat="server">
       <br />Purchase Request Number 
       <asp:Label ID="lblPR" runat="server" Text="0"></asp:Label>
&nbsp;- Mechanic's Approval 
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
    <asp:Button ID="btnMechanic" class="activeButtons" runat="server" Text="Mechanic's Approval" PostBackUrl="~/MechanicApproval.aspx" /><br />
    <asp:Button ID="btnManager" class="inactiveButtons" runat="server" Text="Manager Approval" PostBackUrl="~/ManagerApproval.aspx" />
    <asp:Button ID="btnCompleteSale" class="inactiveButtons" runat="server" Text="Sale Completion" PostBackUrl="~/CompleteSale.aspx" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="clears"></div>
    <asp:Label ID="Label1" class="lbls" runat="server" Text="Mechanic Employee ID:"></asp:Label>
    <asp:DropDownList ID="ddlCustomerID" class="txts" runat="server">
        <asp:ListItem Selected="True">0000001</asp:ListItem>
    </asp:DropDownList>
    <div class="clears"></div>
    <asp:Label ID="Label13" class="lbls" runat="server" Text="To be Filled Out By the Mechanic"></asp:Label>
    <asp:Label ID="lblRequired" class="txts" runat="server" style="color: red; font-size: 85%; font-style:italic;">* = Required Information</asp:Label>
    <div class="clears"></div>
    <asp:Label ID="Label16" class="lbls" runat="server" Text="Trade-In Vehicle ID:"></asp:Label>
    <asp:Label ID="lblTradeInID" class="txts" runat="server" Text="0000001"></asp:Label>
    <div class="clears"></div>
    <asp:Label ID="Label3" class="lbls" runat="server" Text="Trade-In VIN:"></asp:Label>
    <asp:Label ID="Label4" class="txts" runat="server" Text="VIN032312313201"></asp:Label>
    <div class="clears"></div>
    <asp:Label ID="Label5" class="lbls" runat="server" Text="Trade-In Year:"></asp:Label>
    <asp:Label ID="Label6" class="txts" runat="server" Text="2012"></asp:Label>
    <div class="clears"></div>
    <asp:Label ID="Label7" class="lbls" runat="server" Text="Trade-In Make:"></asp:Label>
    <asp:Label ID="Label8" class="txts" runat="server" Text="Subaru"></asp:Label>
    <div class="clears"></div>
    <asp:Label ID="Label9" class="lbls" runat="server" Text="Trade-In Model:"></asp:Label>
    <asp:Label ID="Label10" class="txts" runat="server" Text="Forester"></asp:Label>
    <div class="clears"></div>
    <asp:Label ID="Label11" class="lbls" runat="server" Text="Trade-In Condition:"></asp:Label>
    <asp:Label ID="Label12" class="txts" runat="server" Text="Good"></asp:Label>
    <div class="clears"></div>
    <asp:Label ID="Label2" class="lbls" runat="server" Text="Trade-In Value:*"></asp:Label>
    <asp:TextBox ID="txtTradeInValue" class="txts" runat="server" Text="$8,000.00"></asp:TextBox>
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
