using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// 设备表
    /// </summary>
    public class EquipmentModel
    {
        public int     EquipmentId     { get; set; }//设备Id
        public string  EquipmentName   { get; set; }//设备名称
        public decimal EquipmentMoney  { get; set; }//设备价钱
        public int     EquipmentState  { get; set; }//设备状态
        public int     EquipmentNum    { get; set; }//设备数量
        public string  EquipmentPeople { get; set; }//设备负责人
    }
}
