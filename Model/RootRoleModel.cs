using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// 角色权限表
    /// </summary>
    public class RootRoleModel
    {
        public int RootRoleId   { get; set; }//角色权限Id
        public int RootId       { get; set; }//权限Id
        public int RoleId       { get; set; }//角色Id
    }
}
