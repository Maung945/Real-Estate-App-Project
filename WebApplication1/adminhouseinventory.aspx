<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminhouseinventory.aspx.cs" Inherits="WebApplication1.adminhouseinventory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });

        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('#imgview').attr('src', e.target.result);
                };
                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>


</asp:Content>
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
                                    <img id="imgview" Height="150px" width="100px" src="images/house2.png" />
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
                                <asp:FileUpload onchange="readURL(this);" class="form-control" ID="FileUpload1" runat="server" />
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-md-3">
                                <label>House ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="House ID" ReadOnly="False"></asp:TextBox>
                                        <asp:Button class="btn btn-primary" ID="Button4" runat="server" Text="Go" OnClick="Button4_Click" />
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
                                    <asp:TextBox CssClass="form-control mr-1" ID="TextBox16" runat="server" placeholder="Offers" ReadOnly="False" TextMode="Number"></asp:TextBox>
                                    <%--
                                     <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                                        <asp:ListItem Text="Offer 1" Value="Offer 1" />
                                        <asp:ListItem Text="Offer 2" Value="Offer 2" />
                                        <asp:ListItem Text="Offer 3" Value="Offer 3" />
                                        <asp:ListItem Text="Offer 4" Value="Offer 4" />
                                    </asp:DropDownList>
                                    --%>

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
                                <asp:Button ID="Button2" class="btn-btn-lg btn-block btn-success" runat="server" Text="Add" OnClick="Button2_Click" />
                            </div>

                            <div class="col-4 mx-auto">
                                <asp:Button ID="Button1" class="btn-btn-lg btn-block btn-primary" runat="server" Text="Update" OnClick="Button1_Click" />
                            </div>

                            <div class="col-4 mx-auto">
                                <asp:Button ID="Button3" class="btn-btn-lg btn-block btn-danger" runat="server" Text="Delete" OnClick="Button3_Click" />
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
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:realestateappDBConnectionString %>" SelectCommand="SELECT * FROM [house_master_tbl]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="house_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="house_id" HeaderText="ID" ReadOnly="True" SortExpression="house_id" >
                                        <ItemStyle Font-Bold="True" />
                                        </asp:BoundField>
                                        <%--
                                        <asp:BoundField DataField="house_address" HeaderText="house_address" SortExpression="house_address" />
                                        <asp:BoundField DataField="property_type" HeaderText="property_type" SortExpression="property_type" />
                                        <asp:BoundField DataField="price" HeaderText="price" SortExpression="price" />
                                        <asp:BoundField DataField="price_persqft" HeaderText="price_persqft" SortExpression="price_persqft" />
                                        <asp:BoundField DataField="agent_id" HeaderText="agent_id" SortExpression="agent_id" />
                                        <asp:BoundField DataField="appointment_id" HeaderText="appointment_id" SortExpression="appointment_id" />
                                        <asp:BoundField DataField="year_built" HeaderText="year_built" SortExpression="year_built" />
                                        <asp:BoundField DataField="rooms" HeaderText="rooms" SortExpression="rooms" />
                                        <asp:BoundField DataField="bathrooms" HeaderText="bathrooms" SortExpression="bathrooms" />
                                        <asp:BoundField DataField="offers" HeaderText="offers" SortExpression="offers" />
                                        <asp:BoundField DataField="owner_name" HeaderText="owner_name" SortExpression="owner_name" />
                                        <asp:BoundField DataField="on_appointment" HeaderText="on_appointment" SortExpression="on_appointment" />
                                        <asp:BoundField DataField="house_description" HeaderText="house_description" SortExpression="house_description" />
                                        <asp:BoundField DataField="house_img_link" HeaderText="house_img_link" SortExpression="house_img_link" />
                                        --%>

                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="container-fluid">
                                                    <div class="row">
                                                        <div class="col-lg-10">
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("house_address") %>' Font-Strikeout="False" Font-Bold="True" Font-Size="X-Large"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">

                                                                    Price- <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("price") %>'></asp:Label>
                                                                    &nbsp;| Price.SqFt-&nbsp;<asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("price_persqft") %>'></asp:Label>
                                                                    &nbsp;| Property Type-<asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("property_type") %>'></asp:Label>
                                                                    &nbsp;</div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">

                                                                    Year Built- <asp:Label ID="Label5" runat="server" Font-Bold="True" Text='<%# Eval("year_built") %>'></asp:Label>
                                                                    &nbsp;| Rooms- <asp:Label ID="Label6" runat="server" Font-Bold="True" Text='<%# Eval("rooms") %>'></asp:Label>
                                                                    &nbsp;| Bathrooms- <asp:Label ID="Label7" runat="server" Font-Bold="True" Text='<%# Eval("bathrooms") %>'></asp:Label>
                                                                    &nbsp;| Offers- <asp:Label ID="Label8" runat="server" Font-Bold="True" Text='<%# Eval("offers") %>'></asp:Label>
                                                                    &nbsp;| Appointments- <asp:Label ID="Label9" runat="server" Font-Bold="True" Text='<%# Eval("on_appointment") %>'></asp:Label>

                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">

                                                                    AgentID- <asp:Label ID="Label10" runat="server" Font-Bold="True" Text='<%# Eval("agent_id") %>'></asp:Label>
                                                                    &nbsp;| AppointmentID- <asp:Label ID="Label11" runat="server" Font-Bold="True" Text='<%# Eval("appointment_id") %>'></asp:Label>
                                                                    &nbsp;| Owner Name- <asp:Label ID="Label12" runat="server" Font-Bold="True" Text='<%# Eval("owner_name") %>'></asp:Label>

                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">

                                                                    Description- <asp:Label ID="Label13" runat="server" Font-Bold="True" Text='<%# Eval("house_description") %>'></asp:Label>

                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-lg-2">
                                                            <asp:Image CssClass="img-fluid" ID="Image1" runat="server" ImageUrl='<%# Eval("house_img_link") %>' />
                                                        </div>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>

                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>

