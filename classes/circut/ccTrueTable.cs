using SLCD.classes.database;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace SLCD.classes.circut
{
    public class ccTrueTable
    {
        public static List<string> tTable(string pid, int inputs)
        {
            List<string> tt = new List<string>();

            if (dbConnection.dbTest())
            {
                SQLiteDataReader input = dbProccess.readData(dbConnection.conn, "TB_Inputs", $"IN_CTID = {pid}");
                Random randIN = new Random();


                if (inputs >= 4)
                {
                    for (int i = 0; i < 100; i++)
                    {
                        int x = randIN.Next(0, 2); int y = randIN.Next(0, 2);
                        int w = randIN.Next(0, 2); int z = randIN.Next(0, 2);

                        sbyte[] inps = { (sbyte)x, (sbyte)y, (sbyte)w, (sbyte)z };


                        string res = ccProcess.circutProcess(inps, "X-Y-W-Z", 4, pid);

                        if (tt.Contains(res))
                        {
                            continue;
                        }
                        else
                        {
                            tt.Add(res);
                            continue;
                        }
                    }
                }
                if (inputs >= 3)
                {
                    for (int i = 0; i < 100; i++)
                    {
                        int x = randIN.Next(0, 2); int y = randIN.Next(0, 2);
                        int w = randIN.Next(0, 2);

                        sbyte[] inps = { (sbyte)x, (sbyte)y, (sbyte)w };


                        string res = ccProcess.circutProcess(inps, "X-Y-W", 3, pid);

                        if (tt.Contains(res))
                        {
                            continue;
                        }
                        else
                        {
                            tt.Add(res);
                            continue;
                        }
                    }
                }
                if (inputs >= 2)
                {
                    for (int i = 0; i < 100; i++)
                    {
                        int x = randIN.Next(0, 2); int y = randIN.Next(0, 2);

                        sbyte[] inps = { (sbyte)x, (sbyte)y };


                        string res = ccProcess.circutProcess(inps, "X-Y", 2, pid);

                        if (tt.Contains(res))
                        {
                            continue;
                        }
                        else
                        {
                            tt.Add(res);
                            continue;
                        }
                    }
                }
            }
            return tt;
        }
    }
}