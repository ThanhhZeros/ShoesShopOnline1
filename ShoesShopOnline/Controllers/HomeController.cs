using ShoesShopOnline.Areas.Admin.Data;
using ShoesShopOnline.Models;
using ShoesShopOnline.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoesShopOnline.Controllers
{
    public class HomeController : Controller
    {
        Shoes db = new Shoes();
        // GET: About
        public ActionResult Index()
        {
            //ViewBag.searchString = searchString;
            var sanphams = from s in db.SanPhams select new ProductDetail { };
            sanphams = from p in db.SanPhams
                       join a in db.AnhMoTas on p.MaSP equals a.MaSP
                       orderby p.NgayTao
                       select new ProductDetail()
                       {
                           MaDM = p.MaDM,
                           MaSP = p.MaSP,
                           TenSP = p.TenSP,
                           GiaBan = p.GiaBan,
                           maAnh = a.MaAnh,
                           Anh = a.HinhAnh,
                           MoTa = p.MoTa
                       };
            var products = new List<ProductDetail>();
            foreach (ProductDetail item in sanphams)
            {
                int dem = 0;
                foreach (var t in products)
                {
                    if (item.MaSP.Equals(t.MaSP))
                        dem++;
                }
                if (dem == 0 && products.Count() < 8)
                {
                    products.Add(item);
                }
            }
            /*var topBanChay = (from s in db.SanPhams
                              join a in db.AnhMoTas on s.MaSP equals a.MaSP
                              join dh in db.ChiTietHoaDons on a.MaAnh equals dh.MaAnh
                              group s by s.MaSP into g
                              select g).ToList();*/
            return View(products.ToList());

        }
        [HttpGet]
        public ActionResult Login()
        {
            TaiKhoanNguoiDung session = (TaiKhoanNguoiDung)Session[ShoesShopOnline.Session.ConstaintUser.USER_SESSION];
            if (session != null)
            {
                return RedirectToAction("PageNotFound", "Error");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginAccount loginAccount)
        {
            if (ModelState.IsValid)
            {
                TaiKhoanNguoiDung tk = db.TaiKhoanNguoiDungs.Where
                (a => a.TenDangNhap.Equals(loginAccount.username) && a.MatKhau.Equals(loginAccount.password)).FirstOrDefault();
                if (tk != null)
                {
                    if (tk.TrangThai == false)
                    {
                        ModelState.AddModelError("ErrorLogin", "Tài khoản của bạn đã bị vô hiệu hóa !");
                    }
                    else
                    {
                        Session.Add(ConstaintUser.USER_SESSION, tk);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("ErrorLogin", "Tài khoản hoặc mật khẩu không đúng!");
                }
            }
            return View(loginAccount);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Remove(ConstaintUser.USER_SESSION);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            TaiKhoanNguoiDung session = (TaiKhoanNguoiDung)Session[ShoesShopOnline.Session.ConstaintUser.USER_SESSION];
            if (session != null)
            {
                return RedirectToAction("PageNotFound", "Error");
            }
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(TaiKhoanNguoiDung tk)
        {
            TaiKhoanNguoiDung check = db.TaiKhoanNguoiDungs.Where
                (a => a.TenDangNhap.Equals(tk.TenDangNhap)).FirstOrDefault();
            if (check != null)
            {
                ModelState.AddModelError("ErrorSignUp", "Tên đăng nhập đã tồn tại");
            }
            else
            {
                try
                {
                    tk.TrangThai = true;
                    db.TaiKhoanNguoiDungs.Add(tk);
                    db.SaveChanges();
                    TaiKhoanNguoiDung session = db.TaiKhoanNguoiDungs.Where(a => a.TenDangNhap.Equals(tk.TenDangNhap)).FirstOrDefault();
                    Session[ShoesShopOnline.Session.ConstaintUser.USER_SESSION] = session;
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("ErrorSignUp", "Đăng ký không thành công. Thử lại sau !");
                }
            }

            return View(tk);
        }
        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Blog()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult DanhMuc()
        {
            IEnumerable<DanhMucSP> danhmucs = db.DanhMucSPs.Select(p => p);
            return PartialView(danhmucs);
        }
    }
}