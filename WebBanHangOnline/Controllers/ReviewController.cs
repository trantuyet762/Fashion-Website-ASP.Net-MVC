using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
    public class ReviewController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Review
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult _Review(int productId)
        {
            ViewBag.ProductId = productId;
            var item = new ReviewProduct();
        
            if (User.Identity.IsAuthenticated)
            {
              
                var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = userManager.FindByName(User.Identity.Name);
                if(user != null)
                {
                    item.Email = user.Email;
                    item.FullName = user.FullName;
                    item.UserName = user.UserName;
                }
                // Kiểm tra xem người dùng đã từng mua sản phẩm này chưa
                var order = db.Orders.FirstOrDefault(o => o.CustomerId == user.Id && o.OrderDetails.Any(od => od.ProductId == productId));
                if (order == null)
                {
                    ViewBag.ErrorMessage = "Bạn chưa mua sản phẩm này.";
                    return PartialView();
                }
                return PartialView(item);
            }
           
            return PartialView();
        }
        [AllowAnonymous]
        public ActionResult Load_Review(int productId)
        {
            var item = db.ReviewProducts.Where(x => x.ProductId == productId).OrderByDescending(x => x.id).ToList();
            ViewBag.Count = item.Count;
            return PartialView(item);
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult PostReview(ReviewProduct req)
        {
            if (User.Identity.IsAuthenticated)
            {
                var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = userManager.FindByName(User.Identity.Name);

                if (user != null)
                {
                    req.Email = user.Email;
                    req.FullName = user.FullName;
                    req.UserName = user.UserName;
                }

                if (ModelState.IsValid)
                {
                    req.CreatedDate = DateTime.Now;
                    db.ReviewProducts.Add(req);
                    db.SaveChanges();
                    return Json(new { Success = true });
                }
            }
            else
            {
                return Json(new { Success = false, Message = "Bạn phải đăng nhập để đánh giá." });
            }

            return Json(new { Success = false, Message = "Có lỗi xảy ra khi đánh giá." });
        }
     


    }
}