using NetFinalProject.Models;
using NetFinalProject.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace NetFinalProject.Services
{
    public class LoginService
    {
        public async Task<Result> Login(string name, string pwd)
        {
            using (var db = new DBModel())
            {
                var user = await db.users.SingleOrDefaultAsync(x => x.username == name && x.pwd == pwd);

                if (user == null)
                {
                    return ResultUtil.Error(ResultEnum.ResultType.LOGIN_FAIL);
                }

                return ResultUtil.Success(new UserWrapper(user));
            }

        }
    }
}