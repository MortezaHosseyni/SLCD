using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLCD.classes.circut
{
    public class ccOp
    {

        //Not
        public static sbyte notOP(sbyte x)
        {
            if (x == 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }


        //Or
        public static sbyte orOP(sbyte x, sbyte y)
        {
            sbyte f = (sbyte)(x | y);
            return f;
        }


        //And
        public static sbyte andOP(sbyte x, sbyte y)
        {
            sbyte f = (sbyte)(x & y);
            return f;
        }
    }
}