using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace encrypt_IT
{
    public partial class encrypt : System.Web.UI.Page
    {

        static readonly string inputAreaName = "inputArea";
        static readonly string sTypeName = "sType";
        static readonly string algorythmName = "Algorythm";
        static readonly string storageDirectory = @"D:\txt_examples\ServerStorage\";
        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlCommand cmd;
        string queryStr;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitMethod(object sender, EventArgs e)
        {
            string inputData = Request.Form[inputAreaName];
            string select1 = Request.Form[sTypeName];
            string select2 = Request.Form[algorythmName];

            int cryptTypeNumber = caseMethod(select2);

            bool encrOrDecr =
                (select1 == "s1") ? true : false;

            string message = "So: we are " + select1 + "ing with algo number:" + cryptTypeNumber.ToString() + " and the text is:" + inputData;

            //var script = "document.getElementById('outputBox').value = '" + message + "';";

            //ClientScript.RegisterStartupScript(typeof(string), "textvaluesetter", script, true);

            outputBox.InnerText = message;

            addToDB(encrOrDecr,cryptTypeNumber, inputData.Length);
        }

        private void addToDB(bool type, int cmethod, int size)
        {
            string connString = "server=127.0.0.1 ;user id=encryptuser; password=encrypt2017; database=encryptdb; ";

            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            queryStr = "";

            byte t = (type) ? (byte)0 : (byte)1;

            queryStr = "insert into encryptdb.customers (process,choosenmethod,textsize)" +
                "values('"+t.ToString()+"','"+cmethod.ToString()+"','"+size.ToString()+"')";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);

            cmd.ExecuteReader();

            conn.Close();
        }

  //       <connectionstrings>
  //  <add name = "encryptconnstring"
  //       connectionstrings="server=127.0.0.1;user id=encryptuser;password=encrypt2017;database=encryptdb;"
  //       providername="MySql.Hata.MySqlClient"/>
  //</connectionstrings>

        static int caseMethod(string s)
        {
            switch (s)
            {
                case "s1": return 1;
                case "s2": return 2;
                case "s3": return 3;
                case "s4": return 4;
                case "s5": return 5;
                case "s6": return 6;
                case "s7": return 7;
                case "s8": return 8;
                case "s9": return 9;
                default: return 0;
            }
        }

        protected void UploadBtn_Click(object sender, EventArgs e)
        {
            if (FileUpLoad1.HasFile)
            {
                FileUpLoad1.SaveAs(storageDirectory + FileUpLoad1.FileName);

                var s = new StreamReader(storageDirectory + FileUpLoad1.FileName);

                string text = "";
                while (!s.EndOfStream)
                {
                    text += s.ReadLine();
                    text += "\r\n";
                }

                s.Close();

                outputToInputTextArea(text);
                

            }
            else
            {
                //string message = "smth is wrong with ur file to upload!!!!";

                //outputToInputTextArea(message);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('file has not found')", true);
            }
        }

        void outputToInputTextArea(string text)
        {
            inputArea.Value = text;
        }

        protected void statsRedirect(object sender, EventArgs e)
        {
            Response.Redirect("statPage.aspx");
        }
    }
}