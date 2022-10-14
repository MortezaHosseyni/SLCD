using SLCD.classes.database;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SLCD.designer.userarea
{
    public partial class posts : System.Web.UI.Page
    {
        public SQLiteDataReader pData;
        protected void Page_Load(object sender, EventArgs e)
        {
            string show = Request.QueryString["show"];

            if (dbConnection.dbTest())
            {
                if (show == "all")
                {
                    pData = dbProccess.readData(dbConnection.conn, "TB_Circuts");
                }
                if (show == "disabled")
                {
                    pData = dbProccess.readData(dbConnection.conn, "TB_Circuts", "CT_Enable = 0");
                }
            }
        }
    }
}