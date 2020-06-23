using NetFinalProject.Models;
using NetFinalProject.Requests;
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

            return ResultUtil.Success(new UserWrapper(user));
        }

        public async Task<Result> MySpeech(int id, int page)
        {
            var result = await PaginatedList<Speech>.CreateAsync(db.speeches.Where(t => t.owner == id), page, ConstantUtil.MY_SPEECH_PAGE_SIZE, t => t.id);

            Dictionary<string, object> map = new Dictionary<string, object>();
            map.Add("Total", result.TotalPages);
            map.Add("Current", result.PageIndex);
            map.Add("Data", SpeechWrapper.WrapSpeech(result));

            return ResultUtil.Success(map);
        }

        public async Task<Result> MyComment(int id, int page)
        {
            var result = await PaginatedList<Comment>.CreateAsync(db.comments.Where(t => t.owner == id), page, ConstantUtil.MY_SPEECH_PAGE_SIZE, t => t.id);

            Dictionary<string, object> map = new Dictionary<string, object>();
            map.Add("Total", result.TotalPages);
            map.Add("Current", result.PageIndex);
            map.Add("Data", MyCommentWrapper.WrapComment(result));

            return ResultUtil.Success(map);
        }


        public async Task<Result> ModifyInfo(ModifyInfoRequest request)
        {
            var user = await db.users.SingleOrDefaultAsync(x => x.id == request.Id);

            if (user == null)
            {
                return ResultUtil.Error(ResultEnum.ResultType.LOGIN_FAIL);
            }

            user.birthday = request.Birthday;
            user.email = request.Email;
            user.nickname = request.Nickname;
            user.sex = request.Sex;
            user.phone = request.Phone;
            await db.SaveChangesAsync();

            return ResultUtil.Success();
        }
    }
}