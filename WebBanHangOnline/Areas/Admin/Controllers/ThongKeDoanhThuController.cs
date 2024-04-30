using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;
namespace WebBanHangOnline.Areas.Admin.Controllers
{
   /* [Authorize(Roles = "Admin")]*/
    public class ThongKeDoanhThuController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/ThongKeDoanhThu
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ThongKeDoanhThu(string fromDate, string toDate)
        {
            var query = from order in db.Orders
                        join orderdetail in db.OrderDetails on order.id equals orderdetail.OrderId
                        join product in db.Products on orderdetail.ProductId equals product.id
                        select new
                        {
                            CreatedDate = order.CreatedDate,
                            Quantity = orderdetail.Quantity,
                            Price = orderdetail.Price,
                            OriginalPrice = product.OriginalPrice
                        };
            if (!string.IsNullOrEmpty(fromDate))
            {
                DateTime startDate = DateTime.ParseExact(fromDate, "dd/MM/yyyy", null);
                query = query.Where(x => x.CreatedDate >= startDate);
            }
            if (!string.IsNullOrEmpty(toDate))
            {
                DateTime endDate = DateTime.ParseExact(toDate, "dd/MM/yyyy", null);
                query = query.Where(x => x.CreatedDate <= endDate);
            }
            var result = query.GroupBy(x => DbFunctions.TruncateTime(x.CreatedDate)).Select(x => new
            {
                Date = x.Key.Value,
                TotalBuy =  x.Sum(y => y.Quantity * y.OriginalPrice),
                TotalSell = x.Sum(y => y.Quantity * y.Price)
            }).Select(x => new
            {
                Date = x.Date,
                DoanhThu = x.TotalSell,
                LoiNhuan = x.TotalSell - x.TotalBuy
            });
            return Json(new {Data= result }, JsonRequestBehavior.AllowGet);

        }
    }
}