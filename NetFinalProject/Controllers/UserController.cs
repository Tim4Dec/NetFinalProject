using NetFinalProject.Models;
using NetFinalProject.Services;
using NetFinalProject.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using NetFinalProject.Requests;

namespace NetFinalProject.Controllers
{
    public class UserController : ApiController
    {
        private readonly LoginService loginService = new LoginService();
        private readonly MyInfoService myInfoService = new MyInfoService();
        private readonly RegisterService registerService = new RegisterService();

        [HttpPost]
        [Route("api/User/Login")]
        public async Task<IHttpActionResult> Login([FromBody]LoginRequest loginRequest)
        {
            var result = await loginService.Login(loginRequest.Name, loginRequest.Pwd);

            return Json(result);
        }

        [HttpPost]
        [Route("api/User/ModifyPwd")]
        public async Task<IHttpActionResult> ModifyPwd([FromBody]ModifyPwdRequest modifyPwdRequest)
        {
            var result = await myInfoService.ModifyPwd(modifyPwdRequest.OldPwd, modifyPwdRequest.NewPwd, modifyPwdRequest.Id);

            return Json(result);
        }

        [HttpPost]
        [Route("api/User/Sms")]
        public IHttpActionResult GenerateSms()
        {
            var result = RegisterService.GenerateSms(ConstantUtil.SMS_LENGTH);

            return Json(result);
        }

        [HttpPost]
        [Route("api/User/Verify")]
        public async Task<IHttpActionResult> VerifyName(string name)
        {
            var result = await registerService.VerifyUsername(name);

            return Json(result);
        }

        [HttpPost]
        [Route("api/User/Register")]
        public IHttpActionResult Register([FromBody]LoginRequest request)
        {
            var result = registerService.Register(request.Name, request.Pwd);

            return Json(result);
        }

    }
}