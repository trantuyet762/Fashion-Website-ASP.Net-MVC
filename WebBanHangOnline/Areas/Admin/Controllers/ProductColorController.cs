using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;
namespace WebBanHangOnline.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,Employee")]
    public class ProductColorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/ProductColor
        public ActionResult Index(int? page)
        {
            IEnumerable<ProductColor> items = db.ProductColors.OrderByDescending(x => x.id).ToList();
            var pageSize = 10;
            if (page == null)
            {
                page = 1;
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items);
        }
        public ActionResult Add()
        {

            ViewBag.Product = new SelectList(db.Products.ToList(), "id", "Title");
            ViewBag.Color = new SelectList(db.Colors.ToList(), "id", "ColorName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ProductColor model)
        {
            if (ModelState.IsValid)
            {



                db.ProductColors.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            ViewBag.Product = new SelectList(db.Products.ToList(), "id", "Title");
            ViewBag.Color = new SelectList(db.Colors.ToList(), "id", "ColorName");

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            ViewBag.Product = new SelectList(db.Products.ToList(), "id", "Title");
            ViewBag.Color = new SelectList(db.Colors.ToList(), "id", "ColorName");
            var item = db.ProductColors.Find(id);

            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductColor model)
        {
            if (ModelState.IsValid)
            {

                db.ProductColors.Attach(model);
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.ProductColors.Find(id);
            if (item != null)
            {
                db.ProductColors.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
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
                        var obj = db.ProductColors.Find(Convert.ToInt32(item));
                        db.ProductColors.Remove(obj);
                        db.SaveChanges();
                    }
                }
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}