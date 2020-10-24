<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AssignVolunteer.aspx.cs" Inherits="Lab2.AssignVolunteer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Assign Volunteer to Events
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
            <fieldset>
                <legend>Assign Volunteers to Events: </legend>
                <asp:DropDownList
                    ID ="ddlVolunteerList"
                    runat ="server"
                    DataSourceID ="datasrcUserList"
                    DataTextField ="VolunteerName"
                    DataValueField ="PersonnelID"
                    AutoPostBack ="true" Height="27px" OnSelectedIndexChanged ="ddlVolunteerList_SelectedIndexChanged"></asp:DropDownList>
                <asp:CheckBox 
                    ID="Cb1" 
                    runat="server" 
                    Text ="EventTitle"/>
                <asp:CheckBox 
                    ID="Cb2" 
                    runat="server" 
                    Text ="EventTitle"/>
                <asp:CheckBox 
                    ID="Cb3" 
                    runat="server" 
                    Text ="EventTitle"/>
                <asp:CheckBox 
                    ID="Cb4" 
                    runat="server" 
                    Text ="EventTitle"/>
                <asp:Button 
                    ID="btnAssignVolunteers" 
                    runat="server" 
                    Text="Commit -> " 
                    Onclick ="btnAssignVolunteers_Click" Height="27px"/>
                <asp:Button 
                    ID="btnPopulate" 
                    runat="server" 
                    Text="Display ->" 
                    OnClick ="btnPopulate_Click"  Height="27px"/>
            </fieldset>
            <br />
            <fieldset>
                <legend>Events for Selected Volunteers: </legend>
                <asp:GridView
                    runat ="server"
                    ID ="getResult"
                    AlternatingRowStyle-BackColor ="#eaaaff"
                    EmptyDataText ="No Volunteers Selected!" Height="229px" Width="310px"></asp:GridView>
            </fieldset>
        </div>
        <asp:SqlDataSource runat ="server"
            ID ="datasrcUserList"
            ConnectionString ="<%$ConnectionStrings:CyberDay %>"
            SelectCommand = "Select  FirstName + ' ' + LastName as VolunteerName, PersonnelID  From EventPersonnel ; " />
         
</asp:Content>
