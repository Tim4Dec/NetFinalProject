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
    public class NoticeService
    {
        private readonly DBModel db = new DBModel();

        public async Task<Result> FindAll(int page)
        {
            var result = await PaginatedList<Notice>.CreateAsync(db.notices.AsNoTracking(), page, ConstantUtil.NOTE_PAGE_SIZE, t => t.id);

            Dictionary<string, object> map = new Dictionary<string, object>();
            map.Add("Total", result.TotalPages);
            map.Add("Current", result.PageIndex);
            map.Add("Data", NoticeWrapper.WrapNotice(result));

            return ResultUtil.Success(map);
        }

        public async Task<Result> ShowDetail(int id)
        {
            var notice = await db.notices.SingleOrDefaultAsync(t => t.id == id);

            return ResultUtil.Success(notice);
        }

        public async Task<Result> SearchByTitle(string title, int page)
        {
            var result = await PaginatedList<Notice>.CreateAsync(db.notices.Where(t => t.title.Contains(title)), page, ConstantUtil.NOTE_PAGE_SIZE, t => t.id);

            Dictionary<string, object> map = new Dictionary<string, object>();
            map.Add("Total", result.TotalPages);
            map.Add("Current", result.PageIndex);
            map.Add("Data", result);

            return ResultUtil.Success(map);
        }
    }
}