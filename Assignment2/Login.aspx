<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Assignment2.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        

    </title>
    <style>
        body{
            background-color:aliceblue;
            align-content:center;
        }
        title{
            font-weight:500; 
            Font-Size:larger;
            color:aliceblue;
        }
        .auto-style1 {
            text-align: center;
        }
        </style>
</head>
<body>
    <p>
        <br />
    </p>
    <form id="form1" runat="server">
    <p class="auto-style1">
            &nbsp;</p>
    <p>
        &nbsp;</p>
        <div>
        <table style ="margin:auto; border:5px solid white; align-content:center" align="center">
            <tbody class="auto-style1">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Username" Font-Bold="True"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                </td>
            </tr>

             <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" Font-Bold="True" />
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Label ID="Label3" runat="server" ForeColor ="Red"></asp:Label>
                </td>
            </tr>
            
        </table>
        </div>
    </form>
</body>
</html>
<%--  --%>