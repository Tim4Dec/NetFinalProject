using NetFinalProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using NetFinalProject.Requests;
using System.Web.Http;

namespace NetFinalProject.Controllers
{
    public class SpeechController : ApiController
    {
        private readonly SpeechService speechService = new SpeechService();
        private readonly CommentService commentService = new CommentService();

        [HttpPost]
        [Route("api/Speech/All")]
        public async Task<IHttpActionResult> GetAllSpeech(int page = 1)
        {
            var result = await speechService.FindAll(page);

            return Json(result);
        }

        [HttpPost]
        [Route("api/Speech/Detail")]
        public async Task<IHttpActionResult> ShowDetail(int id)
        {
            var result = await speechService.ShowDetail(id);

            return Json(result);
        }

        [HttpPost]
        [Route("api/Speech/Title")]
        public async Task<IHttpActionResult> SearchByTitle(string title, int page = 1)
        {
            var result = await speechService.SearchByTitle(title, page);

            return Json(result);
        }

        [HttpPost]
        [Route("api/Speech/Deliver")]
        public async Task<IHttpActionResult> DeliverSpeech([FromBody]DeliverSpeechRequest request)
        {
            var result = await speechService.DeliverSpeech(request.Title, request.Content, request.User);

            return Json(result);
        }

        [HttpPost]
        [Route("api/Speech/Delete")]
        public async Task<IHttpActionResult> DeleteSpeech(int id)
        {
            var result = await speechService.DeleteSpeech(id);

            return Json(result);
        }

        [HttpPost]
        [Route("api/Comment/All")]
        public async Task<IHttpActionResult> GetAllComment([FromBody]GetCommentRequest request)
        {
            var result = await commentService.FindAll(request.Speech, request.Page);

            return Json(result);
        }

        [HttpPost]
        [Route("api/Comment/Deliver")]
        public async Task<IHttpActionResult> DeliverComment([FromBody]DeliverCommentRequest request)
        {
            var result = await commentService.DeliverComment(request.Speech, request.Content, request.User);

            return Json(result);
        }

        [HttpPost]
        [Route("api/Comment/Delete")]
        public async Task<IHttpActionResult> DeleteComment(int id)
        {
            var result = await commentService.DeleteComment(id);

            return Json(result);
        }
    }
}