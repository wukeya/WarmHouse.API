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
        public int LocationWid { get; set; }//仓库Id
        public int LocationLid { get; set; }//库位Id
        public int LocationWithOid { get; set; }//订单详细Id
        public int LocationState { get; set; }
    }
}
