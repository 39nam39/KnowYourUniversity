<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Login.aspx.cs" Inherits="FinalWebApplication.Login" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1>Login</h1>
            </hgroup>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:Table runat="server">
        <asp:TableRow>            
            <asp:TableCell>
                <asp:Label runat="server" Text="ENTER USER ID"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="txtLoginID"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell> 
                <asp:Button runat="server" ID="btnLogin" OnClick="btnLogin_Click" Text="Login"/>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button runat="server" ID="btnSignUp" Text="Sign Up" OnClick="btnSignUp_Click"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="lblErrorMsg" Visible="false"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
