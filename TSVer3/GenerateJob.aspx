<%@ Page Title="Generate Job" Language="C#" MasterPageFile="~/UserSite.Master" AutoEventWireup="true" CodeBehind="GenerateJob.aspx.cs" Inherits="TSVer3.GenerateJob" %>

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
                    <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="Generate Job Create/Edit/Delete" BorderWidth="100" Font-Bold="True" Height="120px">
                        <ContentTemplate>
                            <asp:PlaceHolder ID="PlaceHolder_New" runat="server"></asp:PlaceHolder>
                                       <table>                                          
                                            <tr>
                                                <td colspan="11" style="text-align: center; font-weight: bold; color: green; font-size: 18px;">Job Details</td>
                                            </tr>
                                           <tr>
                                                <td>Invoice Type</td>
                                                <td>
                                                        <asp:DropDownList ID="cmb_Category" runat="server" Width="280px" OnSelectedIndexChanged="cmb_Category_SelectedIndexChanged" >
                                                            <asp:ListItem>---Select---</asp:ListItem>
                                                            <asp:ListItem>Sea Export</asp:ListItem>
                                                            <asp:ListItem>Sea Import</asp:ListItem>
                                                            <asp:ListItem>Air Export</asp:ListItem>
                                                            <asp:ListItem>Air Import</asp:ListItem>
                                                        </asp:DropDownList></td>
                                            <td></td>
                                                <td>Invoice No.<asp:Label ID="Label22" runat="server" Text="*" ForeColor="#CC0000"></asp:Label>
                                                </td>
                                                <td><asp:TextBox ID="tbx_JobNo" runat="server"></asp:TextBox></td>
                                            </tr>   
                                            <tr>
                                                <td>Generate By</td>
                                                <td>
                                                        <asp:DropDownList ID="cmb_Sales" runat="server" Width="280px">
                                                        </asp:DropDownList></td>
                                            <td></td><td>Invoice Satus</td>
                                                <td>
                                                        <asp:DropDownList ID="cmb_JobStatus" runat="server" Width="280px">
                                                            <asp:ListItem>Used</asp:ListItem>
                                                        </asp:DropDownList></td> </tr>   
                                            <tr><td colspan="11" style="border: thin solid #000000">                                              
                                                               <table >                                                             
                                                            <tr>
                                                                <td style="width:850px;">
                                                                <asp:Button ID="Btn_ClearParti" runat="server" CssClass="button2" Text="Clear" OnClick="Btn_ClearParti_Click" />&nbsp;&nbsp;
                                                                 <asp:Button ID="Btn_Save" runat="server" CssClass="button2" Text="Save" OnClick="Btn_Save_Click" />&nbsp;&nbsp;
                                                                <asp:Button ID="Btn_Delete" runat="server" CssClass="button2" Text="Delete" OnClientClick="Confirm()" OnClick="Btn_Delete_Click" Visible="False" />&nbsp;&nbsp;
                                                                <asp:Label ID="lbl_Status" Font-Bold="True" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                </td></tr>  
                                      <tr>
                                                <td colspan="11">
                                        <asp:GridView ID="GrdInvoice" runat="server" AutoGenerateColumns="False" DataKeyNames="Id,Particulars"
                                            OnRowDataBound="GrdInvoice_RowDataBound" OnPageIndexChanging="GrdInvoice_PageIndexChanging" 
                                            ForeColor="#333333" CellPadding="6" 
                                            PageSize="100" ShowHeaderWhenEmpty="True" ShowFooter="True" OnSelectedIndexChanged="GrdInvoice_SelectedIndexChanged">
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
                                    <asp:BoundField DataField="JobNo" HeaderText="Id">
                                        <HeaderStyle CssClass="TextCenter" Width="100px" />
                                        <ItemStyle CssClass="TextCenter" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="JobNo" HeaderText="Invoice Type">
                                        <HeaderStyle CssClass="TextCenter" Width="100px" />
                                        <ItemStyle CssClass="TextCenter" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="JobNo" HeaderText="Invoice No.">
                                        <HeaderStyle CssClass="TextCenter" Width="100px" />
                                        <ItemStyle CssClass="TextCenter" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="JobNo" HeaderText="Generate By">
                                        <HeaderStyle CssClass="TextCenter" Width="100px" />
                                        <ItemStyle CssClass="TextCenter" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="JobNo" HeaderText="Invoice Status">
                                        <HeaderStyle CssClass="TextCenter" Width="100px" />
                                        <ItemStyle CssClass="TextCenter" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="JobNo" HeaderText="Create Date">
                                        <HeaderStyle CssClass="TextCenter" Width="100px" />
                                        <ItemStyle CssClass="TextCenter" />
                                    </asp:BoundField>
                                            </Columns>
                                             <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                             <EditRowStyle BackColor="#999999" />
                                            <EmptyDataRowStyle BackColor="LightBlue" ForeColor="Red" />
                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Left" />
                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        </asp:GridView>
                                      </td></tr>
                                        </table>
                        </ContentTemplate>
                    </asp:TabPanel>
                </asp:TabContainer>
                <br />
            </td>
        </tr>
    </table>
</asp:Content>

