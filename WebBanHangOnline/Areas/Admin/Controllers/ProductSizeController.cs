using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;
namespace WebBanHangOnline.Areas.Admin.Controllers
{
    public class ProductSizeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/ProductSize
        public ActionResult Index()
        {
            var items = db.ProductSizes.ToList();
            return View(items);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ProductSizes model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
                model.Modifieddate = DateTime.Now;

               

                db.ProductSizes.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            var item = db.ProductSizes.Find(id);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductSizes model)
        {
            if (ModelState.IsValid)
            {
                model.Modifieddate = DateTime.Now;

               
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
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}