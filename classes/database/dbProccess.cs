using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace SLCD.classes.database
{
    public class dbProccess
    {
        public static SQLiteDataReader readData(SQLiteConnection conn, string tbName, string tbCondition = "1 = 1")
        {
            SQLiteCommand cmd = new SQLiteCommand($"SELECT * FROM {tbName} WHERE {tbCondition}", conn);

            try
            {
                SQLiteDataReader data = cmd.ExecuteReader();
                return data;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}