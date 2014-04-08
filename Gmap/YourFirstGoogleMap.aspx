<%@ Page Title="" Language="C#" MasterPageFile="~/Gmap/MasterPage.master" AutoEventWireup="true" CodeFile="YourFirstGoogleMap.aspx.cs" Inherits="YourFirstGoogleMap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?sensor=false"></script>
<script type ="text/javascript">
    function InitializeMap() 
    {
        var latlng = new google.maps.LatLng(-34.397, 150.644);
        var myOptions = {
            zoom: 8,
            center: latlng,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        var map = new google.maps.Map(document.getElementById("map"), myOptions);
    }
    window.onload = InitializeMap;

</script>
<h2>Creating Your First Google Map Demo:</h2>
<div id ="map"   style="width: 304px; top: 68px; left: 172px; position: absolute; height: 238px">

</div>
</asp:Content>

