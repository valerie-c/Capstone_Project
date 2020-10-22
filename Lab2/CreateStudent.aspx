<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CreateStudent.aspx.cs" Inherits="Lab2.CreateStudent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Valerie Chang & Matt Suder--Create Student Page
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
                        <asp:Label ID="lblStudentFN" runat="server" Text="Student First Name:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtStudentFN" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtStudentFN" Display ="Dynamic" ForeColor ="Red" SetFocusOnError="true" Text="* This is a required field" ErrorMessage ="* Field cannot be blank!"></asp:RequiredFieldValidator>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblStudentLN" runat="server" Text="Student Last Name:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtStudentLN" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtStudentLN" Display ="Dynamic" ForeColor ="Red" SetFocusOnError="true" Text="* This is a required field" ErrorMessage ="* Field cannot be blank!"></asp:RequiredFieldValidator>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblAge" runat="server" Text="Age: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtAge" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtAge" Display ="Dynamic" ForeColor ="Red" SetFocusOnError="true" Text="* This is a required field" ErrorMessage ="* Field cannot be blank!" ></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate ="txtAge" Operator="DataTypeCheck" Type="Integer" ForeColor="Red" SetFocusOnError="true" Text="* Entry must be a whole integer" ErrorMessage ="* Data must be numeric!" ></asp:CompareValidator>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblNotes" runat="server" Text="Notes: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtNotes" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNotes" Display ="Dynamic" ForeColor ="Red" SetFocusOnError="true" Text="* This is a required field" ErrorMessage ="* Field cannot be blank!"></asp:RequiredFieldValidator>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblLunchTicket" runat="server" Text="Lunch Ticket: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtLunchTicket" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtLunchTicket" Display ="Dynamic" ForeColor ="Red" SetFocusOnError="true" Text="* This is a required field" ErrorMessage ="* Field cannot be blank!"></asp:RequiredFieldValidator>
                    </asp:TableCell>
                </asp:TableRow>
             </asp:Table> 
        </div>
        <div>
            <asp:Label ID="Label1" runat="server" Text="Select a Teacher: "></asp:Label>
            <asp:DropDownList 
                    ID ="DropDownList1"
                    runat="server"
                    DataSourceID ="datasrcTeacherList"
                    DataTextField ="TeacherName"
                    DataValueField ="TeacherID"
                    AutoPostBack ="true" Height="27px"></asp:DropDownList>
        </div>
        <div>
             <asp:Label ID="lblShirt" runat="server" Text="Shirt Information: "></asp:Label>
             <asp:DropDownList
                    ID ="DropDownList2"
                    runat ="server"
                    DataSourceID ="datasrcShirtList"
                    DataTextField ="ShirtDetails"
                    DataValueField ="ShirtInfoID"
                    AutoPostBack ="true" Height="27px"></asp:DropDownList>
        </div>
        <div>
       
            <asp:Button ID="btnCommit" runat="server" Text="Commit ->" OnClick ="btnCommit_Click" />
            <asp:Button ID="btnDisplay" CausesValidation="false" runat ="server" Text="Display ->" OnClick="btnDisplay_Click" />
            <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
            
            <fieldset>
                <legend>Teachers for Selected Students: </legend>
                <asp:GridView
                    runat ="server"
                    ID ="getTeacherResult"
                    AlternatingRowStyle-BackColor ="#eaaaff"
                    EmptyDataText ="No Students Selected!" Height="229px" Width="310px"></asp:GridView>
            </fieldset>
        </div>
        <div>

        </div>
        <asp:SqlDataSource
            runat ="server"
            ID ="datasrcTeacherList"
            ConnectionString ="<%$ConnectionStrings:dbconnection %>"
            SelectCommand ="SELECT TeacherID, FirstName + ' ' + LastName as TeacherName FROM Teacher; " />
        <asp:SqlDataSource
            runat ="server"
            ID ="datasrcShirtList"
            Connectionstring ="<%$ConnectionStrings:dbconnection %>"
            SelectCommand ="SELECT ShirtInfoID, ShirtSize + ' ' + ShirtColor as ShirtDetails FROM ShirtInfo; " />
</asp:Content>
