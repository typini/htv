<%--///////////////////////////////////////////////
// File:  AddOns.aspx
// Program Name:  HTV_v2.0
// Programmer:  Tyree Pini
// Group:  Team D
// Course:  CIS470 Senior Project
// Date:  19 April 2017
// Website:  http://htvteamd.azurewebsites.net/
///////////////////////////////////////////////--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/HTV.Master" AutoEventWireup="true" CodeBehind="AddOns.aspx.cs" Inherits="HTV.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHeader" runat="server">
            <br />Purchase Request Number 
            <asp:Label ID="lblPR" runat="server" Text="0"></asp:Label>
            &nbsp;- Vehicle Add-On Options 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: 75px;"></div>
    <asp:Button ID="btnOverview" class="buttons" runat="server" Text="Purchase Overview" PostBackUrl="~/PurchaseOverview.aspx" /><br />
    <asp:Button ID="btnEmployee" class="buttons" runat="server" Text="Lead Employee Info" PostBackUrl="~/EmployeeInformation.aspx" /><br />
    <asp:Button ID="btnCustomer" class="buttons" runat="server" Text="Customer Info" PostBackUrl="~/CustomerInformation.aspx" /><br />
    <asp:Button ID="btnNewVehicle" class="buttons" runat="server" Text="New Vehicle Details" PostBackUrl="~/NewVehicleInformation.aspx" /><br />
    <asp:Button ID="btnAddOns" class="activeButtons" runat="server" Text="Add-On Options" PostBackUrl="~/AddOns.aspx" /><br />
    <asp:Button ID="btnTradeIn" class="buttons" runat="server" Text="Trade-In Details" PostBackUrl="~/TradeIns.aspx" /><br />
    <asp:Button ID="btnFinancing" class="buttons" runat="server" Text="Financing Details" PostBackUrl="~/Financing.aspx" /><br />
    <asp:Button ID="btnMechanic" class="inactiveButtons" runat="server" Text="Mechanic's Approval" PostBackUrl="~/MechanicApproval.aspx" /><br />
    <asp:Button ID="btnManager" class="inactiveButtons" runat="server" Text="Manager Approval" PostBackUrl="~/ManagerApproval.aspx" />
    <asp:Button ID="btnCompleteSale" class="inactiveButtons" runat="server" Text="Sale Completion" PostBackUrl="~/CompleteSale.aspx" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="clears"></div>
    <asp:Label ID="Label1" class="lbls" runat="server" Text="Current Cost of Add-Ons:"></asp:Label>
    <asp:Label ID="lblAddOnCost" class="txts" style="color:gray;" runat="server" Text="$0.00"></asp:Label>
    <div class="clears"></div>
    <asp:Label ID="Label13" class="lbls" runat="server" Text="Select Add-On Options"></asp:Label>
    <div class="clears"></div>
    <asp:CheckBox ID="chbQueenBed" class="chbs" runat="server" />
    <asp:Label ID="Label14" class="lbls" runat="server" Text="Queen Bed"></asp:Label>
    <asp:Label ID="lblQueenBedCost" class="txts" runat="server" Text="$500.00"></asp:Label>
    <div class="clears"></div>
    <asp:CheckBox ID="chbLeatherFurniture" class="chbs" runat="server" Checked="True" />
    <asp:Label ID="Label15" class="lbls" runat="server" Text="Leather Furniture"></asp:Label>
    <asp:Label ID="lblLeatherFurnitureCost" class="txts" runat="server" Text="$2,000.00"></asp:Label>
    <div class="clears"></div>
    <asp:CheckBox ID="chbGPS" class="chbs" runat="server" />
    <asp:Label ID="Label2" class="lbls" runat="server" Text="GPS"></asp:Label>
    <asp:Label ID="lblGPSCost" class="txts" runat="server" Text="$300.00"></asp:Label>
    <div class="clears"></div>
    <asp:CheckBox ID="chbStereo" class="chbs" runat="server" />
    <asp:Label ID="Label3" class="lbls" runat="server" Text="Deluxe Stereo System"></asp:Label>
    <asp:Label ID="lblSteroCost" class="txts" runat="server" Text="$800.00"></asp:Label>
    <div class="clears"></div>
    <asp:CheckBox ID="chbDishWasher" class="chbs" runat="server" Checked="True" />
    <asp:Label ID="Label4" class="lbls" runat="server" Text="Dish Washer"></asp:Label>
    <asp:Label ID="lblDishWasherCost" class="txts" runat="server" Text="$800.00"></asp:Label>
    <div class="clears"></div>
    <asp:CheckBox ID="chbSwampCooler" class="chbs" runat="server" />
    <asp:Label ID="Label5" class="lbls" runat="server" Text="Swamp Cooler"></asp:Label>
    <asp:Label ID="lblSwampCoolerCost" class="txts" runat="server" Text="$600.00"></asp:Label>
    <div class="clears"></div>
    <asp:CheckBox ID="chbWaterSystem" class="chbs" runat="server" />
    <asp:Label ID="Label6" class="lbls" runat="server" Text="Filtration Water System"></asp:Label>
    <asp:Label ID="lblWaterSystemCost" class="txts" runat="server" Text="$500.00"></asp:Label>
    <div class="clears"></div>
    <asp:CheckBox ID="chbCargoHolders" class="chbs" runat="server" />
    <asp:Label ID="Label7" class="lbls" runat="server" Text="Overhead Cargo Holders"></asp:Label>
    <asp:Label ID="lblCargoHoldersCost" class="txts" runat="server" Text="$1,500.00"></asp:Label>
    <div class="clears"></div>
    <asp:CheckBox ID="CheckBox1" class="chbs" runat="server" />
    <asp:Textbox ID="txtNewOption" class="lbls" runat="server" style="width: 250px;" Text="Enter New Option"></asp:Textbox>
    <asp:Textbox ID="txtNewPrice" class="txts" runat="server" style="margin-left: 120px;" Text="$0.00"></asp:Textbox>
    <div class="clears"></div>
    <asp:CheckBox ID="CheckBox2" class="chbs" runat="server" />
    <asp:Textbox ID="Textbox1" class="lbls" runat="server" style="width: 250px;" Text="Enter New Option"></asp:Textbox>
    <asp:Textbox ID="Textbox2" class="txts" runat="server" style="margin-left: 120px;" Text="$0.00"></asp:Textbox>
    <div class="clears"></div>
    <asp:CheckBox ID="CheckBox3" class="chbs" runat="server" />
    <asp:Textbox ID="Textbox3" class="lbls" runat="server" style="width: 250px;" Text="Enter New Option"></asp:Textbox>
    <asp:Textbox ID="Textbox4" class="txts" runat="server" style="margin-left: 120px;" Text="$0.00"></asp:Textbox>
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

