<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DateTime.ascx.cs" Inherits="FinalWebApplication.DateTimeUserControl" %>
<%@ OutputCache duration="10" varybyparam="None" %>

<asp:Table runat="server">
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label runat="server" ID="lblDay">&nbsp;</asp:Label><asp:Label runat="server" ID="lblTime"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label runat="server" ID="lblTerm"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
