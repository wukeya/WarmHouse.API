using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// 采购订单表
    /// </summary>
    public class PurchaseModel
    {
        public int      PurchaseId    { get; set; }//采购id
        public int      PurchaseUid   { get; set; }//用户id
        public int      PurchasePid   { get; set; }//信息id
        public string   PurchaseCode  { get; set; }//订单编号
        public DateTime PurchaseTime  { get; set; }//订单时间  
        public int      PurchaseState { get; set; }//订单状态    --0未完成    1完成
    }
}
