using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.Controllers
{
    public class ContactController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Contact
        public ActionResult Index()
        {
           
            return View();
        }
    }
}