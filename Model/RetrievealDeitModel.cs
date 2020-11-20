using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class RetrievealDeitModel
    {
        public int RetrievealDeitId   { get; set; }
        public string RetrievealDeitCode { get; set; }
        public int RetrievealDeitLid  { get; set; }
        public int RetrievealDeitNum  { get; set; }
        //商品
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
                                               //库位详细表
        public int LocationWithId { get; set; }//库位详细Id
        public int LocationWid { get; set; }//仓库Id
        public int LocationLid { get; set; }//库位Id
        public int LocationWithOid { get; set; }//订单详细Id
        public string LocationRuCode { get; set; } //入库清单编号
        public int LocationState { get; set; }


        //采购订单表
        public int OrderId { get; set; }
        public int OPid { get; set; }
        public int OGid { get; set; }
        public int ONum { get; set; }
        public int OState { get; set; }
        //仓库
        public int WareHouseId { get; set; }//仓库Id
        public string WareHouseName { get; set; }//仓库名称
        //库位
        public int LocationId { get; set; }//库位Id
        public string LocationName { get; set; }//库位名称
        public float LocationMin { get; set; }//库位最小值
        public float LocationMax { get; set; }//库位最大值

    }
}
