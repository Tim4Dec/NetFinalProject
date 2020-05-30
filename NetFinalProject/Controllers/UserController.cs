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
    public class UserController: ApiController
    {
        private readonly LoginService loginService = new LoginService();
        private readonly MyInfoService myInfoService = new MyInfoService();

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
    }
}