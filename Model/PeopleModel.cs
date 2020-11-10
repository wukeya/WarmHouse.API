using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    ///个人信息表
    /// </summary>
    public class PeopleModel
    {
        public int      PeopleId     { get; set; }//个人信息Id
        public string   PeopleName   { get; set; }//个人信息名称
        public string   PeopleAdress { get; set; }//个人地址
        public string   PeopleHobby  { get; set; }//个人爱好
        public int      PeopleUid    { get; set; }//用户Id
        public int      PeopleSex    { get; set; }//用户性别
    }
}
