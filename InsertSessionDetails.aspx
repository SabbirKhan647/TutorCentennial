<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="InsertSessionDetails.aspx.cs" Inherits="InsertSessionDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        <br />
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
    </p>
</asp:Content>

