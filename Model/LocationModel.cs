using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// 库位表
    /// </summary>
    public class LocationModel
    {
        public int    LocationId   { get; set; }//库位Id
        public int    LocationWid  { get; set; }//仓库Id
        public string LocationName { get; set; }//库位名称
        public float  LocationMin  { get; set; }//
        public float  LocationMax  { get; set; }//
    }
}
