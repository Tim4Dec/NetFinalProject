
using System.Runtime.InteropServices;
using static ResultCOM.ResultEnum;

namespace ResultCOM
{
    [ComVisible(true)]
    [Guid("EE1BAA9E-89B7-41A8-93A9-8578C94B7DA1")]
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