using LvDu.dboUtils;
using lvduPhoneWin.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lvduPhoneWin.Controllers
{
    public class HomeController : Controller
    {

        DboUtils dbo = new DboUtils();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult getOrdering()
        {
            String sql = "select * from orderList where orderingState = 'false' ORDER by id";
            DataSet ds = dbo.query(sql);
            List<ordering> navList = new List<ordering>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ordering nav = new ordering()
                {
                    id = (Guid)dr["id"],
                    roomID = dr["roomID"].ToString(),
                    order = dr["ordering"].ToString(),
                    orderID = dr["orderingID"].ToString(),
                    orderState = (Boolean)dr["orderingState"],
                    note = dr["note"].ToString(),
                    createtime = (DateTime)dr["createtime"],
                    total = dr["total"].ToString()
                };
                navList.Add(nav);
            }
            return Json(navList);
        }
        [HttpPost]
        public ActionResult jiesuan(Guid id)
        {
            String sql = "UPDATE orderList SET orderingState='true' where id='"+id + "'";
            int raw = dbo.update(sql);
            if (raw > 0) { return Json("true"); }
            else { return Json("false"); }
        }
        public ActionResult print()
        {
            
            return View();
        }
    }
}