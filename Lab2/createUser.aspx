<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="createUser.aspx.cs" Inherits="Lab2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Valerie Chang & Matt Suder--Create User</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:LinkButton ID="lnkLogin" runat="server" OnClick="lnkLogin_Click">Login</asp:LinkButton>
            <br />
            <br />
            <strong>Create User</strong><br />
            First Name:&nbsp;
            <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
            <br />
            Last Name:
            <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
            <br />
            School:
            <asp:TextBox ID="txtSchool" runat="server"></asp:TextBox>
            <br />
            Grade Taught:
            <asp:TextBox ID="txtGrade" runat="server"></asp:TextBox>
            <br />
            Username:
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            <br />
            Password:
            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
            <br />
            <asp:Label ID="lblStatus" runat="server"></asp:Label>
            <br />
            <asp:LinkButton ID="lnkAnother" runat="server" OnClick="lnkAnother_Click" Visible="False">Create Another</asp:LinkButton>
            <br />
            <br />
            <asp:Button ID="btnPopulate" runat="server" Text="Populate ->" OnClick="btnPopulate_Click" />
        </div>
        <div>
            <asp:GridView ID="GridView1" 
                runat="server" 
                AlternatingRowStyle-BackColor ="#eaaaff"
                EmptyDataText ="No Students Selected!" Height="229px" Width="310px"></asp:GridView>
        </div>
    </form>
</body>
</html>
