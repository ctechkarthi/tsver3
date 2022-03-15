<%@ Page Title="Tracksen" Language="C#" MasterPageFile="~/UserSite.Master" AutoEventWireup="true" CodeBehind="ExpenseList.aspx.cs" Inherits="TSVer3.ExpenseList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Templates/GridViewControl.ascx" TagName="GridViewControl" TagPrefix="WUC" %>

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
    
     <style type="text/css">
        .TextCenter
        {
            text-align: center;
        }        
        .TextRight
        {
            text-align: right;
        }
        .GridviewDiv
        {
            color: #303933;
        }
        Table.Gridview
        {
            border: solid 1px #3c82fa;
        }
        .GridviewTable
        {
            border: none;
        }
        .GridviewTable td
        {
            margin-top: 0;
            padding: 0;
            vertical-align: middle;
        }
        .GridviewTable tr
        {
            color: White;
            background-color: #3c82fa;
            height: 30px;
            text-align: center;
        }
        .Gridview th
        {
            color: #FFFFFF;
            border-right-color: #3c82fa;
            border-bottom-color: #3c82fa;
            padding: 0.5em 0.5em 0.5em 0.5em;
            text-align: center;
        }
        .Gridview td
        {
            border-bottom-color: #3c82fa;
            border-right-color: #3c82fa;
            padding: 0.5em 0.5em 0.5em 0.5em;
        }
        .Gridview tr
        {
            color: Black;
            background-color: White;
            text-align: left;
        }
        :link, :visited
        {
            color: #DF4F13;
            text-decoration: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <td width="10px"></td>
            <td>
                <asp:TabContainer ID="TabContainer1" runat="server" Width="950px">
                    <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="Expense List">
                        <ContentTemplate>
                            <table style="width:900px;">
                                <tr>
                                    <td colspan="11" style="text-align: center; font-weight: bold; color: green; font-size: 18px;">Search/Update Expense</td>
                                    <tr>
                                        <td colspan="11" style="text-align: center;">Category <asp:DropDownList ID="cmb_Category" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmb_Category_SelectedIndexChanged" > <asp:ListItem Value="---Select---">---Select---</asp:ListItem>
                                            <asp:ListItem Value="Air Export">Air Export</asp:ListItem>
                                            <asp:ListItem Value="Air Import">Air Import</asp:ListItem>
                                            <asp:ListItem Value="Sea Export">Sea Export</asp:ListItem>
                                            <asp:ListItem Value="Sea Import">Sea Import</asp:ListItem></asp:DropDownList><br />
                                            Enter Job No.
                                                        <asp:Label ID="Label12" runat="server" Text="*" ForeColor="#CC0000"></asp:Label>
                                            <asp:TextBox ID="tbx_JobNo" runat="server"></asp:TextBox>
                                            <asp:Button ID="Btn_Search" runat="server" Text="Search" OnClick="Btn_Search_Click" />
                                            &nbsp;<asp:Label ID="lbl_SerchError" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label>
                                        </td>
                                    </tr></table>
                            <asp:GridView ID="Grd" runat="server" ForeColor="#333333" EmptyDataText="No Record Found."
                                AutoGenerateColumns="False" OnRowDataBound="Grd_RowDataBound" OnPageIndexChanging="Grd_OnPaging"
                                PageSize="80" AllowPaging="True">
                                <FooterStyle Font-Bold="True" />
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>.
                                        </ItemTemplate>
                                        <HeaderStyle Width="35px" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Job No">
                                        <ItemTemplate>
                                            <a target="_blank" title="Expense PDF" href="ExpensePDF.aspx?etetsrf=AL5rthrh12yyjr6j1rtjeKk003ytwewebrq8wmI385yYqEbTmkoM55qOjgTMA884mtrtrt88735780&ei=H2quXvpibvrytynoqoevnewuUL42om4werfwf9fwf2mtohbnnweuqwoinxcvbdfgreggnkoM55qr4Ag&ien=<%#Eval("JobNo")%>&erwer=dfhkghdfkghdfghdhgieneKk003385yYqEbTmkoM55qOjgTMA1588kghdfghdhgieneKk003488735780"><%#Eval("JobNo")%> </a>
                                        </ItemTemplate>
                                        <ItemStyle Width="120px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="AWBNo" HeaderText="BL/AWBNo">
                                        <HeaderStyle CssClass="TextCenter" Width="200px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Shipper" HeaderText="Shipper">
                                        <HeaderStyle CssClass="TextCenter" Width="350px" />
                                        <ItemStyle CssClass="TextCenter" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total" HeaderText="Total">
                                        <HeaderStyle CssClass="TextCenter" Width="150px" />
                                        <ItemStyle CssClass="TextCenter" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate><a href="Expense.aspx?sstlxlorf=wzpejenbvre5ern15y5hwerqdcAL5rthrh12yyjr6j1rtjeKk003ytwewebrq8wmI385yYqEbTmkoM55qOjgTMA884mtrtrt88735780&ei=H2quXvpibvrytynoqoevnewuUL42om4werfwf9fwf2mtohbnnweuqwoinxcvbdfgreggnkoM55qr4Ag&ien=<%#Eval("JobNo")%>&erwer=dfhkghdfkghdfghdhgieneKk003385yYqEbTmkoM55qOjgTMA1588kghdfghdhgieneKk003488735780"><img src="images/Edit.jpg" width="25" height="25" /></a>
                                        </ItemTemplate>
                                        <ItemStyle Width="30px" />
                                    </asp:TemplateField>
                                </Columns>
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <EditRowStyle BackColor="#999999" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Left" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:TabPanel>
                </asp:TabContainer>
            </td>
        </tr>
    </table>
</asp:Content>
