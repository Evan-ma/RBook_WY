using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace R_bookWY.Class
{
    public class CY
    {
  
    }
    public class MeunInfo
    {
        public string id;
        //菜单标题
        public string meunTitle;
        //菜单地址
        public string meunUrl;
        //菜单状态
        public string meunStatus;
        //菜单标识
        public string meunParent;
        //菜单排序
        public string meunSort;
        //子菜单集合
        public List<MeunInfo> childrenList;
    }
}