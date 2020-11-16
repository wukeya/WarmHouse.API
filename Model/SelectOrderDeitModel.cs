using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class SelectOrderDeitModel
    {
        public int SelectOrderDeitId   { get; set; }
        public int SelectOrderDeitGid  { get; set; }
        public string SelectOrderDeitCode { get; set; }
        public int SelectOrderDeitNum { get; set; }

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
    }
}
