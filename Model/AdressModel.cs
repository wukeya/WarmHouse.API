using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// 地址表
    /// </summary>
    public class AdressModel
    {
        public int    AdressId   { get; set; }//地址Id
        public string AdressName { get; set; }//地址名称
        public int    AdressPid  { get; set; }// 地址父类Id
    }
}
