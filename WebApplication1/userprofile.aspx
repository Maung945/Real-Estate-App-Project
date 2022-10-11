<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userprofile.aspx.cs" Inherits="WebApplication1.userprofile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div classs="container-fluid">
        <div class="row">

            <div class="col-md-5">

                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100px" src="images/cartprofile.png" />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Your Profile </h4>
                                    <span>Account Status - </span>
                                    <asp:Label class="badge badge-pill badge-success" ID="Label1" runat="server" Text="Your Status"></asp:Label>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label>Full Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Full Name"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <label>Member Since</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Member Since" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-md-6">
                                <label>Contact Number</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Contact Number" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <label>Email Address</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Email Address" TextMode="Email"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>State</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">

                                        <asp:ListItem Text="Select" Value="select" />
                                        <asp:ListItem Value="AL" Text="Alabama" />
                                        <asp:ListItem Value="AK" Text="Alaska" />
                                        <asp:ListItem Value="AZ" Text="Arizona" />
                                        <asp:ListItem Value="AR" Text="Arkansas" />
                                        <asp:ListItem Value="CA" Text="California" />
                                        <asp:ListItem Value="CO" Text="Colorado" />
                                        <asp:ListItem Value="CT" Text="Connecticut" />
                                        <asp:ListItem Value="DC" Text="D.C." />
                                        <asp:ListItem Value="DE" Text="Delaware" />
                                        <asp:ListItem Value="FL" Text="Florida" />
                                        <asp:ListItem Value="GA" Text="Georgia" />
                                        <asp:ListItem Value="HI" Text="Hawaii" />
                                        <asp:ListItem Value="ID" Text="Idaho" />
                                        <asp:ListItem Value="IL" Text="Illinois" />
                                        <asp:ListItem Value="IN" Text="Indiana" />
                                        <asp:ListItem Value="IA" Text="Iowa" />
                                        <asp:ListItem Value="KS" Text="Kansas" />
                                        <asp:ListItem Value="KY" Text="Kentucky" />
                                        <asp:ListItem Value="LA" Text="Louisiana" />
                                        <asp:ListItem Value="ME" Text="Maine" />
                                        <asp:ListItem Value="MD" Text="Maryland" />
                                        <asp:ListItem Value="MA" Text="Massachusetts" />
                                        <asp:ListItem Value="MI" Text="Michigan" />
                                        <asp:ListItem Value="MN" Text="Minnesota" />
                                        <asp:ListItem Value="MS" Text="Mississippi" />
                                        <asp:ListItem Value="MO" Text="Missouri" />
                                        <asp:ListItem Value="MT" Text="Montana" />
                                        <asp:ListItem Value="NE" Text="Nebraska" />
                                        <asp:ListItem Value="NV" Text="Nevada" />
                                        <asp:ListItem Value="NH" Text="New Hampshire" />
                                        <asp:ListItem Value="NJ" Text="New Jersey" />
                                        <asp:ListItem Value="NM" Text="New Mexico" />
                                        <asp:ListItem Value="NY" Text="New York" />
                                        <asp:ListItem Value="NC" Text="North Carolina" />
                                        <asp:ListItem Value="ND" Text="North Dakota" />
                                        <asp:ListItem Value="OH" Text="Ohio" />
                                        <asp:ListItem Value="OK" Text="Oklahoma" />
                                        <asp:ListItem Value="OR" Text="Oregon" />
                                        <asp:ListItem Value="PA" Text="Pennsylvania" />
                                        <asp:ListItem Value="RI" Text="Rhode Island" />
                                        <asp:ListItem Value="SC" Text="South Carolina" />
                                        <asp:ListItem Value="SD" Text="South Dakota" />
                                        <asp:ListItem Value="TN" Text="Tennessee" />
                                        <asp:ListItem Value="TX" Text="Texas" />
                                        <asp:ListItem Value="UT" Text="Utah" />
                                        <asp:ListItem Value="VT" Text="Vermont" />
                                        <asp:ListItem Value="VA" Text="Virginia" />
                                        <asp:ListItem Value="WA" Text="Washington" />
                                        <asp:ListItem Value="WV" Text="West Virginia" />
                                        <asp:ListItem Value="WI" Text="Wisconsin" />
                                        <asp:ListItem Value="WY" Text="Wyoming" />
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>City</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox6" runat="server" placeholder="City"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Zip Code</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="Zip Code" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col">
                                <label>Full Address</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Full Address" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col">
                                <center>
                                    <span class="badge badge-info">Login Credentials</span>
                                </center>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-md-4">
                                <label>User ID</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox8" runat="server" placeholder="User ID" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Old Password</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox9" runat="server" placeholder="Password" TextMode="Password" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>New Password</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox10" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                        </div>



                        <div class="row">
                            <div class="col-8 mx-auto">
                                <center>
                                    <div class="form-group">
                                        <asp:Button class="btn btn-primary btn-block btn-lg" ID="Button1" runat="server" Text="Update" />
                                    </div>
                                </center>
                            </div>
                        </div>




                    </div>
                </div>

                <a href="homepage.aspx"><< Back to Home</a><br>
                <br>
            </div>

            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100px" src="images/cart.png" />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Your Appointments & Houses Viewing </h4>

                                    <asp:Label class="badge badge-pill badge-success" ID="Label2" runat="server" Text="Status"></asp:Label>
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
                                <hr>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <asp:GridView AlternatingRowStyle-CssClass="table table-striped table-bordered" ID="GridView1" runat="server"></asp:GridView>
                            </div>
                        </div>



                    </div>
                </div>


            </div>

        </div>
    </div>

</asp:Content>
