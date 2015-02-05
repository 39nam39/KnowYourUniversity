<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="StudentHome.aspx.cs" Inherits="FinalWebApplication.Home" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1>Student Home</h1>
            </hgroup>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">    
    
    <asp:Table runat="server">
        <asp:TableRow>
            <asp:TableCell><h3>Select the Univeristy</h3></asp:TableCell>
            <asp:TableCell><asp:DropDownList runat="server" ID="univListDD" OnSelectedIndexChanged="univListDD_SelectedIndexChanged"></asp:DropDownList></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label runat="server" ID="lblFindNearest" Text="Find Nearest Store" Visible="true"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:TextBox runat="server" ID="txtSearchTerm" Visible="true"></asp:TextBox></asp:TableCell>
            <asp:TableCell><asp:Button runat="server" ID="btnSearch" Text="Search" OnClick="btnSearch_Click" Visible="true"/></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label runat="server" Text="Upload SOP"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:FileUpload ID="FileUpload" runat="server"/></asp:TableCell>
            <asp:TableCell><asp:Button runat="server" ID="btnUpload" OnClick="btnUpload_Click" Text="Upload SOP"/></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>         
            <asp:TableCell><asp:Label runat="server" ID="lblErrorMessage" Visible="false"></asp:Label></asp:TableCell>          
        </asp:TableRow>
    </asp:Table>        
    <br />
    <asp:Table runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="lblUplRes" visible="true" Text="File Location"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server"  Width="750px" ID="txtFileLoc" Enabled="false" Text=""></asp:TextBox> 
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br />

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
