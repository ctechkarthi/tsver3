<%@ Page Title="Tracksen" Language="C#" MasterPageFile="~/UserSite.Master" AutoEventWireup="true" CodeBehind="JobDetails.aspx.cs" Inherits="TSVer3.JobDetails" %>

<%@ Register Src="~/Templates/GridViewControl.ascx" TagName="GridViewControl" TagPrefix="WUC" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="Styles/Tab.css" rel="stylesheet" type="text/css" />
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
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    <div style="font-family: calibri; font-size: 14px">
        <table>
            <tr>
                <td width="10px">
                </td>
                <td>
                    <asp:TabContainer ID="TabContainer1" runat="server" Width="950px" >
                        <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="Job Details">
                                <ContentTemplate>
                                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                                <table>
                                    <tr>
                                        <td width="20px">
                                        </td>
                                        <td>
                                        </td>
                                        <td width="10px">
                                        </td>
                                        <td>
                                        </td>
                                        <td width="20px">
                                        </td>
                                        <td>
                                        </td>
                                        <td width="10px">
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>Invoice Type
                                        </td>
                                        <td>
                                        </td><td>
                                            <asp:DropDownList ID="cmb_Category" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmb_Category_SelectedIndexChanged">
                                            <asp:ListItem Value="---Select---">---Select---</asp:ListItem>
                                            <asp:ListItem Value="Air Export">Air Export</asp:ListItem>
                                            <asp:ListItem Value="Air Import">Air Import</asp:ListItem>
                                            <asp:ListItem Value="Sea Export">Sea Export</asp:ListItem>
                                            <asp:ListItem Value="Sea Import">Sea Import</asp:ListItem>
                                        </asp:DropDownList>
                                        </td>
                                        <td>
                                        </td><td>Invoice No.
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="tbx_JobNo" runat="server" width="230px" ></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>Generate By
                                        </td>
                                        <td>
                                        </td>
                                        <td>                                     
                                        <asp:DropDownList ID="cmb_Sales" runat="server" >
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
                                        </asp:DropDownList>     </td>
                                        <td>
                                        </td>
                                        <td>Status
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                         <asp:DropDownList ID="cmb_JobStatus" runat="server" >
                                            <asp:ListItem Value="Used">Used</asp:ListItem>
                                        </asp:DropDownList> </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td colspan="7">
                                            <asp:Button ID="Btn_Clear" runat="server" Text="Clear" CssClass="DefaultButton" OnClick="Btn_Clear_Click" />&nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="Btn_Insert" runat="server" Text="Save" CssClass="DefaultButton" OnClick="Btn_Insert_Click" />&nbsp;&nbsp; &nbsp;
                                            <asp:Button ID="Btn_Delete" runat="server" Text="Delete" Visible="False" CssClass="DefaultButton" OnClick="Btn_Delete_Click" OnClientClick="return confirm('Are you sure want to Delete?');" />&nbsp;&nbsp;
                                            <asp:Label ID="lbl_Status" runat="server" Font-Bold="True"></asp:Label><br />
                                            <asp:Label ID="Label47" runat="server" ForeColor="Red" Text="Do Not Use Single(') & Double quotes('')"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                 </ContentTemplate>
                        </asp:TabPanel>
                    </asp:TabContainer>
                </td>
            </tr>
        </table>
        <div style="overflow: scroll; width: 950px; border: 1px solid #dbddff; margin-left: 10px;">
            <asp:Label ID="lbl_GrdError" ForeColor="Red" runat="server"></asp:Label>
            <asp:GridView ID="Grd" runat="server" ForeColor="#333333" CellPadding="6" PageSize="50" Width="1230px"
                EmptyDataText="No Record Found." AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                OnPageIndexChanging="Grd_PageIndexChanging" OnRowDataBound="Grd_RowDataBound"
                OnSelectedIndexChanged="Grd_SelectedIndexChanged">
                <Columns>
                    <%--<asp:CommandField SelectImageUrl="~/images/arrowbullet.png" ButtonType="Image" SelectText=""
                        ShowSelectButton="True" Visible="True" />--%>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>.
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <%--<asp:BoundField DataField="Id" HeaderText="Id" />--%>
                    <asp:BoundField DataField="JobNo" HeaderText="Invoice No" />
                    <asp:BoundField DataField="Type" HeaderText="Type" />
                    <asp:BoundField DataField="GBy" HeaderText="Generate By" />
                    <asp:BoundField DataField="JobStatus" HeaderText="Job Status" />
                    <asp:BoundField DataField="Month" HeaderText="Month" />
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
    </div><br />
</asp:Content>
