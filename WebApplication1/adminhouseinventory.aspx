<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminhouseinventory.aspx.cs" Inherits="WebApplication1.adminhouseinventory" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div classs="container container-fluid">
        <div class="row">
            <div class="col-xs-12 col-sm-5 col-m-5 col-lg-5">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>House Details </h4>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100px" src="images/house2.png" />
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
                                <asp:FileUpload class="form-control" ID="FileUpload1" runat="server" />
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-md-3">
                                <label>House ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="House ID" ReadOnly="False"></asp:TextBox>
                                        <asp:LinkButton class="btn btn-primary" ID="LinkButton4" runat="server"><i class="fas fa-check-circle"></i></asp:LinkButton>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-9">
                                <label>House Address</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" placeholder="House Address" ReadOnly="False"></asp:TextBox>
                                </div>
                            </div>

                        </div>



                        <div class="row">
                            <div class="col-md-4">
                                <label>Price</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server" placeholder="Price" ReadOnly="False" TextMode="SingleLine"></asp:TextBox>
                                    </div>
                                </div>

                                <label>Agent ID</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownList2" runat="server">
                                        <asp:ListItem Text="Agent 1" Value="Agent 1" />
                                        <asp:ListItem Text="Agent 2" Value="Agent 2" />
                                        <asp:ListItem Text="Agent 3" Value="Agent 3" />
                                        <asp:ListItem Text="Agent 4" Value="Agent 4" />
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Price/Sqft</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox11" runat="server" placeholder="Price/Sq.ft" ReadOnly="False"></asp:TextBox>
                                </div>

                                <label>Appointment ID</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownList3" runat="server">
                                        <asp:ListItem Text="Appointment 1" Value="Appointment 1" />
                                        <asp:ListItem Text="Appointment 2" Value="Appointment 2" />
                                        <asp:ListItem Text="Appointment 3" Value="Appointment 3" />
                                        <asp:ListItem Text="Appointment 4" Value="Appointment 4" />
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Property Type</label>
                                <div class="form-group">
                                    <asp:ListBox CssClass="form-control" ID="ListBox1" runat="server" SelectionMode="Multiple" Rows="5">
                                        <asp:ListItem Text="Single Family Home" Value="Single Family Home" />
                                        <asp:ListItem Text="Town House" Value="Town House" />
                                        <asp:ListItem Text="Bungalow" Value="Bungalow" />
                                        <asp:ListItem Text="Condo" Value="Condo" />
                                        <asp:ListItem Text="Victorian" Value="Victorian" />
                                        <asp:ListItem Text="Container Home" Value="Container Home" />
                                        <asp:ListItem Text="Split Level" Value="Split Level" />
                                        <asp:ListItem Text="Mediterranean" Value="Mediterranean" />
                                        <asp:ListItem Text="Co-op" Value="Co-op" />
                                        <asp:ListItem Text="Cabin" Value="Cabin" />
                                        <asp:ListItem Text="Apartment" Value="Apartment" />
                                        <asp:ListItem Text="Manufactured Home" Value="Manufactured Home" />
                                        <asp:ListItem Text="Mobile Home" Value="Mobile Home" />
                                        <asp:ListItem Text="Mid-Century Modern Style" Value="Mid-Century Modern Style" />
                                        <asp:ListItem Text="Farmhouse" Value="Farmhouse" />
                                        <asp:ListItem Text="Mansion" Value="Mansion" />
                                        <asp:ListItem Text="Multi Family Home" Value="Multi Family Home" />
                                        <asp:ListItem Text="Office Building" Value="Office Building" />
                                        <asp:ListItem Text="Warehouse" Value="Warehouse" />
                                        <asp:ListItem Text="Commercial Building" Value="Commercial Building" />
                                    </asp:ListBox>
                                </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-md-4">
                                <label>Year Built</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox13" runat="server" placeholder="Year Built" ReadOnly="False"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Rooms</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox14" runat="server" placeholder="Rooms" ReadOnly="False" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Bathrooms</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control mr-1" ID="TextBox15" runat="server" placeholder="Bathrooms" ReadOnly="False" TextMode="Number"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>



                        <div class="row">
                            <div class="col-md-4">
                                <label>Offers</label>
                                <div class="form-group">
                                     <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                                        <asp:ListItem Text="Offer 1" Value="Offer 1" />
                                        <asp:ListItem Text="Offer 2" Value="Offer 2" />
                                        <asp:ListItem Text="Offer 3" Value="Offer 3" />
                                        <asp:ListItem Text="Offer 4" Value="Offer 4" />
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Owner Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Owner Name" ReadOnly="False" TextMode="SingleLine"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Appointments</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control mr-1" ID="TextBox4" runat="server" placeholder="Appointment" ReadOnly="False" TextMode="Number"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>





                        <div class="row">
                            <div class="col-md-12">
                                <label>House Description</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="House Detail Description" ReadOnly="False" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-4 mx-auto">
                                <asp:Button ID="Button2" class="btn-btn-lg btn-block btn-success" runat="server" Text="Add" />
                            </div>

                            <div class="col-4 mx-auto">
                                <asp:Button ID="Button1" class="btn-btn-lg btn-block btn-primary" runat="server" Text="Update" />
                            </div>

                            <div class="col-4 mx-auto">
                                <asp:Button ID="Button3" class="btn-btn-lg btn-block btn-danger" runat="server" Text="Delete" />
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
                                    <h4>House Details</h4>
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
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server"></asp:GridView>
                            </div>
                        </div>

                    </div>
                </div>
            </div>

        </div>
    </div>

</asp:Content>
