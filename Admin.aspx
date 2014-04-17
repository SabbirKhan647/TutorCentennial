<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Activities" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            font-size: large;
            color: #333300;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <span class="auto-style1"><strong>Statistics Display page</strong></span><asp:Panel ID="Panel1" runat="server" style="text-align: right">
        <asp:Button ID="ButtonUserAccount" runat="server" Text="Create User Account" OnClick="ButtonUserAccount_Click" style="text-align: right" Width="193px" />
    </asp:Panel>
    <p>
    <br />
    <asp:Button ID="ButtonTeacher" runat="server" OnClick="ButtonTeacher_Click" Text="Show Teacher List" Width="155px" />
    <asp:GridView ID="GridViewTeacher" runat="server" Width="268px" DataKeyNames="TeacherID" OnRowDeleting="GridViewTeacher_RowDeleting" OnSelectedIndexChanged="GridViewTeacher_SelectedIndexChanged" AllowPaging="True" PageSize="5" OnPageIndexChanging="GridViewTeacher_PageIndexChanging">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:CommandField ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
        <br />
        <asp:Label ID="LabelStatus" runat="server"></asp:Label>
        <asp:GridView ID="GridViewSession" runat="server" DataKeyNames="BatchID" OnRowDeleting="GridViewSession_RowDeleting" AllowPaging="True" PageSize="5" OnPageIndexChanging="GridViewSession_PageIndexChanging">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Button ID="ButtonStuList" runat="server" Text="Show Student List" Width="154px" OnClick="ButtonStuList_Click" />
        <br />
        <asp:GridView ID="GridViewStudent" runat="server" DataKeyNames="StudentID" OnRowDeleting="GridViewStudent_RowDeleting" AllowPaging="True" OnPageIndexChanging="GridViewStudent_PageIndexChanging">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
        <br />
        <br />
        <br />
</p>
    
</asp:Content>

