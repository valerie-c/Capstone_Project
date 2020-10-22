<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="EventInfo.aspx.cs" Inherits="Lab2.EventInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Valerie Chang & Matt Suder--Show Event Informations
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <fieldset>
            <asp:DropDownList 
                ID="DropDownList1" 
                runat="server"
                AutoPostBack ="true" Height="27px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
            
        </fieldset>
        <br />
        <fieldset>
            <center>
                <h2>Display Events Information</h2>
                    <hr />
                </center>
         <div style="display: inline-block;">
                <asp:GridView 
                    ID="GridView1"
                    runat="server"
                    AutoPostBack="true"
                    AutoGenerateColumns="false"
                    AutoGenerateEditButton="true"
                    AllowSorting="true"
                    AllowPaging="true"
                    EmptyDataText ="No Events Selected!" Height="229px" Width="310px">
                    
                    <Columns>
                        <asp:BoundField ReadOnly="true"
                            HeaderText="EventID"
                            DataField="EventID"
                            InsertVisible="False"
                            SortExpression="EventID"/>
                        <asp:BoundField HeaderText="EventTitle"
                            DataField="EventTitle"
                            SortExpression="EventTitle"/>
                        <asp:BoundField HeaderText="Date"
                            DataField="Date"
                            SortExpression="Date"/>
                        <asp:BoundField HeaderText="Time"
                            DataField="Time"
                            SortExpression="Time"/>
                        <asp:BoundField HeaderText="CoordinatorName"
                            DataField="CoordinatorName" 
                            SortExpression="CoordinatorName" />
<%--                        <asp:BoundField HeaderText="VolunteerName"
                            DataField="VolunteerName" 
                            SortExpression="VolunteerName" />
                        <asp:BoundField HeaderText="StudentName" 
                            DataField="StudentName" 
                            SortExpression="StudentName" />  --%>        
                       </Columns>
                </asp:GridView>
             </div>

                <div style="display: inline-block;">
                <asp:GridView ID="GridView2" 
                    runat="server"
                    AutoPostBack="true"
                    AutoGenerateColumns="false"
                    AutoGenerateEditButton="true"
                    AllowSorting="true"
                    AllowPaging="true"
                    EmptyDataText ="No Events Selected!" Height="229px" Width="310px">
                
                    <Columns>
                        <asp:BoundField ReadOnly="true"
                            HeaderText="EventID"
                            DataField="EventID"
                            InsertVisible="False"
                            SortExpression="EventID"/>
                        <asp:BoundField HeaderText="EventTitle"
                            DataField="EventTitle"
                            SortExpression="EventTitle"/>
                        <asp:BoundField HeaderText="Date"
                            DataField="Date"
                            SortExpression="Date"/>
                        <asp:BoundField HeaderText="Time"
                            DataField="Time"
                            SortExpression="Time"/>
                        <asp:BoundField HeaderText="VolunteerName"
                            DataField="VolunteerName" 
                            SortExpression="VolunteerName" />         
                       </Columns>
                </asp:GridView>
                    </div>

             <div style= "display:inline-block;">
            <asp:GridView ID="GridView3" 
                runat="server"
                 AutoPostBack="true"
                    AutoGenerateColumns="false"
                    AutoGenerateEditButton="true"
                    AllowSorting="true"
                    AllowPaging="true"
                    EmptyDataText ="No Events Selected!" Height="229px" Width="310px">
                
                    <Columns>
                        <asp:BoundField ReadOnly="true"
                            HeaderText="EventID"
                            DataField="EventID"
                            InsertVisible="False"
                            SortExpression="EventID"/>
                        <asp:BoundField HeaderText="EventTitle"
                            DataField="EventTitle"
                            SortExpression="EventTitle"/>
                        <asp:BoundField HeaderText="Date"
                            DataField="Date"
                            SortExpression="Date"/>
                        <asp:BoundField HeaderText="Time"
                            DataField="Time"
                            SortExpression="Time"/>
                        <asp:BoundField HeaderText="StudentName" 
                            DataField="StudentName" 
                            SortExpression="StudentName" />          
                       </Columns>
                </asp:GridView>
            </div>                
            </div>

<%--           <asp:SqlDataSource  
                ID="sqlsrcEventQuery"
                runat="server"
                ConnectionString="<%$ConnectionStrings:dbconnection %>"
                SelectCommand="SELECT Event.EventID, Event.EventTitle, Event.Time, Event.Date, Coordinator.FirstName + ' ' + Coordinator.LastName as CoordinatorName,EventPersonnel.FirstName + ' ' + EventPersonnel.LastName as VolunteerName FROM Event, EventPersonnel, EventPresenter, Coordinator WHERE Event.EventID = EventPresenter.EventID and EventPersonnel.PersonnelID = EventPresenter.PersonnelID and Coordinator.CoordinatorID = EventPresenter.CoordinatorID ; " />--%>

   
</asp:Content>
