<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Registration.aspx.cs" Inherits="FinalWebApplication.Registration" EnableViewStateMac="false"%>
<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1>Registration</h1>
            </hgroup>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div>
        <br />
        <asp:Table runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:ListBox ID="lstBox" runat="server"></asp:ListBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="First Name"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="txtfName"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Last Name"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="txtlName"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="User Name"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="txtuName"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table><br />
        <asp:Label ID="Label1" runat="server" Text="Site Key"></asp:Label>
        <asp:Table runat="server" ID="tblSiteKey">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:ImageButton runat="server" ID="img_site1" OnClick="img_site1_Click"/> &nbsp &nbsp &nbsp
                    <asp:ImageButton runat="server" ID="img_site2" OnClick="img_site2_Click"/> &nbsp &nbsp &nbsp
                    <asp:ImageButton runat="server" ID="img_site3" OnClick="img_site3_Click"/> &nbsp &nbsp &nbsp
                    <asp:ImageButton runat="server" ID="img_site4" OnClick="img_site4_Click"/> &nbsp &nbsp &nbsp
                    <asp:ImageButton runat="server" ID="img_site5" OnClick="img_site5_Click"/> &nbsp &nbsp &nbsp
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label2" runat="server" Text="Site Key Phrase"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="txtSiteKey"></asp:TextBox> 
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Table runat="server">            
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Password"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="txtPassword" TextMode="Password"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Repeat Password"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="txtRPassword" TextMode="Password"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="User Type"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RadioButtonList runat="server" ID="rbTypeUser">
                        <asp:ListItem Selected="True" Text="Student" Value="Student_User"></asp:ListItem>
                        <asp:ListItem Selected="False" Text="Visiting Scholar" Value ="Scholar_User"></asp:ListItem>
                    </asp:RadioButtonList>
                </asp:TableCell>
            </asp:TableRow>
            <%--<asp:TableRow>
                <asp:TableCell>
                    <recaptcha:RecaptchaControl ID="recaptcha" runat="server" PublicKey="6LescfISAAAAAKnB81ds14RV_6_XoZgdQ-IZ6q_T" PrivateKey="6LescfISAAAAABQHfJ7X5uQHY_KzglzJZLZ8D2mn" />
                </asp:TableCell>
            </asp:TableRow>--%>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:TextBox ID="txtCaptcha" runat="server" BackColor="#FFFFCC" Font-Bold="False" Font-Italic="True" Font-Names="Jokerman" Font-Size="Large" Height="42px" ReadOnly="True" Width="177px" Enabled="false"></asp:TextBox>
                </asp:TableCell>                
                <asp:TableCell>
                    <asp:Button ID="btnCaptcha" runat="server" Font-Size="Large" OnClick="btnCaptcha_Click" Text="Refresh" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="txtEnteredCaptcha"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>        
        <asp:Label runat="server" ID="lblResult" Visible="false"></asp:Label>
        <br />
        <asp:Button runat="server" ID="btnRegister" Text="Register" OnClick="btnRegister_Click"/>
    </div>
</asp:Content>
