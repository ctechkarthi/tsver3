<%@ Page Title="" Language="C#" MasterPageFile="~/UserSite.Master" AutoEventWireup="true" CodeBehind="CostSheet1.aspx.cs" Inherits="TSVer3.CostSheet1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

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
                    <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="Cost Sheet New/Edit" BorderWidth="100" Font-Bold="True" Height="120px">
                        <ContentTemplate>
                            <asp:PlaceHolder ID="PlaceHolder_New" runat="server"></asp:PlaceHolder>
                            <table>
                                <tr>
                                    <td colspan="11" style="text-align: center; font-weight: bold; color: green; font-size: 18px;">Search/Update Invoice</td>
                                    <tr>
                                        <td colspan="11" style="text-align: center;">Enter Bill No.
                                                        <asp:Label ID="Label12" runat="server" Text="*" ForeColor="#CC0000"></asp:Label>
                                            <asp:TextBox ID="tbx_S_BillNo" runat="server"></asp:TextBox>
                                            <asp:Button ID="Btn_Search" runat="server" Text="Search" OnClick="Btn_Search_Click" Height="29px" />
                                            &nbsp;<asp:Label ID="lbl_SerchError" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label>
                                        </td>
                                    </tr>
                                <tr>
                                    <td colspan="11" style="text-align: center; font-weight: bold; color: green; font-size: 18px;">Generate New Invoice</td>
                                </tr>
                                <tr>
                                    <td>Category
                                        <asp:Label ID="Label26" runat="server" Text="*" ForeColor="#CC0000"></asp:Label>
                                    </td>
                                    <td width="20px"></td>
                                    <td style="width: 180px">
                                        <asp:DropDownList ID="ddl_Category" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_Category_SelectedIndexChanged">
                                            <asp:ListItem Value="---Select---">---Select---</asp:ListItem>
                                            <asp:ListItem Value="Air Export">Air Export</asp:ListItem>
                                            <asp:ListItem Value="Air Import">Air Import</asp:ListItem>
                                            <asp:ListItem Value="Sea Export">Sea Export</asp:ListItem>
                                            <asp:ListItem Value="Sea Import">Sea Import</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td width="15px"></td>
                                    <td>Bill No.
                                        <asp:Label ID="Label21" runat="server" Text="*" ForeColor="#CC0000"></asp:Label>
                                    </td>
                                    <td></td>
                                    <td>
                                        <asp:TextBox ID="tbx_BillNo" runat="server"></asp:TextBox>
                                    </td>
                                    <td width="15px"></td>
                                    <td>Bill Date
                                        <asp:Label ID="Label5" runat="server" Text="*" ForeColor="#CC0000"></asp:Label>
                                    </td>
                                    <td></td>
                                    <td>
                                        <asp:TextBox ID="tbx_BillDate" runat="server"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" TargetControlID="tbx_BillDate" Format="dd/MMM/yyyy"></asp:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Customer
                                        <asp:Label ID="Label22" runat="server" Text="*" ForeColor="#CC0000"></asp:Label>
                                    </td>
                                    <td></td>
                                    <td>
                                        <asp:DropDownList ID="ddl_ClientName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_ClientName_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td></td>
                                    <td valign="top">Month
                                        <asp:Label ID="Label68" runat="server" Text="*" ForeColor="#CC0000"></asp:Label>
                                    </td>
                                    <td></td>
                                    <td valign="top">
                                        <asp:TextBox ID="tbx_Month" runat="server"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender5" runat="server" Enabled="True" TargetControlID="tbx_Month" Format="MMMM - yyyy"></asp:CalendarExtender>
                                    </td>
                                    <td></td>
                                    <td valign="top">Reference
                                        <asp:Label ID="Label70" runat="server" Text="*" ForeColor="#CC0000"></asp:Label>
                                    </td>
                                    <td></td>
                                    <td valign="top">
                                        <asp:TextBox ID="tbx_JobNo" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
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
                                        State<br />
                                        Code<br /><br />
                                        Line<br />
                                    </td>
                                    <td></td>
                                    <td valign="top">
                                        <asp:TextBox ID="tbx_GSTNoCust" runat="server" ToolTip="You can't edit here!"></asp:TextBox><br />
                                        <asp:TextBox ID="tbx_StateCust" runat="server" ToolTip="You can't edit here!"></asp:TextBox><br />
                                        <asp:TextBox ID="tbx_StateCodeCust" runat="server" ToolTip="You can't edit here!"></asp:TextBox><br />
                                        <asp:TextBox ID="tbx_Line" runat="server"></asp:TextBox><br />
                                    </td>
                                    <td></td>
                                    <td valign="top">MBL/AWB<br />
                                        <br />
                                        <br />
                                        HBL/AWB<br />
                                        <br />
                                        SB No.
                                    </td>
                                    <td></td>
                                    <td valign="top">
                                        <asp:TextBox ID="tbx_AWB_No" runat="server"></asp:TextBox><br />
                                        <asp:TextBox ID="tbx_AWB_Date" runat="server"></asp:TextBox><br />
                                        <asp:TextBox ID="tbx_HAWB_No" runat="server"></asp:TextBox><br />
                                        <asp:TextBox ID="tbx_HAWB_Date" runat="server"></asp:TextBox><br />
                                        <asp:TextBox ID="tbx_SBNo" runat="server"></asp:TextBox><br />
                                        <asp:TextBox ID="tbx_SBDate" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Origin
                                    </td>
                                    <td></td>
                                    <td>
                                        <asp:TextBox ID="tbx_Origin" runat="server"></asp:TextBox>
                                    </td>
                                    <td></td>
                                    <td>Dest
                                    </td>
                                    <td></td>
                                    <td>
                                        <asp:TextBox ID="tbx_Dest" runat="server"></asp:TextBox>
                                    </td>
                                    <td></td>
                                    <td>Term of Sh.
                                    </td>
                                    <td></td>
                                    <td>
                                        <asp:TextBox ID="tbx_TOS" runat="server" Text=" "></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Gr Weight</td>
                                    <td></td>
                                    <td>
                                        <asp:TextBox ID="tbx_GW" runat="server"></asp:TextBox>
                                    </td>
                                    <td></td>
                                    <td>Volume</td>
                                    <td></td>
                                    <td>
                                        <asp:TextBox ID="tbx_Volume" runat="server"></asp:TextBox>
                                    </td>
                                    <td></td>
                                    <td>Pkgs</td>
                                    <td></td>
                                    <td>
                                        <asp:TextBox ID="tbx_Pkgs" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Vessel</td>
                                    <td></td>
                                    <td>
                                        <asp:TextBox ID="tbx_Vessel" runat="server"></asp:TextBox>
                                    </td>
                                    <td></td>
                                    <td>FCL/LCL</td>
                                    <td></td>
                                    <td>
                                        <asp:TextBox ID="tbx_FCL" runat="server"></asp:TextBox>
                                    </td>
                                    <td></td>
                                    <td>IEC</td>
                                    <td></td>
                                    <td>
                                        <asp:TextBox ID="tbx_IEC" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Shipper/Consignee</td>
                                    <td></td>
                                    <td>
                                        <asp:DropDownList ID="ddl_Shipper" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_Shipper_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td>
                                        <asp:TextBox ID="tbx_Shipper" runat="server" onkeyup="return toUpper(this.id)"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="11" style="text-align: center; color: red; text-decoration: underline;">Invoice Particulars (Description)</td>
                                </tr>
                                <tr>
                                    <td colspan="11">
                                        <asp:GridView ID="GrdInvoice" runat="server" AutoGenerateColumns="False" DataKeyNames="Id,Particulars"
                                            OnRowEditing="GrdInvoice_RowEditing" OnRowUpdating="GrdInvoice_RowUpdating"
                                            OnRowCancelingEdit="GrdInvoice_RowCancelingEdit" OnRowDataBound="GrdInvoice_RowDataBound" OnPageIndexChanging="GrdInvoice_PageIndexChanging" 
                                            OnRowDeleting="GrdInvoice_RowDeleting" ForeColor="#333333" CellPadding="6" 
                                            PageSize="100" ShowHeaderWhenEmpty="True" ShowFooter="True">
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
                                                <asp:TemplateField HeaderText="Quantity">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtQuantity" runat="server" Width="70px" Text='<%# Bind("Quantity") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblQuantity" runat="server" Text='<%# Bind("Quantity") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txt_Quantity" runat="server" Width="70px"></asp:TextBox>
                                                    </FooterTemplate>
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Unit Price">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtRate" runat="server" Width="70px" Text='<%# Bind("Rate") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRate" runat="server" Text='<%# Bind("Rate") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txt_Rate" runat="server" Width="70px"></asp:TextBox>
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
                                    <td>Total
                                        <asp:Label ID="Label17" runat="server" Text="*" ForeColor="#CC0000"></asp:Label>
                                    </td>
                                    <td></td>
                                    <td>
                                        <asp:TextBox ID="tbx_TotalAmt" runat="server" ReadOnly="True" Width="80px"></asp:TextBox><asp:TextBox ID="tbx_GrandTotal" runat="server" ReadOnly="True" Width="80px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="90px">Currency
                                        <asp:Label ID="Label19" runat="server" Text="*" ForeColor="#CC0000"></asp:Label>
                                    </td>
                                    <td></td>
                                    <td>
                                        <asp:DropDownList ID="ddl_CurrencyType" runat="server">
                                            <asp:ListItem Value="INR">Indian Rupees</asp:ListItem>
                                            <asp:ListItem Value="USD">US Dollar</asp:ListItem>
                                            <asp:ListItem Value="EUR">EURO</asp:ListItem>
                                            <asp:ListItem Value="AUD">Australian Dollar</asp:ListItem>
                                            <asp:ListItem Value="CAD">Canadian Dollar</asp:ListItem>
                                            <asp:ListItem Value="SGD">Singapore Dollar</asp:ListItem>
                                            <asp:ListItem Value="JPY">Japanese Yen</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td></td>
                                    <td valign="top">Currency Value
                                    </td>
                                    <td></td>
                                    <td valign="top">
                                        <asp:TextBox ID="tbx_CurrValue" runat="server" Text="1"></asp:TextBox>
                                    </td>
                                    <td></td>
                                    <td valign="top">Sales Rep
                                    </td>
                                    <td></td>
                                    <td valign="top">
                                        <asp:TextBox ID="tbx_SalesRep" runat="server" Text="Kiran"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Payment Received<br />
                                    </td>
                                    <td></td>
                                    <td>
                                        <asp:RadioButton ID="RB_Yes" runat="server" Text="Yes" GroupName="Payment" />
                                        <asp:RadioButton ID="RB_No" runat="server" Text="No" GroupName="Payment" Checked="True" />
                                    </td>
                                    <td></td>
                                    <td valign="top">Cheque No.
                                    </td>
                                    <td></td>
                                    <td valign="top">
                                        <asp:TextBox ID="tbx_Remarks" runat="server"></asp:TextBox>
                                    </td>
                                    <td></td>
                                    <td colspan="3"></td>
                                </tr>
                                <tr>
                                    <td colspan="11" align="center">
                                        <asp:Button ID="Btn_Clear" runat="server" OnClick="Btn_Clear_Click" Text="Clear" ToolTip="Click Here!"></asp:Button>
                                        &nbsp;&nbsp;
                                        <asp:Button ID="Btn_Insert" runat="server" OnClick="Btn_Insert_Click" OnClientClick="return validate_Invoice_GI1()" Text="Save" ToolTip="Ready to Insert New Record!"></asp:Button>
                                        <asp:Button ID="Btn_Update" runat="server" OnClick="Btn_Update_Click" OnClientClick="return validate_Invoice_GI1()" Text="Update" ToolTip="Click Here!" Visible="False"></asp:Button>&nbsp;&nbsp;
                                        <asp:Button ID="Btn_Delete" runat="server" OnClick="Btn_Delete_Click" OnClientClick="Confirm()" Text="Delete" ToolTip="Click Here!" Visible="False"></asp:Button>&nbsp;&nbsp;
                                        <asp:DropDownList ID="ddl_InvoiceType" runat="server" Visible="False">
                                            <asp:ListItem Value="TAX Invoice">TAX Invoice</asp:ListItem>
                                            <asp:ListItem Value="PROFORMA Invoice">PROFORMA Invoice</asp:ListItem>
                                        </asp:DropDownList>&nbsp;&nbsp;
                                        <asp:ImageButton ID="ImBtn_PDF" runat="server" ImageUrl="~/images/PDF.jpg" OnClick="ImBtn_PDF_Click" ToolTip="Click Here to Generate Invoice!" Visible="False" Width="40px"></asp:ImageButton>
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
