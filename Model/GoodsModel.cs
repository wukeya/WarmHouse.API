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
     
    }
}
