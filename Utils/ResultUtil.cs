using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static NetFinalProject.Utils.ResultEnum;

namespace NetFinalProject.Utils
{
    public class ResultUtil
    {
        public static Result Success(object obj)
        {
            Result result = new Result();
            result.Code = (int)ResultType.SUCCESS;
            result.Data = obj;
            result.Msg = ResultMsg[ResultType.SUCCESS];
            return result;
        }

        public static Result Success()
        {
            return Success(null);
        }

        public static Result Error(ResultType type)
        {
            Result result = new Result();
            result.Code = (int)type;
            result.Msg = ResultMsg[type];
            return result;
        }
    }
}