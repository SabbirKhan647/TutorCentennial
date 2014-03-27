<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Build.aspx.cs" Inherits="Build" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
        &nbsp;Welcome to Batch Chosen Page</p>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Panel ID="PanelGrade" runat="server">
        Choose Your Subject That you want tutoring:&nbsp;
        <asp:DropDownList ID="DropDownSub" runat="server">
        </asp:DropDownList>
        <br />
        Choose Your Grade:&nbsp;
        <asp:DropDownList ID="DropDownGrade" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonShow" runat="server" Text="Show Available Teacher" Width="196px" OnClick="ButtonShow_Click" />
    </asp:Panel>
    adsad
    <br />
<asp:Panel ID="PanelTeacher" runat="server" Visible="False">
    Available Batch with Teacher Listed:<br />
    <asp:GridView ID="GridViewBatch" runat="server" DataKeyNames="BatchID" OnSelectedIndexChanged="GridViewBatch_SelectedIndexChanged" OnRowDeleting="GridViewBatch_RowDeleting">
        <Columns>
            <asp:CommandField ShowSelectButton="True" HeaderText="ViewDetails" SelectText="View" />
            <asp:CommandField DeleteText="Select" ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:Label ID="LabelConfirm" runat="server"></asp:Label>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    <asp:GridView ID="GridViewSessionDetails" runat="server">
    </asp:GridView>
    <br />
</asp:Panel>
<br />
<br />
<br />
<br />
    </asp:Content>

