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
    public class SpeechService
    {
        private readonly DBModel db = new DBModel();

        public async Task<Result> FindAll(int page)
        {
            var result = await PaginatedList<Speech>.CreateAsync(db.speeches.AsNoTracking(), page, ConstantUtil.SPEECH_PAGE_SIZE, t => t.id);

            Dictionary<string, object> map = new Dictionary<string, object>();
            map.Add("Total", result.TotalPages);
            map.Add("Current", result.PageIndex);
            map.Add("Data", SpeechWrapper.WrapSpeech(result));

            return ResultUtil.Success(map);
        }

        public async Task<Result> ShowDetail(int id)
        {
            var speech = await db.speeches.SingleOrDefaultAsync(t => t.id == id);

            return ResultUtil.Success(new SpeechWrapper(speech));
        }

        public async Task<Result> SearchByTitle(string title, int page)
        {
            var result = await PaginatedList<Speech>.CreateAsync(db.speeches.Where(t => t.title.Contains(title)), page, ConstantUtil.SPEECH_PAGE_SIZE, t => t.id);

            Dictionary<string, object> map = new Dictionary<string, object>();
            map.Add("Total", result.TotalPages);
            map.Add("Current", result.PageIndex);
            map.Add("Data", result);

            return ResultUtil.Success(map);
        }

        public async Task<Result> DeliverSpeech(string title, string content, int user)
        {
            Speech s = new Speech
            {
                owner = user,
                title = title,
                content = content,
                time = DateTime.Now
            };

            db.speeches.Add(s);
            await db.SaveChangesAsync();

            return ResultUtil.Success();
        }

        public async Task<Result> DeleteSpeech(int id)
        {
            db.speeches.Remove(await db.speeches.SingleOrDefaultAsync(x => x.id == id));
            db.comments.Remove(await db.comments.SingleOrDefaultAsync(x => x.speech == id));
            await db.SaveChangesAsync();

            return ResultUtil.Success();
        }


    }
}