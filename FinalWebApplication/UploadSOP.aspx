<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="UploadSOP.aspx.cs" Inherits="FinalWebApplication.UploadSOP" EnableViewStateMac="false"%>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1>Upload Your Statement of Purpose below (Max Size 3Mb)</h1>
            </hgroup>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">    
    <div>
        <asp:FileUpload runat="server" ID="fileUploadWindow" />
        <asp:Button runat="server" ID="uploadSOPBtn" OnClick="uploadSOPBtn_Click" Text="Upload SOP" />
        <br /><br />
    </div>
    <div>
        <asp:Label runat="server" ID="lblMessage" Text="Uploaded Successfully" Visible="false"></asp:Label>
        <br />
    </div>
    <div>
        <br />        
    <asp:LinkButton runat="server" ID="linkDownloadBtn" OnClick="linkDownloadBtn_Click">Click for File Location</asp:LinkButton>
        <br />
        <asp:TextBox runat="server" ID="UploadedFileName" Width="100%" Visible="false" ReadOnly="true"></asp:TextBox>
    </div>
</asp:Content>
