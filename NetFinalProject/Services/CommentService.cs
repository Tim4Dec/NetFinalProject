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
    public class CommentService
    {
        private readonly DBModel db = new DBModel();

        public async Task<Result> FindAll(int speech, int page)
        {
            var result = await PaginatedList<Comment>.CreateAsync(db.comments.Where(x => x.speech == speech), page, ConstantUtil.COMMENT_PAGE_SIZE, t => t.id);

            Dictionary<string, object> map = new Dictionary<string, object>();
            map.Add("Total", result.TotalPages);
            map.Add("Current", result.PageIndex);
            map.Add("Data", CommentWrapper.WrapComment(result));

            return ResultUtil.Success(map);
        }

        public async Task<Result> DeliverComment(int speech, string content, int user)
        {
            var count = await db.comments.Where(x => x.speech == speech).CountAsync();
            Comment comment = new Comment
            {
                speech = speech,
                content = content,
                owner = user,
                time = DateTime.Now,
                floor = count + 1,
            };

            db.comments.Add(comment);
            await db.SaveChangesAsync();

            return ResultUtil.Success();
        }

        public async Task<Result> DeleteComment(int id)
        {
            db.comments.Remove(await db.comments.SingleOrDefaultAsync(x => x.id == id));
            await db.SaveChangesAsync();

            return ResultUtil.Success();
        }


    }
}