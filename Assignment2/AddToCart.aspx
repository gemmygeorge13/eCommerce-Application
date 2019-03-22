<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddToCart.aspx.cs" Inherits="Assignment2.AddToCart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            text-align: right;
            width: 80%;
        }
        </style>
    <%--<meta http-equiv="refresh" content="10" />--%>

</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style2">
            <asp:Button ID="Button4" runat="server" Text="Logout" Font-Bold="True" OnClick="Button4_Click" />
        </div>
        <div class="auto-style1">
            
            <br />
            <br />
            <br />
            You have
            <asp:Label ID="Label2" runat="server"></asp:Label>
            Items in your cart&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button3" runat="server" Text="Continue Shopping" OnClick="Button3_Click" />
            
            <br />
            <br />
            <br />
            <asp:Timer ID="Timer1" runat="server" Interval="60000" OnTick="Timer1_Tick">
            </asp:Timer>


            <asp:ScriptManager ID="ScriptManger1" runat="Server" />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center" CellPadding="2" ForeColor="Black" GridLines="None" Height="284px" Width="523px" OnRowDeleting="GridView1_RowDeleting" ShowFooter="True" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px">
                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                <Columns>
                    <asp:BoundField DataField="sno" HeaderText="Sr. No.">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="itemid" HeaderText="ItemId">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="price" HeaderText="Price">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="quantity" HeaderText="Quantity">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="totalprice" HeaderText="Total Price">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:CommandField DeleteText="Remove" ShowDeleteButton="True" />
                </Columns>
                <FooterStyle BackColor="Tan" />
                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                <SortedAscendingCellStyle BackColor="#FAFAE7" />
                <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                <SortedDescendingCellStyle BackColor="#E1DB9C" />
                <SortedDescendingHeaderStyle BackColor="#C2A47B" />
            </asp:GridView>
        </div>
        <p>
            &nbsp;</p>
        <p class="auto-style1">
            <asp:Button ID="Button1" runat="server" Font-Bold="True" OnClick="Button1_Click" Text="Check Out" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" Text="Cancel" Font-Bold="True" OnClick="Button2_Click" />
        </p>
        <p class="auto-style1">
            &nbsp;</p>
    </form>
</body>
</html>
