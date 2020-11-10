using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// 报损表
    /// </summary>
    public class ReportedModel
    {
        public int      ReportedId   { get; set; }//报损Id
        public DateTime ReportedTime { get; set; }//报损时间
        public int      ReportedGid  { get; set; }//报损商品Id
        public int      ReportedNum  { get; set; }//商品数量
    }
}
