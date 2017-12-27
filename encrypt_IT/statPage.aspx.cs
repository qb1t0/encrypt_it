using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using System.Threading;

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
            catch (Exception)
            {

                return;
            }
            conn.Close();


            generateTables();
            string s = drawCharts();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", @"draw(" + "'"+s+"'" + ");", true);
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

        protected string drawCharts()
        {
            string s = "";

            foreach (var o in encTable)
            {
                s += o.ToString() + "|";
            }

            foreach (var o in decTable)
            {
                s += o.ToString() + "|";
            }
            return s;





        }

        protected void Chart1_Load(object sender, EventArgs e)
        {

        }
    }
}