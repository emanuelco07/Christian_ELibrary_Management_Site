<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="homepage.aspx.cs" Inherits="ElibraryManagement.homepage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <img src="imgs/library.png" class="img-fluid"/>
    </section>
    <section>
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <center>
                        <h2>Our Features</h2>
                        <p><b>Our 3 Primary Features</b></p>
                    </center>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <center>
                        <img width="150px" src="imgs/inventory.png" />
                        <h4>Digital Book Inventory</h4>
                        <p class="text-justify">
                            Explore our extensive collection of Christian literature, 
                            from theological studies to daily devotionals. Our digital 
                            inventory is meticulously organized to help you browse and 
                            manage resources that support your spiritual growth and biblical 
                            understanding.
                        </p>
                    </center>
                </div>
                <div class="col-md-4">
                    <center>
                        <img width="150px" src="imgs/search_books.png" />
                        <h4>Search Books</h4>
                        <p class="text-justify">
                            Easily find the wisdom you're looking for. Use our advanced 
                            search tools to filter by author, topic, or scripture reference. 
                            Whether you are preparing a sermon or seeking personal inspiration, 
                            the right book is just a few clicks away.
                        </p>
                    </center>
                </div>
                <div class="col-md-4">
                    <center>
                        <img width="150px" src="imgs/defaulter_list.png" />
                        <h4>Defaulter List</h4>
                        <p class="text-justify">
                            To ensure that our resources remain available to the entire community, 
                            we kindly track book returns. This section helps us maintain good 
                            stewardship of our collection, reminding members to return borrowed 
                            materials on time so others may also be blessed by them.
                        </p>
                    </center>
                </div>
    </section>
    <section>
        <img src="imgs/library2.png" class="img-fluid"/>
    </section>
    <section>
    <div class="container">
        <div class="row">
            <div class="col-12">
                <center>
                    <h2>Our Process</h2>
                    <p><b>We have a Simple 3 Steps Process</b></p>
                </center>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <center>
                    <img width="150px" src="imgs/sign_up.png" />
                    <h4>Sign Up</h4>
                    <p class="text-justify">
                        Join our library community in just a few clicks! 
                        Create your personal account to gain full access to our 
                        collection. By signing up, you can easily borrow books.
                    </p>
                </center>
            </div>
            <div class="col-md-4">
                <center>
                    <img width="150px" src="imgs/search_books.png" />
                    <h4>Search Books</h4>
                    <p class="text-justify">
                        Discover the resources you need for your faith walk. 
                        Browse our online catalog from anywhere to find titles 
                        that inspire and educate. Whether you’re looking for a 
                        specific author or a new topic to study, our search tool 
                        makes it simple.
                    </p>
                </center>
            </div>
            <div class="col-md-4">
                <center>
                    <img width="150px" src="imgs/visit_us.png" />
                    <h4>Visit Us</h4>
                    <p class="text-justify">
                        Once you've found your next book, come say hello! 
                        Visit our physical location to pick up your borrowed 
                        materials and enjoy a quiet space for study and fellowship. 
                        We look forward to welcoming you into our peaceful environment.
                    </p>
                </center>
            </div>
</section>
</asp:Content>
