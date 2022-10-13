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
    public partial class index : System.Web.UI.MasterPage
    {
        public SQLiteDataReader cgData;
        public SQLiteDataReader ctData;
        public string sesionID;
        protected void Page_Load(object sender, EventArgs e)
        {
            sesionID = this.Session.SessionID; 
            if (dbConnection.dbTest())
            {
                cgData = dbProccess.readData(dbConnection.conn, "TB_Category");
            }
        }
        public void getPosts()
        {
            ctData = dbProccess.readData(dbConnection.conn, "TB_Circuts", $"CT_CategoryID = {cgData["CG_ID"]}");
        }
    }
}