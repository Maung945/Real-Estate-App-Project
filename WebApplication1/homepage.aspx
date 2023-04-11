<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="homepage.aspx.cs" Inherits="WebApplication1.homepage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="CSS/homepage.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="VideoContainer">
        <video autoplay muted loop class="MainVideo">
            <source src="images/MainVideo.mp4" type="video/mp4">
        </video>
    </div>

    <div class="TagContainer">
        <h1>Find a home</h1>
        <a href="userlogin.aspx">Explore</a>
    </div>

</asp:Content>

