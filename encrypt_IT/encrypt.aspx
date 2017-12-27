<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="encrypt.aspx.cs" Inherits="encrypt_IT.encrypt" %>

<!DOCTYPE html>

<html>
<head>
	<meta charset="utf-8">
 	<title>Encrypt it</title>
    <link rel="stylesheet" href="CSS/style.css">
</head>
<body>
 	<div class = "top_hat">
		<a>Encrypt It</a>
	</div>
 	<article>
	
 		<form id="input1" runat="server">
 			<textarea placeholder="Input" id="inputArea" name="inputArea" runat="server"></textarea>
 			<div class="trapdoor">
 				<div class="top door">
  				</div>
  				<div class="bottom door">
 				</div>
  				<input type="submit" class="twitter-follow-button" data-show-count="false" data-size="large" data-dnt="false" runat="server" onserverclick="submitMethod"></>
			</div>
 			<textarea readonly placeholder="Output" id="outputBox" name="outputBox" runat="server"></textarea>
 			<br>

 			<asp:FileUpLoad id="FileUpLoad1" runat="server" />
             <asp:Button id="UploadBtn" Text="Upload File" OnClick="UploadBtn_Click" runat="server" Width="105px" />
    		<!--<input type="submit" value="Upload" name="submit">-->
 			<select name="sType" size="1">
 				<option selected="" value="s1" >Encrypt</option>
 				<option value="s2">Decrypt</option>
 			</select>
 			<select name="Algorythm" size="1">
 				<option selected="" value="s1" >3DES</option>
 				<option value="s2">AES</option>
 				<option value="s3" >Blowfish</option>
 				<option value="s4">Twofish</option>
 				<option value="s5" >IDEA</option>
 				<option value="s6">MD5</option>
 				<option value="s7" >SHA 1</option>
 				<option value="s8">HMAC</option>
 				<option value="s9" >RSA Security: RC4</option>
 			</select>
 			<br>
            
        
 	<footer>
 		&copy !23.1415 2017 <a href="statPage.aspx" runat="server">stats</a>
 	</footer>
 		</form>
 	</article>
        
 	</body>
</html>