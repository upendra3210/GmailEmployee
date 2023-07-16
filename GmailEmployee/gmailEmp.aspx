<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gmailEmp.aspx.cs" Inherits="GmailEmployee.gmailEmp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 26px;
        }
        .auto-style2 {
            margin-left: 19px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>Registation Form</h3>
            <div>
                <table>
                    <tr>
                       <td><asp:Label ID="lblName" runat="server" Text="Full Name:"></asp:Label></td>
                        <td><asp:TextBox ID="TxtName" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblDob" runat="server" Text="DOB:"></asp:Label></td>
                        <td><asp:TextBox ID="EmpDob" runat="server" TextMode="Date"></asp:TextBox></td>
                    </tr>
                     <tr>
                       <td><asp:Label ID="Gmail" runat="server" Text="Gmail:"></asp:Label></td>
                        <td><asp:TextBox ID="txtGmail" runat="server" TextMode="Email"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblPhone" runat="server" Text="phone Number:"></asp:Label></td>
                        <td><asp:TextBox ID="EmpPhone" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="auto-style1"><asp:Label ID="lblAge" runat="server" Text="Age:"></asp:Label></td>
                        <td class="auto-style1"><asp:TextBox ID="EmpAge" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblAddress" runat="server" Text="Address:"></asp:Label></td>
                        <td><asp:TextBox ID="Address" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Button ID="BtnSubmit" runat="server" OnClick="BtnSubmit_Click" BackColor="Blue" ForeColor="White" Text="Submit" Width="100px"></asp:Button></td>
                        <td><asp:Button ID="BtnCancel" runat="server" BackColor="Blue" CssClass="auto-style2" ForeColor="White" Text="Cancel" Width="100px"></asp:Button></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label1" runat="server" Visible="false"></asp:Label></td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>

