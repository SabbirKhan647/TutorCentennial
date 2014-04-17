<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register assembly="GMaps" namespace="Subgurim.Controles" tagprefix="cc1" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">

    <style type="text/css">
        .auto-style1 {
            font-size: xx-large;
            color: #333300;
        }
        .auto-style2 {
            font-size: small;
        }
    </style>

</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to Tutoring Management Webportal&nbsp; Manage
    </h2>
    <p>
        First time online Tutoring Management System including finding Tutors and getting students extending to education portal management</p>
    <asp:Panel ID="PanelChoose" runat="server" Visible="False">
        <p>
            Choose your role:<asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem>Tutor</asp:ListItem>
                <asp:ListItem>Student</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Button ID="ButtonSubmit" runat="server" OnClick="ButtonSubmit_Click" Text="Submit" />
            <br />
            <br />
        </p>
        
        
    </asp:Panel>
    <asp:Panel ID="PanelDes" runat="server">
        
    <p>
        <strong>By Registering this Website Tutor will be able to do the following thing:</strong><br />
        
      <asp:BulletedList ID="BulletedListTeacher" runat="server">  
            <asp:ListItem>Registration</asp:ListItem>  
            <asp:ListItem>Create his/her sessions</asp:ListItem>  
            <asp:ListItem>Upload Handouts, Worksheets, Assignments according to Session</asp:ListItem>  
            <asp:ListItem>View his/her student list</asp:ListItem> 
           
            
        </asp:BulletedList>  
        <strong>Bonus:
        </strong>Admin will upload additional wroksheets and handouts
        <br />
        <br />
    <strong>By Registering this Website Student will be able to do the following thing:</strong><br />
      <asp:BulletedList ID="BulletedListStudent" runat="server">  
            <asp:ListItem>Registration</asp:ListItem>  
            <asp:ListItem>Find Appropriate Tutor</asp:ListItem>  
            <asp:ListItem>Choose Tutor according to subject</asp:ListItem>  
            <asp:ListItem>Will be able to download handouts/ worksheets/ Asssignments</asp:ListItem> 
          
            
        </asp:BulletedList> 
        <strong>Upcoming Features:
        </strong>
        <asp:BulletedList ID="BulletedListUpcoming" runat="server">  
            <asp:ListItem>Seperate Email for users from the system</asp:ListItem>  
            <asp:ListItem>Communication between users, Chat, Email exchange</asp:ListItem>  
            <asp:ListItem>Online Quiz</asp:ListItem>  
            <asp:ListItem>Online Grading System</asp:ListItem> 
            <asp:ListItem>Online Payment System</asp:ListItem>
            
        </asp:BulletedList> 
    </p>
    <br />
    <br />
        </asp:Panel>
    <asp:Panel ID="PanelTutorCongrate" runat="server" Visible="False">
        Congratulation!!!

       <strong>Now You will be able to do the following thing:</strong><br />
        
      <asp:BulletedList ID="BulletedListConTutor" runat="server">  
            <asp:ListItem>Registration</asp:ListItem>  
            <asp:ListItem>Create  sessions</asp:ListItem>  
            <asp:ListItem>Upload Handouts, Worksheets, Assignments according to Session</asp:ListItem>  
            <asp:ListItem>View student list</asp:ListItem> 
           
        </asp:BulletedList>  
        <strong>Bonus:
        </strong>You will get additional worksheets and handouts from admin
        <br />
        <span class="auto-style1"><strong>Manual for tutor: </strong></span> <br /><span class="auto-style2"><strong>Create profile First -&gt; Create your session -&gt; Create Session Details -&gt; Then upload document according to your session if you have any</strong></span></asp:Panel>
    <asp:Panel ID="PanelConStu" runat="server" Visible="False">
        Congratulations!!! <br />
        Now As a Student you will enjoy the following features:
        <asp:BulletedList ID="BulletedListConStu" runat="server">  
             
            <asp:ListItem>Find Appropriate Tutor</asp:ListItem>  
            <asp:ListItem>Choose Tutor according to subject</asp:ListItem>  
            <asp:ListItem>Will be able to download handouts/ worksheets/ Asssignments</asp:ListItem> 
          
            
        </asp:BulletedList> 
    </asp:Panel>
</asp:Content>
