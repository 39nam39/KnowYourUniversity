<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="XMLViewer.aspx.cs" Inherits="FinalWebApplication.XMLViewer" EnableViewStateMac="false"%>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1>XML File Viewer</h1>
            </hgroup>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:TextBox ID="txtXMLArea" runat="server" TextMode="MultiLine" Height="600px" Width="500px"></asp:TextBox><br />
    <asp:Label ID="lblError" runat="server"></asp:Label>
    <a href="Default.aspx">BACK</a>
    </asp:Content>
