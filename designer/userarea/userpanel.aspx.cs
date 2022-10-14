using SLCD.classes.database;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SLCD.designer.userarea
{
    public partial class userpanel : System.Web.UI.Page
    {
        public SQLiteDataReader pData;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (dbConnection.dbTest())
            {
                isLogin();

                loadPosts();
            }
        }

        public void loadPosts()
        {
            pData = dbProccess.readData(dbConnection.conn, "TB_Circuts");
        }

        public void isLogin()
        {
            SessionIDManager manager = new SessionIDManager();
            string sid = manager.GetSessionID(HttpContext.Current);
            SQLiteDataReader logOn = dbProccess.readData(dbConnection.conn, "TB_LoginLog", $"LL_SessionID = '{sid}'");
            if (logOn.StepCount <= 0)
            {
                Response.Redirect("../userarea/login.aspx");
                return;
            }
            if (logOn.StepCount > 0)
            {
                logOn.Read();
                if (logOn["LL_LogoutDate"].ToString() == "")
                {
                    return;
                }
                else
                {
                    Response.Redirect("../userarea/login.aspx");
                }
                return;
            }
        }
    }
}