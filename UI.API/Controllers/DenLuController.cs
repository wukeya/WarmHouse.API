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
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Text;
namespace UI.API.Controllers
{
    [Route("DengLu")]
    [ApiController]
   
    public class DenLuController : ControllerBase
    {
        string a = "";
        //依赖注入
        private IDengLuBLL _ibll;
        public DenLuController(IDengLuBLL ibll)
        {
            _ibll = ibll;
          
        }
        //接收手机号进行发送
        [Route("PhoneToUrl")]
        [HttpGet]
        public string PhoneToUrl(string phone="") 
        {
           
                Random random = new Random();
                a=random.Next().ToString().Substring(0,4);
          
            string url = $"http://utf8.api.smschinese.cn/?Uid=wukeya&Key=d41d8cd98f00b204e980&smsMob={phone}&smsText=验证码:{a}";
            GetHtmlFromUrl(url);
            return a;
        }

        //发送短信
        [Route("GetHtmlFromUrl")]
        [HttpGet]
        public string GetHtmlFromUrl(string url)
        {
            string strRet = null;
            if (url == null || url.Trim().ToString() == "")
            {
                return strRet;
            }
            string targeturl = url.Trim().ToString();
            try
            {
                HttpWebRequest hr = (HttpWebRequest)WebRequest.Create(targeturl);
                hr.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)";
                hr.Method = "GET";
                hr.Timeout = 30 * 60 * 1000;
                WebResponse hs = hr.GetResponse();
                Stream sr = hs.GetResponseStream();
                StreamReader ser = new StreamReader(sr, Encoding.Default);
                strRet = ser.ReadToEnd();
            }
            catch(Exception ex)
            {
                strRet = null;
            }
            return strRet;
        }


        //登录
        #region
        [Route("UserLogin")]
        [HttpGet]
        
        public UserdModel UserLogin(string name, string pass="")
        {
            //解密密码
            string str = _ibll.SearchPass(name);
            //登录
            if (pass==str)
            {
                UserdModel model = _ibll.UserLogin(name, str);
                return model;
            }
            return null;
        }
        [Route("UserdZhuChe")]
        [HttpPost]
        public IActionResult UserdZhuChe(string ff="")
        {
            UserdModel model = JsonConvert.DeserializeObject<UserdModel>(ff);
            int i= _ibll.UserdZhuChe(model);   
            return Ok(i);
        }
        #endregion
    }
}