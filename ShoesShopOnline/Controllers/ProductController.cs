using PagedList;
using ShoesShopOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoesShopOnline.Controllers
{
    public class ProductController : Controller
    {
        Shoes db = new Shoes();
        // GET: Product
        public ActionResult Index(string searchString, string madm, int page = 1, int pageSize = 9)
        {
            ViewBag.searchString = searchString;
            ViewBag.madm = madm;
            //var sanphams = db.SanPhams.Select(p => p);
            var sanphams = from p in db.SanPhams
                           join c in db.AnhMoTas on p.MaSP equals c.MaSP
                           join d in db.ChiTietSanPhams on c.MaAnh equals d.MaAnh
                           select new
                           {
                               p,
                               c,d
                           };
            if (!String.IsNullOrEmpty(searchString))
            {
                sanphams = sanphams.Where(sp => sp.p.TenSP.Contains(searchString));
            }
            if (madm != null && madm != null)
            {
                sanphams = sanphams.Where(s => s.p.MaDM == madm);
                ViewBag.DanhMuc = db.DanhMucSPs.Where(d => d.MaDM == madm).FirstOrDefault();
            }
            return View(sanphams.OrderBy(sp => sp.p.MaSP).ToPagedList(page, pageSize));
        }

        public ActionResult ProductDetail(int id)
        {
            SanPham sp = db.SanPhams.Include("DanhMucSP").Where(s => s.MaSP.Equals(id)).FirstOrDefault();
            List<ChiTietSanPham> list = db.ChiTietSanPhams.Include("SizeGiay").Where(s => s.MaAnh.Equals(id)).ToList();
            ViewBag.SPCT = list;
            ViewBag.Exitst = list[0];
            return View(sp);
        }
    }
}