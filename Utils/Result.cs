using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetFinalProject.Utils
{
    public class Result
    {
        public int Code { get; set; }
        public string Msg { get; set; }
        public object Data { get; set; }

        public Result()
        {

        }

        public Result(int code, string msg, object data)
        {
            Code = code;
            Msg = msg;
            Data = data;
        }


    }
}