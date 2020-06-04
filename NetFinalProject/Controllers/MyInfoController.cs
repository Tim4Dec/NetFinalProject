using NetFinalProject.Requests;
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
    public class MyInfoController : ApiController
    {
        private readonly MyInfoService myInfoService = new MyInfoService();

        [HttpPost]
        [Route("api/User/Info")]
        public async Task<IHttpActionResult> MyInfos(int id)
        {
            var result = await myInfoService.MyInfos(id);

            return Json(result);
        }

        [HttpPost]
        [Route("api/User/Speech")]
        public async Task<IHttpActionResult> MySpeech([FromBody]MySpeechRequest request)
        {
            var result = await myInfoService.MySpeech(request.User, request.Page);

            return Json(result);
        }

        [HttpPost]
        [Route("api/User/Comment")]
        public async Task<IHttpActionResult> MyComment([FromBody]MySpeechRequest request)
        {
            var result = await myInfoService.MyComment(request.User, request.Page);

            return Json(result);
        }
    }
}