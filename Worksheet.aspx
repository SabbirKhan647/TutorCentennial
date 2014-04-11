<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Worksheet.aspx.cs" Inherits="Worksheet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .auto-style1
        {
            width: 100%;
        }
        .auto-style4
        {
            width: 97px;
        }
        .auto-style5
        {
            width: 333px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
  <div style="overflow: auto; width: 900px; height: auto">  
&nbsp;&nbsp;
        &nbsp;<asp:Panel ID="PanelUpDownload" style="overflow: auto; width: 850px; height: auto" runat="server" BorderStyle="Ridge" Visible="False">
            <h3>Panel For Tutor</h3>
            <br />
&nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Upload" Width="176px" />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Download" Width="177px" />
            <br />
            <br />
            
     

            <table class="auto-style1">
                <tr>
                    <td class="auto-style5">
                        <table>
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:FileUpload ID="FileUpload1" runat="server" Visible="False" />
                                </td>
                                <td class="auto-style4">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>Choose Subject:
                                    <asp:DropDownList ID="DropDownListSub" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListSub_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td class="auto-style4">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>Choose&nbsp; Grade:&nbsp;
                                    <asp:DropDownList ID="DropDownListGrade" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListGrade_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td class="auto-style4">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LabelSession" runat="server" Text="Choose Session:"></asp:Label>
                                    &nbsp;<asp:DropDownList ID="DropDownListSession" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td class="auto-style4">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>Level Of Difficulty:
                                    <asp:DropDownList ID="DropDownListLOD" runat="server">
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="auto-style4">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td class="auto-style4">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="ButtonShow" runat="server" OnClick="ButtonShow_Click" Text="Show List for download" Visible="False" Width="171px" />
                                </td>
                                <td class="auto-style4">
                                    <asp:Button ID="ButtonUpload" runat="server" OnClick="ButtonUpload_Click" Text="Upload" Visible="False" Width="97px" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        
                        <asp:GridView ID="GridViewWorksheet" runat="server" DataKeyNames="WorksheetID" OnSelectedIndexChanged="GridViewWorksheet_SelectedIndexChanged" style="margin-left: 0px">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                         <asp:HyperLink ID="HyperLink1" runat="server"
                            NavigateUrl='<%# Eval("WorksheetId", "GetFile.aspx?ID={0}") %>'
                            Text="Download"></asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField SelectText="View" ShowSelectButton="True" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>

           
            <br />
        </asp:Panel>
        <br />
        <asp:Panel ID="PanelWorksheetStudent" style="overflow: auto; width: 850px; height: auto" runat="server" Visible="False" BorderStyle="Ridge">
            <h3><strong>Panel for Student </strong></h3>
            <br />
            Select Session:
            <asp:DropDownList ID="DropDownListSessionStu" runat="server" OnSelectedIndexChanged="DropDownListSessionStu_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="ButtonShowStudent" runat="server" OnClick="ButtonShowStudent_Click" Text="Button" Width="148px" />
            <br />
            <asp:GridView ID="GridViewStuDown" runat="server">
                <Columns>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# Eval("WorksheetId", "GetFile.aspx?ID={0}") %>'>Download</asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:Panel>
        <br />
<br />
      </div>
</asp:Content>

