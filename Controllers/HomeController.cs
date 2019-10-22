using R_bookWY.Class;
using R_bookWY.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Web.Mvc;

namespace R_bookWY.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index_1()
        {
            return View();
        }
        public ActionResult getParentMeun()
        {
            BookEntities bk = new BookEntities();
            //获取所有的菜单(包括子菜单和父级菜单)
            List<MeunInfo> list = new List<MeunInfo>();
            string sql = "select * from t_moudle where upcode = '-1'";
            List<t_moudle> tu = bk.Database.SqlQuery<t_moudle>(sql).ToList();
            for (int i = 0; i < tu.Count; i++)
            {
                MeunInfo mi = new MeunInfo();
                mi.id = tu[i].id;
                mi.meunTitle = tu[i].name;
                mi.meunUrl = tu[i].url;
                mi.meunParent = tu[i].upcode;
                mi.childrenList = new List<MeunInfo>();
                list.Add(mi);
            }
            for (int i = 0; i < list.Count; i++)
            {
                sql = "select * from t_moudle where upcode = '" + list[i].id + "'";
                List<t_moudle> tup = bk.Database.SqlQuery<t_moudle>(sql).ToList();
                for (int p = 0; p < tup.Count; p++)
                {
                    MeunInfo mi = new MeunInfo();
                    mi.id = tup[i].id;
                    mi.meunTitle = tup[i].name;
                    mi.meunUrl = tup[i].url;
                    mi.meunParent = tup[i].upcode;
                    list[i].childrenList.Add(mi);
                }
            }
            JsonResult result = new JsonResult();
            result.Data = list;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
    }

}