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
        public int      RetrievealId     { get; set; }//出库订单Id
        public int      RetrievealUid    { get; set; }//出库用户Id
        public int      RetrievealPid    { get; set; }//出库信息Id
        public DateTime RetrievealTime   { get; set; }//出库时间
        public string   RetrievealAdress { get; set; }//出库地址
        public int      RetrievealState  { get; set; }//出库状态   --0未完成  1完成
    }
}
