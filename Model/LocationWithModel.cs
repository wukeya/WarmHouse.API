using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// 库位详细表
    /// </summary>
    public class LocationWithModel
    {
        public int LocationWithId  { get; set; }//库位详细Id
        public int LocationWithPid { get; set; }//库位订单Id
        public int LocationWithGid { get; set; }//库位商品Id
        public int LocationWithNum { get; set; }//库位商品数量
    }
}
