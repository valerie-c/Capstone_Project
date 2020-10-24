<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AssignCoordinator.aspx.cs" Inherits="Lab2.AssignCoordinator" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
   Assign Coordinators to Events
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div>
            <fieldset>
                <legend>Assign Coordinator to Events: </legend>
                <asp:DropDownList
                    ID ="ddlCoordinatorList"
                    runat ="server"
                    DataSourceID ="datasrcUserList"
                    DataTextField ="CoordinatorName"
                    DataValueField ="CoordinatorID"
                    AutoPostBack ="true" Height="27px" ></asp:DropDownList>
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
                    ID="btnAssignCoordinators" 
                    runat="server" 
                    Text="Commit -> " 
                    Onclick ="btnAssignCoordinators_Click" Height="27px"/>
                <asp:Button 
                    ID="btnPopulate" 
                    CausesValidation="false"
                    runat="server" 
                    Text="Display ->" 
                    OnClick ="btnPopulate_Click"  Height="27px"/>
            </fieldset>
            <br />
            <fieldset>
                <legend>Events for Selected Coordinators: </legend>
                <asp:GridView
                    runat ="server"
                    ID ="getResult"
                    AlternatingRowStyle-BackColor ="#eaaaff"
                    EmptyDataText ="No Coordinators Selected!" Height="229px" Width="310px"></asp:GridView>
            </fieldset>
        </div>
        <asp:SqlDataSource runat ="server"
            ID ="datasrcUserList"
            ConnectionString ="<%$ConnectionStrings:CyberDay %>"
            SelectCommand = "Select  FirstName + ' ' + LastName as CoordinatorName, CoordinatorID  From Coordinator ; " />
</asp:Content>
