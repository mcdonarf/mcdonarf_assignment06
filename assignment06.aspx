<%@ Page Language="C#" AutoEventWireup="true" CodeFile="assignment06.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Assignment 06</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblTransactionTime" runat="server" Text="Enter Transaction Time: HH:MM:SS(24H)"></asp:Label>
        <asp:TextBox ID="txtTransactionTime" runat="server" TextMode="Time"></asp:TextBox> <br />
        <asp:Label ID="lblTransactionDate" runat="server" Text="Enter Transaction Date: YYYY-MM-DD"></asp:Label>
        <asp:TextBox ID="txtTransactionDate" runat="server" TextMode="Date"></asp:TextBox> <br />
        <asp:Label ID="lblStore" runat="server" Text="Select Store"></asp:Label>
        <asp:DropDownList ID="ddlStore" runat="server"></asp:DropDownList> <br />
        <asp:Label ID="lblLoyalty" runat="server" Text="Select Loyalty Number"></asp:Label>
        <asp:DropDownList ID="ddlLoyalty" runat="server"></asp:DropDownList> <br />
        <asp:Label ID="lblTransactionType" runat="server" Text="Select Transaction Type"></asp:Label>
        <asp:DropDownList ID="ddlTransactionType" runat="server"></asp:DropDownList> <br />
        <asp:Label ID="lblEmpl" runat="server" Text="Select the Employee"></asp:Label>
        <asp:DropDownList ID="ddlEmpl" runat="server"></asp:DropDownList> <br />
        <asp:Label ID="lblComment" runat="server" Text="Leave a comment if prefered for the transaction."></asp:Label>
        <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine"></asp:TextBox> <br />
        <asp:Label ID="lblProduct" runat="server" Text="Select Product"></asp:Label>
        <asp:ListBox ID="lbProduct" runat="server"></asp:ListBox> <br />
        <asp:Label ID="lblQtyOfProduct" runat="server" Text="Enter the quantity of product."></asp:Label>
        <asp:TextBox ID="txtQtyOfProduct" runat="server" TextMode="Number"></asp:TextBox> <br />
        <asp:Label ID="lblPricePerSale" runat="server" Text="Enter the price per sellable unit as marked."></asp:Label>
        <asp:TextBox ID="txtPricePerSale" runat="server"></asp:TextBox> <br />
        <asp:Label ID="lblPricePerSaleToCustomer" runat="server" Text="Enter the price per sellable unit to the customer."></asp:Label>
        <asp:TextBox ID="txtPricePerSaleToCustomer" runat="server"></asp:TextBox> <br />
        <asp:Label ID="lblTransDetailComment" runat="server" Text="Leave a comment if prefered for the transaction detail."></asp:Label>
        <asp:TextBox ID="txtTransDetailComment" runat="server" TextMode="MultiLine"></asp:TextBox> <br />
        <asp:Button ID="btnInsert" runat="server" Text="Insert" OnClick="btnInsert_Click" /> <br />
        <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
    </div>
    </form>
</body>
</html>
