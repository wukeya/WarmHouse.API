using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// 供应商类
    /// </summary>
    public class SuppleModel
    {
        public int    SuppleId     { get; set; }//供应商iD
        public string SuppleName   { get; set; }//供应商名称
        public string SuppleAdress { get; set; }//供应商地址
        public string SupplePhone  { get; set; }//供应商电话
        public string SupplePople  { get; set; }//供应商负责人

    }
}
