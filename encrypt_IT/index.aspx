<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="encrypt_IT.index" %>

<!DOCTYPE html>

 <html runat="server">
<head>
	<meta charset="utf-8">
 	<title>Encrypt it</title>
    <link rel="stylesheet" href="CSS/style.css">
    <script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
    <style type="text/css">
    	article {
    		min-height: 1000px
    	}
    </style>
</head>
<body runat="server">
	<form id="form1" runat="server">
	<div class = "top_hat">
		<a>Encrypt It</a>
	</div>
 	<article>
 		<div id="container" >
 			<div id="message"></div>
  		</div>
  		<script src="js/index.js"></script>
<!--
 		<div class="index_text">
 			<a href="encrypt.html" id="hiddenlink">laboris</a> hidden link here <
 		</div>
-->
 		
		<iframe src="https://player.vimeo.com/video/134932244" width="640" height="360"></iframe>
 	    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="encrypt" />
 	</article>
   
 	<footer>
 		&copy !23.1415 2017
 	</footer>
    </form>
</body>
</html>
