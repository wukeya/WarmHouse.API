using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.IBll;
using DAL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace UI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DenLuController : ControllerBase
    {
        JWTHelper jwt = new JWTHelper();
        public IWebHostEnvironment _iwebh;
        //依赖注入
        private IDengLuBLL _ibll;
        public DenLuController(IDengLuBLL ibll, IWebHostEnvironment iwebh)
        {
            _ibll = ibll;
            _iwebh = iwebh;
        }

        //登录
        #region
        [Route("UserdDenLuint")]
        [HttpGet]
        public IActionResult UserdDenLuint(string username, string userpass)
        {
            UserdModel model = _ibll.UserdDenLuint(username, userpass);

            Dictionary<string, object> pairs = new Dictionary<string, object>();
            pairs.Add("username", model.UserName);
            pairs.Add("userpass", model.UserPass);
            var token = jwt.GetToken(pairs, 200000);
            var json = jwt.GetPayload(token);

            return Ok(json);
        }
        [Route("UserdZhuChe")]
        [HttpPost]
        public IActionResult UserdZhuChe(UserdModel model)
        {
            var name = model.UserName;
            var pass = model.UserPass;
            Dictionary<string, object> pairs = new Dictionary<string, object>();
            pairs.Add(name, model.UserName);
            pairs.Add(pass, model.UserPass);
            var token = jwt.GetToken(pairs, 200000);
            var json = jwt.GetPayload(token);
            return Ok(json);
        }
        #endregion
    }
}