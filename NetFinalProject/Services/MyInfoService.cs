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
    public class MyInfoService
    {
        private readonly DBModel db = new DBModel();

        public async Task<Result> ModifyPwd(string oldPwd, string newPwd, int id)
        {
            var user = await db.users.SingleOrDefaultAsync(x => x.id == id && x.pwd == oldPwd);

            if(user == null)
            {
                return ResultUtil.Error(ResultEnum.ResultType.LOGIN_FAIL);
            }

            user.pwd = newPwd;
            await db.SaveChangesAsync();

            return ResultUtil.Success();
        }

        public async Task<Result> MyInfos(int id)
        {
            var user = await db.users.SingleOrDefaultAsync(x => x.id == id);

            if(user == null)
            {
                return ResultUtil.Error(ResultEnum.ResultType.NOT_FOUND);
            }

            user.pwd = null;
            return ResultUtil.Success(user);
        }
    }
}