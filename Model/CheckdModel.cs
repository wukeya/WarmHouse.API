using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// 盘点表
    /// </summary>
    public class CheckdModel
    {
        public int CheckdId   { get; set; }//盘点id
        public int CheckdGid  { get; set; }//盘点商品id
        public int CheckdGnum { get; set; }//盘点数量
    }
}
