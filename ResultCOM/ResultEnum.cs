using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;


namespace ResultCOM
{
    public class ResultEnum
    {
        [ComVisible(true)]
        [Guid("9187C434-73DC-4CC9-9D82-63A6A0619A58")]
        public enum ResultType
        {
            SUCCESS = 200,
            FAIL = 400,
            UNAUTHORIZED = 401,
            NOT_FOUND = 404,
            HAVE_OCCUPIED = 5,
            LOGIN_FAIL = 1,
            NOT_LOGIN = 2,
            NOT_RECORD = 7,
        };

        public static Dictionary<ResultType, string> ResultMsg = new Dictionary<ResultType, string> {
            { ResultType.SUCCESS, "success" },
            { ResultType.FAIL, "fail" },
            { ResultType.UNAUTHORIZED, "unauthorized" },
            { ResultType.NOT_FOUND, "not found" },
            { ResultType.LOGIN_FAIL, "invalid password ot user" },
            { ResultType.NOT_LOGIN, "login please" },
            { ResultType.HAVE_OCCUPIED, "have been occupied" },

        };


    }
}
