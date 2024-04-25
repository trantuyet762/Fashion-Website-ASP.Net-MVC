using System;
using PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;
namespace WebBanHangOnline.Controllers
{
    public class PostController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Post
        public ActionResult Index(int? page)
        {
            var pageSize = 2;
            if (page == null)
            {
                page = 1;
            }
            IEnumerable<Post> items = db.Post.OrderByDescending(x => x.id);
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items);
        }
    }
}