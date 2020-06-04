using NetFinalProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace NetFinalProject.Controllers
{
    public class ArticleController : ApiController
    {
        private readonly ArticleService articleService = new ArticleService();

        [HttpPost]
        [Route("api/Article/All")]
        public async Task<IHttpActionResult> GetAll(int page = 1)
        {
            var result = await articleService.FindAll(page);

            Console.WriteLine("request");

            return Json(result);
        }

        [HttpPost]
        [Route("api/Article/Detail")]
        public async Task<IHttpActionResult> ShowDetail(int id)
        {
            var result = await articleService.ShowDetail(id);

            return Json(result);
        }

        [HttpPost]
        [Route("api/Article/Title")]
        public async Task<IHttpActionResult> SearchByTitle(string title, int page = 1)
        {
            var result = await articleService.SearchByTitle(title, page);

            return Json(result);
        }



    }
}