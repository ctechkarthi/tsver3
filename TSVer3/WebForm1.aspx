<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="TSVer3.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <script type="text/javascript">
        function GetGridRowvalues() {
            var TaxAmt = document.getElementById("TextBox1");
            var NonTaxAmt = document.getElementById("TextBox2");
            if (TaxAmt.value == '') {
                alert('Please enter Tax Amount Ex: 0 or 0.00'); return false;
            }
            if (NonTaxAmt.value == '') {
                alert('Please enter Non Tax Amount Ex: 0 or 0.00'); return false;
            }
            return false;
        }
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><br />
        <asp:Button ID="Button1" runat="server" Text="Button"   OnClick="Button1_Click" />
        <asp:Label ID="Label1" runat="server" ></asp:Label><br />
        <asp:Label ID="Label2" runat="server" ></asp:Label><br />
    </div>
    </form>
</body>
</html>
