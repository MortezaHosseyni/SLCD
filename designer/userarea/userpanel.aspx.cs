using SLCD.classes.database;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SLCD.designer.userarea
{
    public partial class userpanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionIDManager manager = new SessionIDManager();
            string sid = manager.GetSessionID(HttpContext.Current);
            if (dbConnection.dbTest())
            {
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
}