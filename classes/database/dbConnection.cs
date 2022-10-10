using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Web;

namespace SLCD.classes.database
{
    public class dbConnection
    {
        public static string dbConn = @"Data Source=" + HttpRuntime.AppDomainAppPath + "\\classes\\database\\SLCD.db; Version=3; New=False; Compress=True; Read Only = False;";
        public static SQLiteConnection conn = new SQLiteConnection(dbConn);

        public static bool dbTest()
        {
            if (conn.State == ConnectionState.Closed)
            {
                try
                {
                    conn.Open();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
    }
}