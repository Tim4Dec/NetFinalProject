using NetFinalProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using NetFinalProject.Requests;

namespace NetFinalProject.Controllers
{
    public class NoticeController : ApiController
    {
        private readonly NoticeService noticeService = new NoticeService();

        [HttpPost]
        [Route("api/Notice/All")]
        public async Task<IHttpActionResult> GetAll(int page = 1)
        {
            var result = await noticeService.FindAll(page);

            return Json(result);
        }

        [HttpPost]
        [Route("api/Notice/Detail")]
        public async Task<IHttpActionResult> ShowDetail(int id)
        {
            var result = await noticeService.ShowDetail(id);

            return Json(result);
        }

        [HttpPost]
        [Route("api/Notice/Title")]
        public async Task<IHttpActionResult> SearchByTitle([FromBody]SearchRequest request)
        {
            var result = await noticeService.SearchByTitle(request.Title, request.Page);

            return Json(result);
        }







    }
}