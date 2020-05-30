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
    public class ArticleService
    {
        private readonly DBModel db = new DBModel();

        public async Task<Result> FindAll(int page)
        {
            var result = await PaginatedList<article>.CreateAsync(db.articles.AsNoTracking(), page, ConstantUtil.PAGE_SIZE, t => t.id);

            return ResultUtil.Success(result);
        }

        public async Task<Result> ShowDetail(int id)
        {
            var article = await db.articles.SingleOrDefaultAsync(t => t.id == id);

            return ResultUtil.Success(article);
        }

        public async Task<Result> SearchByTitle(string title, int page)
        {
            var result = await PaginatedList<article>.CreateAsync(db.articles.Where(t => t.title.Contains(title)), page, ConstantUtil.PAGE_SIZE, t => t.id);

            return ResultUtil.Success(result);
        }
    }
}