﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>支付宝手机网站支付接口</title>
    <style>
        * {
            margin: 0;
            padding: 0;
        }

        ul, ol {
            list-style: none;
        }

        body {
            font-family: "Helvetica Neue",Helvetica,Arial,"Lucida Grande",sans-serif;
        }

        .hidden {
            display: none;
        }

        .new-btn-login-sp {
            padding: 1px;
            display: inline-block;
            width: 75%;
        }

        .new-btn-login {
            background-color: #02aaf1;
            color: #FFFFFF;
            font-weight: bold;
            border: none;
            width: 100%;
            height: 30px;
            border-radius: 5px;
            font-size: 16px;
        }

        #main {
            width: 100%;
            margin: 0 auto;
            font-size: 14px;
        }

        .red-star {
            color: #f00;
            width: 10px;
            display: inline-block;
        }

        .null-star {
            color: #fff;
        }

        .content {
            margin-top: 5px;
        }

            .content dt {
                width: 100px;
                display: inline-block;
                float: left;
                margin-left: 20px;
                color: #666;
                font-size: 13px;
                margin-top: 8px;
            }

            .content dd {
                margin-left: 120px;
                margin-bottom: 5px;
            }

                .content dd input {
                    width: 85%;
                    height: 28px;
                    border: 0;
                    -webkit-border-radius: 0;
                    -webkit-appearance: none;
                }

        #foot {
            margin-top: 10px;
            position: absolute;
            bottom: 15px;
            width: 100%;
        }

        .foot-ul {
            width: 100%;
        }

            .foot-ul li {
                width: 100%;
                text-align: center;
                color: #666;
            }

        .note-help {
            color: #999999;
            font-size: 12px;
            line-height: 130%;
            margin-top: 5px;
            width: 100%;
            display: block;
        }

        #btn-dd {
            margin: 20px;
            text-align: center;
        }

        .foot-ul {
            width: 100%;
        }

        .one_line {
            display: block;
            height: 1px;
            border: 0;
            border-top: 1px solid #eeeeee;
            width: 100%;
            margin-left: 20px;
        }

        .am-header {
            display: -webkit-box;
            display: -ms-flexbox;
            display: box;
            width: 100%;
            position: relative;
            padding: 7px 0;
            -webkit-box-sizing: border-box;
            -ms-box-sizing: border-box;
            box-sizing: border-box;
            background: #1D222D;
            height: 50px;
            text-align: center;
            -webkit-box-pack: center;
            -ms-flex-pack: center;
            box-pack: center;
            -webkit-box-align: center;
            -ms-flex-align: center;
            box-align: center;
        }

            .am-header h1 {
                -webkit-box-flex: 1;
                -ms-flex: 1;
                box-flex: 1;
                line-height: 18px;
                text-align: center;
                font-size: 18px;
                font-weight: 300;
                color: #fff;
            }
    </style>
</head>


<body text="#000000" bgcolor="#ffffff" leftmargin="0" topmargin="4">
    <form id="Form1" runat="server">
        <header class="am-header">
            <h1>支付宝手机网站支付接口快速通道</h1>
        </header>
        <div id="main">
            <div id="body" style="clear: left">
                <dl class="content">
                    <dt>商户订单号：</dt>
                    <dd>
                        <asp:TextBox ID="WIDout_trade_no" name="WIDout_trade_no"  runat="server"></asp:TextBox>
                    </dd>
                    <%--<hr class="one_line">--%>
                    <dt>订单名称：</dt>
                    <dd>
                        <asp:TextBox ID="WIDsubject" name="WIDsubject" runat="server"></asp:TextBox>
                    </dd>
                    <%--<hr class="one_line">--%>
                    <dt>付款金额：</dt>
                    <dd>
                        <asp:TextBox ID="WIDtotal_fee" name="WIDtotal_fee" runat="server"></asp:TextBox>
                    </dd>
                    <%--<hr class="one_line">--%>
                    <dt>商品展示网址：</dt>
                    <dd>
                        <asp:TextBox ID="WIDshow_url" name="WIDshow_url" runat="server"></asp:TextBox>
                    </dd>
                    <%--<hr class="one_line">--%>
                    <dt>商品描述：</dt>
                    <dd>
                        <asp:TextBox ID="WIDbody" name="WIDbody" runat="server"></asp:TextBox>
                    </dd>
                    <%--<hr class="one_line">--%>
                    <dt></dt>
                    <dd id="btn-dd">
                        <span class="new-btn-login-sp">
                            <asp:Button ID="BtnAlipay" name="BtnAlipay" class="new-btn-login" Text="确 认" Style="text-align: center;" runat="server" OnClick="BtnAlipay_Click" />
                        </span>
                        <span class="note-help">如果您点击“确认”按钮，即表示您同意该次的执行操作。</span>
                    </dd>
                </dl>
            </div>
            <div id="foot">
                <ul class="foot-ul">
                    <li>支付宝版权所有 2015-2018 ALIPAY.COM 
                    </li>
                </ul>
            </div>
        </div>
    </form>
</body>
<script language="javascript">
    function GetDateNow() {
        var vNow = new Date();
        var sNow = "";
        sNow += String(vNow.getFullYear());
        sNow += String(vNow.getMonth() + 1);
        sNow += String(vNow.getDate());
        sNow += String(vNow.getHours());
        sNow += String(vNow.getMinutes());
        sNow += String(vNow.getSeconds());
        sNow += String(vNow.getMilliseconds());
        document.getElementById("WIDout_trade_no").value = sNow;
        document.getElementById("WIDsubject").value = "测试";
        document.getElementById("WIDtotal_fee").value = "0.01";
    }
    GetDateNow();
</script>
</html>
