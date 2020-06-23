

using System.Runtime.InteropServices;

namespace ResultCOM
{
    [ComVisible(true)]
    [Guid("64024317-B427-482C-8C7D-24E9E402619F")]
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