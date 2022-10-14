using SLCD.classes.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SLCD.designer.userarea
{
    public partial class user : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btn_LogOut_Click(object sender, EventArgs e)
        {
            DateTime toDay = DateTime.Now;
            SessionIDManager manager = new SessionIDManager();
            string sid = manager.GetSessionID(HttpContext.Current);

            if (dbConnection.dbTest())
            {
                if (dbProccess.updateData(dbConnection.conn, "TB_LoginLog", $"LL_LogoutDate = '{toDay}'", $"LL_SessionID = '{sid}' AND LL_LogoutDate IS NULL"))
                {
                    Response.Redirect("../../designer/home.aspx");
                }
            }
        }
    }
}