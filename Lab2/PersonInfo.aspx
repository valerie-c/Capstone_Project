<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="PersonInfo.aspx.cs" Inherits="Lab2.PersonInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Valerie Chang & Matt Suder--Show Coordinator/Volunteer Informations
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <fieldset>
            <asp:Label ID="Label1" runat="server" Text="Coordinator Name:"></asp:Label>
            <asp:DropDownList 
                ID="DropDownList1" 
                runat="server"
                AutoPostBack ="true" Height ="27px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"> </asp:DropDownList>
<%--             <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />--%>
            <hr />
            <asp:Label ID="Label2" runat="server" Text="Volunteer Name:"></asp:Label>
            <asp:DropDownList 
                ID="DropDownList2" 
                runat="server"
                AutoPostBack ="true" Height ="27px" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"></asp:DropDownList>
<%--            <asp:Button ID="Button1" runat="server" Text="Clear" OnClick="Button1_Click" />--%>
            
        </fieldset>
        <br />
        <fieldset>
            <center>
                <h2>Display Coordinator & Volunteer Information</h2>
                    <hr />
                </center>
                <asp:GridView 
                    ID="GridView1"
                    runat="server"
                    AutoPostBack="true"
                    AutoGenerateColumns="false"
                    AutoGenerateEditButton="true"
                    AllowSorting="true"
                    AllowPaging="true"
                    EmptyDataText ="No Coordinator Selected!" Height="229px" Width="310px">
                    
                    <Columns>
                        <asp:BoundField ReadOnly="true"
                            HeaderText="CoordinatorID"
                            DataField="CoordinatorID"
                            InsertVisible="False"
                            SortExpression="CordinatorID"/>
                        <asp:BoundField HeaderText="CoordinatorName"
                            DataField="CoordinatorName" 
                            SortExpression="CoordinatorName" />
                        <asp:BoundField HeaderText="CoordinatorPhone"
                            DataField="PhoneNumber"
                            SortExpression="PhoneNumber" />
                        <asp:BoundField HeaderText="CoordinatorEmail"
                            DataField="Email"
                            SortExpression="Email" />
                        <asp:BoundField HeaderText="EventTitle"
                            DataField="EventTitle"
                            SortExpression="EventTitle"/>
                        <asp:BoundField HeaderText="Date"
                            DataField="Date"
                            SortExpression="Date"/>
                        <asp:BoundField HeaderText="Time"
                            DataField="Time"
                            SortExpression="Time"/>
          
                       </Columns>
                </asp:GridView>

                <asp:GridView
                    ID="GridView2"
                    runat="server"
                    AutoPostBack="true"
                    AutoGenerateColumns="false"
                    AutoGenerateEditButton="true"
                    AllowSorting="true"
                    AllowPaging="true"
                    EmptyDataText ="No Volunteer Selected!" Height="229px" Width="310px">

                <Columns>
                        <asp:BoundField ReadOnly="true"
                            HeaderText="PersonnelID"
                            DataField="PersonnelID"
                            InsertVisible="False"
                            SortExpression="PersonnelID"/>
                        <asp:BoundField HeaderText="VolunteerName"
                            DataField="VolunteerName" 
                            SortExpression="VolunteerName" />
                        <asp:BoundField HeaderText="VolunteerPhone"
                            DataField="PhoneNumber"
                            SortExpression="PhoneNumber" />
                        <asp:BoundField HeaderText="VolunteerEmail"
                            DataField="EmailAddress"
                            SortExpression="EmailAddress" />
                        <asp:BoundField HeaderText="EventTitle"
                            DataField="EventTitle"
                            SortExpression="EventTitle"/>
                        <asp:BoundField HeaderText="Date"
                            DataField="Date"
                            SortExpression="Date"/>
                        <asp:BoundField HeaderText="Time"
                            DataField="Time"
                            SortExpression="Time"/>
          
                       </Columns>
                </asp:GridView>
            </div>

<%--           <asp:SqlDataSource  
                ID="sqlsrcEventQuery"
                runat="server"
                ConnectionString="<%$ConnectionStrings:dbconnection %>"
                SelectCommand="SELECT Event.EventID, Event.EventTitle, Event.Time, Event.Date, Coordinator.FirstName + ' ' + Coordinator.LastName as CoordinatorName,EventPersonnel.FirstName + ' ' + EventPersonnel.LastName as VolunteerName FROM Event, EventPersonnel, EventPresenter, Coordinator WHERE Event.EventID = EventPresenter.EventID and EventPersonnel.PersonnelID = EventPresenter.PersonnelID and Coordinator.CoordinatorID = EventPresenter.CoordinatorID ; " />--%>

   
</asp:Content>


       
