﻿using Hethongnongsan.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;

namespace Hethongnongsan.Controllers
{
    public class SoldController : Controller
    { //Scaffold-DbContext "Data Source=NGUYENDUYTRINH\DUYTRINH;Initial Catalog=Hethongnongsan;Integrated Security=True;Encrypt=True;Trust Server Certificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -force
        HethongnongsanContext db = new HethongnongsanContext();
        // GET: Sold
        public ActionResult Index()
        {
            string ids = Request.Cookies["nguoidung"]?.Value.Replace("=", "");
            if (ids != null)
            {
                Shop shop = db.Shop.Where(row => row.Idchusohuu == int.Parse(ids)).FirstOrDefault();
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
            return View();
        }
        [HttpPost]
        public ActionResult soldpro(SanPhamDaBan spdb)
        {       
            db.SanPhamDaBan.Add(spdb);
            String listshopcart = spdb.Idshopcart.ToString();
            string[] numberStrings = listshopcart.Split(',');
            string[] newNumberStrings = new string[numberStrings.Length - 1];
            Array.Copy(numberStrings, newNumberStrings, numberStrings.Length - 1);
            int[] numbers = newNumberStrings.Select(int.Parse).ToArray();
            int i = 0;
            Debug.WriteLine("Số lượng sản phẩm đã bán: " + listshopcart);
            foreach (var item in numbers)
            {
                Shopcart shopcart = db.Shopcart.Where(row => row.Idshopcart == numbers[i]).FirstOrDefault();
                shopcart.Status = 1;
                shopcart.Diemden = spdb.Diachi;
                shopcart.Ngaymua = spdb.Ngayban;

                Sanpham sp = db.Sanpham.Where(row => row.Idsanpham == shopcart.Idsanpham).FirstOrDefault();
                shopcart.Tongtien = (float)sp.Gia * shopcart.Soluong;
                i++;
            }
            db.SaveChanges();
            String url = "https://localhost:44345/Products/Detail/" + spdb.Idnguoimua;
            return Redirect(url);
        }
    }
}