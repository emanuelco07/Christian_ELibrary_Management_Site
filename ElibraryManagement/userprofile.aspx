<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userprofile.aspx.cs" Inherits="ElibraryManagement.userprofile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        //To create the search enbale Grid View
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100px" src="imgs/generaluser.png" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Your Profile</h4>
                                    <span>Account Status - </span>
                                    <asp:Label class="badge rounded-pill text-bg-info" ID="Label1" runat="server" Text="Your Status" Height="20px"></asp:Label>
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
                                <div class="mb-3">
                                    <asp:TextBox class="form-control" ID="TextBox1" runat="server"
                                        placeholder="Full Name"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Date of Birth</label>
                                <div class="mb-3">
                                    <asp:TextBox class="form-control" ID="TextBox2" runat="server"
                                        placeholder="Date of Birth" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Contact Number</label>
                                <div class="mb-3">
                                    <asp:TextBox class="form-control" ID="TextBox3" runat="server"
                                        placeholder="Contact Number" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Email ID</label>
                                <div class="mb-3">
                                    <asp:TextBox class="form-control" ID="TextBox4" runat="server"
                                        placeholder="Email ID" TextMode="Email"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <label>State</label>
                                <div class="mb-3">
                                    <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                                        <asp:ListItem Text="Select" Value="select"></asp:ListItem>
                                        <asp:ListItem Text="Afghanistan" Value="Afghanistan"></asp:ListItem>
                                        <asp:ListItem Text="Albania" Value="Albania"></asp:ListItem>
                                        <asp:ListItem Text="Algeria" Value="Algeria"></asp:ListItem>
                                        <asp:ListItem Text="Andorra" Value="Andorra"></asp:ListItem>
                                        <asp:ListItem Text="Angola" Value="Angola"></asp:ListItem>
                                        <asp:ListItem Text="Antigua and Barbuda" Value="Antigua and Barbuda"></asp:ListItem>
                                        <asp:ListItem Text="Argentina" Value="Argentina"></asp:ListItem>
                                        <asp:ListItem Text="Armenia" Value="Armenia"></asp:ListItem>
                                        <asp:ListItem Text="Australia" Value="Australia"></asp:ListItem>
                                        <asp:ListItem Text="Austria" Value="Austria"></asp:ListItem>
                                        <asp:ListItem Text="Azerbaijan" Value="Azerbaijan"></asp:ListItem>

                                        <asp:ListItem Text="Bahamas" Value="Bahamas"></asp:ListItem>
                                        <asp:ListItem Text="Bahrain" Value="Bahrain"></asp:ListItem>
                                        <asp:ListItem Text="Bangladesh" Value="Bangladesh"></asp:ListItem>
                                        <asp:ListItem Text="Barbados" Value="Barbados"></asp:ListItem>
                                        <asp:ListItem Text="Belarus" Value="Belarus"></asp:ListItem>
                                        <asp:ListItem Text="Belgium" Value="Belgium"></asp:ListItem>
                                        <asp:ListItem Text="Belize" Value="Belize"></asp:ListItem>
                                        <asp:ListItem Text="Benin" Value="Benin"></asp:ListItem>
                                        <asp:ListItem Text="Bhutan" Value="Bhutan"></asp:ListItem>
                                        <asp:ListItem Text="Bolivia" Value="Bolivia"></asp:ListItem>
                                        <asp:ListItem Text="Bosnia and Herzegovina" Value="Bosnia and Herzegovina"></asp:ListItem>
                                        <asp:ListItem Text="Botswana" Value="Botswana"></asp:ListItem>
                                        <asp:ListItem Text="Brazil" Value="Brazil"></asp:ListItem>
                                        <asp:ListItem Text="Brunei" Value="Brunei"></asp:ListItem>
                                        <asp:ListItem Text="Bulgaria" Value="Bulgaria"></asp:ListItem>
                                        <asp:ListItem Text="Burkina Faso" Value="Burkina Faso"></asp:ListItem>
                                        <asp:ListItem Text="Burundi" Value="Burundi"></asp:ListItem>

                                        <asp:ListItem Text="Cabo Verde" Value="Cabo Verde"></asp:ListItem>
                                        <asp:ListItem Text="Cambodia" Value="Cambodia"></asp:ListItem>
                                        <asp:ListItem Text="Cameroon" Value="Cameroon"></asp:ListItem>
                                        <asp:ListItem Text="Canada" Value="Canada"></asp:ListItem>
                                        <asp:ListItem Text="Central African Republic" Value="Central African Republic"></asp:ListItem>
                                        <asp:ListItem Text="Chad" Value="Chad"></asp:ListItem>
                                        <asp:ListItem Text="Chile" Value="Chile"></asp:ListItem>
                                        <asp:ListItem Text="China" Value="China"></asp:ListItem>
                                        <asp:ListItem Text="Colombia" Value="Colombia"></asp:ListItem>
                                        <asp:ListItem Text="Comoros" Value="Comoros"></asp:ListItem>
                                        <asp:ListItem Text="Congo (Congo-Brazzaville)" Value="Congo (Congo-Brazzaville)"></asp:ListItem>
                                        <asp:ListItem Text="Costa Rica" Value="Costa Rica"></asp:ListItem>
                                        <asp:ListItem Text="Croatia" Value="Croatia"></asp:ListItem>
                                        <asp:ListItem Text="Cuba" Value="Cuba"></asp:ListItem>
                                        <asp:ListItem Text="Cyprus" Value="Cyprus"></asp:ListItem>
                                        <asp:ListItem Text="Czech Republic" Value="Czech Republic"></asp:ListItem>

                                        <asp:ListItem Text="Democratic Republic of the Congo" Value="Democratic Republic of the Congo"></asp:ListItem>
                                        <asp:ListItem Text="Denmark" Value="Denmark"></asp:ListItem>
                                        <asp:ListItem Text="Djibouti" Value="Djibouti"></asp:ListItem>
                                        <asp:ListItem Text="Dominica" Value="Dominica"></asp:ListItem>
                                        <asp:ListItem Text="Dominican Republic" Value="Dominican Republic"></asp:ListItem>

                                        <asp:ListItem Text="Ecuador" Value="Ecuador"></asp:ListItem>
                                        <asp:ListItem Text="Egypt" Value="Egypt"></asp:ListItem>
                                        <asp:ListItem Text="El Salvador" Value="El Salvador"></asp:ListItem>
                                        <asp:ListItem Text="Equatorial Guinea" Value="Equatorial Guinea"></asp:ListItem>
                                        <asp:ListItem Text="Eritrea" Value="Eritrea"></asp:ListItem>
                                        <asp:ListItem Text="Estonia" Value="Estonia"></asp:ListItem>
                                        <asp:ListItem Text="Eswatini" Value="Eswatini"></asp:ListItem>
                                        <asp:ListItem Text="Ethiopia" Value="Ethiopia"></asp:ListItem>

                                        <asp:ListItem Text="Fiji" Value="Fiji"></asp:ListItem>
                                        <asp:ListItem Text="Finland" Value="Finland"></asp:ListItem>
                                        <asp:ListItem Text="France" Value="France"></asp:ListItem>

                                        <asp:ListItem Text="Gabon" Value="Gabon"></asp:ListItem>
                                        <asp:ListItem Text="Gambia" Value="Gambia"></asp:ListItem>
                                        <asp:ListItem Text="Georgia" Value="Georgia"></asp:ListItem>
                                        <asp:ListItem Text="Germany" Value="Germany"></asp:ListItem>
                                        <asp:ListItem Text="Ghana" Value="Ghana"></asp:ListItem>
                                        <asp:ListItem Text="Greece" Value="Greece"></asp:ListItem>
                                        <asp:ListItem Text="Grenada" Value="Grenada"></asp:ListItem>
                                        <asp:ListItem Text="Guatemala" Value="Guatemala"></asp:ListItem>
                                        <asp:ListItem Text="Guinea" Value="Guinea"></asp:ListItem>
                                        <asp:ListItem Text="Guinea-Bissau" Value="Guinea-Bissau"></asp:ListItem>
                                        <asp:ListItem Text="Guyana" Value="Guyana"></asp:ListItem>

                                        <asp:ListItem Text="Haiti" Value="Haiti"></asp:ListItem>
                                        <asp:ListItem Text="Honduras" Value="Honduras"></asp:ListItem>
                                        <asp:ListItem Text="Hungary" Value="Hungary"></asp:ListItem>

                                        <asp:ListItem Text="Iceland" Value="Iceland"></asp:ListItem>
                                        <asp:ListItem Text="India" Value="India"></asp:ListItem>
                                        <asp:ListItem Text="Indonesia" Value="Indonesia"></asp:ListItem>
                                        <asp:ListItem Text="Iran" Value="Iran"></asp:ListItem>
                                        <asp:ListItem Text="Iraq" Value="Iraq"></asp:ListItem>
                                        <asp:ListItem Text="Ireland" Value="Ireland"></asp:ListItem>
                                        <asp:ListItem Text="Israel" Value="Israel"></asp:ListItem>
                                        <asp:ListItem Text="Italy" Value="Italy"></asp:ListItem>

                                        <asp:ListItem Text="Jamaica" Value="Jamaica"></asp:ListItem>
                                        <asp:ListItem Text="Japan" Value="Japan"></asp:ListItem>
                                        <asp:ListItem Text="Jordan" Value="Jordan"></asp:ListItem>

                                        <asp:ListItem Text="Kazakhstan" Value="Kazakhstan"></asp:ListItem>
                                        <asp:ListItem Text="Kenya" Value="Kenya"></asp:ListItem>
                                        <asp:ListItem Text="Kiribati" Value="Kiribati"></asp:ListItem>
                                        <asp:ListItem Text="Kuwait" Value="Kuwait"></asp:ListItem>
                                        <asp:ListItem Text="Kyrgyzstan" Value="Kyrgyzstan"></asp:ListItem>

                                        <asp:ListItem Text="Laos" Value="Laos"></asp:ListItem>
                                        <asp:ListItem Text="Latvia" Value="Latvia"></asp:ListItem>
                                        <asp:ListItem Text="Lebanon" Value="Lebanon"></asp:ListItem>
                                        <asp:ListItem Text="Lesotho" Value="Lesotho"></asp:ListItem>
                                        <asp:ListItem Text="Liberia" Value="Liberia"></asp:ListItem>
                                        <asp:ListItem Text="Libya" Value="Libya"></asp:ListItem>
                                        <asp:ListItem Text="Liechtenstein" Value="Liechtenstein"></asp:ListItem>
                                        <asp:ListItem Text="Lithuania" Value="Lithuania"></asp:ListItem>
                                        <asp:ListItem Text="Luxembourg" Value="Luxembourg"></asp:ListItem>

                                        <asp:ListItem Text="Madagascar" Value="Madagascar"></asp:ListItem>
                                        <asp:ListItem Text="Malawi" Value="Malawi"></asp:ListItem>
                                        <asp:ListItem Text="Malaysia" Value="Malaysia"></asp:ListItem>
                                        <asp:ListItem Text="Maldives" Value="Maldives"></asp:ListItem>
                                        <asp:ListItem Text="Mali" Value="Mali"></asp:ListItem>
                                        <asp:ListItem Text="Malta" Value="Malta"></asp:ListItem>
                                        <asp:ListItem Text="Marshall Islands" Value="Marshall Islands"></asp:ListItem>
                                        <asp:ListItem Text="Mauritania" Value="Mauritania"></asp:ListItem>
                                        <asp:ListItem Text="Mauritius" Value="Mauritius"></asp:ListItem>
                                        <asp:ListItem Text="Mexico" Value="Mexico"></asp:ListItem>
                                        <asp:ListItem Text="Micronesia" Value="Micronesia"></asp:ListItem>
                                        <asp:ListItem Text="Moldova" Value="Moldova"></asp:ListItem>
                                        <asp:ListItem Text="Monaco" Value="Monaco"></asp:ListItem>
                                        <asp:ListItem Text="Mongolia" Value="Mongolia"></asp:ListItem>
                                        <asp:ListItem Text="Montenegro" Value="Montenegro"></asp:ListItem>
                                        <asp:ListItem Text="Morocco" Value="Morocco"></asp:ListItem>
                                        <asp:ListItem Text="Mozambique" Value="Mozambique"></asp:ListItem>
                                        <asp:ListItem Text="Myanmar" Value="Myanmar"></asp:ListItem>

                                        <asp:ListItem Text="Namibia" Value="Namibia"></asp:ListItem>
                                        <asp:ListItem Text="Nauru" Value="Nauru"></asp:ListItem>
                                        <asp:ListItem Text="Nepal" Value="Nepal"></asp:ListItem>
                                        <asp:ListItem Text="Netherlands" Value="Netherlands"></asp:ListItem>
                                        <asp:ListItem Text="New Zealand" Value="New Zealand"></asp:ListItem>
                                        <asp:ListItem Text="Nicaragua" Value="Nicaragua"></asp:ListItem>
                                        <asp:ListItem Text="Niger" Value="Niger"></asp:ListItem>
                                        <asp:ListItem Text="Nigeria" Value="Nigeria"></asp:ListItem>
                                        <asp:ListItem Text="North Korea" Value="North Korea"></asp:ListItem>
                                        <asp:ListItem Text="North Macedonia" Value="North Macedonia"></asp:ListItem>
                                        <asp:ListItem Text="Norway" Value="Norway"></asp:ListItem>

                                        <asp:ListItem Text="Oman" Value="Oman"></asp:ListItem>

                                        <asp:ListItem Text="Pakistan" Value="Pakistan"></asp:ListItem>
                                        <asp:ListItem Text="Palau" Value="Palau"></asp:ListItem>
                                        <asp:ListItem Text="Panama" Value="Panama"></asp:ListItem>
                                        <asp:ListItem Text="Papua New Guinea" Value="Papua New Guinea"></asp:ListItem>
                                        <asp:ListItem Text="Paraguay" Value="Paraguay"></asp:ListItem>
                                        <asp:ListItem Text="Peru" Value="Peru"></asp:ListItem>
                                        <asp:ListItem Text="Philippines" Value="Philippines"></asp:ListItem>
                                        <asp:ListItem Text="Poland" Value="Poland"></asp:ListItem>
                                        <asp:ListItem Text="Portugal" Value="Portugal"></asp:ListItem>

                                        <asp:ListItem Text="Qatar" Value="Qatar"></asp:ListItem>

                                        <asp:ListItem Text="Romania" Value="Romania"></asp:ListItem>
                                        <asp:ListItem Text="Russia" Value="Russia"></asp:ListItem>
                                        <asp:ListItem Text="Rwanda" Value="Rwanda"></asp:ListItem>

                                        <asp:ListItem Text="Saint Kitts and Nevis" Value="Saint Kitts and Nevis"></asp:ListItem>
                                        <asp:ListItem Text="Saint Lucia" Value="Saint Lucia"></asp:ListItem>
                                        <asp:ListItem Text="Saint Vincent and the Grenadines" Value="Saint Vincent and the Grenadines"></asp:ListItem>
                                        <asp:ListItem Text="Samoa" Value="Samoa"></asp:ListItem>
                                        <asp:ListItem Text="San Marino" Value="San Marino"></asp:ListItem>
                                        <asp:ListItem Text="Sao Tome and Principe" Value="Sao Tome and Principe"></asp:ListItem>
                                        <asp:ListItem Text="Saudi Arabia" Value="Saudi Arabia"></asp:ListItem>
                                        <asp:ListItem Text="Senegal" Value="Senegal"></asp:ListItem>
                                        <asp:ListItem Text="Serbia" Value="Serbia"></asp:ListItem>
                                        <asp:ListItem Text="Seychelles" Value="Seychelles"></asp:ListItem>
                                        <asp:ListItem Text="Sierra Leone" Value="Sierra Leone"></asp:ListItem>
                                        <asp:ListItem Text="Singapore" Value="Singapore"></asp:ListItem>
                                        <asp:ListItem Text="Slovakia" Value="Slovakia"></asp:ListItem>
                                        <asp:ListItem Text="Slovenia" Value="Slovenia"></asp:ListItem>
                                        <asp:ListItem Text="Solomon Islands" Value="Solomon Islands"></asp:ListItem>
                                        <asp:ListItem Text="Somalia" Value="Somalia"></asp:ListItem>
                                        <asp:ListItem Text="South Africa" Value="South Africa"></asp:ListItem>
                                        <asp:ListItem Text="South Korea" Value="South Korea"></asp:ListItem>
                                        <asp:ListItem Text="South Sudan" Value="South Sudan"></asp:ListItem>
                                        <asp:ListItem Text="Spain" Value="Spain"></asp:ListItem>
                                        <asp:ListItem Text="Sri Lanka" Value="Sri Lanka"></asp:ListItem>
                                        <asp:ListItem Text="Sudan" Value="Sudan"></asp:ListItem>
                                        <asp:ListItem Text="Suriname" Value="Suriname"></asp:ListItem>
                                        <asp:ListItem Text="Sweden" Value="Sweden"></asp:ListItem>
                                        <asp:ListItem Text="Switzerland" Value="Switzerland"></asp:ListItem>
                                        <asp:ListItem Text="Syria" Value="Syria"></asp:ListItem>

                                        <asp:ListItem Text="Taiwan" Value="Taiwan"></asp:ListItem>
                                        <asp:ListItem Text="Tajikistan" Value="Tajikistan"></asp:ListItem>
                                        <asp:ListItem Text="Tanzania" Value="Tanzania"></asp:ListItem>
                                        <asp:ListItem Text="Thailand" Value="Thailand"></asp:ListItem>
                                        <asp:ListItem Text="Timor-Leste" Value="Timor-Leste"></asp:ListItem>
                                        <asp:ListItem Text="Togo" Value="Togo"></asp:ListItem>
                                        <asp:ListItem Text="Tonga" Value="Tonga"></asp:ListItem>
                                        <asp:ListItem Text="Trinidad and Tobago" Value="Trinidad and Tobago"></asp:ListItem>
                                        <asp:ListItem Text="Tunisia" Value="Tunisia"></asp:ListItem>
                                        <asp:ListItem Text="Turkey" Value="Turkey"></asp:ListItem>
                                        <asp:ListItem Text="Turkmenistan" Value="Turkmenistan"></asp:ListItem>
                                        <asp:ListItem Text="Tuvalu" Value="Tuvalu"></asp:ListItem>

                                        <asp:ListItem Text="Uganda" Value="Uganda"></asp:ListItem>
                                        <asp:ListItem Text="Ukraine" Value="Ukraine"></asp:ListItem>
                                        <asp:ListItem Text="United Arab Emirates" Value="United Arab Emirates"></asp:ListItem>
                                        <asp:ListItem Text="United Kingdom" Value="United Kingdom"></asp:ListItem>
                                        <asp:ListItem Text="United States" Value="United States"></asp:ListItem>
                                        <asp:ListItem Text="Uruguay" Value="Uruguay"></asp:ListItem>
                                        <asp:ListItem Text="Uzbekistan" Value="Uzbekistan"></asp:ListItem>

                                        <asp:ListItem Text="Vanuatu" Value="Vanuatu"></asp:ListItem>
                                        <asp:ListItem Text="Vatican City" Value="Vatican City"></asp:ListItem>
                                        <asp:ListItem Text="Venezuela" Value="Venezuela"></asp:ListItem>
                                        <asp:ListItem Text="Vietnam" Value="Vietnam"></asp:ListItem>

                                        <asp:ListItem Text="Yemen" Value="Yemen"></asp:ListItem>

                                        <asp:ListItem Text="Zambia" Value="Zambia"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>City</label>
                                <div class="mb-3">
                                    <asp:TextBox class="form-control" ID="TextBox6" runat="server"
                                        placeholder="City"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Pincode</label>
                                <div class="mb-3">
                                    <asp:TextBox class="form-control" ID="TextBox7" runat="server"
                                        placeholder="Pincode" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <label>Full adress</label>
                                <div class="mb-3">
                                    <asp:TextBox class="form-control" ID="TextBox5" runat="server"
                                        placeholder="Full Adress" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <center>
                                <div class="col">
                                    <span class="badge rounded-pill text-bg-primary">Login Credentials</span>
                                </div>
                            </center>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <label>Member ID</label>
                                <div class="mb-3">
                                    <asp:TextBox class="form-control" ID="TextBox8" runat="server"
                                        placeholder="User ID" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Old Password</label>
                                <div class="mb-3">
                                    <asp:TextBox class="form-control" ID="TextBox9" runat="server"
                                        placeholder="Password" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>New Password</label>
                                <div class="mb-3">
                                    <asp:TextBox class="form-control" ID="TextBox10" runat="server"
                                        placeholder="New Password" TextMode="Password" ReadOnly="False"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-8 mx-auto">
                                <center>
                                    <div class="mb-3">
                                        <asp:Button class="btn btn-primary d-block w-100 btn-lg" ID="Button1" runat="server" Text="Update" OnClick="Button1_Click" />
                                    </div>
                                </center>
                            </div>
                        </div>
                    </div>
                </div>
                <br />
            </div>
            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100px" src="imgs/books.png" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Your Issued Books</h4>
                                    <asp:Label class="badge rounded-pill text-bg-primary" ID="Label2" runat="server" Text="your books info"></asp:Label>
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
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound"></asp:GridView>
                            </div>
                        </div>
                        <br />
                    </div>
                </div>
            </div>
</asp:Content>
