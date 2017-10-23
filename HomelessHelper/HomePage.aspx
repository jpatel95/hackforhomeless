<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HomePage.aspx.cs" Inherits="HomePage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <asp:HyperLink ID="helpLink" runat="server" NavigateUrl="HelpPage.htm" Target="_blank">Directions for use</asp:HyperLink>
        <br />
        <br />
        <asp:DropDownList ID="ActionDropDown" runat="server" AutoPostBack="True" 
            onselectedindexchanged="ActionDropDown_SelectedIndexChanged">
        <asp:ListItem>Insert</asp:ListItem>
        <asp:ListItem>Search</asp:ListItem>
        <asp:ListItem>Update</asp:ListItem>
        <asp:ListItem>Delete</asp:ListItem>
        <asp:ListItem>List</asp:ListItem>

        </asp:DropDownList>
        <br />
        <br />

        <asp:Table ID="Table1" runat="server" CellPadding="5">
        <asp:TableRow>
            <asp:TableCell><asp:Label Font-Bold="true" ID="CellAgencyID" Text="Agency ID" runat="server"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:Label Font-Bold="true" ID="CellName" Text="Name" runat="server"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:Label Font-Bold="true" ID="CellStateID" Text="State ID" runat="server"></asp:Label></asp:TableCell>
        </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                <asp:TextBox ID="AgencyID" runat="server" ViewStateMode="Enabled"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                <asp:TextBox ID="Name" runat="server" ViewStateMode="Enabled"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                <asp:TextBox ID="StateID" runat="server" ViewStateMode="Enabled"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Label Font-Bold="true" ID="CellCurrBalance" Text="Current Balance" runat="server"></asp:Label></asp:TableCell>
                <asp:TableCell><asp:Label Font-Bold="true" ID="CellTotalEarned" Text="Total Earned" runat="server"></asp:Label></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                <asp:TextBox ID="CurrBalance" runat="server" ViewStateMode="Enabled"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                <asp:TextBox ID ="TotalEarned" runat="server" ViewStateMode="Enabled"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Go!" />
        <br />
        <asp:Table ID="Table2" runat="server" CellPadding="5" Visible="False">
        <asp:TableRow>
            <asp:TableCell Font-Bold="True">Agency ID</asp:TableCell>
            <asp:TableCell Font-Bold="True">Name</asp:TableCell>
            <asp:TableCell Font-Bold="True">State ID</asp:TableCell>
            <asp:TableCell Font-Bold="True">Current Balance</asp:TableCell>
            <asp:TableCell Font-Bold="True">Total Earned</asp:TableCell>
        </asp:TableRow>
        </asp:Table>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
