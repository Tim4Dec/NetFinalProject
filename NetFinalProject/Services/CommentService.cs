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

        public async Task<Result> FindAll(int page)
        {
            var result = await PaginatedList<comment>.CreateAsync(db.comments.AsNoTracking(), page, ConstantUtil.PAGE_SIZE, t => t.id);

            return ResultUtil.Success(result);
        }


    }
}