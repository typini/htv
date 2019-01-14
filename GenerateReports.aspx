<%--///////////////////////////////////////////////
// File:  GenerateReports.aspx
// Program Name:  HTV_v2.0
// Programmer:  Tyree Pini
// Group:  Team D
// Course:  CIS470 Senior Project
// Date:  19 April 2017
// Website:  http://htvteamd.azurewebsites.net/
///////////////////////////////////////////////--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/HTV.Master" AutoEventWireup="true" CodeBehind="GenerateReports.aspx.cs" Inherits="HTV.WebForm12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHeader" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: 70px;"></div>
    <div>
        <asp:Label ID="Label3" runat="server" Text="You are logged in."></asp:Label><br />
        <asp:Label ID="Label1" runat="server" Text="Employee:  John Jones"></asp:Label><br />
        <asp:Label ID="Label2" runat="server" Text="Position:  Sales Person"></asp:Label><br />
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Button ID="Button1" runat="server" class="mainButtons" Text="Generate Invoice" />
    <asp:Button ID="Button2" runat="server" class="mainButtons" Text="Generate Vehicles Sold in a Month Report" />
    <asp:Button ID="Button3" runat="server" class="mainButtons" Text="Generate Employee Sales Report" />
    <asp:Button ID="Button4" runat="server" class="mainButtons" Text="Generate Vehicle Options Report" />
    <asp:Button ID="Button5" runat="server" class="mainButtons" Text="Generate Sales with Trade-Ins Report" />
    <asp:Button ID="Button6" runat="server" class="mainButtons" Text="Back to Main Menu" PostBackUrl="~/MainMenu.aspx" />
    <div style="height: 400px;"></div>
    <br />
    <asp:Label ID="Label4" class="lbls" runat="server" Text="Select an Invoice to Print:"></asp:Label>
    <asp:DropDownList ID="ddlCompletedPurchaseRequestIDs" class="txts" runat="server">
        <asp:ListItem Selected="True">522-11-5564: Vaughn, Clarissa</asp:ListItem>
        </asp:DropDownList>
    <div class="clears"></div>
    <asp:Button ID="btnPrint" class="contentButtons" runat="server" Text="Print"/>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentFooter" runat="server">
    <asp:Label ID="Warnings" class="warning" runat="server" Text=""></asp:Label><br />Copyright &copy; 2017 Team D
</asp:Content>
