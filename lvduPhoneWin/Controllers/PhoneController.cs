using LvDu.dboUtils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lvduPhoneWin.Entity;

namespace lvduPhoneWin.Controllers
{
    public class PhoneController : Controller
    {
        DboUtils dbo = new DboUtils();

        public ActionResult Index(String roomid)
        {
            ViewBag.roomid = roomid;
            return View();
        }
        [HttpPost]
        public ActionResult getNav()
        {
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
        [HttpPost]
        public ActionResult getInfo(int id)
        {
            String sql = "select * from good where upitem='" + id + "'  ORDER by upitem";
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
        [HttpPost]
        public ActionResult getInfoAll()
        {
            String sql = "select * from good ORDER by upitem";
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
        [HttpPost]
        public ActionResult createOrder(String roomId, String ordering, String orderingId, String orderingState, String node, String total)
        {
            String sql = "INSERT INTO orderList(roomId,ordering,orderingId,orderingState,note,total) VALUES('" + roomId + "','" + ordering + "','" + orderingId + "','" + orderingState + "','" + node + "','" + total + "') ";
            int raw = 0;
            raw = dbo.insert(sql);
            if (raw > 0)
            {
                return Json("true");
            }
            else
            {
                return Json("false");
            }
        }

        [HttpPost]
        public ActionResult Search(String name)
        {
            if(name != null&&name.Length>0)
            {
                String sql = "select * from good where name like '%"+name+"%' ORDER by upitem";
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
            else
            {
                return Json("error");
            }
           
        }


        public ActionResult getOrderSuccess()
        {
            return View();
        }
    }
}