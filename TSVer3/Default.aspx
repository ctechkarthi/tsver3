<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TSVer3.Default" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>C.S Hawkler Logistics, Bangalore : Tracksen</title>
    <link rel="shortcut icon" href="images/fav_tracksen.jpg" />
    <script type="text/javascript" language="javascript">
        function DisableBackButton() {
            window.history.forward()
        }
        DisableBackButton();
        window.onload = DisableBackButton;
        window.onpageshow = function (evt) { if (evt.persisted) DisableBackButton() }
        window.onunload = function () { void (0) }
    </script>    
    <style>
        body {
             background: url('wallpaper1.jpg') no-repeat fixed center center;
            background-size: cover;
            font-family: verdana;
            font-size: 12px;
        }

        .logo {
            width: 200px;
            height: 60px;
            background: url('Logo_Tracksen.png') no-repeat; 
            margin: 30px auto;
        }

        .login-block {
            width: 320px;
            padding: 20px;
            background: #fff;
            border-radius: 5px;
            border-top: 5px solid #ff656c;
            margin: 0 auto;
        }

            .login-block h1 {
                text-align: center;
                color: #000;
                font-size: 18px;
                text-transform: uppercase;
                margin-top: 0;
                margin-bottom: 20px;
            }

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
                border-color: #66AFE9;
                outline: 0px none;
                box-shadow: 0px 1px 1px rgba(0, 0, 0, 0.075) inset, 0px 0px 8px rgba(102, 175, 233, 0.6);
                border: 1px solid #AAA;
                /* box-shadow: 0px 0px 3px #CCC, 0px 8px 13px #EEE inset;*/
                border-radius: 5px;
                padding-right: 5px;
                padding-left: 5px;
                transition: padding 0.25s ease 0s;
                height: 20px;
                width: 180px;
                margin: 1px;
            }

        input[type=password] {
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

            input[type=password]:focus {
                border-color: #66AFE9;
                outline: 0px none;
                box-shadow: 0px 1px 1px rgba(0, 0, 0, 0.075) inset, 0px 0px 8px rgba(102, 175, 233, 0.6);
                border: 1px solid #AAA;
                /* box-shadow: 0px 0px 3px #CCC, 0px 8px 13px #EEE inset;*/
                border-radius: 5px;
                padding-right: 5px;
                padding-left: 5px;
                transition: padding 0.25s ease 0s;
                height: 20px;
                width: 180px;
                margin: 1px;
            }

        input[type=submit] {
            padding: 5px 8px 8px;
            border-radius: 8px;
            box-shadow: 0px 2px 3px #232C53;
            background: none repeat scroll 0% 0% #105167;
            height: 25px;
            font-size: 13px;
            font-family: "Helvetica Neue","Lucida Grande","Segoe UI",Arial,Helvetica,Verdana,sans-serif;
            width: auto;
            border: 1px solid #232C53;
            color: #FFF;
            line-height: 14px;
            text-align: center;
            font-weight: bold;
            margin: 5px 2px 3px px;
            text-decoration: none;
            cursor: pointer;
        }

            input[type=submit]:hover {
                background: #c766d9; /* Old browsers */
                background: -moz-linear-gradient(top, #c766d9 0%, #bd7fe0 6%, #ce9be6 20%, #b362bf 40%, #ac4db1 51%, #a952ba 78%, #8956a3 100%); /* FF3.6+ */
                background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,#c766d9), color-stop(6%,#bd7fe0), color-stop(20%,#ce9be6), color-stop(40%,#b362bf), color-stop(51%,#ac4db1), color-stop(78%,#a952ba), color-stop(100%,#8956a3)); /* Chrome,Safari4+ */
                background: -webkit-linear-gradient(top, #c766d9 0%,#bd7fe0 6%,#ce9be6 20%,#b362bf 40%,#ac4db1 51%,#a952ba 78%,#8956a3 100%); /* Chrome10+,Safari5.1+ */
                background: -o-linear-gradient(top, #c766d9 0%,#bd7fe0 6%,#ce9be6 20%,#b362bf 40%,#ac4db1 51%,#a952ba 78%,#8956a3 100%); /* Opera 11.10+ */
                background: -ms-linear-gradient(top, #c766d9 0%,#bd7fe0 6%,#ce9be6 20%,#b362bf 40%,#ac4db1 51%,#a952ba 78%,#8956a3 100%); /* IE10+ */
                background: linear-gradient(to bottom, #c766d9 0%,#bd7fe0 6%,#ce9be6 20%,#b362bf 40%,#ac4db1 51%,#a952ba 78%,#8956a3 100%); /* W3C */
                filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#c766d9', endColorstr='#8956a3',GradientType=0 ); /* IE6-9 */
                color: #fff;
                -moz-box-shadow: inset 0 0 10px #853e8e;
                -webkit-box-shadow: inset 0 0 10px #853e8e;
                box-shadow: inset 0 0 10px #853e8e;
            }

        .login-block-header-left {
            color: white;
            margin-top: 30px;
            margin-left: 0;
            font-size: 22px;
        }

        .login-block-header-right {
            color: white;
            margin-top: -22px;
            margin-left: 0px;
            font-size: 22px;
            text-align: right;
        }

        .login-block-footer-left {
            color: #000;
            margin-top: 250px;
            margin-left: 0;
            font-size: 10px;
        }

            .login-block-footer-left a {
                color: #000;
                margin-top: 250px;
                margin-left: 0;
                font-size: 10px;
                text-decoration: none;
            }

                .login-block-footer-left a:hover {
                    color: #000;
                    margin-top: 250px;
                    margin-left: 0;
                    font-size: 10px;
                    text-decoration: underline;
                }

        a {
            color: #000;
            font-size: 11px;
            text-decoration: none;
        }

            a:hover {
                color: #000;
                font-size: 11px;
                text-decoration: underline;
            }

        .login-block-footer-right {
            color: #000;
            margin-right: 100px;
            font-size: 10px;
        }
    </style>
    <script language="javascript" type="text/javascript">
        function validate() {
            if (document.getElementById("<%=tbx_UserName.ClientID%>").value == "") {
                alert("Please Enter Username");
                document.getElementById("<%=tbx_UserName.ClientID%>").focus();
                      return false;
                  }
                  if (document.getElementById("<%=tbx_Password.ClientID%>").value == "") {
                alert("Please Enter Password");
                document.getElementById("<%=tbx_Password.ClientID%>").focus();
                      return false;
                  }
                  return true;
              }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-block-header-left">C.S Hawkler Logistics Pvt. Ltd.</div>
        <div class="login-block-header-right">Tracksen Group</div>
       <%-- <div class="logo"></div>--%>
        <div class="login-block">
            <h1>C.S Hawkler Web Portal</h1>
            <table>
                <tr>
                    <td>Username</td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="tbx_UserName" runat="server" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Password</td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="tbx_Password" runat="server" TextMode="Password" Text="test123" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center" colspan="4">
                        <asp:Button ID="Btn_Login" runat="server" Text="Login" OnClick="Btn_Login_Click" OnClientClick="return validate()" />
                        &nbsp; <a href="LoginManagement.aspx">Retrieve Your Login Information?</a></td>
                </tr>
                <tr>
                    <td style="text-align: center" colspan="4">
                        <asp:Label ID="lbl_Status" runat="server" Font-Bold="true"></asp:Label></td>
                </tr>
            </table>
        </div>
        <div class="login-block-footer-left">Copyright © 2020 tracksen.com | Ver3.0 | <a href="#">Terms of Use</a> | <a href="#">Browser and Display Compatibility</a></div>
        <div class="login-block-footer-right">Entry to this site is restricted to employees and affiliates of C.S Hawkler Logistics Pvt. Ltd.</div>
    </form>
</body>
</html>

