using LvDu.dboUtils;
using lvduPhoneWin.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace lvduPhoneWin.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult getGood()
        {
            DboUtils dbo = new DboUtils();
            String sql = "select * from good  ORDER by upitem";
            DataSet ds = dbo.query(sql);
            List<good> navList = new List<good>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                good info = new good()
                {
                    id = (Guid)dr["id"],
                    img = dr["img"].ToString(),
                    info = dr["info"].ToString(),
                    price = (double)dr["price"],
                    upitem = (int)dr["upitem"],
                    name = dr["name"].ToString()
                };
                navList.Add(info);
            }
            return Json(navList);
        }
        public ActionResult Modify(Guid id)
        {
            DboUtils db = new DboUtils();
            String sql = "select * from good where id = '" + id + "'";
            DataSet ds = db.query(sql);
            DataRow dr = ds.Tables[0].Rows[0];
            good g = new good()
            {
                id = (Guid)dr["id"],
                img = dr["img"].ToString(),
                info = dr["info"].ToString(),
                price = (double)dr["price"],
                upitem = (int)dr["upitem"],
                name = dr["name"].ToString()
            };

            ViewBag.g = g;
            return View();
        }
        public String ConfirmModify(Guid id, String name, double price, String image, String info)
        {

            DboUtils db = new DboUtils();

            String sql = "update good set name='" + name + "',price='" + price + "',img='" + image + "',info='" + info + "'where id='" + id + "'";
            int x = db.update(sql);
            string message = "操作失败";
            if (x > 0)
            {
                message = "操作成功";
                return message;
            }
            else
            {
                return message;
            }
        }
        public String deleteGood(Guid id)
        {
            DboUtils db = new DboUtils();

            String sql = "delete from good where id='" + id + "'";

            int x = db.delete(sql);
            string message = "操作失败";
            if (x > 0)
            {
                message = "操作成功";
                return message;
            }
            else
            {
                return message;
            }
        }





        public ActionResult Nav()
        {
            return View();
        }

        [HttpPost]
        public ActionResult getNav()
        {
            DboUtils dbo = new DboUtils();
            String sql = "select * from nav ORDER by id";
            DataSet ds = dbo.query(sql);
            List<nav> navList = new List<nav>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                nav nav = new nav()
                {
                    id = (int)dr["id"],
                    name = dr["name"].ToString(),
                    href = dr["href"].ToString()
                };
                navList.Add(nav);
            }
            return Json(navList);
        }
        public ActionResult ModifyNav(int id)
        {
            DboUtils db = new DboUtils();
            String sql = "select * from Nav where id = '" + id + "'";
            DataSet ds = db.query(sql);
            DataRow dr = ds.Tables[0].Rows[0];
            nav nav = new nav()
            {
                id = (int)dr["id"],
                name = dr["name"].ToString(),
                href = dr["href"].ToString()
            };

            ViewBag.g = nav;
            return View();
        }

        public String ConfirmModifyNav(int id, String name, String href)
        {
            DboUtils db = new DboUtils();
            String sql = "update nav set name='" + name + "',href='" + href + "'where id='" + id + "'";
            int x = db.update(sql);
            string message = "操作失败";
            if (x > 0)
            {
                message = "操作成功";
                return message;
            }
            else
            {
                return message;
            }
        }

        public String deleteNav(int id)
        {
            DboUtils db = new DboUtils();

            String sql = "delete from nav where id='" + id + "'";

            int x = db.delete(sql);
            string message = "操作失败";
            if (x > 0)
            {
                message = "操作成功";
                return message;
            }
            else
            {
                return message;
            }
        }

        public ActionResult addNav()
        {
            return View();
        }

        public String ConfirmAddNav(int id, String name, String href)
        {
            DboUtils db = new DboUtils();
            String sql = "INSERT INTO nav(id,name,href) VALUES('" + id + "','" + name + "','" + href + "')";
            int x = db.insert(sql);
            string message = "操作失败";
            if (x > 0)
            {
                message = "操作成功";
                return message;
            }
            else
            {
                return message;
            }
        }

        public ActionResult addGood()
        {
            return View();
        }

        public String ConfirmAddGood(String name, int upitem, double price, String img, String info)
        {

            Console.WriteLine(name + "---" + upitem + "---" + price + "---" + img + "---" + info);

            DboUtils db = new DboUtils();
            String sql = "INSERT INTO good(name,price,img,info,upitem) VALUES('" + name + "','" + price + "','" + img + "','" + info + "','"+upitem+"')";
            int x = db.insert(sql);
            string message = "操作失败";
            if (x > 0)
            {
                message = "操作成功";
                return message;
            }
            else
            {
                return message;
            }
        }

        public ActionResult upLoad()
        {
            return View();
        }

    }
    
}