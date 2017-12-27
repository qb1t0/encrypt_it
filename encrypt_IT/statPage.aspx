<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="statPage.aspx.cs" Inherits="encrypt_IT.statPage" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" runat="server">
<head runat="server">
    <meta charset="utf-8" />
    <title>Encrypt it</title>
    <link rel="stylesheet" href="CSS/style.css" />
    
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script>
        var globalArray;
        var values;
         function drawSarahChart() {

            
          
          // Create the data table for Sarah's pizza.


          var data = new google.visualization.DataTable();
          data.addColumn('string', 'Methods');
          data.addColumn('number', 'Times');
          
          for (var i = 0; values[i] ; i++) {
              console.log(values[i]);
              values[i] = parseInt(values[i]);
          }
          data.addRows([
            ['3DES', values[0]],
            ['AES', values[1]],
            ['Blowfish', values[2]],
            ['Twofish', values[3]],
            ['IDEA', values[4]],
            ['MD5', values[5]],
            ['SHA 1', values[6]],
            ['HMAC', values[7]],
            ['RSA Security: RC4', values[8]],
          ]);

          // Set options for Sarah's pie chart.
          var options = {
              title: 'Encrypt',
              width: 450,
              height: 300,
              backgroundColor: ['f5f7ff'],
              is3D: true,
          };

          // Instantiate and draw the chart for Sarah's pizza.
          var chart = new google.visualization.PieChart(document.getElementById('encrypt_div'));
          chart.draw(data, options);
      }

      // Callback that draws the pie chart for Anthony's pizza.
      function drawAnthonyChart() {
         
          // Create the data table for Anthony's pizza.
          var data = new google.visualization.DataTable();
          data.addColumn('string', 'Methods');
          data.addColumn('number', 'Times');
          
          data.addRows([
            ['3DES', values[9]],
            ['AES', values[10]],
            ['Blowfish', values[11]],
            ['Twofish', values[12]],
            ['IDEA', values[13]],
            ['MD5', values[14]],
            ['SHA 1', values[15]],
            ['HMAC', values[16]],
            ['RSA Security: RC4', values[17]],
          ]);

          // Set options for Anthony's pie chart.
          var options = {
              title: 'Decrypt',
              width: 450,
              height: 300,
              backgroundColor: ['f5f7ff'],
              is3D: true,
          };

          // Instantiate and draw the chart for Anthony's pizza.
          var chart = new google.visualization.PieChart(document.getElementById('decrypt_div'));
          chart.draw(data, options);
      }
        
 function draw(array) {
             
     globalArray = array;
     values = array.split("|");
     

            // Load Charts and the corechart package.
            google.charts.load('current', { 'packages': ['corechart'] });

            // Draw the pie chart for Sarah's pizza when Charts is loaded.
            google.charts.setOnLoadCallback(drawSarahChart);

            // Draw the pie chart for the Anthony's pizza when Charts is loaded.
            google.charts.setOnLoadCallback(drawAnthonyChart);
            return array;
        }
    </script>




</head>
     
<body runat="server">
    <form id="input1" runat="server">
       <asp:HiddenField ID="ValueHiddenField" Value="" runat="server" />
        
        <script type="text/javascript">
        
       
        // Callback that draws the pie chart for Sarah's pizza.
      
    </script>
        <div class="top_hat">
            <a>Encrypt It</a>
        </div>
        <article>
            <!--Table and divs that hold the pie charts-->
           
            <table class="columns">
                <tr>
                    <td>
                        <div id="encrypt_div" style=""></div>
                    </td>
                    <td>
                        <div id="decrypt_div" style=""></div>
                    </td>
                </tr>

            </table>
            <a href="encrypt.aspx">Get back to encrypting/decrypting stuff</a>
        </article>
        <footer runat="server">
            &copy !23.1415 2017
        
        </footer>
    </form>
</body>
</html>
