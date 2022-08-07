<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Judgepg2.aspx.cs" Inherits="WebApplication1.Judgepg2" %>



<!DOCTYPE html>
<html lang="en">

<head runat="server">
  <meta charset="utf-8">
  <meta content="width=device-width, initial-scale=1.0" name="viewport">

  <title>CFC</title>
  <meta content="" name="description">
  <meta content="" name="keywords">

  <!-- Favicons -->
  <link href="assets/img/favicon.png" rel="icon">
  <link href="assets/img/apple-touch-icon.png" rel="apple-touch-icon">

  <!-- Google Fonts -->
  <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i|Jost:300,300i,400,400i,500,500i,600,600i,700,700i|Poppins:300,300i,400,400i,500,500i,600,600i,700,700i" rel="stylesheet">

  <!-- Vendor CSS Files -->
  <link href="assets/vendor/aos/aos.css" rel="stylesheet">
  <link href="assets/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">
  <link href="assets/vendor/bootstrap-icons/bootstrap-icons.css" rel="stylesheet">
  <link href="assets/vendor/boxicons/css/boxicons.min.css" rel="stylesheet">
  <link href="assets/vendor/glightbox/css/glightbox.min.css" rel="stylesheet">
  <link href="assets/vendor/remixicon/remixicon.css" rel="stylesheet">
  <link href="assets/vendor/swiper/swiper-bundle.min.css" rel="stylesheet">

  <!-- Template Main CSS File -->
  <link href="assets/css/style.css" rel="stylesheet">

  <!-- =======================================================
  * Template Name: CFC - v4.7.1
  * Template URL: https://bootstrapmade.com/arsha-free-bootstrap-html-template-corporate/
  * Author: BootstrapMade.com
  * License: https://bootstrapmade.com/license/
  ======================================================== -->
</head>

<body>
	
  <!-- ======= Header ======= -->
  <header id="header" class="fixed-top ">
    <div class="container d-flex align-items-center">

      <h1 class="logo me-auto"><a href="index.html">CFC</a></h1>
      <!-- Uncomment below if you prefer to use an image logo -->
      <!-- <a href="index.html" class="logo me-auto"><img src="assets/img/logo.png" alt="" class="img-fluid"></a>-->

           <nav id="navbar" class="navbar">
        <ul>
          <li><a class="nav-link scrollto active" href="Homepage.aspx">Home</a></li>
          <li><a class="nav-link scrollto" href="Peoplelog.aspx">Public</a></li>
          <li><a class="nav-link scrollto" href="PoliceLog2.aspx">Police</a></li>
          <li><a class="nav-link   scrollto" href="Judgepg2.aspx">Judge</a></li>
          <li><a class="nav-link scrollto" href="#contact">Contact</a></li>
          <li><a class="getstarted scrollto" href="HomePage.aspx">Logout</a></li>
        </ul>
        <i class="bi bi-list mobile-nav-toggle"></i>
      </nav><!-- .navbar -->

    </div>
  </header><!-- End Header -->

  <!-- ======= Hero Section ======= -->
  <section id="hero" class="d-flex align-items-center">

    <div class="container">
      <div class="row">
        <div class="col-lg-6 d-flex flex-column justify-content-center pt-4 pt-lg-0 order-2 order-lg-1" data-aos="fade-up" data-aos-delay="200">
          <h1>CFC</h1>
          <h2>Crime Free City</h2>
          <div class="d-flex justify-content-center justify-content-lg-start">
            <a href="#about" class="btn-get-started scrollto">Get Started</a>
            
          </div>
        </div>
        <div class="col-lg-6 order-1 order-lg-2 hero-img" data-aos="zoom-in" data-aos-delay="200">
          <img src="assets/img/hero-img.png" class="img-fluid animated" alt="">
        </div>
      </div>
    </div>

  </section><!-- End Hero -->

  <main id="main">

 

    <!-- ======= About Us Section ======= -->
    <section id="about" class="about">
      <div class="container" data-aos="fade-up">

        <div class="section-title">
          <h2>Judge Login</h2>
        </div>

        <div class="row content">
            <center>
              <form id="form1" runat="server">
                <table cellspacing="4" width="70%" border="0">
                    <tr>
                        <td></td>
                        <td width="30%"></td>
                        <td  width="30%"></td>
                    </tr>
                    <tr>
                        <td>
                        <asp:Label ID="Label1" runat="server" CssClass="auto-style5" Text="Enter ID"></asp:Label>
                     </td>
                       <td colspan="2">
                      <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style1" Width="300px"></asp:TextBox><br /><br />
                    </td> 
                           </tr>
                    <tr>
                        <td>
                        <asp:Label ID="Label2" runat="server" CssClass="auto-style2" Text="Enter Password"></asp:Label>
                             </td>
                       <td colspan="2">
                <asp:TextBox ID="TextBox2" runat="server" CssClass="auto-style3" Width="300px" TextMode="Password"></asp:TextBox><br /><br />
                            </td> 
                           </tr>
                    <tr>
                        <td></td>
                        <td colspan="2">
                     
                            <asp:Button ID="Button1" runat="server" CssClass="auto-style4" Text="SUBMIT" OnClick="Button1_Click" />
                      </td>
                            </tr>
                 </table>
               </form>
                </center>
        </div>

      </div>
    </section><!-- End About Us Section -->

    <!-- ======= Contact Section ======= -->
    <section id="contact" class="contact">
      <div class="container" data-aos="fade-up">

        <div class="section-title">
          <h2>Contact</h2>
          <p>Connect with us</p>
        </div>

          <div class="col-lg-14 mt-5 mt-lg-0 d-flex align-items-stretch">
            <form action="forms/contact.php" method="post" role="form" class="php-email-form">
              <div class="row">
                <div class="form-group col-md-6">
                  <label for="name">Your Name</label>
                  <input type="text" name="name" class="form-control" id="name" required>
                </div>
                <div class="form-group col-md-6">
                  <label for="name">Your Email</label>
                  <input type="email" class="form-control" name="email" id="email" required>
                </div>
              </div>
              <div class="form-group">
                <label for="name">Subject</label>
                <input type="text" class="form-control" name="subject" id="subject" required>
              </div>
              <div class="form-group">
                <label for="name">Message</label>
                <textarea class="form-control" name="message" rows="10" required></textarea>
              </div>
              <div class="my-3">
                <div class="loading">Loading</div>
                <div class="error-message"></div>
                <div class="sent-message">Your message has been sent. Thank you!</div>
              </div>
              <div class="text-center"><button type="submit">Send Message</button></div>
            </form>
          </div>

        </div>

      </div>
    </section><!-- End Contact Section -->

  </main><!-- End #main -->

  <!-- ======= Footer ======= -->
  <footer id="footer">

    

    <div class="footer-top">
      <div class="container">
        <div class="row">

          <div class="col-lg-3 col-md-6 footer-contact">
            <h3>CFC</h3>
            <p>
              <strong>Email:</strong> kishore38090@gmail.com<br>
            </p>
          </div>

          <div class="col-lg-3 col-md-6 footer-links">
            <h4>Useful Links</h4>
            <ul>
              <li><i class="bx bx-chevron-right"></i> <a href="HomePage.aspx">Home</a></li>
            </ul>
          </div>


          <div class="col-lg-3 col-md-6 footer-links">
            <h4>Our Social Networks</h4>
            <p>Contact Us</p>
            <div class="social-links mt-3">
              <a href="#" class="twitter"><i class="bx bxl-twitter"></i></a>
              <a href="#" class="facebook"><i class="bx bxl-facebook"></i></a>
              <a href="#" class="instagram"><i class="bx bxl-instagram"></i></a>
              <a href="#" class="google-plus"><i class="bx bxl-skype"></i></a>
              <a href="#" class="linkedin"><i class="bx bxl-linkedin"></i></a>
            </div>
          </div>

        </div>
      </div>
    </div>

    <div class="container footer-bottom clearfix">
      <div class="copyright">
        &copy; Copyright <strong><span>CFC</span></strong>. All Rights Reserved
      </div>
      <div class="credits">
        <!-- All the links in the footer should remain intact. -->
        <!-- You can delete the links only if you purchased the pro version. -->
        <!-- Licensing information: https://bootstrapmade.com/license/ -->
        <!-- Purchase the pro version with working PHP/AJAX contact form: https://bootstrapmade.com/arsha-free-bootstrap-html-template-corporate/ -->
        Designed by <a href="https://bootstrapmade.com/">BootstrapMade</a>
      </div>
    </div>
  </footer><!-- End Footer -->

  <div id="preloader"></div>
  <a href="#" class="back-to-top d-flex align-items-center justify-content-center"><i class="bi bi-arrow-up-short"></i></a>

  <!-- Vendor JS Files -->
  <script src="assets/vendor/aos/aos.js"></script>
  <script src="assets/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
  <script src="assets/vendor/glightbox/js/glightbox.min.js"></script>
  <script src="assets/vendor/isotope-layout/isotope.pkgd.min.js"></script>
  <script src="assets/vendor/swiper/swiper-bundle.min.js"></script>
  <script src="assets/vendor/waypoints/noframework.waypoints.js"></script>
  <script src="assets/vendor/php-email-form/validate.js"></script>

  <!-- Template Main JS File -->
  <script src="assets/js/main.js"></script>

</body>

</html>