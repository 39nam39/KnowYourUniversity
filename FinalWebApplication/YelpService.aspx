<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="YelpService.aspx.cs" Inherits="FinalWebApplication.YelpService" EnableViewStateMac="false" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1>Find Nearest Store</h1>
            </hgroup>
        </div>
    </section>
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
    <h3>SEARCH ITEM(Coffee/Chili's)</h3>
        
    <asp:TextBox ID="searchItem" runat="server"></asp:TextBox>
    <h3>ZipCode/Locality(Tempe/85281)</h3>
    <asp:TextBox ID="zip_locality" runat="server"></asp:TextBox>
    <asp:Button ID="btnSearch" Text="Search" runat="server" OnClick="btnSearch_Click"/>
        </hgroup>
    <div>
        <h1> Results </h1>
        <asp:GridView runat="server" ID="resultGrid" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Business Name"/>
                <asp:BoundField DataField="PhoneNo" HeaderText="Phone"/>
                <asp:BoundField DataField="Location" HeaderText="Location"/>                
            </Columns>            
        </asp:GridView>
    </div>
</asp:Content>