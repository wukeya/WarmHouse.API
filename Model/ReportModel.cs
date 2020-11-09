using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ReportModel
    {
        public int ReportedId   { get; set; }
        public DateTime ReportedTime { get; set; }
        public int ReportedGid  { get; set; }
        public int ReportedNum  { get; set; }
    }
}
