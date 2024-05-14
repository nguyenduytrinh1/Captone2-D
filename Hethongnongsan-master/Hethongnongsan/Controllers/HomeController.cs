using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hethongnongsan.Models;

namespace Hethongnongsan.Controllers
{
    public class HomeController : Controller
    {
        HethongnongsanContext db = new HethongnongsanContext();
        // GET: Home
        public ActionResult Index()
        {
            var listsp = db.Sanpham.ToList();
            var listblogs = db.Forum.ToList();
            ViewBag.listblogs = listblogs;
            string id = Request.Cookies["nguoidung"]?.Value.Replace("=", "");
            if (id != null)
            {
                Shop shop = db.Shop.Where(row => row.Idchusohuu == int.Parse(id)).FirstOrDefault();
                if (shop != null)
                {
                    ViewBag.shop = shop;
                }
                else
                {
                    ViewBag.shop = null; 
                }
            }
            else
            {
                ViewBag.shop = null;
            }
            return View(listsp);
        }
        public ActionResult Backadmin()
        {
            string url = "https://localhost:44345/Admin/Index";
            return Redirect(url);
        }
    }
}