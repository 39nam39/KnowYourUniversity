<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FinalWebApplication._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1>Your University</h1>
            </hgroup>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div>
        <p> This application will give information related to the university you selected.
            There are two types of users.
            <br />
            1. Prospective Students.
            2. Visiting Scholars. <br /> 
            Go to the respective home page to access the main contents of the website.<br />
        <b> 1. Upload SOP - As a registered user, you can upload a pdf/doc file (max 3mb size).<br />
            2. Yelp will help you to find the nearest restaurant, store from the selected main university's campus.<br />
            3. Bing will help compile the latest news regarding the selected university.<br />
        </b>
            Some of these service require you to select the university from a drop down while others services need not.
            If no university is chosen, by default Arizona State University will be selected.</p>
    </div>
    <br />
    <asp:Button runat="server" ID="btnLogin" OnClick="btnLogin_Click" Text="Login"/>
    <div>
       <asp:Table runat="server" ID="tableTryIt">
           <asp:TableRow>
               <asp:TableHeaderCell Text ="Member Name"></asp:TableHeaderCell>
               <asp:TableHeaderCell Text="Service Name"></asp:TableHeaderCell>               
               <asp:TableHeaderCell Text="Tryit Page"></asp:TableHeaderCell>               
               <asp:TableHeaderCell Text="Description"></asp:TableHeaderCell>
           </asp:TableRow>
           <asp:TableRow>
               <asp:TableCell Text="Uday Kumar"></asp:TableCell>
               <asp:TableCell Text="Upload SOP"></asp:TableCell>
               <asp:TableCell Text =""><a href="http://webstrar23.fulton.asu.edu/page0/page02/UploadSOP.aspx"> Upload SOP</a></asp:TableCell>
               <asp:TableCell Text ="Invoke this service to Stores the statement of purposes uploaded by the user. The user has to be registered to access this service"></asp:TableCell>
           </asp:TableRow>
           <asp:TableRow>
               <asp:TableCell Text="Uday Kumar"></asp:TableCell>
               <asp:TableCell Text="YELP"></asp:TableCell>
               <asp:TableCell Text =""><a href="http://webstrar23.fulton.asu.edu/page0/page02/YelpService.aspx">Yelp</a></asp:TableCell>
               <asp:TableCell Text ="Invoke this service to get the nearest store given a location. I/P = Search Term and Location"></asp:TableCell>
           </asp:TableRow>
           <asp:TableRow>
               <asp:TableCell Text="Uday Kumar"></asp:TableCell>
               <asp:TableCell Text="BING"></asp:TableCell>
               <asp:TableCell Text =""><a href="http://webstrar23.fulton.asu.edu/page0/page02/BingNews.aspx"> Bing</a></asp:TableCell>
               <asp:TableCell Text ="Invoke this service to get the latest local news given. I/P = Search term and Location"></asp:TableCell>
           </asp:TableRow>
           <asp:TableRow>
               <asp:TableCell Text="Uday Kumar"></asp:TableCell>
               <asp:TableCell Text="XML Univsrsity List Storage"></asp:TableCell>
               <asp:TableCell><a href="http://webstrar23.fulton.asu.edu/page2/univ.xml">University List</a></asp:TableCell>
               <asp:TableCell Text="This XML has been generated from various list available at Forbes top 500 and US University accredation"></asp:TableCell>
           </asp:TableRow>
           <asp:TableRow>
               <asp:TableCell Text="Uday Kumar"></asp:TableCell>
               <asp:TableCell Text="XML User Details"></asp:TableCell>
               <asp:TableCell><a href="http://webstrar23.fulton.asu.edu/page2/userdetails.xml">User Details</a></asp:TableCell>
               <asp:TableCell Text="This XML has the user information, note that the password is not being saved as plain text (Using Salt and Hash)."></asp:TableCell>
           </asp:TableRow>                
       </asp:Table>
   </div>
</asp:Content>
