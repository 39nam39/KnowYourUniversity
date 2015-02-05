<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="BingNews.aspx.cs" Inherits="FinalWebApplication.BingNews" EnableViewStateMac="false"%>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1>Bing Local News</h1>
            </hgroup>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">    
    <h3>Search</h3>
    <asp:TextBox runat="server" ID="txtSearchTerm"></asp:TextBox>
    <asp:Button runat="server" ID="btnSearch" Text="Search" OnClick="btnSearch_Click"/>
    <br />
    <div id="searchResults">
        <asp:ListView ID="lstViewSearch" runat="server"></asp:ListView>
    </div>
    <div>
        <asp:GridView ID="gridViewSearch" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="resdate" HeaderText="Date"/>
                <asp:BoundField DataField="restitle" HeaderText="Title"/>
                <asp:BoundField DataField="resURL" HeaderText="Link"/>
                <asp:BoundField DataField="ressource" HeaderText="Source"/>                
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>