<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="statPage.aspx.cs" Inherits="encrypt_IT.statPage" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" runat="server">
<head runat="server">
    <meta charset="utf-8"/>
 	<title>Encrypt it</title>
    <link rel="stylesheet" href="CSS/style.css"/>
    <script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
    <style type="text/css">
    	article {
    		min-height: 1000px
    	}
    </style>
</head>
<body runat="server">
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="statusTextBox" Font-Names="stattb" Text="" runat="server"/>
    </div>
    <div>

       <div id="chart"></div>
        <asp:Chart id="Chart1" runat="server"/> 

    </div> 
         <div id="chart2"></div>
        <asp:Chart id="Chart2" runat="server"/> 

    </div> 
        <p runat="server">
    <asp:Button ID="returnBtn" OnClick="returnRedirect" Text="return" runat="server"/>
        </p>
    </form>
    </body>
</html>
