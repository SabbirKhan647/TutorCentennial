<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to Tutoring Management Webportal&nbsp; Manage
    </h2>
    <p>
    </p>
    <asp:Panel ID="PanelChoose" runat="server" Visible="False">
        <p>
            Choose your role:<asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem>Tutor</asp:ListItem>
                <asp:ListItem>Student</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Button ID="ButtonSubmit" runat="server" OnClick="ButtonSubmit_Click" Text="Submit" />
            <br />
        </p>
    </asp:Panel>
</asp:Content>
