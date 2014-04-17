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
        .style1
        {
            width: 100%;
        }
        *{margin:0px 0px 0px 0px;
  padding:0px;
}
        .style2
        {
            width: 100px;
        }
        .auto-style3 {
            width: 2px;
        }
        .auto-style4 {
            font-weight: normal;
            font-size: large;
            color: #003300;
        }
        .auto-style5 {
            font-size: large;
            color: #003300;
        }
        .auto-style6 {
            width: 402px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    
    &nbsp;&nbsp;
    <br />
&nbsp;<asp:Label ID="Label12" runat="server"></asp:Label>
    <asp:Panel ID="PanelTeacher" runat="server" Visible="False" BorderStyle="Solid">
        <h3 class="auto-style4"><strong>Create your profile </strong></h3>
        <h3><strong>Teacher Profile</strong></h3>
&nbsp;<table class="auto-style1">
            <tr>
                <td>
                    <table>
                        <tr>
                            <td>
                                <asp:Panel ID="PanelTutorCreateProfile" runat="server">
                    <table>
                        <tr>
                            <td>FirstName:</td>
                            <td>
                                <asp:TextBox ID="TextBoxFName" runat="server" Width="191px"></asp:TextBox>
                            </td>
                            <td class="auto-style3">&nbsp;</td>
                        </tr>
                       
                        <tr>
                            <td>LastName:</td>
                            <td>
                                <asp:TextBox ID="TextBoxLName" runat="server" Width="217px"></asp:TextBox>
                            </td>
                            <td rowspan="9" class="auto-style3">
                                <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" Height="50px" OnModeChanging="DetailsView1_ModeChanging" Width="125px">
                                    <Fields>
                                        <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
                                        <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                                        <asp:BoundField DataField="phone" HeaderText="Phone" SortExpression="phone" />
                                        <asp:BoundField DataField="address" HeaderText="Address" SortExpression="address" />
                                        <asp:BoundField DataField="Province" HeaderText="Province" SortExpression="Province" />
                                        <asp:CommandField ShowEditButton="True" />
                                    </Fields>
                                </asp:DetailsView>
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
                            <td>PostalCode:</td>
                            <td>
                                <asp:TextBox ID="TextBoxPC" runat="server" Width="94px" OnTextChanged="TextBoxEmail_TextChanged"></asp:TextBox>
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
                                <asp:Button ID="ButtonProfile" runat="server" Text="Create Profile" Width="98px" OnClick="ButtonProfile_Click" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="LabelRole" runat="server" Font-Bold="True" ForeColor="#003300"></asp:Label>
                            </td>
                        </tr>
                    </table>

                    </asp:Panel></td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>

                    
                </td>
                <td>
                    <asp:Panel ID="PanelSession" runat="server"> 
                        <span class="auto-style5"><strong>Create your session&nbsp; </strong></span>
                    <table>
                        <tr>
                            <td>Create Session: </td>
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
                                <asp:DropDownList ID="DropDownListGrade" runat="server">
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
                                <asp:Button ID="ButtonBatch" runat="server" OnClick="ButtonBatch_Click" Text="Create Session" />
                            </td>
                        </tr>
                    </table>

                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID="PanelUpdateTutor" runat="server">
                    </asp:Panel>
                </td>
                <td>
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="Label11" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Button ID="ButtonSession" runat="server" OnClick="ButtonSession_Click" Text="Go to session Details Page" Width="227px" />
                </td>
            </tr>
        </table>
&nbsp;</asp:Panel>
&nbsp;
    
    <br />
    <asp:Panel ID="PanelStudent" runat="server" Visible="False" BorderStyle="Solid">
        <h3><strong>Student Profile </strong></h3>
        <table class="auto-style1">
            <tr>
                <td class="auto-style6">
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
                            <td>Phone:</td>
                            <td>
                                <asp:TextBox ID="TextBoxPhone0" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>PostalCode:</td>
                            <td>
                                <asp:TextBox ID="TextBoxPCStu" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Province:</td>
                            <td>
                                <asp:DropDownList ID="DropDownProvince0" runat="server">
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
                            <td>Address:</td>
                            <td>
                                <asp:TextBox ID="TextBoxAddress0" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                &nbsp;</td>
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
                            <td class="auto-style2">
                                <asp:Label ID="LabelStudent" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#333300"></asp:Label>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style2">
                                <asp:DetailsView ID="DetailsViewStu" runat="server" Height="50px" OnModeChanging="DetailsViewStu_ModeChanging" Width="125px">
                                    <Fields>
                                        <asp:CommandField ShowEditButton="True" />
                                    </Fields>
                                </asp:DetailsView>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">
                    <asp:Button ID="ButtonStudentProfile" runat="server" OnClick="ButtonStudentProfile_Click" Text="Create Profile" Width="132px" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    
</asp:Content>
