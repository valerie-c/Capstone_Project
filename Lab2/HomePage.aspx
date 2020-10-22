<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Lab2.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Valerie Chang & Matt Suder--Login Page
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
            <%--<asp:Label ID="lblUserStatus" runat="server" Text=""></asp:Label>--%>
            <asp:Image ID="Image1" runat="server" ImageUrl="/Images/welcome.jpg"/>
        </div>
</asp:Content>
