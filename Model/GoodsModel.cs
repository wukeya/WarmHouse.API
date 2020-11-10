using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// 商品表
    /// </summary>
    public class GoodsModel
    {
        public int GoodsId      { get; set; }
        public string GoodsName    { get; set; }
        public int GoodsTid     { get; set; }
        public int GoodsSid     { get; set; }
        public string GoodsImg     { get; set; }
        public string GoodsCode    { get; set; }
        public int GoodsUid     { get; set; }
        public int GoodsNum     { get; set; }
        public decimal GoodsMoney   { get; set; }
        public int GoodsSize    { get; set; }
        public string GoodsPeople  { get; set; }
        public int GoodsState   { get; set; }

        //单位类
        public int UnitId { get; set; }
        public string UnitName { get; set; }

        //供应商类
        public int SuppleId { get; set; }
        public string SuppleName { get; set; }
        public string SuppleAdress { get; set; }
        public string SupplePhone { get; set; }
        public string SupplePople { get; set; }

        //类型类
        public int TypedId { get; set; }
        public string TypedName { get; set; }

    }
}
