using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.Web.Mvc;
using System.IO;
using System.Net;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;
namespace WebBanHangOnline.Areas.Admin.Controllers
{
    public class ProductSizeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/ProductSize
        public ActionResult Index(int? page)
        {
            IEnumerable<ProductSize> items = db.ProductSizes.OrderByDescending(x => x.id).ToList();
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
            ViewBag.Size = new SelectList(db.Sizes.ToList(), "id", "SizeName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ProductSize model)
        {
            if (ModelState.IsValid)
            {



                db.ProductSizes.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            ViewBag.Product = new SelectList(db.Products.ToList(), "id", "Title");
            ViewBag.Size = new SelectList(db.Sizes.ToList(), "id", "SizeName");

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            ViewBag.Product = new SelectList(db.Products.ToList(), "id", "Title");
            ViewBag.Size = new SelectList(db.Sizes.ToList(), "id", "SizeName");
            var item = db.ProductSizes.Find(id);

            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductSize model)
        {
            if (ModelState.IsValid)
            {

                db.ProductSizes.Attach(model);
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.ProductSizes.Find(id);
            if (item != null)
            {
                db.ProductSizes.Remove(item);
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
                        var obj = db.ProductSizes.Find(Convert.ToInt32(item));
                        db.ProductSizes.Remove(obj);
                        db.SaveChanges();
                    }
                }
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}