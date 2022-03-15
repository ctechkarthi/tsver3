<%@ Page Title="Login" Language="C#" MasterPageFile="~/UserSite.Master" AutoEventWireup="true" CodeBehind="LoginDetails.aspx.cs" Inherits="TSVer3.LoginDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="Styles/Tab.css" type="text/css" media="all" />
    <script type="text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to Change Passsword ?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <td width="10px"></td>
            <td>
                 <asp:TabContainer ID="TabContainer1" runat="server" Width="950px" >
        <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="Change Password" >
            <ContentTemplate>
                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                <br />
                <table>
                    <tr>
                        <td width="20px"></td>
                        <td>New Password:
                                                <asp:Label ID="Label43" runat="server" ForeColor="Red" Text="*"></asp:Label> </td>
                        <td width="15px"></td>
                        <td>
                            <asp:TextBox ID="tbx_NewPassword1" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td ></td>
                        <td>Confirm New Password:
                                                <asp:Label ID="Label11" runat="server" ForeColor="Red" Text="*"></asp:Label> </td>
                        <td ></td>
                        <td>
                            <asp:TextBox ID="tbx_NewPassword2" runat="server" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" ></td>
                        <td>
                            <asp:Button ID="Btn_Update" runat="server" Text="Update" OnClientClick="Confirm()" OnClick="Btn_Update_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" ></td>
                        <td>
                            <asp:Label ID="lbl_Status" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                </table>Note: If you want any changes in Company/Contact Name,Email please contact our team.
            </ContentTemplate>
        </asp:TabPanel>
    </asp:TabContainer>
                 </td>
        </tr>
    </table>
    <br />
</asp:Content>
