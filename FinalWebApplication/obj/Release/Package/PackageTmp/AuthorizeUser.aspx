<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AuthorizeUser.aspx.cs" Inherits="FinalWebApplication.AuthorizeUser" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1>Authorize User</h1>
            </hgroup>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:Table runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" Text="Your Site Key"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Image runat="server" ID="imgSiteKey"/>
            </asp:TableCell>          
            <asp:TableCell>
                <asp:Label runat="server" ID="lblKeyPhrase"></asp:Label>
            </asp:TableCell>  
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="txtPassword" TextMode="Password"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button runat="server" ID="btnAUthorize" Text="Authorize" OnClick="btnAUthorize_Click"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="lblResult" Visible="false"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
