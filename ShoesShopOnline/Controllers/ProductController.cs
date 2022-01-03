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
        [HttpGet]
        public ActionResult Index(string searchString, string searchPrice, string madm, int? page)
        {

            ViewBag.searchString = searchString;
            ViewBag.searchPrice = searchPrice;
            var sanphams = (from p in db.SanPhams
                            join a in db.AnhMoTas on p.MaSP equals a.MaSP
                            where p.MaDM == madm
                            select new ProductDetail()
                            {
                                MaDM = p.MaDM,
                                MaSP = p.MaSP,
                                TenSP = p.TenSP,
                                GiaBan = p.GiaBan,
                                maAnh = a.MaAnh,
                                Anh = a.HinhAnh,
                                MoTa = p.MoTa
                            });
            ViewBag.madm = madm;
            var danhmuc = (from ten in db.DanhMucSPs where ten.MaDM.Equals(madm) select ten).FirstOrDefault();
            try
            {

                if (!String.IsNullOrEmpty(searchString) && !String.IsNullOrEmpty(searchPrice))
                {
                    decimal Gia = Convert.ToDecimal(searchPrice);
                    sanphams = (from p in db.SanPhams
                                join a in db.AnhMoTas on p.MaSP equals a.MaSP
                                where p.TenSP.Contains(searchString) && p.GiaBan <= Gia
                                select new ProductDetail()
                                {
                                    MaDM = p.MaDM,
                                    MaSP = p.MaSP,
                                    TenSP = p.TenSP,
                                    GiaBan = p.GiaBan,
                                    maAnh = a.MaAnh,
                                    Anh = a.HinhAnh,
                                    MoTa = p.MoTa
                                });
                }
                else if (!String.IsNullOrEmpty(searchString))
                {
                    //decimal Gia = Convert.ToDecimal(searchPrice);
                    sanphams = (from p in db.SanPhams
                                join a in db.AnhMoTas on p.MaSP equals a.MaSP
                                where p.TenSP.Contains(searchString)
                                select new ProductDetail()
                                {
                                    MaDM = p.MaDM,
                                    MaSP = p.MaSP,
                                    TenSP = p.TenSP,
                                    GiaBan = p.GiaBan,
                                    maAnh = a.MaAnh,
                                    Anh = a.HinhAnh,
                                    MoTa = p.MoTa
                                });
                }
                else if (!String.IsNullOrEmpty(searchPrice))
                {
                    decimal Gia = Convert.ToDecimal(searchPrice);
                    sanphams = (from p in db.SanPhams
                                join a in db.AnhMoTas on p.MaSP equals a.MaSP
                                where p.GiaBan <= Gia
                                select new ProductDetail()
                                {
                                    MaDM = p.MaDM,
                                    MaSP = p.MaSP,
                                    TenSP = p.TenSP,
                                    GiaBan = p.GiaBan,
                                    maAnh = a.MaAnh,
                                    Anh = a.HinhAnh,
                                    MoTa = p.MoTa
                                });
                }
            }
            catch (Exception)
            {

            }
            var products = new List<ProductDetail>();
            foreach (var item in sanphams)
            {
                int dem = 0;
                foreach (var t in products)
                {
                    if (item.MaSP.Equals(t.MaSP))
                        dem++;
                }
                if (dem == 0)
                    products.Add(item);
            }
            var danhsachSP = products.OrderBy(sp => sp.MaSP);
            if (danhsachSP.Count() == 0)
            {
                ViewBag.Error = "Không tìm được sản phẩm phù hợp!";
            }
            int pageSize = 9;
            int pageNumber = (page ?? 1);
            return View(danhsachSP.ToPagedList(pageNumber, pageSize));
        }


        public ActionResult ProductDetail(string id, int maImage, string madm)
        {
            //SanPham sp = db.SanPhams.Include("DanhMucSP").Where(s => s.MaSP.Equals(id)).FirstOrDefault();

            var sanpham = (from p in db.SanPhams
                           join a in db.AnhMoTas on p.MaSP equals a.MaSP
                           where p.MaSP.Equals(id) && a.MaAnh == maImage
                           select new ProductDetail()
                           {
                               MaDM = p.MaDM,
                               MaSP = p.MaSP,
                               TenSP = p.TenSP,
                               GiaBan = p.GiaBan,
                               maAnh = a.MaAnh,
                               Anh = a.HinhAnh,
                               MoTa = p.MoTa
                           }).FirstOrDefault();
            //int maImage = sanpham.maANh;
            ICollection<AnhMoTa> listAnh = (from a in db.AnhMoTas
                                            where a.MaSP.Equals(id)
                                            select a).ToList();
            ICollection<ChiTietSanPham> listSize = (from s in db.ChiTietSanPhams
                                                    where s.MaAnh.Equals(maImage)
                                                    select s).ToList();
            ICollection<ProductDetail> Products = (from p in db.SanPhams
                                                   join a in db.AnhMoTas on p.MaSP equals a.MaSP
                                                   where p.MaDM == madm
                                                   select new ProductDetail()
                                                   {
                                                       MaDM = p.MaDM,
                                                       MaSP = p.MaSP,
                                                       TenSP = p.TenSP,
                                                       GiaBan = p.GiaBan,
                                                       maAnh = a.MaAnh,
                                                       Anh = a.HinhAnh,
                                                       MoTa = p.MoTa
                                                   }).ToList();
            ICollection<ProductDetail> RelateProducts = Filter(Products);
            ViewBag.Images = listAnh;
            ViewBag.SizeList = listSize;
            ViewBag.ListRelate = RelateProducts;
            ViewBag.check = RelateProducts.Count();
            return View(sanpham);
        }
        private ICollection<ProductDetail> Filter(ICollection<ProductDetail> products)
        {
            List<ProductDetail> list = new List<ProductDetail>();
            foreach (var item in products)
            {
                int dem = 0;
                foreach (var t in list)
                {
                    if (item.MaSP == t.MaSP)
                        dem++;
                }
                if (dem == 0 && list.Count() < 4)
                    list.Add(item);
            }
            return list;
        }

    }
}