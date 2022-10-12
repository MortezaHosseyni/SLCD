using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using SLCD.classes.circut;
using SLCD.classes.database;

namespace SLCD.classes.circut
{
    public class ccProcess
    {
        public static string circutProcess(sbyte[] input, string formul, int inCount, string lcID)
        {
            //return $"(NOT {input[0]} AND {input[1]}) AND ({input[2]} OR {input[3]}) = {    ccOp.andOP(ccOp.andOP(ccOp.notOP(input[0]), input[1]), ccOp.orOP(input[2], input[3]))     }";
            

            if (inCount >= 4)
            {
                int x = formul.IndexOf("X"); formul = formul.Remove(x, "X".Length).Insert(x, input[0].ToString());
                int y = formul.IndexOf("Y"); formul = formul.Remove(y, "Y".Length).Insert(y, input[1].ToString());
                int w = formul.IndexOf("W"); formul = formul.Remove(w, "W".Length).Insert(w, input[2].ToString());
                int z = formul.IndexOf("Z"); formul = formul.Remove(z, "Z".Length).Insert(z, input[3].ToString());

                return formul;
            }

            if (inCount >= 3)
            {
                int x = formul.IndexOf("X"); formul = formul.Remove(x, "X".Length).Insert(x, input[0].ToString());
                int y = formul.IndexOf("Y"); formul = formul.Remove(y, "Y".Length).Insert(y, input[1].ToString());
                int w = formul.IndexOf("W"); formul = formul.Remove(w, "W".Length).Insert(w, input[2].ToString());

                return formul;
            }

            if (inCount >= 2)
            {
                int x = formul.IndexOf("X"); formul = formul.Remove(x, "X".Length).Insert(x, input[0].ToString());
                int y = formul.IndexOf("Y"); formul = formul.Remove(y, "Y".Length).Insert(y, input[1].ToString());
                sbyte result = 0;

                if (dbConnection.dbTest())
                {
                    SQLiteDataReader data = dbProccess.readData(dbConnection.conn, "TB_Inputs", $"IN_CTID = {lcID}");
                    int  xID = 0 , yID = 0,
                        xNOT = input[0], yNOT = input[1],
                        xAND = 0, yAND = 0,
                         xOR = 0, yOR = 0;

                    

                    while (data.Read())
                    {
                        //X
                        if (data["IN_Name"].ToString() == "X")
                        {
                            xID = Convert.ToInt32(data["IN_ID"]);
                            if (Convert.ToInt32(data["IN_NOT"]) == 1)
                            {
                                xNOT = ccOp.notOP(input[0]);
                            }
                            if (data["IN_AND"].ToString() != "")
                            {
                                xAND = Convert.ToInt32(data["IN_AND"]);
                            }
                            if (data["IN_OR"].ToString() != "")
                            {
                                xOR = Convert.ToInt32(data["IN_OR"]);
                            }
                        }
                        //X

                        //Y
                        if (data["IN_Name"].ToString() == "Y")
                        {
                            yID = Convert.ToInt32(data["IN_ID"]);
                            if (Convert.ToInt32(data["IN_NOT"]) == 1)
                            {
                                yNOT = ccOp.notOP(input[1]);
                            }
                            if (data["IN_AND"].ToString() != "")
                            {
                                yAND = Convert.ToInt32(data["IN_AND"]);
                            }
                            if (data["IN_OR"].ToString() != "")
                            {
                                yOR = Convert.ToInt32(data["IN_OR"]);
                            }
                        }
                        //Y

                        //Process
                        if (xAND == yID || yAND == xID)
                        {
                            result = ccOp.andOP((sbyte)xNOT, (sbyte)yNOT);
                        }
                        if (xOR == yID || yOR == xID)
                        {
                            result = ccOp.orOP((sbyte)xNOT, (sbyte)yNOT);
                        }
                    }
                }
                return formul + " = " + result.ToString();
            }
            return formul;
        }
    }
}