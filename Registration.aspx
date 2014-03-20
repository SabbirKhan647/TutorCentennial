<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Registration.aspx.cs" Inherits="About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .auto-style1
        {
            width: 100%;
        }
        .auto-style2
        {
            width: 80px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    
    <asp:Button ID="ButtonTeacher" runat="server" Text="Teacher Registration" Width="141px" OnClick="ButtonTeacher_Click" Visible="False" />
&nbsp;&nbsp;
    <asp:Button ID="ButtonStudent" runat="server" Text="Student Registration" OnClick="ButtonStudent_Click" Visible="False" />
    <br />
    <asp:Panel ID="PanelTeacher" runat="server" Visible="False">
        <asp:Label ID="LabelRole" runat="server"></asp:Label>
        <table class="auto-style1">
            <tr>
                <td>
                    <table>
                        <tr>
                            <td>FirstName:</td>
                            <td>
                                <asp:TextBox ID="TextBoxFName" runat="server" Width="214px"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>LastName:</td>
                            <td>
                                <asp:TextBox ID="TextBoxLName" runat="server" Width="217px"></asp:TextBox>
                            </td>
                            <td rowspan="10">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>Email:</td>
                            <td>
                                <asp:TextBox ID="TextBoxEmail" runat="server" Width="217px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Phone:</td>
                            <td>
                                <asp:TextBox ID="TextBoxPhone" runat="server" Width="181px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Address:</td>
                            <td>
                                <asp:TextBox ID="TextBoxAddress" runat="server" Width="292px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Province:</td>
                            <td>
                                <asp:DropDownList ID="DropDownProvince" runat="server">
                                    <asp:ListItem>ON</asp:ListItem>
                                    <asp:ListItem>BC</asp:ListItem>
                                    <asp:ListItem>AB</asp:ListItem>
                                    <asp:ListItem>MT</asp:ListItem>
                                    <asp:ListItem>SK</asp:ListItem>
                                    <asp:ListItem>NS</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Gender:</td>
                            <td>
                                <asp:DropDownList ID="DropDownGender" runat="server">
                                    <asp:ListItem>M</asp:ListItem>
                                    <asp:ListItem>F</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Qualification:</td>
                            <td>
                                <asp:TextBox ID="TextBoxQualification" runat="server" Width="288px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Institute:</td>
                            <td>
                                <asp:TextBox ID="TextBoxInstitute" runat="server" Width="287px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <asp:Button ID="ButtonProfile" runat="server" Text="Create Profile" Width="98px" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                    <table>
                        <tr>
                            <td>Create Batch: </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>Select Subject:<br />
                                </td>
                            <td>
                                <asp:DropDownList ID="DropDownListSubject" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Select Grade:</td>
                            <td>
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Maximum Student:</td>
                            <td>
                                <asp:DropDownList ID="DropDownNoOfStu" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Start Date:</td>
                            <td>
                                <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <asp:Button ID="ButtonBatch" runat="server" OnClick="ButtonBatch_Click" Text="Create Batch" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
&nbsp;</asp:Panel>
&nbsp;
    
    <br />
    <asp:Panel ID="PanelStudent" runat="server" Visible="False">
        <table class="auto-style1">
            <tr>
                <td>
                    <table>
                        <tr>
                            <td>FirstName:</td>
                            <td>
                                <asp:TextBox ID="TextBoxFName0" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>LastName:</td>
                            <td>
                                <asp:TextBox ID="TextBoxLName0" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Email:</td>
                            <td>
                                <asp:TextBox ID="TextBoxEmail0" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Phone:</td>
                            <td>
                                <asp:TextBox ID="TextBoxPhone0" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Address:</td>
                            <td>
                                <asp:TextBox ID="TextBoxAddress0" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Grade:</td>
                            <td>
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </td>
                <td>
                    <table>
                        <tr>
                            <td class="auto-style2">Choose your subject: </td>
                            <td>
                                <asp:CheckBoxList ID="CheckBoxList3" runat="server">
                                    <asp:ListItem>Math</asp:ListItem>
                                    <asp:ListItem>English</asp:ListItem>
                                    <asp:ListItem>Science</asp:ListItem>
                                    <asp:ListItem>History</asp:ListItem>
                                    <asp:ListItem>Geography</asp:ListItem>
                                    <asp:ListItem>Computer</asp:ListItem>
                                </asp:CheckBoxList>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    The list of teacher according to your subject choose
                    <asp:GridView ID="GridViewTeacher" runat="server">
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    
</asp:Content>
