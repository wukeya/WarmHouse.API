using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class SelectOrderModel
    {
        public int SelectOrderId     { get; set; }
        public string SelectOrderCode   { get; set; }
        public DateTime SelectOrderTime   { get; set; }
        public string SelectOrderPeople { get; set; }
        public int SelectOrderState  { get; set; }
        public string Gids { get; set; }
        public string Nums { get; set; }
    }
}
