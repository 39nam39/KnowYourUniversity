<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master"  CodeBehind="ScholarHome.aspx.cs" Inherits="FinalWebApplication.ScholarHome" EnableViewStateMac="false"%>
<%@ Register Src="~/DateTime.ascx" TagPrefix="dtConrtol" TagName="DateTimeControl" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1>Scholar Home</h1>
            </hgroup>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">    
    <div style="text-align: right; margin-left: 90%;">
            <dtConrtol:DateTimeControl runat="server" ID="dateTimeCtrl" Visible="true"/>
    </div>
    <asp:Table ID="tabScholar" runat="server">
        <asp:TableRow>
            <asp:TableCell><h3>Select the Univeristy</h3></asp:TableCell>
            <asp:TableCell><asp:DropDownList runat="server" ID="univListDD" OnSelectedIndexChanged="univListDD_SelectedIndexChanged"></asp:DropDownList></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="lblBingNews" runat="server" Text="BING Local News"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:Button runat="server" Text="Get News" ID="btnLocalNews" OnClick="btnLocalNews_Click"/></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label runat="server" ID="lblFindNearest" Text="Find Nearest Store" Visible="true"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:TextBox runat="server" ID="txtSearchTerm" Visible="true"></asp:TextBox></asp:TableCell>
            <asp:TableCell><asp:Button runat="server" ID="btnSearch" Text="Search" OnClick="btnSearch_Click" Visible="true"/></asp:TableCell>
        </asp:TableRow>
    </asp:Table>    
    <br />
    <br />
    <h2> Results </h2>
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
    <br />
    <br />
    <div>        
        <asp:GridView runat="server" ID="resultGrid" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Business Name"/>
                <asp:BoundField DataField="PhoneNo" HeaderText="Phone"/>
                <asp:BoundField DataField="Location" HeaderText="Location"/>                
            </Columns>            
        </asp:GridView>
    </div>
    </asp:Content>