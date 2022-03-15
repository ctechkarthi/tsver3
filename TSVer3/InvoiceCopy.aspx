<%@ Page Title="" Language="C#" MasterPageFile="~/UserSite.Master" AutoEventWireup="true" CodeBehind="InvoiceCopy.aspx.cs" Inherits="TSVer3.InvoiceCopy" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="Styles/Tab.css" type="text/css" media="all" />

    <script language="javascript" type="text/javascript">
        var oldgridcolor;
        function SetMouseOver(element) {
            oldgridcolor = element.style.backgroundColor;
            element.style.backgroundColor = '#dbddff';
            element.style.cursor = 'pointer';
        }
        function SetMouseOut(element) {
            element.style.backgroundColor = oldgridcolor;
        }
    </script>
    <script type="text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to Delete Invoice ?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
    <script>
        function openFile(fileName) {
            window.open(fileName, '_blank');
        }
    </script>
    <script type="text/javascript">
        function toUpper(txt) {
            document.getElementById(txt).value = document.getElementById(txt).value.toUpperCase();
            return true;
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <table>
        <tr>
            <td width="10px"></td>
            <td>
                <asp:TabContainer ID="TC_Conversion" runat="server" Visible="true" Width="950px">
                    <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="Invoice Copy" BorderWidth="100" Font-Bold="True" Height="120px">
                        <ContentTemplate>
                            <asp:PlaceHolder ID="PlaceHolder_New" runat="server"></asp:PlaceHolder>
                            <table>
                                <tr>
                                    <td colspan="11" style="text-align: center; font-weight: bold; color: green; font-size: 18px;">Existing Invoice</td>
                                </tr>
                                <tr>
                                    <td>Category
                                    </td>
                                    <td width="20px"></td>
                                    <td style="width: 180px">
                                        <asp:DropDownList ID="ddl_Category" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_Category_SelectedIndexChanged" >
                                            <asp:ListItem Value="---Select---">---Select---</asp:ListItem>
                                            <asp:ListItem Value="Air Export">Air Export</asp:ListItem>
                                            <asp:ListItem Value="Air Import">Air Import</asp:ListItem>
                                            <asp:ListItem Value="Sea Export">Sea Export</asp:ListItem>
                                            <asp:ListItem Value="Sea Import">Sea Import</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td width="15px"></td>
                                    <td>Bill No.
                                    </td>
                                    <td></td>
                                    <td>
                                        <asp:DropDownList ID="ddl_BillNo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_BillNo_SelectedIndexChanged" >
                                        </asp:DropDownList>
                                    </td>
                                    <td></td>
                                    <td valign="top">Job No
                                    </td>
                                    <td></td>
                                    <td valign="top">
                                        <asp:Label ID="lbl_JobNo" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Bill Date
                                    </td>
                                    <td></td>
                                    <td>
                                        <asp:Label ID="lbl_BillDate" runat="server"></asp:Label>
                                    </td><td></td>
                                    <td valign="top">Month
                                    </td>
                                    <td></td>
                                    <td valign="top">
                                        <asp:Label ID="lbl_Month" runat="server" ></asp:Label>
                                    </td>
                                    <td></td>                                    
                                    <td>Customer
                                    </td>
                                    <td></td>
                                    <td>
                                             <asp:Label ID="lbl_Customer" runat="server" ></asp:Label>   
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td colspan="11" style="text-align: center; font-weight: bold; color: green; font-size: 18px;">New Invoice</td>
                                </tr>
                                <tr><td>New Job No.
                                        <asp:Label ID="Label1" runat="server" Text="*" ForeColor="#CC0000"></asp:Label>
                                    </td>
                                    <td></td>
                                    <td>
                                        <asp:Label ID="lbl_NewJobNo" runat="server"></asp:Label>                                   
                                    </td>
                                    <td width="15px"></td>
                                    <td>New Bill No.
                                        <asp:Label ID="Label2" runat="server" Text="*" ForeColor="#CC0000"></asp:Label>
                                    </td>
                                    <td></td>
                                    <td>
                                        <asp:TextBox ID="tbx_NewBillNo" runat="server" AutoPostBack="true" OnTextChanged="tbx_NewBillNo_TextChanged"></asp:TextBox>                                   
                                    </td>
                                    <td width="15px"></td>
                                </tr>
                                <tr>
                                    <td colspan="11" align="center">
                                        <asp:Button ID="Btn_Clear" runat="server" OnClick="Btn_Clear_Click" Text="Clear" ToolTip="Click Here!"></asp:Button>
                                        &nbsp;&nbsp;
                                        <asp:Button ID="Btn_Insert" runat="server" OnClick="Btn_Insert_Click" Text="Save" Visible="false"></asp:Button>
                                        <asp:Label ID="lbl_Status" runat="server" Font-Bold="True"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:TabPanel>
                </asp:TabContainer>
                <br />
            </td>
        </tr>
    </table>
</asp:Content>
