using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;
namespace WebBanHangOnline.Controllers
{
    public class NewController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: New
        public ActionResult Index(int? page)
        {
            var pageSize = 2;
            if(page== null)
            {
                page = 1;
            }
            IEnumerable<New> items = db.New.OrderByDescending(x => x.id);
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items);
        }
        public ActionResult Partial_New_Home()
        {
            var items = db.New.Take(3).ToList();
            return PartialView(items);
        }
        public ActionResult Detail(int id)
        {
            var item = db.New.Find(id);
            return View(item);
        }
    }
}