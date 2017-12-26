<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="encryptCs.aspx.cs" Inherits="encrypt_IT.encryptCs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<meta charset="utf-8"/>
 	<title>Encrypt it</title>
    <link rel="stylesheet" href="CSS/style.css"/>
    <script src="js/FExample.js"></script>
    <style type="text/css">
        #TextArea1 {
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="encryptCs" runat="server">
        <div class = "top_hat">
		<a>Encrypt It</a>
	</div>

        <p>
            &nbsp;</p>
        <p>
            <asp:TextBox ID="TextBox1" runat="server" Height="300px" TextMode="MultiLine" Width="350px"></asp:TextBox>
            <asp:TextBox ID="TextBox2" runat="server" Height="300px" ReadOnly="True" TextMode="MultiLine" Width="350px"></asp:TextBox>
        </p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <asp:Button ID="Button1" runat="server" Text="Button" />

    </form>
</body>
</html>
