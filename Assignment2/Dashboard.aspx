<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Assignment2.Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            height: 205px;
        }
        .auto-style3 {
            text-align: center;
        }
        .auto-style4 {
            height: 33px;
        }
        .auto-style5 {
            height: 40px;
        }
        .auto-style6 {
            text-align: right;
        }
        .auto-style7 {
            text-align: right;
            width: 80%;
        }
    </style>
    <meta http-equiv="refresh" content="5" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style6">
            <div class="auto-style7">
                <asp:Button ID="Button2" runat="server" Text="Logout" Font-Bold="True" OnClick="Button2_Click" />
            </div>
            
            <div class="auto-style3">
                
            &nbsp;<br />
            <br />
            You have products in your cart&nbsp;&nbsp;<asp:Label ID="Label10" runat="server"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/AddToCart.aspx">Show Cart</asp:HyperLink>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            </div>
            <asp:DataList ID="DataList1" runat="server" CellPadding="2" ForeColor="Black" DataKeyField="itemNumber" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="DataList1_SelectedIndexChanged" HorizontalAlign="Center" RepeatColumns="4" RepeatDirection="Horizontal" OnItemCommand="DataList1_ItemCommand" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" Height="209px" Width="941px">
                <AlternatingItemStyle BackColor="PaleGoldenrod" />
                <FooterStyle BackColor="Tan" />
                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                <ItemTemplate>
                    <table class="auto-style1">
                        <tr>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="Item Number"></asp:Label>
                                :<asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("itemNumber") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style4">
                                <asp:Label ID="Label5" runat="server" Text="Price"></asp:Label>
                                :
                                <asp:Label ID="Label6" runat="server" Text='<%# Eval("price") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style5">
                                <asp:Label ID="Label7" runat="server" Text="Quantity"></asp:Label>
                                :<asp:Label ID="Label8" runat="server" Text='<%# Eval("Inventory_Item") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                    <asp:ListItem Value="1"></asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="Button1" runat="server" CommandArgument='<%# Eval("itemNumber") %>' CommandName="addtocart" OnClick="Button1_Click" Text="Add to Cart" />
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
                <SelectedItemStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            </asp:DataList>
            <br />
            <br />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:mySampleDatabaseConnectionString %>" OnSelecting="SqlDataSource1_Selecting" SelectCommand="SELECT * FROM [Item$]"></asp:SqlDataSource>


            <asp:Repeater ID ="d1" runat ="server" OnItemCommand="d1_ItemCommand">
                <HeaderTemplate>
                    <table> 
                        <tr> 
                            <th>Item Number</th>
                            <th>Price</th>
                            <th>Items Remaining</th>
                            <th>Enter Quantity</th>
                            <th></th>
                        </tr> 
                    

                    
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td> <%#Eval("ITEMNUMBER") %></td>
                        <td> <%#Eval("Price") %></td>
                        <td> <%#Eval("Inventory_item") %></td>
                        <td>
                            <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            
                        </td>
                    </tr>                    
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </form>
    <p>
        &nbsp;</p>
</body>
</html>
