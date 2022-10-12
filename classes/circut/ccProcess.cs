using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SLCD.classes.circut;

namespace SLCD.classes.circut
{
    public class ccProcess
    {
        public static string circutProcess(sbyte[] input, string formul, int inCount)
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
                
                return formul;
            }

            return "";
        }
    }
}