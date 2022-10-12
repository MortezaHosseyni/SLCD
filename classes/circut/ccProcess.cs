using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SLCD.classes.circut;

namespace SLCD.classes.circut
{
    public class ccProcess
    {
        public static string circutProcess(sbyte[] input)
        {
            return $"(NOT {input[0]} AND {input[1]}) AND ({input[2]} OR {input[3]}) = {    ccOp.andOP(ccOp.andOP(ccOp.notOP(input[0]), input[1]), ccOp.orOP(input[2], input[3]))     }";
        }
    }
}