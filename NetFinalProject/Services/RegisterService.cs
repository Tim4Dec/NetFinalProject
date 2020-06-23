using NetFinalProject.Models;
using NetFinalProject.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using CMD5;
using System.Runtime.InteropServices;
using ResultCOM;

namespace NetFinalProject.Services
{
    public class RegisterService
    {
        [DllImport("C:\\Users\\user\\source\\repos\\NetFinalProject\\Debug\\AuthCode.dll", EntryPoint = "Generate", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Generate(int len, ref byte str);


        public static string GenerateSms(int len)
        {
            /*
            string buffer = "0123456789";
            StringBuilder sb = new StringBuilder();
            Random r = new Random();
            int range = buffer.Length;
            for(int i = 0; i < len; i++)
            {
                sb.Append(buffer.Substring(r.Next(range), 1));
            }
            

            return sb.ToString();
            */
            byte[] bt = new byte[len];
            Generate(len, ref bt[0]);
            string authCode = System.Text.Encoding.Default.GetString(bt, 0, bt.Length); //将字节数组转换为字符串

            return authCode;
        }

        public async Task<Result> VerifyUsername(string name)
        {
            using(var db = new DBModel())
            {
                var user = await db.users.SingleOrDefaultAsync(x => x.username == name);
                if(user == null)
                {
                    return ResultUtil.Success();
                }
            }
            return ResultUtil.Error(ResultEnum.ResultType.HAVE_OCCUPIED);
        }

        public Result Register(string name, string password)
        {
            string encoded_pwd = Md5Encode.Encode(password);
            User user = new User
            {
                username = name,
                pwd = encoded_pwd,
            };


            using(var db = new DBModel())
            {
                db.users.Add(user);
                var result = db.SaveChangesAsync().IsCompleted;
                if(result == false)
                {
                    return ResultUtil.Error(ResultEnum.ResultType.HAVE_OCCUPIED);
                }
            }

            return ResultUtil.Success();
        }
    } 
}