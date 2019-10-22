using R_bookWY.Class;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
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
            //获取所有的菜单(包括子菜单和父级菜单)
            List<MeunInfo> list = new List<MeunInfo>();
            CY C = new CY();
            string sql = "select * from t_moudle where upcode = '-1'";
            DataTable dt = C.ZxSql(sql);
            for (int i = 0; i < dt.Rows.Count; i++)

            {
                MeunInfo mi = new MeunInfo();
                {
                    mi.id = dt.Rows[i]["id"].ToString();
                    mi.meunTitle = dt.Rows[i]["name"].ToString();
                    mi.meunUrl = dt.Rows[i]["url"].ToString();
                    mi.meunParent = dt.Rows[i]["upcode"].ToString();
                    mi.childrenList = new List<MeunInfo>();
                    list.Add(mi);
                }
            }
            for (int i = 0; i < list.Count; i++)
            {
                sql = "select * from t_moudle where upcode = '"+ list[i].id + "'";
                DataTable dtp = C.ZxSql(sql);
                for (int p = 0; p < dtp.Rows.Count; p++)
                {
                    MeunInfo mi = new MeunInfo();
                    mi.id = dtp.Rows[p]["id"].ToString();
                    mi.meunTitle = dtp.Rows[p]["name"].ToString();
                    mi.meunUrl = dtp.Rows[p]["url"].ToString();
                    mi.meunParent = dtp.Rows[p]["upcode"].ToString();
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