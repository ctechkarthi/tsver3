<%@ Page Title="" Language="C#" MasterPageFile="~/UserSite.Master" AutoEventWireup="true" CodeBehind="Expense.aspx.cs" Inherits="TSVer3.Expense" %>

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
            if (confirm("Do you want to Delete Expense ?")) {
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
                    <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="Expense Create/Edit/Delete" BorderWidth="100" Font-Bold="True" Height="120px">
                        <ContentTemplate>
                            <asp:PlaceHolder ID="PlaceHolder_New" runat="server"></asp:PlaceHolder>
                                       <table style="width:850px;">                                          
                                            <tr>
                                                <td colspan="11" style="text-align: center; font-weight: bold; color: green; font-size: 18px;">Job Expense Entry Form</td>
                                            </tr>  <tr>
                                                <td colspan="5" style="text-align:center;" >Category <asp:DropDownList ID="cmb_Category" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmb_Category_SelectedIndexChanged" > <asp:ListItem Value="---Select---">---Select---</asp:ListItem>
                                            <asp:ListItem Value="Air Export">Air Export</asp:ListItem>
                                            <asp:ListItem Value="Air Import">Air Import</asp:ListItem>
                                            <asp:ListItem Value="Sea Export">Sea Export</asp:ListItem>
                                            <asp:ListItem Value="Sea Import">Sea Import</asp:ListItem></asp:DropDownList>
                                        </td> </tr>
                                           <tr>
                                                <td>Job No </td>
                                                <td><asp:DropDownList ID="ddl_JobNo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_JobNo_SelectedIndexChanged"></asp:DropDownList><br /> <asp:TextBox ID="tbx_JobNo" runat="server"></asp:TextBox>
                                        </td>
                                            <td></td>
                                                <td>Customer</td>
                                                <td><asp:DropDownList ID="ddl_ClientName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_ClientName_SelectedIndexChanged">
                                        </asp:DropDownList><br /><asp:TextBox ID="tbx_ClientName" runat="server"></asp:TextBox></td>
                                            </tr>      
                                           <tr>
                                                <td>Date</td>
                                                <td><asp:TextBox ID="tbx_Date" runat="server"></asp:TextBox></td>
                                            <td></td>
                                                <td>BL/AWB</td>
                                                <td><asp:TextBox ID="tbx_AWB" runat="server"></asp:TextBox></td>
                                            </tr>                             
                                     </table>        
                             <table style="width:750px;">
                                <tr><td style="text-align:center; font-weight:bold;">Expense Name</td><td style="text-align:center; font-weight:bold;">Particulars</td><td></td><td style="text-align:center; font-weight:bold;">Amount</td></tr>
                                <tr><td>Custom Expenses</td><td><asp:TextBox ID="tbx_p_customs" runat="server"></asp:TextBox></td><td></td><td><asp:TextBox ID="tbx_a_customs" runat="server" Text="0" OnTextChanged="tbx_a_customs_TextChanged" ></asp:TextBox></td></tr>
                                <tr><td>EDI Charges</td><td><asp:TextBox ID="tbx_p_edi" runat="server"></asp:TextBox></td><td></td><td><asp:TextBox ID="tbx_a_edi" runat="server" Text="0" OnTextChanged="tbx_a_edi_TextChanged" ></asp:TextBox></td></tr>
                                <tr><td>ADC Charges</td><td><asp:TextBox ID="tbx_p_adc" runat="server"></asp:TextBox></td><td></td><td><asp:TextBox ID="tbx_a_adc" runat="server" Text="0" OnTextChanged="tbx_a_adc_TextChanged" ></asp:TextBox></td></tr>
                                <tr><td>Loading / Unloading</td><td><asp:TextBox ID="tbx_p_loading" runat="server"></asp:TextBox></td><td></td><td><asp:TextBox ID="tbx_a_loading" runat="server" Text="0" OnTextChanged="tbx_a_loading_TextChanged" ></asp:TextBox></td></tr>
                                <tr><td>Terminal Charges</td><td><asp:TextBox ID="tbx_p_terminal" runat="server"></asp:TextBox></td><td></td><td><asp:TextBox ID="tbx_a_terminal" runat="server" Text="0" OnTextChanged="tbx_a_terminal_TextChanged" ></asp:TextBox></td></tr>
                                <tr><td>Transport Charges</td><td><asp:TextBox ID="tbx_p_transport" runat="server"></asp:TextBox></td><td></td><td><asp:TextBox ID="tbx_a_transport" runat="server" Text="0" OnTextChanged="tbx_a_transport_TextChanged" ></asp:TextBox></td></tr>
                                <tr><td>AIR/SEA Freight</td><td><asp:TextBox ID="tbx_p_airfreight" runat="server"></asp:TextBox></td><td></td><td><asp:TextBox ID="tbx_a_airfreight" runat="server" Text="0" OnTextChanged="tbx_a_airfreight_TextChanged" ></asp:TextBox></td></tr>
                                <tr><td>FSC</td><td><asp:TextBox ID="tbx_p_fsc" runat="server"></asp:TextBox></td><td></td><td><asp:TextBox ID="tbx_a_fsc" runat="server" Text="0" OnTextChanged="tbx_a_fsc_TextChanged" ></asp:TextBox></td></tr>
                                <tr><td>SC</td><td><asp:TextBox ID="tbx_p_sc" runat="server"></asp:TextBox></td><td></td><td><asp:TextBox ID="tbx_a_sc" runat="server" Text="0" OnTextChanged="tbx_a_sc_TextChanged" ></asp:TextBox></td></tr>
                                <tr><td>MCC</td><td><asp:TextBox ID="tbx_p_mcc" runat="server"></asp:TextBox></td><td></td><td><asp:TextBox ID="tbx_a_mcc" runat="server" Text="0" OnTextChanged="tbx_a_mcc_TextChanged" ></asp:TextBox></td></tr>
                                <tr><td>X-RAY</td><td><asp:TextBox ID="tbx_p_xray" runat="server"></asp:TextBox></td><td></td><td><asp:TextBox ID="tbx_a_xray" runat="server" Text="0" OnTextChanged="tbx_a_xray_TextChanged" ></asp:TextBox></td></tr>
                                <tr><td>AMS</td><td><asp:TextBox ID="tbx_p_ams" runat="server"></asp:TextBox></td><td></td><td><asp:TextBox ID="tbx_a_ams" runat="server" Text="0" OnTextChanged="tbx_a_ams_TextChanged" ></asp:TextBox></td></tr>
                                <tr><td>DG Fee/DRY ICE Fee</td><td><asp:TextBox ID="tbx_p_dgfee" runat="server"></asp:TextBox></td><td></td><td><asp:TextBox ID="tbx_a_dgfee" runat="server" Text="0" OnTextChanged="tbx_a_dgfee_TextChanged" ></asp:TextBox></td></tr>
                                <tr><td>GSP/COO Charges</td><td><asp:TextBox ID="tbx_p_gsp" runat="server"></asp:TextBox></td><td></td><td><asp:TextBox ID="tbx_a_gsp" runat="server" Text="0" OnTextChanged="tbx_a_gsp_TextChanged" ></asp:TextBox></td></tr>
                                <tr><td>AWB + PCA</td><td><asp:TextBox ID="tbx_p_awb" runat="server"></asp:TextBox></td><td></td><td><asp:TextBox ID="tbx_a_awb" runat="server" Text="0" OnTextChanged="tbx_a_awb_TextChanged" ></asp:TextBox></td></tr>
                                <tr><td>MISC Charges</td><td><asp:TextBox ID="tbx_p_misc1" runat="server"></asp:TextBox></td><td></td><td><asp:TextBox ID="tbx_a_misc1" runat="server" Text="0" OnTextChanged="tbx_a_misc1_TextChanged" ></asp:TextBox></td></tr>
                                <tr><td>OT Charges</td><td><asp:TextBox ID="tbx_p_OT" runat="server"></asp:TextBox></td><td></td><td><asp:TextBox ID="tbx_a_OT" runat="server" Text="0" OnTextChanged="tbx_a_OT_TextChanged" ></asp:TextBox></td></tr>
                                <tr><td>Replacement</td><td><asp:TextBox ID="tbx_p_Replacement" runat="server"></asp:TextBox></td><td></td><td><asp:TextBox ID="tbx_a_Replacement" runat="server" Text="0" OnTextChanged="tbx_a_Replacement_TextChanged" ></asp:TextBox></td></tr>
                                <tr><td>Delivery Order</td><td><asp:TextBox ID="tbx_p_DO" runat="server"></asp:TextBox></td><td></td><td><asp:TextBox ID="tbx_a_DO" runat="server" Text="0" OnTextChanged="tbx_a_DO_TextChanged" ></asp:TextBox></td></tr>
                                <tr><td>IHC / LCL Charges</td><td><asp:TextBox ID="tbx_p_IHC" runat="server"></asp:TextBox></td><td></td><td><asp:TextBox ID="tbx_a_IHC" runat="server" Text="0" OnTextChanged="tbx_a_IHC_TextChanged" ></asp:TextBox></td></tr>
                                <tr><td>TSA Charges</td><td><asp:TextBox ID="tbx_p_TSA" runat="server"></asp:TextBox></td><td></td><td><asp:TextBox ID="tbx_a_TSA" runat="server" Text="0" OnTextChanged="tbx_a_TSA_TextChanged" ></asp:TextBox></td></tr>
                                <tr><td>Stuffing Charges</td><td><asp:TextBox ID="tbx_p_STUFFING" runat="server"></asp:TextBox></td><td></td><td><asp:TextBox ID="tbx_a_STUFFING" runat="server" Text="0" OnTextChanged="tbx_a_STUFFING_TextChanged" ></asp:TextBox></td></tr>
                                </table>                                
                                                               <table >                                                             
                                                            <tr>
                                                                <td style="width:850px;">
                                                                <asp:Button ID="Btn_ClearParti" runat="server" CssClass="button2" Text="Clear" OnClick="Btn_ClearParti_Click" />&nbsp;&nbsp;
                                                                 <asp:Button ID="Btn_Insert" runat="server" CssClass="button2" Text="Save" OnClick="Btn_Insert_Click" />&nbsp;&nbsp;
                                                                <asp:Button ID="Btn_Update" runat="server" CssClass="button2" Text="Upate" OnClick="Btn_Update_Click" Visible="False" />&nbsp;&nbsp;
                                                                <asp:Button ID="Btn_Delete" runat="server" CssClass="button2" Text="Delete" OnClick="Btn_Delete_Click" Visible="False"  OnClientClick="Confirm()"  />&nbsp;&nbsp;<asp:ImageButton ID="ImBtn_PDF" runat="server" ImageUrl="~/images/PDF.jpg" OnClick="ImBtn_PDF_Click" ToolTip="Click Here to Generate Invoice!" Visible="False"  Width="40px"></asp:ImageButton>&nbsp;&nbsp;
                                                                Total Expense is: <asp:Label ID="lbl_total" Font-Bold="True" runat="server" Text="0"></asp:Label>&nbsp;&nbsp;
                                                                <asp:Label ID="lbl_Status" Font-Bold="True" runat="server"></asp:Label>
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

