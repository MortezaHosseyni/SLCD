using SLCD.classes.circut;
using SLCD.classes.database;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SLCD.designer
{
    public partial class post : System.Web.UI.Page
    {
        public SQLiteDataReader pData;
        public SQLiteDataReader tData;

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

            //Check Login
            checkLogin();

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
                    lbl_PostInputs.InnerText = inputs;
                    lbl_PostFormul.InnerText = (string)pData["CT_Formul"];
                }
            }
        }


        public void checkInputs()
        {
            switch (cCount)
            {
                case 2: inp_w.Visible = false; inp_z.Visible = false; break;
                case 3: inp_z.Visible = false; break;
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

            txt_results.Value = ccProcess.circutProcess(inps, lbl_PostFormul.InnerText, cCount, pid);
        }



        public void checkLogin()
        {
            SessionIDManager manager = new SessionIDManager();
            string sid = manager.GetSessionID(HttpContext.Current);
            if (dbConnection.dbTest())
            {
                SQLiteDataReader logOn = dbProccess.readData(dbConnection.conn, "TB_LoginLog", $"LL_SessionID = '{sid}'");
                if (logOn.StepCount <= 0)
                {
                    return;
                }
                if (logOn.StepCount > 0)
                {
                    logOn.Read();
                    if (logOn["LL_LogoutDate"].ToString() == "")
                    {
                        div_Enable.Visible = true;
                        return;
                    }
                    return;
                }
            }
        }

        protected void btn_Enable_Click(object sender, EventArgs e)
        {
            if (dbConnection.dbTest())
            {
                if (dbProccess.updateData(dbConnection.conn, "TB_Circuts", "CT_Enable = 1", $"CT_ID = {pid}"))
                {
                    Response.Write("<script> alert('Post enabled!') </script>");
                    Response.End();
                }
            }
        }

        protected void btn_Disable_Click(object sender, EventArgs e)
        {
            if (dbConnection.dbTest())
            {
                if (dbProccess.updateData(dbConnection.conn, "TB_Circuts", "CT_Enable = 0", $"CT_ID = {pid}"))
                {
                    Response.Write("<script> alert('Post disabled!') </script>");
                    Response.End();
                }
            }
        }

        protected void btn_TrueTable_Click(object sender, EventArgs e)
        {
            tData = dbProccess.readData(dbConnection.conn, "TB_TrueTable", $"TT_CircutID = {pid}");
            if (tData.StepCount > 0)
            {
                return;
            }
            else
            {
                if (Convert.ToInt32(lbl_PostInputs.InnerText) >= 4)
                {
                    List<string> tab = ccTrueTable.tTable(pid, Convert.ToInt32(lbl_PostInputs.InnerText));

                    foreach (var item in tab)
                    {
                        string x = item.Split('-')[0];
                        string y = item.Split('-')[1];
                        string w = item.Split('-')[2];
                        string z = item.Split('-')[3].Split('=')[0];
                        string result = item.Split('=')[1];

                        dbProccess.saveData(dbConnection.conn, "TB_TrueTable", "TT_X, TT_Y, TT_W, TT_Z, TT_Result, TT_CircutID", $"{x}, {y}, {w}, {z}, {result}, {Convert.ToInt32(pid)}");
                    }
                    tData = dbProccess.readData(dbConnection.conn, "TB_TrueTable", $"TT_CircutID = {pid}");
                }

                if (Convert.ToInt32(lbl_PostInputs.InnerText) >= 3)
                {
                    List<string> tab = ccTrueTable.tTable(pid, Convert.ToInt32(lbl_PostInputs.InnerText));

                    foreach (var item in tab)
                    {
                        string x = item.Split('-')[0];
                        string y = item.Split('-')[1];
                        string w = item.Split('-')[2].Split('=')[0];
                        string result = item.Split('=')[1];

                        dbProccess.saveData(dbConnection.conn, "TB_TrueTable", "TT_X, TT_Y, TT_W, TT_Result, TT_CircutID", $"{x}, {y}, {w}, {result}, {Convert.ToInt32(pid)}");
                    }
                    tData = dbProccess.readData(dbConnection.conn, "TB_TrueTable", $"TT_CircutID = {pid}");
                }

                if (Convert.ToInt32(lbl_PostInputs.InnerText) >= 2)
                {
                    List<string> tab = ccTrueTable.tTable(pid, Convert.ToInt32(lbl_PostInputs.InnerText));

                    foreach (var item in tab)
                    {
                        string x = item.Split('-')[0];
                        string y = item.Split('-')[1].Split('=')[0];
                        string result = item.Split('=')[1];

                        dbProccess.saveData(dbConnection.conn, "TB_TrueTable", "TT_X, TT_Y, TT_Result, TT_CircutID", $"{x}, {y}, {result}, {Convert.ToInt32(pid)}");
                    }
                    tData = dbProccess.readData(dbConnection.conn, "TB_TrueTable", $"TT_CircutID = {pid}");
                }
            }
        }
    }
}