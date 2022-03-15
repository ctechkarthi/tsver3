<%@ Page Title="Tracksen" Language="C#" MasterPageFile="~/UserSite.Master" AutoEventWireup="true" CodeBehind="Particulars.aspx.cs" Inherits="TSVer3.Particulars" %>

<%@ Register Src="UpdateIndicator.ascx" TagName="UpdateIndicator" TagPrefix="WUC" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Templates/GridViewControl.ascx" TagName="GridViewControl" TagPrefix="WUC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="Styles/Tab.css" type="text/css" media="all" />
    <style type="text/css">
        .TextCenter {
            text-align: center;
        }
    </style>
    <style type="text/css">
        .GridviewDiv {
            color: #303933;
        }

        Table.Gridview {
            border: solid 1px #3c82fa;
        }

        .GridviewTable {
            border: none;
        }

            .GridviewTable td {
                margin-top: 0;
                padding: 0;
                vertical-align: middle;
            }

            .GridviewTable tr {
                color: White;
                background-color: #3c82fa;
                height: 30px;
                text-align: center;
            }

        .Gridview th {
            color: #FFFFFF;
            border-right-color: #3c82fa;
            border-bottom-color: #3c82fa;
            padding: 0.5em 0.5em 0.5em 0.5em;
            text-align: center;
        }

        .Gridview td {
            border-bottom-color: #3c82fa;
            border-right-color: #3c82fa;
            padding: 0.5em 0.5em 0.5em 0.5em;
        }

        .Gridview tr {
            color: Black;
            background-color: White;
            text-align: left;
        }

        :link, :visited {
            color: #DF4F13;
            text-decoration: none;
        }
    </style>
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
    <script language="javascript" type="text/javascript">
        function loadGrid() {
            var nuovourl = window.location.href + '';
            nuovourl = nuovourl + (nuovourl.indexOf('?') > -1 ? "&refreshme=1" : "?refreshme=1");
            window.location.href = nuovourl;
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
                <asp:TabContainer ID="TabContainer1" runat="server" Width="950px" ActiveTabIndex="0">
                    <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="View Cart" OnClientClick="loadGrid">
                        <ContentTemplate>
                            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                            <br />
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label72" runat="server" Text="Enter Particulars :"></asp:Label>
                                    </td>
                                    <td></td>
                                    <td>
                                        <asp:TextBox ID="tbx_Particular_Search" runat="server" Width="200px"  onkeyup="return toUpper(this.id)"></asp:TextBox>
                                    </td>
                                    <td>&nbsp;&nbsp;<asp:Button ID="Btn_Show" runat="server" Text="Show" CssClass="DefaultButton"
                                        OnClick="Btn_Show_Click" />
                                    </td>
                                    <td>&nbsp;&nbsp;<asp:Button ID="Btn_Reset" runat="server" Text="Refresh" CssClass="DefaultButton"
                                        OnClick="Btn_Reset_Click" />
                                    </td>
                                    <td>&nbsp;&nbsp;<asp:ImageButton ID="IB_Excel" runat="server" ImageUrl="~/images/Excel.jpg"
                                        Width="30px" ToolTip="Convert Excel" OnClick="IB_Excel_Click" />
                                    </td>
                                    <td>&nbsp;&nbsp;<asp:Label ID="lbl_Error" runat="server" Font-Bold="True" ForeColor="#CC0000"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <div style="overflow: scroll;">
                                <asp:GridView ID="Grd" runat="server" ForeColor="#333333" CellPadding="6"
                                    EmptyDataText="No Record Found." AllowPaging="True" AllowSorting="True"
                                    PageSize="100" AutoGenerateColumns="False" OnPageIndexChanging="Grd_PageIndexChanging"
                                    OnRowDataBound="Grd_RowDataBound" OnSelectedIndexChanged="Grd_SelectedIndexChanged"
                                    Font-Names="Verdana" Font-Size="10pt">
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-Width="25px">
                                            <HeaderTemplate>
                                                S.No
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>.
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="HSN" HeaderText="HSN/SAC" HeaderStyle-Width="120px">
                                            <HeaderStyle CssClass="TextCenter" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Particulars" HeaderText="Particulars" HeaderStyle-Width="400px">
                                            <HeaderStyle CssClass="TextCenter" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CGST" HeaderText="CGST">
                                            <HeaderStyle CssClass="TextCenter" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="SGST" HeaderText="SGST">
                                            <HeaderStyle CssClass="TextCenter" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IGST" HeaderText="IGST">
                                            <HeaderStyle CssClass="TextCenter" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="GST" HeaderText="GST">
                                            <HeaderStyle CssClass="TextCenter" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Active" HeaderText="Active" HeaderStyle-Width="90px">
                                            <HeaderStyle CssClass="TextCenter" />
                                        </asp:BoundField>
                                    </Columns>
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <EditRowStyle BackColor="#999999" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Left" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                    <PagerTemplate>
                                        <WUC:GridViewControl ID="GridViewControl1" runat="server" />
                                    </PagerTemplate>
                                </asp:GridView>
                            </div>
                        </ContentTemplate>
                    </asp:TabPanel>
                    <asp:TabPanel ID="TP_New" runat="server" HeaderText="Particulars Changes">
                        <ContentTemplate>
                            <asp:PlaceHolder ID="PlaceHolder_New" runat="server"></asp:PlaceHolder>
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="0">
                                <ProgressTemplate>
                                    <WUC:UpdateIndicator ID="UpdateProgress6" runat="server" />
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <td>Particulars</td>
                                            <td width='10px'></td>
                                            <td>
                                                <asp:TextBox ID="tbx_Particulars" runat="server" Width="300px" onkeyup="return toUpper(this.id)"></asp:TextBox>
                                            </td>
                                            <td></td>
                                            <td>HSN/SAC</td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="tbx_HSN" runat="server"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td>GST</td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="tbx_GST" runat="server" OnTextChanged="tbx_GST_TextChanged" AutoPostBack="true"></asp:TextBox></td>
                                            <td></td>
                                            <td>IGST</td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="tbx_IGST" runat="server"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td>Central GST</td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="tbx_CGST" runat="server"></asp:TextBox></td>
                                            <td></td>
                                            <td>State GST</td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="tbx_SGST" runat="server"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td>Active</td>
                                            <td></td>
                                            <td>
                                                <asp:RadioButton ID="RB_Yes" runat="server" Text="Yes" GroupName="Act" Checked="true" />&nbsp;&nbsp;<asp:RadioButton ID="RB_No" runat="server" Text="No" GroupName="Act" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td></td>
                                            <td colspan="5">
                                                <asp:Button ID="Btn_Clear" runat="server" Text="Clear" CssClass="DefaultButton" OnClick="Btn_Clear_Click" />
                                                &nbsp;&nbsp;
                                                <asp:Button ID="Btn_Insert" runat="server" Text="Save" CssClass="DefaultButton"
                                                    OnClientClick="return validate_insert()" OnClick="Btn_Insert_Click" />
                                                                    <asp:Button ID="Btn_Edit" runat="server" Text="Update" CssClass="DefaultButton"
                                                                        OnClientClick="return validate_insert()" Visible="False" OnClick="Btn_Edit_Click" />
                                                &nbsp;&nbsp;
                                                <asp:Label ID="lbl_Status" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label><br />
                                                <asp:Label ID="Label47" runat="server" ForeColor="Red" Font-Size="10px" Text="* Do Not Use Single(') & Double quotes('')"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="Btn_Insert" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="Btn_Clear" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="Btn_Edit" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </ContentTemplate>
                    </asp:TabPanel>
                </asp:TabContainer>
            </td>
        </tr>
    </table>
    <br />
</asp:Content>
