<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="createEvent.aspx.cs" Inherits="Lab2.createEvent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Create Event Page
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
                
            <asp:Table runat="server">
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                        <asp:Label ID="lblHeaderMessage" runat="server" Text="Please Fill in the Boxes!" Font-Bold="true" Font-Size="Larger" ></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblTitle" runat="server" Text="Event Title: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtTitle" Display ="Dynamic" ForeColor ="Red" SetFocusOnError="true" Text="* This is a required field" ErrorMessage ="* Field cannot be blank!"></asp:RequiredFieldValidator>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblDate" runat="server" Text="Event Date: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDate" Display ="Dynamic" ForeColor ="Red" SetFocusOnError="true" Text="* This is a required field" ErrorMessage ="* Field cannot be blank!"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate ="txtDate" Operator="DataTypeCheck" Type="Date" ForeColor="Red" SetFocusOnError="true" Text="* Entry must be in Date format" ErrorMessage ="* Data must be in Date format!" ></asp:CompareValidator>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblTime" runat="server" Text="Event Time: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtTime" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtTime" Display ="Dynamic" ForeColor ="Red" SetFocusOnError="true" Text="* This is a required field" ErrorMessage ="* Field cannot be blank!" ></asp:RequiredFieldValidator>
<%--                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate ="txtTime" Operator="DataTypeCheck" Type="Date" ForeColor="Red" SetFocusOnError="true" Text="* Entry must be in Time format" ErrorMessage ="* Data must be in Time format!" ></asp:CompareValidator>--%>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblLocation" runat="server" Text="Event Location: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtLocation" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtLocation" Display ="Dynamic" ForeColor ="Red" SetFocusOnError="true" Text="* This is a required field" ErrorMessage ="* Field cannot be blank!"></asp:RequiredFieldValidator>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblSchoolName" runat="server" Text="Middle School Name: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtSchoolName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtSchoolName" Display ="Dynamic" ForeColor ="Red" SetFocusOnError="true" Text="* This is a required field" ErrorMessage ="* Field cannot be blank!"></asp:RequiredFieldValidator>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblSchoolNumber" runat="server" Text="Middle School Contact Number: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtSchoolNumber" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtSchoolNumber" Display ="Dynamic" ForeColor ="Red" SetFocusOnError="true" Text="* This is a required field" ErrorMessage ="* Field cannot be blank!"></asp:RequiredFieldValidator>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblSchoolEmail" runat="server" Text="Middle School Contach Email: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtSchoolEmail" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtSchoolEmail" Display ="Dynamic" ForeColor ="Red" SetFocusOnError="true" Text="* This is a required field" ErrorMessage ="* Field cannot be blank!"></asp:RequiredFieldValidator>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblRoomNbr" runat="server" Text="Room Number: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtRoomNbr" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtRoomNbr" Display ="Dynamic" ForeColor ="Red" SetFocusOnError="true" Text="* This is a required field" ErrorMessage ="* Field cannot be blank!"></asp:RequiredFieldValidator>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblRoomCap" runat="server" Text="Room Capacity: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtRoomCap" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtRoomCap" Display ="Dynamic" ForeColor ="Red" SetFocusOnError="true" Text="* This is a required field" ErrorMessage ="* Field cannot be blank!"></asp:RequiredFieldValidator>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblDescription" runat="server" Text="Event Description: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDescription" Display ="Dynamic" ForeColor ="Red" SetFocusOnError="true" Text="* This is a required field" ErrorMessage ="* Field cannot be blank!"></asp:RequiredFieldValidator>
                    </asp:TableCell>
                </asp:TableRow>
             </asp:Table> 
        </div>

        <div>
       
            <asp:Button ID="btnCommit" runat="server" Text="Commit ->" OnClick ="btnCommit_Click" />
            <asp:Button ID="btnDisplay" CausesValidation="false" runat ="server" Text="Display ->" OnClick="btnDisplay_Click" />
            <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
            
            <fieldset>
                <legend>Itinerary: </legend>
                <asp:GridView
                    runat ="server"
                    ID ="getEventResult"
                    AlternatingRowStyle-BackColor ="#eaaaff"
                    EmptyDataText ="No Events Selected!" Height="229px" Width="310px"></asp:GridView>
            </fieldset>
        </div>

</asp:Content>

