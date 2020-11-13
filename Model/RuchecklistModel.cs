using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class RuchecklistModel
    {
        public int RuchecklistId     { get; set; }
        public string RuchecklistCode   { get; set; }
        public DateTime RuchecklistTime   { get; set; }
        public string RuchecklistPeople { get; set; }
        public int RucheckState      { get; set; }
    }
}
