<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Geocoding.aspx.cs" Inherits="ReverseGeocoding" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?sensor=false"></script>
<script language="javascript" type="text/javascript">

    var map;
    var geocoder;
    function InitializeMap() {

        var latlng = new google.maps.LatLng(-34.397, 150.644);
        var myOptions =
        {
            zoom: 8,
            center: latlng,
            mapTypeId: google.maps.MapTypeId.ROADMAP,
            disableDefaultUI: true
        };
        map = new google.maps.Map(document.getElementById("map"), myOptions);
    }
    
    function FindLocaiton() {
        geocoder = new google.maps.Geocoder();
        InitializeMap();
        
        var address = document.getElementById("<%= Label1.ClientID %>").innerText;
        geocoder.geocode({ 'address': address }, function (results, status) {
            if (status == google.maps.GeocoderStatus.OK) {
                map.setCenter(results[0].geometry.location);
                var marker = new google.maps.Marker({
                    map: map,
                    position: results[0].geometry.location
                });

            }
            else {
                alert("Geocode was not successful for the following reason: " + status);
            }
        });

    }

    function Button1_onclick() {
        FindLocaiton();
    }

    window.onload = FindLocaiton();//InitializeMap;

</script>

    
<h2>Tutor's Location:</h2>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <p>&nbsp;</p>
<table>
<tr>
<td>
    <input id="addressinput" type="text" style="width: 447px" />   

</td>
<td>
    <input id="Button1" type="button" value="Find" onclick="return Button1_onclick()" /></td>
</tr>
<tr>
<td colspan ="2">
<div id ="map" style="height: 253px" >
</div>
</td>
</tr>
</table>
    <br />
    <p>Click below to see the direction from your location to tutors location:</p>
    <asp:Button ID="ButtonDirection" runat="server" Text="Direction" Width="97px" OnClick="ButtonDirection_Click" />
</asp:Content>

