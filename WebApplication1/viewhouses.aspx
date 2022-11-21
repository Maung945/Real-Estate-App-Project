<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="viewhouses.aspx.cs" Inherits="WebApplication1.viewhouses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">

            <div class="col-sm-12">
                <center>
                    <h3>House Listings</h3>
                </center>
                <div class="row">
                    <div class="col-sm-12 col-md-12">
                        <asp:Panel class="alert alert-success" role="alert" ID="Panel1" runat="server" Visible="False">
                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                        </asp:Panel>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="card">
                        <div class="card-body">

                            <div class="row">
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:realestateappDBConnectionString %>" SelectCommand="SELECT * FROM [house_master_tbl]"></asp:SqlDataSource>
                                <div class="col">
                                    <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="house_id" DataSourceID="SqlDataSource1">
                                        <Columns>
                                            <asp:BoundField DataField="house_id" HeaderText="ID" ReadOnly="True" SortExpression="house_id">
                                                <ItemStyle Font-Bold="True" />
                                            </asp:BoundField>

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
                                                                        Price-
                                                                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("price") %>'></asp:Label>
                                                                        &nbsp;| SqFt-&nbsp;<asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("price_persqft") %>'></asp:Label>
                                                                        &nbsp;| Property Type-<asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("property_type") %>'></asp:Label>
                                                                        &nbsp;
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-12">
                                                                        Year Built-
                                                                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Text='<%# Eval("year_built") %>'></asp:Label>
                                                                        &nbsp;| Rooms-
                                                                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Text='<%# Eval("rooms") %>'></asp:Label>
                                                                        &nbsp;| Bathrooms-
                                                                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Text='<%# Eval("bathrooms") %>'></asp:Label>
                                                                        &nbsp;| Offers-
                                                                    <asp:Label ID="Label8" runat="server" Font-Bold="True" Text='<%# Eval("offers") %>'></asp:Label>
                                                                        &nbsp;| Units-
                                                                    <asp:Label ID="Label9" runat="server" Font-Bold="True" Text='<%# Eval("on_appointment") %>'></asp:Label>

                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-12">
                                                                        AgentID-
                                                                    <asp:Label ID="Label10" runat="server" Font-Bold="True" Text='<%# Eval("agent_id") %>'></asp:Label>
                                                                        &nbsp;| AppointmentID-
                                                                    <asp:Label ID="Label11" runat="server" Font-Bold="True" Text='<%# Eval("appointment_id") %>'></asp:Label>
                                                                        &nbsp;| Owner Name-
                                                                    <asp:Label ID="Label12" runat="server" Font-Bold="True" Text='<%# Eval("owner_name") %>'></asp:Label>

                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-12">
                                                                        Description-
                                                                    <asp:Label ID="Label13" runat="server" Font-Bold="True" Text='<%# Eval("house_description") %>'></asp:Label>

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
            <center>
                <a href="home.aspx"><< Back to Home</a><span class="clearfix"></span><br />
                <center>
        </div>
    </div>
</asp:Content>
