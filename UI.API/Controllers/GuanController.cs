using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using BLL;
using BLL.IBll;

namespace UI.API.Controllers
{
    [Route("Guan")]
    [ApiController]
    public class GuanController : ControllerBase
    {
        //依赖注入
        private IGuanBLL _ibll;
        public GuanController(IGuanBLL ibll)
        {
            _ibll = ibll;
        }
        //绑定单位
        [Route("Unit")]
        [HttpGet]
        public List<UnitModel> UnitBang()
        {
            return _ibll.UnitBang();
        }
    }
}
