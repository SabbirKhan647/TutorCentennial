<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="InsertSessionDetails.aspx.cs" Inherits="InsertSessionDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            font-size: large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
        <strong><span class="auto-style1">Welcome to the session Details page
        </span></strong>
        <br /> <strong>Here is your session list. 
        Choose session from the list then build weekly time table of that session</strong><br />
        <br />
&nbsp;<asp:Label ID="Label1" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server"></asp:Label>
        <br />
        <table>
            <tr>
                <td>
        <table>
            <tr>
                <td>Choose Session:</td>
                <td>
                    <asp:DropDownList ID="DropDownListBatch" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Choose Day:</td>
                <td>
                    <asp:DropDownList ID="DropDownListDay" runat="server">
                        <asp:ListItem>Select A Day</asp:ListItem>
                        <asp:ListItem>Sunday</asp:ListItem>
                        <asp:ListItem>Monday</asp:ListItem>
                        <asp:ListItem>Tuesday</asp:ListItem>
                        <asp:ListItem>Wednesday</asp:ListItem>
                        <asp:ListItem>Thursday</asp:ListItem>
                        <asp:ListItem>Friday</asp:ListItem>
                        <asp:ListItem>Saturday</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Choose Start Time:</td>
                <td>
                    <asp:DropDownList ID="DropDownStTime" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Choose End Time:</td>
                <td>
                    <asp:DropDownList ID="DropDownEndTime" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="ButtonInsert" runat="server" OnClick="ButtonInsert_Click" Text="Insert" Width="95px" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
                </td>
                <td>
                    <asp:GridView ID="GridViewSession" runat="server" AutoGenerateColumns="False" DataKeyNames="BatchID" OnSelectedIndexChanged="GridViewSession_SelectedIndexChanged">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="BatchName" HeaderText="BatchName" SortExpression="BatchName" />
                            <asp:BoundField DataField="dateCreated" HeaderText="DateCreated" SortExpression="dateCreated" />
                            <asp:BoundField DataField="startDate" HeaderText="Start Date" SortExpression="startDate" />
                            <asp:BoundField DataField="MaxStudent" HeaderText="MaxStudent" SortExpression="MaxStudent" />
                        </Columns>
                    </asp:GridView>
                    <br />
                    <asp:GridView ID="GridViewSessionDay" runat="server">
                    </asp:GridView>
                </td>
            </tr>
        </table>
        <br />
        <br />
    </div>
</asp:Content>

