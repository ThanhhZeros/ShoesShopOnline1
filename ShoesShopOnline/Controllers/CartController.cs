using ShoesShopOnline.Models;
using ShoesShopOnline.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ShoesShopOnline.Controllers
{
    public class CartController : Controller
    {
        Shoes db = new Shoes();

        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[ConstainCart.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }

        //C1
        //public ActionResult AddItem(int maSP, int quality)
        //{
        //    var SanPham = db.ChiTietSanPhams.Where(p => p.MaAnh == maSP).FirstOrDefault();

        //    var cart = Session[CartSession];
        //    if (cart != null)
        //    {
        //        var list = (List<CartItem>)cart;
        //        if (list.Exists(x => x.ChiTietSanPham.MaAnh == maSP))
        //        {
        //            foreach (var item in list)
        //            {
        //                if (item.ChiTietSanPham.MaAnh == maSP)
        //                    item.SoLuong += quality;
        //            }
        //        }
        //        else
        //        {
        //            var item = new CartItem();
        //            item.ChiTietSanPham = SanPham;
        //            item.MaAnh = SanPham.MaAnh;
        //            item.SoLuong = quality;
        //            item.Gia = SanPham.AnhMoTa.SanPham.GiaBan;
        //            list.Add(item);
        //        }
        //        Session[CartSession] = list;
        //    }
        //    else
        //    {
        //        var item = new CartItem();
        //        item.ChiTietSanPham = SanPham;
        //        item.MaAnh = SanPham.MaAnh;
        //        item.SoLuong = quality;
        //        item.Gia = SanPham.AnhMoTa.SanPham.GiaBan;
        //        var list = new List<CartItem>();
        //        list.Add(item);
        //        Session[CartSession] = list;
        //    }
        //    return RedirectToAction("Index");
        //}

        //C2
        public JsonResult AddCart(int maSP, int kichCo)
        {
            var SanPham = db.ChiTietSanPhams.Where(p => p.MaAnh == maSP).FirstOrDefault();
            var cart = Session[ConstainCart.CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
<<<<<<< HEAD
                if (list.Exists(x => x.ChiTietSanPham.MaAnh == maSP && x.KichCo==kichCo))
=======
                if (list.Exists(x => x.ChiTietSanPham.MaAnh == maSP && x.KichCo == kichCo))
>>>>>>> 3ef677c70d3ebdedd570a5cebc28b220eb812637
                {
                    foreach (var item in list)
                    {
                        if (item.ChiTietSanPham.MaAnh == maSP && item.KichCo == kichCo)
                            item.SoLuong += 1;
                    }
                }
                else
                {
                    var item = new CartItem();
                    item.ChiTietSanPham = SanPham;
                    item.MaAnh = SanPham.MaAnh;
                    item.KichCo = kichCo;
                    item.SoLuong = 1;
                    item.Gia = SanPham.AnhMoTa.SanPham.GiaBan;
                    list.Add(item);
                }
                Session[ConstainCart.CartSession] = list;
            }
            else
            {
                var item = new CartItem();
                item.ChiTietSanPham = SanPham;
                item.MaAnh = SanPham.MaAnh;
                item.KichCo = kichCo;
                item.SoLuong = 1;
                item.Gia = SanPham.AnhMoTa.SanPham.GiaBan;
                var list = new List<CartItem>();
                list.Add(item);
                Session[ConstainCart.CartSession] = list;
            }
            return Json(new
            {
                status = true
            });
        }

        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[ConstainCart.CartSession];
            foreach (var item in sessionCart)
            {
<<<<<<< HEAD
                var jsonItem = jsonCart.SingleOrDefault(x => x.ChiTietSanPham.MaAnh == item.MaAnh && x.KichCo==item.KichCo);
=======
                var jsonItem = jsonCart.SingleOrDefault(x => x.ChiTietSanPham.MaAnh == item.MaAnh && x.KichCo == item.KichCo);
>>>>>>> 3ef677c70d3ebdedd570a5cebc28b220eb812637
                if (jsonItem != null)
                {
                    item.SoLuong = jsonItem.SoLuong;
                }
            }
            Session[ConstainCart.CartSession] = sessionCart;
            return Json(sessionCart, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(int MaAnh, int KichCo)
        {
            var sessionCart = (List<CartItem>)Session[ConstainCart.CartSession];
<<<<<<< HEAD
            sessionCart.RemoveAll(x => x.MaAnh == MaAnh&&x.KichCo==KichCo);
=======
            sessionCart.RemoveAll(x => x.MaAnh == MaAnh && x.KichCo == KichCo);
>>>>>>> 3ef677c70d3ebdedd570a5cebc28b220eb812637
            Session[ConstainCart.CartSession] = sessionCart;
            return Json(sessionCart, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Payment()
        {
<<<<<<< HEAD
            
=======

>>>>>>> 3ef677c70d3ebdedd570a5cebc28b220eb812637
            if (Session[ShoesShopOnline.Session.ConstaintUser.USER_SESSION] == null || Session[ShoesShopOnline.Session.ConstaintUser.USER_SESSION].ToString() == "")
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var cart = Session[ConstainCart.CartSession];
                var list = new List<CartItem>();
                if (cart != null)
                {
                    list = (List<CartItem>)cart;
                }
                return View(list);
            }
        }

        public ActionResult Payment(FormCollection collection)
        {
            //Thêm đơn hàng
            HoaDon hoaDon = new HoaDon();
            TaiKhoanNguoiDung tk = (TaiKhoanNguoiDung)Session[ShoesShopOnline.Session.ConstaintUser.USER_SESSION];
            hoaDon.MaTK = tk.MaTK;
            hoaDon.HoTenNguoiNhan = collection["name"];
            hoaDon.SDTNguoiNhan = collection["phone"];
            hoaDon.EmailNguoiNhan = collection["email"];
            hoaDon.DiaChiNhan = collection["address"];
            hoaDon.GhiChu = collection["note"];
            hoaDon.NgayLap = DateTime.Now;
            hoaDon.TrangThai = "Đang chuẩn bị";
            db.HoaDons.Add(hoaDon);
            db.SaveChanges();
            //Thêm chi tiết đơn hàng
            var cart = Session[ConstainCart.CartSession];
            var list = new List<CartItem>();
            list = (List<CartItem>)cart;
<<<<<<< HEAD
            foreach(var item in list)
=======
            foreach (var item in list)
>>>>>>> 3ef677c70d3ebdedd570a5cebc28b220eb812637
            {
                ChiTietHoaDon cthd = new ChiTietHoaDon();
                cthd.MaHD = hoaDon.MaHD;
                cthd.MaAnh = item.MaAnh;
                cthd.KichCo = item.KichCo;
                cthd.SoluongMua = item.SoLuong;
                db.ChiTietHoaDons.Add(cthd);
            }
            db.SaveChanges();
            Session[ConstainCart.CartSession] = null;
            return RedirectToAction("SubmitOrder", "Cart");
        }

        public ActionResult SubmitOrder()
        {
            return View();
        }
    }

}