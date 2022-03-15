<%@ Page Title="Tracksen" Language="C#" MasterPageFile="~/UserSite.Master" AutoEventWireup="true" CodeBehind="InvoiceChanges.aspx.cs" Inherits="TSVer3.InvoiceChanges" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <link rel="stylesheet" href="Styles/Tab.css" type="text/css" media="all" />
   <script type="text/javascript">
       function UpdateConfirm() {
           var confirm_value = document.createElement("INPUT");
           confirm_value.type = "hidden";
           confirm_value.name = "confirm_valueUpdate";
           if (confirm("Do you want to Update Invoice/Bill No. ?")) {
               confirm_value.value = "Yes";
           } else {
               confirm_value.value = "No";
           }
           document.forms[0].appendChild(confirm_value);
       }
    </script>
<script type="text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to Delete Job/Invoice ?")) {
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
                <asp:TabContainer ID="TC_Conversion" runat="server" Visible="true" Width="950px">
                    <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="Change Invoiceo." BorderWidth="100" Font-Bold="True" Height="120px">
                        <ContentTemplate>
                            <asp:PlaceHolder ID="PlaceHolder_Edit" runat="server"></asp:PlaceHolder>
                            <table>
                                <tr>
                                    <td>Type<asp:Label ID="Label3" runat="server" Text="*" ForeColor="#CC0000"></asp:Label>
                                    </td>
                                    <td width="20px"></td>
                                    <td>
                                        <asp:DropDownList ID="ddl_Type" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_Type_SelectedIndexChanged" >
                                       <asp:ListItem>---Select---</asp:ListItem>
                                            <asp:ListItem>Update</asp:ListItem>
                                            <asp:ListItem>Delete</asp:ListItem>
                                             </asp:DropDownList>
                                    </td>
                                    <td width="20px"></td>
                                    <td>Month<asp:Label ID="Label26" runat="server" Text="*" ForeColor="#CC0000"></asp:Label>
                                    </td>
                                    <td width="20px"></td>
                                    <td>
                                        <asp:DropDownList ID="ddl_Month" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_Month_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td width="20px"></td>
                                    <td>Bill No.<asp:Label ID="Label23" runat="server" Text="*" ForeColor="#CC0000"></asp:Label>
                                    </td>
                                    <td width="15px"></td>
                                    <td>
                                        <asp:DropDownList ID="ddl_BillNo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_BillNo_SelectedIndexChanged"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                <td>Job No.</td><td> </td><td>
                                    <asp:Label ID="lbl_JobNo" runat="server"></asp:Label></td> <td></td><td>To</td>
                                    <td></td>
                                    <td>
                                        <asp:Label ID="lbl_InvTo" runat="server"></asp:Label></td>
                                    <td></td>
                                    <td>Date</td>
                                    <td></td>
                                    <td>
                                        <asp:Label ID="lbl_InvDate" runat="server"></asp:Label></td>
                                </tr>
                                <tr id="tr_InvNo" runat="server">
                                    <td style="text-align:center" colspan="11">
                                       New Invoice No.<asp:TextBox ID="tbx_NewInvNo" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:center" colspan="11">
                                        <asp:Button ID="Btn_Update" runat="server" OnClick="Btn_Update_Click" OnClientClick="UpdateConfirm()" Text="Update" Visible="False"></asp:Button>
                                       <asp:Button ID="Btn_Delete" runat="server" OnClick="Btn_Delete_Click" OnClientClick="Confirm()" Text="Delete" Visible="False"></asp:Button>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:center" colspan="11">
                                        <asp:Label ID="lbl_Status" runat="server" Font-Bold="True"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:TabPanel>
                </asp:TabContainer></td>
        </tr>
    </table>
    <br />
</asp:Content>
