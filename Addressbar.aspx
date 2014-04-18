<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Addressbar.aspx.cs" Inherits="Addressbar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?sensor=false"></script>
<script language="javascript" type="text/javascript">
    var directionsDisplay;
    var directionsService = new google.maps.DirectionsService();

    function InitializeMap() {
        directionsDisplay = new google.maps.DirectionsRenderer();
        var latlng = new google.maps.LatLng(-34.397, 150.644);
        var myOptions =
        {
            zoom: 8,
            center: latlng,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        var map = new google.maps.Map(document.getElementById("map"), myOptions);

        directionsDisplay.setMap(map);
        directionsDisplay.setPanel(document.getElementById('directionpanel'));

        var control = document.getElementById('control');
        control.style.display = 'block';


    }



    function calcRoute() {

        //var start = document.getElementById('startvalue').value;
        //var end = document.getElementById('endvalue').value;
        var start = document.getElementById("<%= LabelTutor.ClientID %>").innerText;
        var end = document.getElementById("<%= LabelStudent.ClientID %>").innerText;
        var request = {
            origin: start,
            destination: end,
            travelMode: google.maps.DirectionsTravelMode.DRIVING
        };
        directionsService.route(request, function (response, status) {
            if (status == google.maps.DirectionsStatus.OK) {
                directionsDisplay.setDirections(response);
            }
        });

    }



    function Button1_onclick() {
        calcRoute();
    }

    window.onload = InitializeMap;
    </script>
    
<table id ="control">
<tr>
<td>
<table style="height: 108px; width: 433px">
<tr>
<td>&nbsp;</td>
<td>
    &nbsp;</td>
</tr>
<tr>
<td>&nbsp;</td>
<td>&nbsp;</td>
</tr>
<tr>
<td>Tutor&#39;s Location:</td>
<td>
    <asp:Label ID="LabelTutor" runat="server" Text="Label"></asp:Label>
    </td>
</tr>
<tr>
<td>Student&#39;s Location:</td>
<td>
    <asp:Label ID="LabelStudent" runat="server" Text="Label"></asp:Label>
    </td>
</tr>
<tr>
<td align ="right">
    <input id="Button1" type="button" value="GetDirections" onclick="return Button1_onclick()" /></td>
</tr>
</table>
</td>
</tr>
<tr>
<td valign ="top">
<div id ="directionpanel"  style="height: auto;overflow: auto" ></div>
</td>
<td valign ="top">
<div id ="map" style="height: 390px; width: 489px"></div>
</td>
</tr>
</table>
</asp:Content>

