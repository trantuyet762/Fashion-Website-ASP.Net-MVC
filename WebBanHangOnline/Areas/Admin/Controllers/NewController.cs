using System;
using PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.Areas.Admin.Controllers
{
    /*[Authorize(Roles = "Admin,Employee")]*/
    public class NewController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/New
        public ActionResult Index(string Searchtext, int? page)
        {
            var pageSize = 5;
            if(page == null)
            {
                page = 1;
            }
            IEnumerable<New> items = db.New.OrderByDescending(x => x.id);
           
            if (!string.IsNullOrEmpty(Searchtext))
            {
               items=  items.Where(x => x.Alias.Contains(Searchtext) || x.Title.Contains(Searchtext));
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
             items = items.ToPagedList(pageIndex,pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(New model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
                model.Modifieddate = DateTime.Now;
                model.CategoryID = 3;
                model.Alias = WebBanHangOnline.Models.Common.Filter.FilterChar(model.Title);
                db.New.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var item = db.New.Find(id);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(New model)
        {
            if (ModelState.IsValid)
            {
                model.Modifieddate = DateTime.Now;

                model.Alias = WebBanHangOnline.Models.Common.Filter.FilterChar(model.Title);
                db.New.Attach(model);
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.New.Find(id);
            if (item != null)
            {
                db.New.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
        [HttpPost]
        public ActionResult IsActive(int id)
        {
            var item = db.New.Find(id);
            if (item != null)
            {
                item.IsActive = !item.IsActive;
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, isActive = item.IsActive });
            }
            return Json(new { success = false });
        }
        public ActionResult DeleteAll(string ids)
        {
            if (!string.IsNullOrEmpty(ids))
            {
                var items = ids.Split(',');
                if (items != null && items.Any())
                {
                    foreach (var item in items)
                    {
                        var obj = db.New.Find(Convert.ToInt32(item));
                        db.New.Remove(obj);
                        db.SaveChanges();
                    }
                }
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

    }
}