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
        public ActionResult Index(string madm, int? page)
        {
            //ViewBag.searchString = searchString;
            var sanphams = from s in db.SanPhams select new ProductDetail { };
            /*if (!String.IsNullOrEmpty(searchString))
            {
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
            }*/
                ViewBag.madm = madm;
                var danhmuc = (from ten in db.DanhMucSPs where ten.MaDM.Equals(madm) select ten).FirstOrDefault();
                ViewBag.tendm = danhmuc.TenDanhMuc;
                sanphams = (from p in db.SanPhams
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
            //var sanphams = db.SanPhams.Select(p => p);

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
            int pageSize = 9;
            int pageNumber = (page ?? 1);
            return View(danhsachSP.ToPagedList(pageNumber, pageSize));

        }

        /*public ActionResult SearchProduct(string search)
        {
            ICollection<ProductDetail> sanphams = (from p in db.SanPhams
                        join a in db.AnhMoTas on p.MaSP equals a.MaSP
                        where p.TenSP.Contains(search)
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
            ICollection<ProductDetail> products = Filter(sanphams);
            return View();
        }*/

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
            /* foreach (var item in listAnh)
             {
                 item.MaAnh
             }*/
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