using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// 退货表
    /// </summary>
    public class ReturndModel
    {
        public int ReturnId  { get; set; }//退货Id
        public int ReturnGid { get; set; }//退货商品Id
        public int ReturnPid { get; set; }//订单Id
        public int RetrunNum { get; set; }//退货数量
    }
}
