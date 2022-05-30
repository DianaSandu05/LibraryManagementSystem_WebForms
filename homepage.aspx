<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="homepage.aspx.cs" Inherits="LibraryManagementAssignment16451.homepage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div id="slides" class="carousel slide" data-ride="caroudel">
            <ul class="carousel-indicators">
                <li data-target="#slides" data-slide-to="0"></li>
                <li data-target="#slides" data-slide-to="1"></li>
                <li data-target="#slides" data-slide-to="2"></li>
            </ul>
            <div class="carousel-inner">
                <div class="carousel-item active">
                    <img src="imgs/imgcarousel.jpeg" class="img-fluid" />
                    <div class="carousel-caption">
                        <h1 class="display-2">Book's Universe</h1>
                        <h3>Borrow books if you are student, lecturer or team member</h3>
                    <a href="viewBooks.aspx" class="btn btn-outline-info active" role="button" aria-pressed="true">View Books</a>
                    </div>
                </div>
                <div class="carousel-item">
                    <img src="imgs/mainHome.jpg" class="img-fluid"/>   

                </div>
                <div class="carousel-item">
                    <img src="imgs/scienceCarousel.jpg" class="img-fluid" />
                </div>
            </div>
        </div>
        
    </section>

    <section>
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <center>
                     <h2>Our features</h2> 
                    <p><b>Our 3 primary features</b></p>   
                    <center>
            </div>
          </div>
            <div class="row">
                <div class="col-md-4">
                    <center>
                    <img  src="imgs/featureimg.jpg" width="100" height="100"/>  
                    <h5>Book's Universe</h5>
                    <p class="text-justify">Book's Universe for students, lecturers and team members who can borrow up to 5 books at once for 5 weeks.</p>  
                 <center>
                </div>
                   
                
                <div class="col-md-4"> 
                    <center>
                    <img  src="imgs/imgfeature.png" width="100" height="100" />
                    <h5>Book's Management & Inventory</h5>
                    <p class="text-justify">Book's Universe for students, lecturers and team members who can borrow up to 5 books at once for 5 weeks.</p>
                <center>
                </div>
                <div class="col-md-4">
                    <center>
                        <img src="imgs/memberfeature.png"  width="100" height="100"/>
                    <h5>Members management</h5>
                    <p class="text-justify">Book's Universe for students, lecturers and team members who can borrow up to 5 books at once for 5 weeks.</p>
                  <center>
                    </div>
               </div>
       
        </div>
    </section>
    <section>
        <div class="container-fluid padding">
            <div class="row text-center">
                <div class="col-md-4">
                    <hr class="light" />
                    <h5>Contact us</h5>
                    <hr class="light" />
                    <p>555-555-5555</p>
                    <p>contact@booksuniverse.com</p>
                    <p>103 Alder Street</p>
                    <p>London, United Kingdom</p>
                    <p>Postcode</p>
                </div>
                <div class="col-md-4">
                    <hr class="light" />
                    <h5>Our hours</h5>
                    <hr class="light" />
                    <p>Monday: 9am - 5pm</p>
                    <p>Tuesday: 9am - 5pm</p>
                    <p>Wednesday: 9am - 5pm</p>
                    <p>Thursday: 9am - 5pm</p>
                    <p>Friday: 9am - 4pm</p>     
                </div>
                <div class="col-md-4">
                    <hr class="light" />
                    <h5>Best reviewed books</h5>
                    <hr class="light" />
                    <p>Think and Grow Rich - Napoleon Hill</p>
                    <p>Applied Computing - author</p>
                    <p>Book name - author</p>
                    <p>Book name - author</p>
                    <p>Book name - author</p>     
                </div>
            </div>
        </div>
        
    </section>

</asp:Content>
