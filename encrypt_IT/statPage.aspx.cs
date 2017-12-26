using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace encrypt_IT
{
    public partial class statPage : System.Web.UI.Page
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlCommand cmd;
        MySql.Data.MySqlClient.MySqlDataReader reader;
        string queryStr;
        string name;

        List<Customer> customers;
        int[] encTable;
        int[] decTable;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string connString = "server=127.0.0.1 ;user id=encryptuser; password=encrypt2017; database=encryptdb; ";
                conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
                conn.Open();
                queryStr = "";
                queryStr = "SELECT * FROM encryptdb.customers;";
                cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);

                reader = cmd.ExecuteReader();
                name = "";
                customers = new List<Customer>();
                while (reader.HasRows && reader.Read())
                {
                    name = reader.GetString(reader.GetOrdinal("process")) + "|" +
                        reader.GetString(reader.GetOrdinal("choosenmethod")) + "|" +
                        reader.GetString(reader.GetOrdinal("textsize"));

                    string[] info = name.Split('|');
                    customers.Add(new Customer(Convert.ToInt32(info[0]), Convert.ToInt32(info[1]), Convert.ToInt32(info[2])));

                }
            }
            catch (Exception ex)
            {
                statusTextBox.Text = ex.ToString();
                return;
            }
            conn.Close();

            statusTextBox.Text = "data has been received from db";
            generateTables();
            drawCharts();
        }

        protected void returnRedirect(object sender, EventArgs e)
        {
            Response.Redirect("encrypt.aspx");
        }

        protected void generateTables()
        {
            encTable = new int[9];
            decTable = new int[9];

            foreach (Customer o in customers)
            {
                if (o.Process == 0)
                {
                    encTable[o.ChoosenMethod - 1]++;
                }
                else
                {
                    decTable[o.ChoosenMethod - 1]++;
                }
            }
        }

        protected void drawCharts()
        {
           int [] yVal = encTable;
            string[] xName = { "3DES", "AES", "Blowfish", "Twofish", "IDEA", "MD5", "SHA 1", "HMAC", "RSA Security: RC4" };

            //CREATE THE CHART
            // Don't need to create the chart because it's a control!

            //BIND THE DATA TO THE CHART
            Chart1.Series.Add(new Series());
            Chart1.Series[0].Points.DataBindXY(xName, yVal);

            //SET THE CHART TYPE TO BE PIE
            Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Pie;
            Chart1.Series[0]["PieLabelStyle"] = "Outside";
            Chart1.Series[0]["PieStartAngle"] = "-90";

            //SET THE COLOR PALETTE FOR THE CHART TO BE A PRESET OF NONE 
            //DEFINE OUR OWN COLOR PALETTE FOR THE CHART 
            Chart1.Palette = System.Web.UI.DataVisualization.Charting.ChartColorPalette.None;
            Chart1.PaletteCustomColors = new Color[] { Color.Blue, Color.Red ,Color.Green, Color.Gold, Color.Fuchsia, Color.Khaki, Color.LightCoral, Color.Magenta, Color.MistyRose };

            //SET THE IMAGE OUTPUT TYPE TO BE JPEG
            Chart1.ImageType = System.Web.UI.DataVisualization.Charting.ChartImageType.Jpeg;

            //ADD A PLACE HOLDER CHART AREA TO THE CHART
            //SET THE CHART AREA TO BE 3D
            Chart1.ChartAreas.Add(new ChartArea());
            Chart1.ChartAreas[0].Area3DStyle.Enable3D = true;

            //ADD A PLACE HOLDER LEGEND TO THE CHART
            //DISABLE THE LEGEND
            Chart1.Legends.Add(new Legend());
            Chart1.Legends[0].Enabled = false;


            ///////////////////////////////////////////////

            yVal = decTable;
            

            //CREATE THE CHART
            // Don't need to create the chart because it's a control!

            //BIND THE DATA TO THE CHART
            Chart2.Series.Add(new Series());
            Chart2.Series[0].Points.DataBindXY(xName, yVal);
                 
            //SET2THE CHART TYPE TO BE PIE
            Chart2.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Pie;
            Chart2.Series[0]["PieLabelStyle"] = "Outside";
            Chart2.Series[0]["PieStartAngle"] = "-90";
                 
            //SET2THE COLOR PALETTE FOR THE CHART TO BE A PRESET OF NONE 
            //DEF2NE OUR OWN COLOR PALETTE FOR THE CHART 
            Chart2.Palette = System.Web.UI.DataVisualization.Charting.ChartColorPalette.None;
            Chart2.PaletteCustomColors = new Color[] { Color.Blue, Color.Red, Color.Green, Color.Gold, Color.Fuchsia, Color.Khaki, Color.LightCoral, Color.Magenta, Color.MistyRose };
                 
            //SET2THE IMAGE OUTPUT TYPE TO BE JPEG
            Chart2.ImageType = System.Web.UI.DataVisualization.Charting.ChartImageType.Jpeg;
                 
            //ADD2A PLACE HOLDER CHART AREA TO THE CHART
            //SET2THE CHART AREA TO BE 3D
            Chart2.ChartAreas.Add(new ChartArea());
            Chart2.ChartAreas[0].Area3DStyle.Enable3D = true;
                 
            //ADD2A PLACE HOLDER LEGEND TO THE CHART
            //DIS2BLE THE LEGEND
            Chart2.Legends.Add(new Legend());
            Chart2.Legends[0].Enabled = false;
        }

        protected void Chart1_Load(object sender, EventArgs e)
        {

        }
    }
}