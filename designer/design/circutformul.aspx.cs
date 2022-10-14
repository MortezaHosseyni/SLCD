using SLCD.classes.database;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SLCD.designer.design
{
    public partial class circutformul : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ctid = Request.QueryString["ctid"];
            string[] names = { "X", "Y", "W", "Z" };

            if (dbConnection.dbTest())
            {
                SQLiteDataReader circut = dbProccess.readData(dbConnection.conn, "TB_Circuts", $"CT_ID = {ctid}");
                circut.Read();

                for (int i = 0; i < (int)circut["CT_InputCount"]; i++)
                {
                    
                }
            }
        }
    }
}