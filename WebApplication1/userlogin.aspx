<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userlogin.aspx.cs" Inherits="WebApplication1.userlogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="google-signin-client_id" content="YOUR_CLIENT_ID.apps.googleusercontent.com">
    <script src="https://apis.google.com/js/platform.js" async defer></script>
    <script>
        function onSignIn(googleUser) {
            // Get the Google ID token
            var id_token = googleUser.getAuthResponse().id_token;

            // Send the token to the server for verification
            // You can use AJAX to make a POST request to your server with the token

            // For example, using jQuery:
            // $.post("/verifyToken", { token: id_token })
            //    .done(function(data) { console.log(data); })
            //    .fail(function() { console.log("Error verifying token"); });
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-4 mx-auto">

                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100px" src="images/user.png" />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h2>Member Login </h2>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <label>Member ID</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Member ID"></asp:TextBox>

                                </div>

                                <label>Password</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>

                                </div>

                                <div class="form-group">
                                    <asp:Button class="btn btn-success btn-block btn-lg" ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
                                </div>
                                <div class="form-group">
                                    <a href="usersignup.aspx" class="btn btn-info btn-block btn-lg">Sign Up</a>
                                </div>

                                <div class="form-group">
                                    <div class="g-signin2" data-onsuccess="onSignIn" style="margin-top: 10px; font-size: 16px;"></div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>

                <a href="homepage.aspx"><< Back to Home</a><br>
                <br>
            </div>
        </div>
    </div>
</asp:Content>
