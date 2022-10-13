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

                sbyte resultWZ = 0, resultYZ = 0, resultYW = 0, resultXZ = 0, resultXW = 0, resultXY = 0, resultTotal = 0;

                if (dbConnection.dbTest())
                {
                    SQLiteDataReader data = dbProccess.readData(dbConnection.conn, "TB_Inputs", $"IN_CTID = {lcID}");
                    int xID = 0, yID = 0, wID = 0, zID = 0,
                        xNOT = input[0], yNOT = input[1], wNOT = input[2], zNOT = input[3],
                        xAND = 0, yAND = 0, wAND = 0, zAND = 0,
                         xOR = 0, yOR = 0, wOR = 0, zOR = 0;
                    
                    string twiName = "";
                    int twiOP = 0; //0-> AND, 1-> OR

                    while (data.Read())
                    {
                        #region ReadData
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

                        //W
                        if (data["IN_Name"].ToString() == "W")
                        {
                            wID = Convert.ToInt32(data["IN_ID"]);
                            if (Convert.ToInt32(data["IN_NOT"]) == 1)
                            {
                                wNOT = ccOp.notOP(input[2]);
                            }
                            if (data["IN_AND"].ToString() != "")
                            {
                                wAND = Convert.ToInt32(data["IN_AND"]);
                            }
                            if (data["IN_OR"].ToString() != "")
                            {
                                wOR = Convert.ToInt32(data["IN_OR"]);
                            }
                        }

                        //Z
                        if (data["IN_Name"].ToString() == "Z")
                        {
                            zID = Convert.ToInt32(data["IN_ID"]);
                            if (Convert.ToInt32(data["IN_NOT"]) == 1)
                            {
                                zNOT = ccOp.notOP(input[3]);
                            }
                            if (data["IN_AND"].ToString() != "")
                            {
                                zAND = Convert.ToInt32(data["IN_AND"]);
                            }
                            if (data["IN_OR"].ToString() != "")
                            {
                                zOR = Convert.ToInt32(data["IN_OR"]);
                            }
                        }

                        if (data["IN_IsAND"] != null)
                        {
                            twiName = data["IN_Name"].ToString();
                            twiOP = 0;
                        }
                        else if (data["IN_IsOR"] != null)
                        {
                            twiName = data["IN_Name"].ToString();
                            twiOP = 1;
                        }

                        #endregion
                    }

                    #region Process 1
                    if (xAND == yID || yAND == xID) //AND
                    {
                        resultXY = ccOp.andOP((sbyte)xNOT, (sbyte)yNOT);
                    }

                    if (xAND == wID || wAND == xID)
                    {
                        resultXW = ccOp.andOP((sbyte)xNOT, (sbyte)wNOT);
                    }

                    if (xAND == zID || zAND == xID)
                    {
                        resultXZ = ccOp.andOP((sbyte)xNOT, (sbyte)zNOT);
                    }





                    if (yAND == wID || wAND == yID)
                    {
                        resultYW = ccOp.andOP((sbyte)yNOT, (sbyte)wNOT);
                    }

                    if (yAND == zID || zAND == yID)
                    {
                        resultYZ = ccOp.andOP((sbyte)yNOT, (sbyte)zNOT);
                    }



                    if (wAND == zID || zAND == wID)
                    {
                        resultWZ = ccOp.andOP((sbyte)wNOT, (sbyte)zNOT);
                    }




                    if (xOR == yID || yOR == xID) //OR
                    {
                        resultXY = ccOp.orOP((sbyte)xNOT, (sbyte)yNOT);
                    }

                    if (xOR == wID || wOR == xID)
                    {
                        resultXW = ccOp.orOP((sbyte)xNOT, (sbyte)wNOT);
                    }

                    if (xOR == zID || zOR == xID)
                    {
                        resultXZ = ccOp.orOP((sbyte)xNOT, (sbyte)zNOT);
                    }





                    if (yOR == wID || wOR == yID)
                    {
                        resultYW = ccOp.orOP((sbyte)yNOT, (sbyte)wNOT);
                    }

                    if (yOR == zID || zOR == yID)
                    {
                        resultYZ = ccOp.orOP((sbyte)yNOT, (sbyte)zNOT);
                    }



                    if (wOR == zID || zOR == wID)
                    {
                        resultWZ = ccOp.orOP((sbyte)wNOT, (sbyte)zNOT);
                    }
                    #endregion

                    #region Process 2
                    switch (twiName)
                    {
                        case "YZ-WZ":
                        case "WZ-YZ":
                            if (twiOP == 0)
                            {
                                resultTotal = ccOp.andOP(resultWZ, resultYZ);
                            }
                            if (twiOP == 1)
                            {
                                resultTotal = ccOp.orOP(resultWZ, resultYZ);
                            }
                            break;
                        case "YW-WZ":
                        case "WZ-YW":
                            if (twiOP == 0)
                            {
                                resultTotal = ccOp.andOP(resultWZ, resultYW);
                            }
                            if (twiOP == 1)
                            {
                                resultTotal = ccOp.orOP(resultWZ, resultYW);
                            }
                            break;
                        case "XZ-WZ":
                        case "WZ-XZ":
                            if (twiOP == 0)
                            {
                                resultTotal = ccOp.andOP(resultWZ, resultXZ);
                            }
                            if (twiOP == 1)
                            {
                                resultTotal = ccOp.orOP(resultWZ, resultXZ);
                            }
                            break;
                        case "XW-WZ":
                        case "WZ-XW":
                            if (twiOP == 0)
                            {
                                resultTotal = ccOp.andOP(resultWZ, resultXW);
                            }
                            if (twiOP == 1)
                            {
                                resultTotal = ccOp.orOP(resultWZ, resultXW);
                            }
                            break;
                        case "XY-WZ":
                        case "WZ-XY":
                            if (twiOP == 0)
                            {
                                resultTotal = ccOp.andOP(resultWZ, resultXY);
                            }
                            if (twiOP == 1)
                            {
                                resultTotal = ccOp.orOP(resultWZ, resultXY);
                            }
                            break;


                        case "YW-YZ":
                        case "YZ-YW":
                            if (twiOP == 0)
                            {
                                resultTotal = ccOp.andOP(resultYZ, resultYW);
                            }
                            if (twiOP == 1)
                            {
                                resultTotal = ccOp.orOP(resultYZ, resultYW);
                            }
                            break;
                        case "XZ-YZ":
                        case "YZ-XZ":
                            if (twiOP == 0)
                            {
                                resultTotal = ccOp.andOP(resultYZ, resultXZ);
                            }
                            if (twiOP == 1)
                            {
                                resultTotal = ccOp.orOP(resultYZ, resultXZ);
                            }
                            break;
                        case "XW-YZ":
                        case "YZ-XW":
                            if (twiOP == 0)
                            {
                                resultTotal = ccOp.andOP(resultYZ, resultXW);
                            }
                            if (twiOP == 1)
                            {
                                resultTotal = ccOp.orOP(resultYZ, resultXW);
                            }
                            break;
                        case "XY-YZ":
                        case "YZ-XY":
                            if (twiOP == 0)
                            {
                                resultTotal = ccOp.andOP(resultYZ, resultXY);
                            }
                            if (twiOP == 1)
                            {
                                resultTotal = ccOp.orOP(resultYZ, resultXY);
                            }
                            break;



                        case "XZ-YW":
                        case "YW-XZ":
                            if (twiOP == 0)
                            {
                                resultTotal = ccOp.andOP(resultYW, resultXZ);
                            }
                            if (twiOP == 1)
                            {
                                resultTotal = ccOp.orOP(resultYW, resultXZ);
                            }
                            break;
                        case "XW-YW":
                        case "YW-XW":
                            if (twiOP == 0)
                            {
                                resultTotal = ccOp.andOP(resultYW, resultXW);
                            }
                            if (twiOP == 1)
                            {
                                resultTotal = ccOp.orOP(resultYW, resultXW);
                            }
                            break;
                        case "XY-YW":
                        case "YW-XY":
                            if (twiOP == 0)
                            {
                                resultTotal = ccOp.andOP(resultYW, resultXY);
                            }
                            if (twiOP == 1)
                            {
                                resultTotal = ccOp.orOP(resultYW, resultXY);
                            }
                            break;



                        case "XW-XZ":
                        case "XZ-XW":
                            if (twiOP == 0)
                            {
                                resultTotal = ccOp.andOP(resultXZ, resultXW);
                            }
                            if (twiOP == 1)
                            {
                                resultTotal = ccOp.orOP(resultXZ, resultXW);
                            }
                            break;
                        case "XY-XZ":
                        case "XZ-XY":
                            if (twiOP == 0)
                            {
                                resultTotal = ccOp.andOP(resultXZ, resultXY);
                            }
                            if (twiOP == 1)
                            {
                                resultTotal = ccOp.orOP(resultXZ, resultXY);
                            }
                            break;


                        case "XY-XW":
                        case "XW-XY":
                            if (twiOP == 0)
                            {
                                resultTotal = ccOp.andOP(resultXW, resultXY);
                            }
                            if (twiOP == 1)
                            {
                                resultTotal = ccOp.orOP(resultXW, resultXY);
                            }
                            break;
                        default: break;
                    }
                    #endregion

                }
                return formul + " = " + resultTotal.ToString();
            }

            if (inCount >= 3)
            {
                int x = formul.IndexOf("X"); formul = formul.Remove(x, "X".Length).Insert(x, input[0].ToString());
                int y = formul.IndexOf("Y"); formul = formul.Remove(y, "Y".Length).Insert(y, input[1].ToString());
                int w = formul.IndexOf("W"); formul = formul.Remove(w, "W".Length).Insert(w, input[2].ToString());

                sbyte result1 = 0, result2 = 0, result3 = 0;

                if (dbConnection.dbTest())
                {
                    SQLiteDataReader data = dbProccess.readData(dbConnection.conn, "TB_Inputs", $"IN_CTID = {lcID}");
                    int xID = 0, yID = 0, wID = 0,
                        xNOT = input[0], yNOT = input[1], wNOT = input[2],
                        xAND = 0, yAND = 0, wAND = 0,
                         xOR = 0, yOR = 0, wOR = 0;



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

                        //W
                        if (data["IN_Name"].ToString() == "W")
                        {
                            wID = Convert.ToInt32(data["IN_ID"]);
                            if (Convert.ToInt32(data["IN_NOT"]) == 1)
                            {
                                wNOT = ccOp.notOP(input[2]);
                            }
                            if (data["IN_AND"].ToString() != "")
                            {
                                wAND = Convert.ToInt32(data["IN_AND"]);
                            }
                            if (data["IN_OR"].ToString() != "")
                            {
                                wOR = Convert.ToInt32(data["IN_OR"]);
                            }
                        }
                        //W

                        //Process
                        #region Process 1
                        if (xAND == yID || yAND == xID) //AND
                        {
                            result1 = ccOp.andOP(input[0], input[1]);
                        }
                        else
                        {
                            result2 = input[2];
                        }
                        if (xAND == wID || wAND == xID)
                        {
                            result1 = ccOp.andOP(input[0], input[2]);
                        }
                        else
                        {
                            result2 = input[1];
                        }
                        if (yAND == wID || wAND == yID)
                        {
                            result1 = ccOp.andOP(input[1], input[2]);
                        }
                        else
                        {
                            result2 = input[0];
                        }

                        if (xOR == yID || yOR == xID) //OR
                        {
                            result1 = ccOp.orOP(input[0], input[1]);
                        }
                        else
                        {
                            result2 = input[2];
                        }
                        if (xOR == wID || wOR == xID)
                        {
                            result1 = ccOp.orOP(input[0], input[2]);
                        }
                        else
                        {
                            result2 = input[1];
                        }
                        if (yOR == wID || wOR == yID)
                        {
                            result1 = ccOp.orOP(input[1], input[2]);
                        }
                        else
                        {
                            result2 = input[0];
                        }
                        #endregion

                        #region Process 2
                        if (result2 == input[2])
                        {
                            if (xAND == wID && yAND == wID)
                            {
                                result3 = ccOp.andOP(result1, result2);
                            }
                            if (xOR == wID && yOR == wID)
                            {
                                result3 = ccOp.orOP(result1, result2);
                            }
                        }
                        if (result2 == input[1])
                        {
                            if (xAND == yID && wAND == yID)
                            {
                                result3 = ccOp.andOP(result1, result2);
                            }
                            if (xOR == yID && wOR == yID)
                            {
                                result3 = ccOp.orOP(result1, result2);
                            }
                        }
                        if (result2 == input[0])
                        {
                            if (yAND == xID && wAND == xID)
                            {
                                result3 = ccOp.andOP(result1, result2);
                            }
                            if (yOR == xID && wOR == xID)
                            {
                                result3 = ccOp.orOP(result1, result2);
                            }
                        }
                        #endregion
                    }
                }
                return formul + " = " + result3.ToString();
            }

            if (inCount >= 2)
            {
                int x = formul.IndexOf("X"); formul = formul.Remove(x, "X".Length).Insert(x, input[0].ToString());
                int y = formul.IndexOf("Y"); formul = formul.Remove(y, "Y".Length).Insert(y, input[1].ToString());
                sbyte result = 0;

                if (dbConnection.dbTest())
                {
                    SQLiteDataReader data = dbProccess.readData(dbConnection.conn, "TB_Inputs", $"IN_CTID = {lcID}");
                    int xID = 0, yID = 0,
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