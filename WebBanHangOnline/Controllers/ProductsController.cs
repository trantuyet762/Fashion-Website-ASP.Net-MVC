﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;
namespace WebBanHangOnline.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Products
        [AllowAnonymous]
       /* public ActionResult Index()
        {
            var items = db.Products.ToList();
            return View(items);
        }*/
       public ActionResult Index(string searchtext, int? page)
        {
            IEnumerable<Product> items = db.Products.Where(x=> x.IsActive).OrderByDescending(x => x.id);
            

            if (!string.IsNullOrEmpty(searchtext))
            {
                var Searchtext = searchtext.ToLower();
                items = items.Where(x => x.Title.ToLower().Contains(Searchtext) || x.Alias.ToLower().Contains(Searchtext));
            }
            return View(items);
        }
        [AllowAnonymous]
        public ActionResult Detail(string alias, int id)
        {
            var item = db.Products.Find(id);
            if( item != null)
            {
                db.Products.Attach(item);
                item.ViewCount = item.ViewCount + 1;
                db.Entry(item).Property(x => x.ViewCount).IsModified = true;
                
                db.SaveChanges();
            }

            ViewBag.ProductSize = new SelectList(db.ProductColors.ToList(), "ProductID", "SizeName");
            ViewBag.ProductColor = new SelectList(db.ProductSizes.ToList(), "ProductID", "ColorName");
            return View(item);
        }
        [AllowAnonymous]
        public ActionResult ProductCategory(string alias,int id)
        {

            var items = db.Products.Where(x=> x.IsActive).ToList();
            if (id >0 )
            {
                items = items.Where(x => x.ProductCategoryID == id).ToList();
            }
            var cate = db.ProductCategories.Find(id);
            if(cate != null)
            {
                ViewBag.CateName = cate.Title;
            }
            ViewBag.CateId = id;
            return View(items);
        }
        [AllowAnonymous]
        public ActionResult Partial_ItemsByCateId()
        {
            var items = db.Products.Where(x => x.IsHome && x.IsActive).Take(12).ToList();
            return PartialView(items);
        }
        [AllowAnonymous]
        public ActionResult Partial_ProductSales()
        {
            var items = db.Products.Where(x => x.IsSale && x.IsActive).Take(12).ToList();
            return PartialView(items);
        }
        [AllowAnonymous]
        public ActionResult GetQuantity(int productId, int sizeId, int colorId)
        {
            var productQuantity = db.ProductQuantities.FirstOrDefault(pq => pq.ProductId == productId && pq.SizeId == sizeId && pq.ColorId == colorId);

            if (productQuantity != null)
            {
                return Json(productQuantity.QuantityProduct, JsonRequestBehavior.AllowGet);
            }

            return Json(0, JsonRequestBehavior.AllowGet);
        }

    }
}