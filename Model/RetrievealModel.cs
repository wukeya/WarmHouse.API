using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// 出库订单表
    /// </summary>
    public class RetrievealModel
    {
        public int      RetrievealId    { get; set; }//出库订单Id
        public string      RetrievealCode  { get; set; }//出库用户Id
        public int      RetrievealUid   { get; set; }//出库信息Id
        public DateTime RetrievealTime  { get; set; }//出库时间
        public int   RetrievealState { get; set; }//出库地址
        public string nums { get; set; }
        public string ids { get; set; }
    }
}
