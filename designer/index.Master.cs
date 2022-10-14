using SLCD.classes;
using SLCD.classes.database;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SLCD.designer
{
    public partial class index : System.Web.UI.MasterPage
    {
        public SQLiteDataReader cgData;
        public SQLiteDataReader ctData;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (dbConnection.dbTest())
            {
                cgData = dbProccess.readData(dbConnection.conn, "TB_Category");
            }

            checkLogin();
        }
        public void getPosts()
        {
            ctData = dbProccess.readData(dbConnection.conn, "TB_Circuts", $"CT_CategoryID = {cgData["CG_ID"]}");
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
                        lbl_Login.HRef = "userarea/userpanel.aspx";
                        lbl_Login.InnerText = logOn["LL_Username"].ToString();
                        return;
                    }
                    return;
                }
            }
        }
    }
}