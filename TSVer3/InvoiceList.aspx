<%@ Page Title="Tracksen" Language="C#" MasterPageFile="~/UserSite.Master" AutoEventWireup="true" CodeBehind="InvoiceList.aspx.cs" Inherits="TSVer3.InvoiceList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Templates/GridViewControl.ascx" TagName="GridViewControl" TagPrefix="WUC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="Styles/Tab.css" type="text/css" media="all" />
    <style type="text/css">
        .tbxwidth {
            width: 170px;
        }
    </style>
    <style type="text/css">        
        .TextCenter
        {
            text-align: center;
        }        
        .TextRight
        {
            text-align: right;
        }
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <td width="10px"></td>
            <td>
                <asp:TabContainer ID="TabContainer1" runat="server" Width="950px">
                    <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="Invoice Report">
                        <ContentTemplate>
                            <table>
                                <tr>
                                    <td width="10px"></td>
                                    <td>
                                       Month
                                    </td>
                                    <td></td>
                                    <td>
                                        <asp:DropDownList ID="ddl_Month" runat="server"></asp:DropDownList>
                                    </td>
                                    <td width="10px"></td>
                                    <td>
                                        <asp:Button ID="Btn_Submit" runat="server" Text="Submit" OnClick="Btn_Submit_Click" />
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="IBtn_Excel" runat="server" Width="30px" ImageUrl="~/images/Excel.jpg"
                                            Visible="False" OnClick="IBtn_Excel_Click1" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_Error" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <table>
                                <tr>
                                    <td>
                                        <div id="div_Grd" runat="server" style="overflow: scroll; width: 950px; border: 1px solid #dbddff; margin-left: 10px;">
                                            <asp:GridView ID="Grd" runat="server" ForeColor="#333333" EmptyDataText="No Record Found."
                                                AutoGenerateColumns="False" OnRowDataBound="Grd_RowDataBound"
                                                PageSize="100" ShowFooter="True">
                                                <FooterStyle Font-Bold="True" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S. No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1 %>.
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="50px" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                               <asp:TemplateField HeaderText="Invoice No" ItemStyle-Width="120px">
                                                        <ItemTemplate>
                                                            <a target="_blank" href="InvoiceNew.aspx?ien=<%#Eval("BillNo")%>"><%#Eval("BillNo")%> </a>
                                                        </ItemTemplate>
                                                        </asp:TemplateField>
                                                <asp:BoundField DataField="BillDate" HeaderText="Invoice Date" HeaderStyle-Width="100px" />
                                                <asp:BoundField DataField="CompName" HeaderText="To" HeaderStyle-Width="110px" />                                                   
                                                <asp:BoundField DataField="Currency" HeaderText="Currency" HeaderStyle-Width="90px" />                                                  
                                                <asp:BoundField DataField="CurrValue" HeaderText="ExRate" HeaderStyle-Width="90px" /> 
                                                <asp:BoundField DataField="TotalTax" HeaderText="Total Tax" HeaderStyle-Width="110px" />
                                                <asp:BoundField DataField="TotalNonTax" HeaderText="Total Non Tax" HeaderStyle-Width="120px" />
                                                <asp:BoundField DataField="GrandTotal" HeaderText="Grand Total" HeaderStyle-Width="120px" />
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
                                            </asp:GridView>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:TabPanel>
                </asp:TabContainer>
            </td>
        </tr>
    </table>
    <br />
</asp:Content>
