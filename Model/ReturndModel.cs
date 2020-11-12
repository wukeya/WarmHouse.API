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
        public int  ReturnOid   { get; set; }//退货订单详细Id
        public int  ReturnPid   { get; set; }//订单Id
        public int ReturnState { get; set; }//退货状态

        //采购表
        public int PurchaseId { get; set; }//采购id
        public int PurchaseUid { get; set; }//用户id
        public int PurchasePid { get; set; }//信息id
        public string PurchaseCode { get; set; }//订单编号
        public DateTime PurchaseTime { get; set; }//订单时间  
        public int PurchaseState { get; set; }//订单状态    --0未完成    1完成
        //商品表
        public int GoodsId { get; set; }//商品Id
        public string GoodsName { get; set; }//商品名称
        public int GoodsTid { get; set; }//商品类型Id
        public int GoodsSid { get; set; }//商品供应商Id
        public string GoodsImg { get; set; }//商品图片
        public string GoodsCode { get; set; }//商品编号
        public int GoodsUid { get; set; }//商品单位ID
        public int GoodsNum { get; set; }//商品数量
        public decimal GoodsMoney { get; set; }//商品价钱
        public int GoodsSize { get; set; }//商品体积
        public string GoodsPeople { get; set; }//商品负责人
        public int GoodsState { get; set; }//商品状态  --0下架   1上架
        //订单
        public int OrderId { get; set; }
        public int OPid { get; set; }
        public int OGid { get; set; }
        public int ONum { get; set; }
        public int OState { get; set; }
    }
}
