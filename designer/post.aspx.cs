using SLCD.classes.database;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SLCD.designer
{
    public partial class post : System.Web.UI.Page
    {
        public SQLiteDataReader pData;
        public int cCount;
        protected void Page_Load(object sender, EventArgs e)
        {
            string pid = Request.QueryString["pid"];
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
    }
}