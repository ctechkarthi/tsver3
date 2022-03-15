<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UpdateIndicator.ascx.cs"
    Inherits="TSVer3.UpdateIndicator" %>
<asp:UpdateProgress ID="updateProgress" runat="server">
    <ProgressTemplate>
        <div 
            style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0;
            right: 0; left: 0; z-index: 9999999; opacity: 0.7; background-color: #FFFFFF;">
             <table Style="padding: 10px; position: fixed;
                top: 40%; left: 40%;" >
            <tr>
                <td >
                    <img src="images/loading/tt_spinner.gif" width="100px" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label10" runat="server" Font-Bold="true" ForeColor="Blue" Font-Italic="true" >Loading Please wait...</asp:Label>
                </td>
            </tr>
        </table>
        <%--<asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="~/images/loading/ajax-loader.gif"
                AlternateText="Loading ..." ToolTip="Loading ..." Style="padding: 10px; position: fixed;
                top: 45%; left: 50%;" />--%>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
<%--
<div class="updatePanelAnimationContainer">
    <div class="updatePanelAnimationBody">
      <table style="margin: auto;" >
            <tr>
                <td>
                    <img src="images/loading/tt_spinner.gif" alt="Please wait..." width="100px" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label10" runat="server" ForeColor="Blue" Font-Italic="true" >Please wait...</asp:Label>
                </td>
            </tr>
        </table>
    </div>
</div>--%>