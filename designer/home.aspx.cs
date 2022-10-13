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
    public partial class home : System.Web.UI.Page
    {
        public SQLiteDataReader pData;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (dbConnection.dbTest())
            {
                pData = dbProccess.readData(dbConnection.conn, "TB_Circuts");
            }
        }
    }
}