using SLCD.classes.circut;
using SLCD.classes.database;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SLCD.designer
{
    public partial class post : System.Web.UI.Page
    {
        public SQLiteDataReader pData;
        public int cCount;
        public string pid;


        protected void Page_Load(object sender, EventArgs e)
        {
            //Get Post ID
            pid = Request.QueryString["pid"];

            //Fill Post Page
            fillData();

            //Check Inputs
            checkInputs();
        }






        public void fillData()
        {
            if (dbConnection.dbTest())
            {
                pData = dbProccess.readData(dbConnection.conn, "TB_Circuts", $"CT_ID = {pid}");

                while (pData.Read())
                {
                    Page.Title = (string)pData["CT_Name"];

                    img_PostImage.Alt = (string)pData["CT_Name"];
                    img_PostImage.Src = "../resources/pictures/" + (string)pData["CT_Picture"];

                    string inputs = pData["CT_InputCount"].ToString();
                    cCount = Convert.ToInt32(pData["CT_InputCount"]);

                    lbl_PostName.InnerText = (string)pData["CT_Name"];
                    lbl_PostInputs.InnerText = "Inputs: " + inputs;
                    lbl_PostFormul.InnerText = "Formul: " + (string)pData["CT_Formul"];
                }
            }
        }


        public void checkInputs()
        {
            switch (cCount)
            {
                case 2: inp_z.Visible = false; inp_w.Visible = false; break;
                case 3: inp_w.Visible = false; break;
                default: break;
            }
        }


        public void btn_Process_Click(object sender, EventArgs e)
        {
            sbyte[] inps = {
                Convert.ToSByte(inp_1.SelectedIndex),
                Convert.ToSByte(inp_2.SelectedIndex),
                Convert.ToSByte(inp_3.SelectedIndex),
                Convert.ToSByte(inp_4.SelectedIndex)
            };

            txt_results.Value = ccProcess.circutProcess(inps);
        }
    }
}