using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// 物流
    /// </summary>
    public class WuliuModel
    {
        public int    WuliuId     { get; set; }//物流Id
        public int    WuliuPid    { get; set; }//订单id
        public string WuliuAdress { get; set; }//物流地址
    }
}
