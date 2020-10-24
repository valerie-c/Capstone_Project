<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AssignStudent.aspx.cs" Inherits="Lab2.AssignStudent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
   Assign Students to Events
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
            <fieldset>
                <legend>Assign Students to Events: </legend>
                <asp:DropDownList
                    ID ="ddlUserList"
                    runat ="server"
                    DataSourceID ="datasrcUserList"
                    DataTextField ="StudentName"
                    DataValueField ="StudentID"
                    AutoPostBack ="true" Height="27px"></asp:DropDownList>
                <asp:CheckBox 
                    ID="CheckBox1" 
                    runat="server" 
                    Text ="EventTitle"/>
                <asp:CheckBox 
                    ID="CheckBox2" 
                    runat="server" 
                    Text ="EventTitle"/>
                <asp:CheckBox 
                    ID="CheckBox3" 
                    runat="server" 
                    Text ="Trade Shows"/>
                <asp:CheckBox 
                    ID="CheckBox4" 
                    runat="server" 
                    Text ="Product Launches"/>
                <asp:Button 
                    ID="btnAssignStudent" 
                    runat="server" 
                    Text="Commit -> " 
                    Onclick ="btnAssignStudent_Click" Height="27px"/>
                <asp:Button 
                    ID="btnShowAll" 
                    CausesValidation="false"
                    runat="server" 
                    Text="Display ->" 
                    OnClick ="btnShowAll_Click" Height="27px"/>
            </fieldset>
            <br />
            <fieldset>
                <legend>Events for Selected Students: </legend>
                <asp:GridView
                    runat ="server"
                    ID ="getEventsResult"
                    AlternatingRowStyle-BackColor ="#eaaaff"
                    EmptyDataText ="No Students Selected!" Height="229px" Width="310px"></asp:GridView>
            </fieldset>
        </div>
        <asp:SqlDataSource runat ="server"
            ID ="datasrcUserList"
            ConnectionString ="<%$ConnectionStrings:CyberDay %>"
            SelectCommand = "Select  FirstName + ' ' + LastName as StudentName, StudentID  From Student; " />
</asp:Content>
