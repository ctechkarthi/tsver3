<%@ Page Title="Tracksen" Language="C#" MasterPageFile="~/UserSite1.Master" AutoEventWireup="true" CodeBehind="WebHome.aspx.cs" Inherits="TSVer3.WebHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
    <meta http-equiv="refresh" content="60">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <div style="margin-left: 15px; color: #000000; font-family: verdana; font-size: 12px;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td valign="top">
                        <br />
                        Company Name:&nbsp;&nbsp;
                        <asp:Label ID="lbl_CompName" runat="server"></asp:Label><br />
                        Name:&nbsp;&nbsp;
                        <asp:Label ID="lbl_UserName" runat="server"></asp:Label><br />
                        Login User Name:&nbsp;&nbsp;
                        <asp:Label ID="lbl_LoginUserName" runat="server"></asp:Label><br />
                        Login Time:&nbsp;&nbsp;
                        <asp:Label ID="lbl_LoginTime" runat="server"></asp:Label><br /><br />
                        Browser Capabilities Type:&nbsp;&nbsp;
                        <asp:Label ID="lbl_BType" runat="server"></asp:Label><br />
                        Browser Name:&nbsp;&nbsp;
                        <asp:Label ID="lbl_BName" runat="server"></asp:Label><br />
                        Browser Version:&nbsp;&nbsp;
                        <asp:Label ID="lbl_BVersion" runat="server"></asp:Label><br />
                        IP Address:&nbsp;&nbsp;
                        <asp:Label ID="lbl_IpAddress" runat="server"></asp:Label><br />
                    </td>                  <td style="width:50px;"></td>  
                    <td> <asp:Label ID="lbl_Validity" runat="server" Font-Size="Large" ForeColor="Green" ></asp:Label> <asp:Label ID="lbl_Validity_R" runat="server" Font-Size="XX-Large" ForeColor="Red" ></asp:Label></td>
              </tr></table></div>
</asp:Content>
