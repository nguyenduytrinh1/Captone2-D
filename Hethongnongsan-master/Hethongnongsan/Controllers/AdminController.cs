﻿using Hethongnongsan.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hethongnongsan.Controllers
{
    public class AdminController : Controller
    {
        HethongnongsanContext db = new HethongnongsanContext();
        // GET: Admin
        public ActionResult Index()
        {
            //Tổng tiền theo từng tháng
            List<Shopcart> shopa = db.Shopcart.ToList();
            float thang1 = 0; float thang2 = 0; float thang3 = 0; float thang4 = 0; float thang5 = 0; float thang6 = 0; float thang7 = 0; float thang8 = 0; float thang9 = 0;
            float thang10 = 0; float thang11 = 0; float thang12 = 0;
            if (shopa != null)
            {
                foreach (var item in shopa)
                {
                    string[] resultString = item.Ngaymua.ToString().Split('/');

                    Debug.WriteLine("Quản lý tài khoản: " + resultString[0]);
                    if (resultString[0] == "1")
                    {
                        thang1 = thang1 + (float)item.Tongtien;
                    }
                    else if (resultString[0] == "2")
                    {
                        thang2 = thang2 + (float)item.Tongtien;
                    }
                    else if (resultString[0] == "3")
                    {
                        thang3 = thang3 + (float)item.Tongtien;
                    }
                    else if (resultString[0] == "4")
                    {
                        thang4 = thang4 + (float)item.Tongtien;
                    }
                    else if (resultString[0] == "5")
                    {
                        thang5 = thang5 + (float)item.Tongtien;
                    }
                    else if (resultString[0] == "6")
                    {
                        thang6 = thang6 + (float)item.Tongtien;
                    }
                    else if (resultString[0] == "7")
                    {
                        thang7 = thang7 + (float)item.Tongtien;
                    }
                    else if (resultString[0] == "8")
                    {
                        thang8 = thang8 + (float)item.Tongtien;
                    }
                    else if (resultString[0] == "9")
                    {
                        thang9 = thang9 + (float)item.Tongtien;
                    }
                    else if (resultString[0] == "10")
                    {
                        thang10 = thang10 + (float)item.Tongtien;
                    }
                    else if (resultString[0] == "11")
                    {
                        thang11 = thang11 + (float)item.Tongtien;
                    }
                    else
                    {
                        thang12 = thang12 + (float)item.Tongtien;
                    }
                }
                ViewBag.thang1 = thang1;
                ViewBag.thang2 = thang2;
                ViewBag.thang3 = thang3;
                ViewBag.thang4 = thang4;
                ViewBag.thang5 = thang5;
                ViewBag.thang6 = thang6;
                ViewBag.thang7 = thang7;
                ViewBag.thang8 = thang8;
                ViewBag.thang9 = thang9;
                ViewBag.thang10 = thang10;
                ViewBag.thang11 = thang11;
                ViewBag.thang12 = thang12;


                //Quản lý tài khoản
                int count = db.Nguoidung.Count();

                //Tổng tiền theo từng năm
                List<Shopcart> shop = db.Shopcart.ToList();
                float tongdoanhthu = 0;
                foreach (var item in shop)
                {
                    string resultString = item.Ngaymua.ToString().Substring(0, item.Ngaymua.ToString().Length - 12);
                    string lastFourChars = resultString.Substring(resultString.Length - 4);
                    Debug.WriteLine("Quản lý tài khoản: " + lastFourChars);
                    if (lastFourChars == DateTime.Now.Year.ToString())
                    {
                        tongdoanhthu = tongdoanhthu + (float)item.Tongtien;
                    }
                }

                //shop nào bán hàng nhiều nhất
                int shopcarts = 0; int idshoptop = 0; int sps = 0; int idsanphamtop = 0;
                List<Shop> shops = db.Shop.ToList();
                foreach (var item in shops)
                {
                    int tongsoluong = (int)db.Shopcart.Where(row => row.Idshop == item.Idshop).Sum(s => s.Soluong);
                    if (shopcarts < tongsoluong)
                    {
                        shopcarts = tongsoluong;
                        idshoptop = item.Idshop;
                    }
                }

                //sản phẩm được mua nhiều nhất
                List<Sanpham> sp = db.Sanpham.ToList();
                foreach (var item in sp)
                {
                    int tongsoluong = (int)db.Shopcart.Where(row => row.Idsanpham == item.Idsanpham).Sum(s => s.Soluong);
                    if (sps < tongsoluong)
                    {
                        sps = tongsoluong;
                        idsanphamtop = item.Idsanpham;
                    }
                }
                Debug.WriteLine("Quản lý tài khoản: " + count);
                Debug.WriteLine("Tổng tiền theo từng năm: " + tongdoanhthu);
                Debug.WriteLine("shop nào bán hàng nhiều nhất: " + idshoptop);
                Debug.WriteLine("sản phẩm được mua nhiều nhất: " + idsanphamtop);

                Shop shoptop = db.Shop.Where(row => row.Idshop == idshoptop).FirstOrDefault();
                Sanpham sptop = db.Sanpham.Where(row => row.Idsanpham == idsanphamtop).FirstOrDefault();
                ViewBag.nguoidung = count;
                ViewBag.tongdoanhthu = tongdoanhthu;
                ViewBag.idshoptop = shoptop;
                ViewBag.idsanphamtop = sptop;
            }
            else
            {
                ViewBag.thang1 = thang1;
                ViewBag.thang2 = thang2;
                ViewBag.thang3 = thang3;
                ViewBag.thang4 = thang4;
                ViewBag.thang5 = thang5;
                ViewBag.thang6 = thang6;
                ViewBag.thang7 = thang7;
                ViewBag.thang8 = thang8;
                ViewBag.thang9 = thang9;
                ViewBag.thang10 = thang10;
                ViewBag.thang11 = thang11;
                ViewBag.thang12 = thang12;
                ViewBag.nguoidung = null;
                ViewBag.tongdoanhthu = null;
                ViewBag.idshoptop = null;
                ViewBag.idsanphamtop = null;
            }
            return View();
        }
        public ActionResult nguoidung()
        {
            List<Nguoidung> ngdung = db.Nguoidung.ToList();
            int count = db.Nguoidung.Count();

            //Tổng tiền theo từng năm
            List<Shopcart> shop = db.Shopcart.ToList();
            float tongdoanhthu = 0;
            foreach (var item in shop)
            {
                string resultString = item.Ngaymua.ToString().Substring(0, item.Ngaymua.ToString().Length - 12);
                string lastFourChars = resultString.Substring(resultString.Length - 4);
                Debug.WriteLine("Quản lý tài khoản: " + lastFourChars);
                if (lastFourChars == DateTime.Now.Year.ToString())
                {
                    tongdoanhthu = tongdoanhthu + (float)item.Tongtien;
                }
            }

            //shop nào bán hàng nhiều nhất
            int shopcarts = 0; int idshoptop = 0; int sps = 0; int idsanphamtop = 0;
            List<Shop> shops = db.Shop.ToList();
            foreach (var item in shops)
            {
                int tongsoluong = (int)db.Shopcart.Where(row => row.Idshop == item.Idshop).Sum(s => s.Soluong);
                if (shopcarts < tongsoluong)
                {
                    shopcarts = tongsoluong;
                    idshoptop = item.Idshop;
                }
            }

            //sản phẩm được mua nhiều nhất
            List<Sanpham> sp = db.Sanpham.ToList();
            foreach (var item in sp)
            {
                int tongsoluong = (int)db.Shopcart.Where(row => row.Idsanpham == item.Idsanpham).Sum(s => s.Soluong);
                if (sps < tongsoluong)
                {
                    sps = tongsoluong;
                    idsanphamtop = item.Idsanpham;
                }
            }
            Debug.WriteLine("Quản lý tài khoản: " + count);
            Debug.WriteLine("Tổng tiền theo từng năm: " + tongdoanhthu);
            Debug.WriteLine("shop nào bán hàng nhiều nhất: " + idshoptop);
            Debug.WriteLine("sản phẩm được mua nhiều nhất: " + idsanphamtop);

            Shop shoptop = db.Shop.Where(row => row.Idshop == idshoptop).FirstOrDefault();
            Sanpham sptop = db.Sanpham.Where(row => row.Idsanpham == idsanphamtop).FirstOrDefault();
            ViewBag.nguoidung = count;
            ViewBag.tongdoanhthu = tongdoanhthu;
            ViewBag.idshoptop = shoptop;
            ViewBag.idsanphamtop = sptop;

            return View(ngdung);
        }
        public ActionResult Shop()
        {
            List<Shop> shopa = db.Shop.ToList();

            int count = db.Nguoidung.Count();

            //Tổng tiền theo từng năm
            List<Shopcart> shop = db.Shopcart.ToList();
            float tongdoanhthu = 0;
            foreach (var item in shop)
            {
                string resultString = item.Ngaymua.ToString().Substring(0, item.Ngaymua.ToString().Length - 12);
                string lastFourChars = resultString.Substring(resultString.Length - 4);
                Debug.WriteLine("Quản lý tài khoản: " + lastFourChars);
                if (lastFourChars == DateTime.Now.Year.ToString())
                {
                    tongdoanhthu = tongdoanhthu + (float)item.Tongtien;
                }
            }

            //shop nào bán hàng nhiều nhất
            int shopcarts = 0; int idshoptop = 0; int sps = 0; int idsanphamtop = 0;
            List<Shop> shops = db.Shop.ToList();
            foreach (var item in shops)
            {
                int tongsoluong = (int)db.Shopcart.Where(row => row.Idshop == item.Idshop).Sum(s => s.Soluong);
                if (shopcarts < tongsoluong)
                {
                    shopcarts = tongsoluong;
                    idshoptop = item.Idshop;
                }
            }

            //sản phẩm được mua nhiều nhất
            List<Sanpham> sp = db.Sanpham.ToList();
            foreach (var item in sp)
            {
                int tongsoluong = (int)db.Shopcart.Where(row => row.Idsanpham == item.Idsanpham).Sum(s => s.Soluong);
                if (sps < tongsoluong)
                {
                    sps = tongsoluong;
                    idsanphamtop = item.Idsanpham;
                }
            }
            Debug.WriteLine("Quản lý tài khoản: " + count);
            Debug.WriteLine("Tổng tiền theo từng năm: " + tongdoanhthu);
            Debug.WriteLine("shop nào bán hàng nhiều nhất: " + idshoptop);
            Debug.WriteLine("sản phẩm được mua nhiều nhất: " + idsanphamtop);

            Shop shoptop = db.Shop.Where(row => row.Idshop == idshoptop).FirstOrDefault();
            Sanpham sptop = db.Sanpham.Where(row => row.Idsanpham == idsanphamtop).FirstOrDefault();
            ViewBag.nguoidung = count;
            ViewBag.tongdoanhthu = tongdoanhthu;
            ViewBag.idshoptop = shoptop;
            ViewBag.idsanphamtop = sptop;

            return View(shopa);
        }
        public ActionResult deleteNguoidung(int id)
        {
            Nguoidung nguoidung = db.Nguoidung.FirstOrDefault(row => row.Idnguoidung == id);
            if (nguoidung.Idshop != null)
            {
                Shop shop = db.Shop.FirstOrDefault(row => row.Idchusohuu == id);
                Sanpham sp = db.Sanpham.FirstOrDefault(row => row.Idshop == shop.Idshop);
                db.Shop.Remove(shop);
                db.Sanpham.Remove(sp);
                db.SaveChanges(true);
            }
            if (nguoidung.Idshopcart != null)
            {
                Shopcart shopcart = db.Shopcart.FirstOrDefault(row => row.Idnguoidung == id);
                db.Shopcart.Remove(shopcart);
                db.SaveChanges(true);
            }
            db.Nguoidung.Remove(nguoidung);          
            db.SaveChanges(true);
            return RedirectToAction("nguoidung");
        }
        public ActionResult allshop()
        {
            List<Shop> shopcart = db.Shop.ToList();


            //Quản lý tài khoản
            int count = db.Nguoidung.Count();

            //Tổng tiền theo từng năm
            List<Shopcart> shop = db.Shopcart.ToList();
            float tongdoanhthu = 0;
            foreach (var item in shop)
            {
                string resultString = item.Ngaymua.ToString().Substring(0, item.Ngaymua.ToString().Length - 12);
                string lastFourChars = resultString.Substring(resultString.Length - 4);
                Debug.WriteLine("Quản lý tài khoản: " + lastFourChars);
                if (lastFourChars == DateTime.Now.Year.ToString())
                {
                    tongdoanhthu = tongdoanhthu + (float)item.Tongtien;
                }
            }

            //shop nào bán hàng nhiều nhất
            int shopcarts = 0; int idshoptop = 0; int sps = 0; int idsanphamtop = 0;
            List<Shop> shops = db.Shop.ToList();
            foreach (var item in shops)
            {
                int tongsoluong = (int)db.Shopcart.Where(row => row.Idshop == item.Idshop).Sum(s => s.Soluong);
                if (shopcarts < tongsoluong)
                {
                    shopcarts = tongsoluong;
                    idshoptop = item.Idshop;
                }
            }

            //sản phẩm được mua nhiều nhất
            List<Sanpham> sp = db.Sanpham.ToList();
            foreach (var item in sp)
            {
                int tongsoluong = (int)db.Shopcart.Where(row => row.Idsanpham == item.Idsanpham).Sum(s => s.Soluong);
                if (sps < tongsoluong)
                {
                    sps = tongsoluong;
                    idsanphamtop = item.Idsanpham;
                }
            }
            Debug.WriteLine("Quản lý tài khoản: " + count);
            Debug.WriteLine("Tổng tiền theo từng năm: " + tongdoanhthu);
            Debug.WriteLine("shop nào bán hàng nhiều nhất: " + idshoptop);
            Debug.WriteLine("sản phẩm được mua nhiều nhất: " + idsanphamtop);

            Shop shoptop = db.Shop.Where(row => row.Idshop == idshoptop).FirstOrDefault();
            Sanpham sptop = db.Sanpham.Where(row => row.Idsanpham == idsanphamtop).FirstOrDefault();
            ViewBag.nguoidung = count;
            ViewBag.tongdoanhthu = tongdoanhthu;
            ViewBag.idshoptop = shoptop;
            ViewBag.idsanphamtop = sptop;
            return View(shopcart);
        }
    }
}