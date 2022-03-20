<%@ Page Title="Tracksen" Language="C#" MasterPageFile="~/UserSite.Master" AutoEventWireup="true" CodeBehind="GeneralInvoice4.aspx.cs" Inherits="TSVer3.GeneralInvoice4" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="Styles/Tab.css" type="text/css" media="all" />
    <link href="test/CSS/CSS.css" rel="stylesheet" type="text/css" />
    <script src="test/scripts/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="test/scripts/jquery.blockUI.js" type="text/javascript"></script>

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
        function ConfirmIRN() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to Generate IRN ?")) {
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
     <style>
        input[type=text] {
            border: 1px solid #AAA;
            box-shadow: 0px 0px 3px #CCC, 0px 8px 13px #EEE inset;
            border-radius: 5px;
            padding-right: 5px;
            padding-left: 5px;
            transition: padding 0.25s ease 0s;
            height: 20px;
            width: 180px;
            margin: 1px;
        }

            input[type=text]:focus {
                box-shadow: 0 0 5px rgba(81, 203, 238, 1);
                padding: 3px 0px 3px 3px;
                margin: 5px 1px 3px 0px;
                border: 1px solid rgba(81, 203, 238, 1);
                border-radius: 5px;
                padding-right: 5px;
                padding-left: 5px;
                transition: padding 0.25s ease 0s;
                height: 20px;
                width: 180px;
                margin: 1px;
            }
    </style>
    
    <style type="text/css"> 
        .headertext {
            font-size: 20px;
            color: #f19a19;
            font-weight: bold;
        }
        .TextCenter {
            text-align: center;
        }
        .modalBackground {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }
        .modalPopup1 {
            background-color: #fff;
            border: 3px solid #ccc;
            padding: 10px;
            width: 850px;
        }
        .scroll-top-wrapper {
            position: fixed;
            opacity: 0;
            visibility: hidden;
            overflow: hidden;
            text-align: center;
            z-index: 99999999;
            background-color: #777777;
            color: #eeeeee;
            width: 50px;
            height: 48px;
            line-height: 48px;
            right: 30px;
            bottom: 30px;
            padding-top: 2px;
            border-top-left-radius: 10px;
            border-top-right-radius: 10px;
            border-bottom-right-radius: 10px;
            border-bottom-left-radius: 10px;
            -webkit-transition: all 0.5s ease-in-out;
            -moz-transition: all 0.5s ease-in-out;
            -ms-transition: all 0.5s ease-in-out;
            -o-transition: all 0.5s ease-in-out;
            transition: all 0.5s ease-in-out;
        }
            .scroll-top-wrapper:hover {
                background-color: #888888;
            }
            .scroll-top-wrapper.show {
                visibility: visible;
                cursor: pointer;
                opacity: 1.0;
            }
            .scroll-top-wrapper i.fa {
                line-height: inherit;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <td width="10px"></td>
            <td>
                <asp:TabContainer ID="TC_Conversion" runat="server" Visible="true" Width="950px">
                    <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="Invoice" BorderWidth="100" Font-Bold="True" Height="120px">
                        <ContentTemplate>
                            <asp:PlaceHolder ID="PlaceHolder_New" runat="server"></asp:PlaceHolder>
                            <table>
                                <tr>
                                    <td colspan="11" style="text-align: center; font-weight: bold; color: green; font-size: 18px;">Customer Invoice Entry Form  - Category - 
                                        <asp:DropDownList ID="ddl_Category" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_Category_SelectedIndexChanged">
                                            <asp:ListItem Value="---Select---">---Select---</asp:ListItem>
                                            <asp:ListItem Value="Air Export">Air Export</asp:ListItem>
                                            <asp:ListItem Value="Air Import">Air Import</asp:ListItem>
                                            <asp:ListItem Value="Sea Export">Sea Export</asp:ListItem>
                                            <asp:ListItem Value="Sea Import">Sea Import</asp:ListItem>
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td>Job No.
                                    </td>
                                    <td width="20px"></td>
                                    <td style="width: 180px">
                                        <asp:DropDownList ID="ddl_JobNo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_JobNo_SelectedIndexChanged1" >
                                        </asp:DropDownList>
                                    </td>
                                    <td width="15px"></td>
                                    <td>Job No.
                                        <asp:Label ID="Label21" runat="server" Text="*" ForeColor="#CC0000"></asp:Label>
                                    </td>
                                    <td></td>
                                    <td>
                                        <asp:TextBox ID="tbx_JobNo" runat="server"></asp:TextBox>
                                    </td>
                                    <td width="15px"></td>
                                    <td>Bill No
                                        <asp:Label ID="Label5" runat="server" Text="*" ForeColor="#CC0000"></asp:Label>
                                    </td>
                                    <td></td>
                                    <td>
                                        <asp:TextBox ID="tbx_BillNo" runat="server"></asp:TextBox>
                                   </td>
                                </tr>
                                <tr>
                                    <td>Custommer
                                        <asp:Label ID="Label22" runat="server" Text="*" ForeColor="#CC0000"></asp:Label>
                                    </td>
                                    <td></td>
                                    <td>
                                        <asp:DropDownList ID="ddl_ClientName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_ClientName_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td></td>
                                    <td valign="top">Date
                                        <asp:Label ID="Label1" runat="server" Text="*" ForeColor="#CC0000"></asp:Label>
                                    </td>
                                    <td></td>
                                    <td valign="top">
                                        <asp:TextBox ID="tbx_BillDate" runat="server" OnTextChanged="tbx_BillDate_TextChanged" AutoPostBack="True" AutoCompleteType="Disabled"></asp:TextBox>
                                      <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" TargetControlID="tbx_BillDate" Format="dd-MMM-yyyy"></asp:CalendarExtender>
                                      </td>
                                    <td></td>
                                    <td valign="top">Month
                                    </td>
                                    <td></td>
                                    <td valign="top">
                                        <asp:Label ID="lbl_Month" runat="server"></asp:Label>
                                       </td>
                                </tr>
                                <tr>
                                    <td><asp:LinkButton ID="LBtn_Guarantee" runat="server" ToolTip="Click here to add Guarantee Name!">Guarantee Name</asp:LinkButton>
                                      </td>
                                    <td></td>
                                    <td>
                                        <asp:TextBox ID="tbx_InvToL1" runat="server"></asp:TextBox><br />
                                        <asp:TextBox ID="tbx_InvToL2" runat="server" Font-Size="12px"></asp:TextBox><br />
                                        <asp:TextBox ID="tbx_InvToL3" runat="server" Font-Size="12px"></asp:TextBox><br />
                                        <asp:TextBox ID="tbx_InvToL4" runat="server" Font-Size="12px"></asp:TextBox><br />
                                        <asp:TextBox ID="tbx_InvToL5" runat="server" Font-Size="12px"></asp:TextBox>
                                    </td>
                                    <td></td>
                                    <td valign="top">GST<br />
                                        State<br />.<br />
                                        Line/Vessel<br />
                                    </td>
                                    <td></td>
                                    <td valign="top">
                                        <asp:TextBox ID="tbx_GSTNoCust" runat="server" ToolTip="You can't edit here!"></asp:TextBox><br />
                                        <asp:TextBox ID="tbx_StateCust" runat="server" ToolTip="You can't edit here!" placeholder="State Name" Width="120px"></asp:TextBox>
                                        <asp:TextBox ID="tbx_StateCodeCust" runat="server" ToolTip="You can't edit here!" placeholder="Ex: 29" Width="42px"></asp:TextBox><br />
                                        <asp:TextBox ID="tbx_Line" runat="server" placeholder="Shipping/Airline"></asp:TextBox><br />
                                    </td>
                                    <td></td>
                                    <td valign="top">MBL/AWB<br />
                                        HBL/AWB<br />
                                        BE/SB No.<br />.<br />
                                        BE/SB Date
                                    </td>
                                    <td></td>
                                    <td valign="top">
                                        <asp:TextBox ID="tbx_AWB_No" runat="server" placeholder="MAWB/MBL" AutoCompleteType="Disabled"></asp:TextBox><br />
                                        <asp:TextBox ID="tbx_HAWB_No" runat="server" placeholder="HAWB/HBL" AutoCompleteType="Disabled"></asp:TextBox><br />
                                        <asp:TextBox ID="tbx_SBNo" runat="server" placeholder="SB No." AutoCompleteType="Disabled"></asp:TextBox><br />
                                        <asp:TextBox ID="tbx_SBDate" runat="server" placeholder="SB Date" AutoCompleteType="Disabled"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Origin/POL
                                    </td>
                                    <td></td>
                                    <td>
                                        <asp:TextBox ID="tbx_Origin" runat="server"></asp:TextBox>
                                    </td>
                                    <td></td>
                                    <td>Dest/POD
                                    </td>
                                    <td></td>
                                    <td>
                                        <asp:TextBox ID="tbx_Dest" runat="server"></asp:TextBox>
                                    </td>
                                    <td></td>
                                    <td>Gr Weight</td>
                                    <td></td>
                                    <td>
                                        <asp:TextBox ID="tbx_GW" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Ch Wt/Volume</td>
                                    <td></td>
                                    <td>
                                        <asp:TextBox ID="tbx_Volume" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                                    </td>
                                    <td></td>
                                    <td>Pkgs</td>
                                    <td></td>
                                    <td>
                                        <asp:TextBox ID="tbx_Pkgs" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                                    </td>
                                    <td></td>
                                    <td>EGM/IGM</td>
                                    <td></td>
                                    <td>
                                        <asp:TextBox ID="tbx_EGM" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>CBM</td>
                                    <td></td>
                                    <td>
                                        <asp:TextBox ID="tbx_CBM" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                                    </td>
                                    <td></td>
                                    <td>Shipper Inv.</td>
                                    <td></td>
                                    <td>
                                        <asp:TextBox ID="tbx_ShInvoice" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                                    </td>
                                    <td></td>
                                    <td>Currency</td>
                                    <td></td>
                                    <td>
                                         <asp:DropDownList ID="ddl_CurrencyType" runat="server" Width="128px">
                                            <asp:ListItem Value="INR">Indian Rupees</asp:ListItem>
                                            <asp:ListItem Value="USD">US Dollar</asp:ListItem>
                                            <asp:ListItem Value="EUR">EURO</asp:ListItem>
                                            <asp:ListItem Value="AUD">Australian Dollar</asp:ListItem>
                                            <asp:ListItem Value="CAD">Canadian Dollar</asp:ListItem>
                                            <asp:ListItem Value="SGD">Singapore Dollar</asp:ListItem>
                                            <asp:ListItem Value="JPY">Japanese Yen</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:TextBox ID="tbx_CurrValue" runat="server" Text="1" Width="42px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Shipper/Consignee</td>
                                    <td></td>
                                    <td>
                                        <asp:DropDownList ID="ddl_Shipper" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_Shipper_SelectedIndexChanged">
                                        </asp:DropDownList><br />
                                        <asp:TextBox ID="tbx_Shipper" runat="server" onkeyup="return toUpper(this.id)"></asp:TextBox>
                                    </td>
                                    <td></td>
                                     <td>Advance</td>
                                    <td></td>
                                    <td>
                                        <asp:TextBox ID="tbx_Advance" runat="server" onkeyup="return toUpper(this.id)" Text="0" ></asp:TextBox>
                                    </td><td></td> <td width="90px">Sales Rep</td>
                                    <td></td>
                                    <td>
                                        <asp:DropDownList ID="ddl_SalesRep" runat="server" Width="150px">
                                        <asp:ListItem >BRANCH</asp:ListItem>
                                        <asp:ListItem >NOMINATION</asp:ListItem>
                                        <asp:ListItem >Raghu</asp:ListItem>
                                        <asp:ListItem >Victor</asp:ListItem>
                                        <asp:ListItem >Sridhar</asp:ListItem>
                                        <asp:ListItem >Somashekar</asp:ListItem>
                                        <asp:ListItem >Madhu</asp:ListItem>
                                        <asp:ListItem >Veeresh</asp:ListItem>
                                        <asp:ListItem >Theerthesha</asp:ListItem>
                                        <asp:ListItem >GuruPrased</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="11" style="text-align: center; color: red; text-decoration: underline;">Particulars with amount</td>
                                </tr>
                                <tr>
                                    <td colspan="11">
                                        <asp:GridView ID="GrdInvoice" runat="server" AutoGenerateColumns="False" DataKeyNames="Id,Particulars"
                                            OnRowEditing="GrdInvoice_RowEditing" OnRowUpdating="GrdInvoice_RowUpdating"
                                            OnRowCancelingEdit="GrdInvoice_RowCancelingEdit" OnRowDataBound="GrdInvoice_RowDataBound" OnPageIndexChanging="GrdInvoice_PageIndexChanging" 
                                            OnRowDeleting="GrdInvoice_RowDeleting" ForeColor="#333333" CellPadding="6" 
                                            PageSize="100" ShowHeaderWhenEmpty="True" ShowFooter="True" >
                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        S.No                                                    
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>.                                                    
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ID">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Particulars">
                                                    <EditItemTemplate>
                                                        <asp:DropDownList ID="cmbParticulars" runat="server" DataTextField="Particulars"
                                                            DataValueField="Particulars" Width="280px">
                                                        </asp:DropDownList>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblParticulars" runat="server" Text='<%# Eval("Particulars") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:DropDownList ID="cmbParticulars_I" runat="server" DataTextField="Particulars"
                                                            DataValueField="Particulars" Width="280px">
                                                        </asp:DropDownList>
                                                    </FooterTemplate>
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Additional">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtAdditionalInfo" runat="server" Width="100px" Text='<%# Bind("Additional") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAdditionalInfo" runat="server" Text='<%# Bind("Additional") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txt_AdditionalInfo" runat="server" Width="100px"></asp:TextBox>
                                                    </FooterTemplate>
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Non-Tax Amt">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtNonTaxAmt" runat="server" Width="70px" Text='<%# Bind("NonTaxAmt") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblNonTaxAmt" runat="server" Text='<%# Bind("NonTaxAmt") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txt_NonTaxAmt" runat="server" Width="70px" Text="0.00"></asp:TextBox>
                                                    </FooterTemplate>
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Tax Amt">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtTaxAmt" runat="server" Width="70px" Text='<%# Bind("TaxAmt") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTaxAmt" runat="server" Text='<%# Bind("TaxAmt") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txt_TaxAmt" runat="server" Width="70px" Text="0.00"></asp:TextBox>
                                                    </FooterTemplate>
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:CommandField ShowEditButton="True" ShowHeader="True" HeaderText="Edit" />
                                                <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ShowHeader="True" />
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="Add" CommandName="Footer" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                             <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                             <EditRowStyle BackColor="#999999" />
                                            <EmptyDataRowStyle BackColor="LightBlue" ForeColor="Red" />
                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Left" />
                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr> <td colspan="5">
                                                             <asp:Label ID="lbl_POP_Result" Font-Bold="True" runat="server"></asp:Label><asp:Label ID="lblId" Visible="False" runat="server"></asp:Label><asp:Label ID="lbl_HSN" Visible="False" runat="server"></asp:Label>
                                  </td>
                                </tr>
                                <tr>
                                    <td>Total Tax
                                    </td>
                                    <td></td>
                                    <td>
                                        <asp:TextBox ID="tbx_TotalTax" runat="server" ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td></td>
                                    <td>Total Non-Tax
                                    </td>
                                    <td></td>
                                    <td>
                                        <asp:TextBox ID="tbx_TotalNonTax" runat="server" ReadOnly="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>IGST
                                    </td>
                                    <td></td>
                                    <td>
                                        <asp:TextBox ID="tbx_IGST_Total" runat="server" ReadOnly="True" ToolTip="You can't edit here!"></asp:TextBox>
                                    </td>
                                    <td></td>
                                    <td>CGST/SGST
                                    </td>
                                    <td></td>
                                    <td>
                                        <asp:TextBox ID="tbx_SGST_Total" runat="server" ReadOnly="True" ToolTip="You can't edit here!"></asp:TextBox>
                                    </td>
                                    <td></td>
                                    <td>Total</td>
                                    <td></td>
                                    <td>
                                        <asp:TextBox ID="tbx_TotalAmt" runat="server" Width="80px"></asp:TextBox><asp:TextBox ID="tbx_GrandTotal" Font-Bold="True" runat="server" Width="80px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="11" align="center">
                                        <asp:Button ID="Btn_Clear" runat="server" OnClick="Btn_Clear_Click" Text="Clear" ToolTip="Click Here!"></asp:Button>
                                         &nbsp;&nbsp;
                                        <asp:Button ID="Btn_Save" runat="server" Text="Save" ToolTip="Click Here!" Visible="False" OnClick="Btn_Save_Click"></asp:Button>&nbsp;&nbsp;
                                         <asp:Button ID="Btn_IRN" runat="server" OnClientClick="ConfirmIRN()" Text="Generate IRN" ToolTip="Click Here!" Visible="False" OnClick="Btn_IRN_Click"></asp:Button>&nbsp;&nbsp;
                                        <asp:Button ID="Btn_Delete" runat="server" OnClick="Btn_Delete_Click" OnClientClick="Confirm()" Text="Delete" ToolTip="Click Here!" Visible="False"></asp:Button>&nbsp;&nbsp;
                                       <asp:DropDownList ID="ddl_BankName" runat="server" >
                                            <asp:ListItem Value="HDFC Bank - INR">HDFC Bank - INR</asp:ListItem>
                                            <asp:ListItem Value="HDFC Bank - USD">HDFC Bank - USD</asp:ListItem>
                                            <asp:ListItem Value="IDBI Bank">IDBI Bank</asp:ListItem>
                                            <asp:ListItem Value="ICICI Bank">ICICI Bank</asp:ListItem>
                                            <asp:ListItem Value="YES Bank">YES Bank</asp:ListItem>
                                         </asp:DropDownList> &nbsp;&nbsp;
                                           <asp:DropDownList ID="ddl_Signature" runat="server" Width="150px">
                                            <asp:ListItem Value="E-Signature">E-Signature</asp:ListItem>
                                            <asp:ListItem Value="Without Signature">Without Signature</asp:ListItem>
                                            <asp:ListItem Value="Manual Signature">Manual Signature</asp:ListItem>
                                        </asp:DropDownList> &nbsp;&nbsp;
                                        <asp:ImageButton ID="ImBtn_PDF" runat="server" ImageUrl="~/images/PDF.jpg" OnClick="ImBtn_PDF_Click" ToolTip="Click Here to Generate Invoice!" Visible="False" Width="40px"></asp:ImageButton>
                                        <asp:Label ID="lbl_Status" runat="server" Font-Bold="True"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                                 <!-- ModalPopupExtender -->
                                    <asp:ModalPopupExtender ID="MP_Guarantee" runat="server" BackgroundCssClass="modalBackground" CancelControlID="IBtn_Close" DynamicServicePath="" Enabled="True" PopupControlID="Panel1" TargetControlID="LBtn_Guarantee">
                            </asp:ModalPopupExtender>
                                    <asp:Panel ID="Panel1" runat="server" align="center" Style="display: none">
                                        <table cellpadding="0" cellspacing="0" border="0" style="background-color: #38ACEC;">
                                            <tr>
                                                <td height="16px">
                                                    <asp:ImageButton ID="IBtn_Close" runat="server" ImageUrl="close.gif" Style="border: 0px"
                                                        Width="13px" align="right" Height="13px" ToolTip="Close" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-left: 16px; padding-right: 16px; padding-bottom: 16px">
                                                    <table id="tbl_OC_Values" runat="server" width="350px" border="0" cellpadding="0"
                                                        cellspacing="0" style="background-color: #fff; text-align:center; ">
                                                        <tr style=" text-align:center; " runat="server">
                                                           <td runat="server"></td> <td align="center" class="headertext" runat="server">
                                                                <asp:Label ID="Label200" runat="server" Text="Guarantee Name" Font-Bold="True"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr runat="server"><td width="75px" runat="server"></td>
                                                            <td runat="server" >
                                                                 <br /><asp:TextBox ID="tbx_GurL1" runat="server" placeholder="Gurantee Name"></asp:TextBox><br />
                                        <asp:TextBox ID="tbx_GurL2" runat="server" placeholder="Gurantee Address" ></asp:TextBox><br />
                                        <asp:TextBox ID="tbx_GurL3" runat="server" placeholder="Gurantee Address" ></asp:TextBox><br />
                                        <asp:TextBox ID="tbx_GurL4" runat="server"  placeholder="Gurantee Address"></asp:TextBox><br />
                                                            </td><td width="20px" runat="server"></td>
                                                        </tr>
                                                        <tr runat="server">
                                                            <td runat="server"><br /></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="2px"></td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <!-- ModalPopupExtender -->
                        </ContentTemplate>
                    </asp:TabPanel>
                </asp:TabContainer>
                <br />
            </td>
        </tr>
    </table>
</asp:Content>
