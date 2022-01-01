using ShoesShopOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoesShopOnline.Controllers
{
    public class AccountUserController : Controller
    {
        Shoes db = new Shoes();
        // GET: AccountUser
        [HttpGet]
        public ActionResult ChangePassWord()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassWord(string oldpassword, string password)
        {
            TaiKhoanNguoiDung tk = (TaiKhoanNguoiDung)Session[ShoesShopOnline.Session.ConstaintUser.USER_SESSION];
            if (tk.MatKhau != oldpassword)
            {
                ModelState.AddModelError("ErrorUpdate", "Mật khẩu cũ không đúng");
            }
            else
            {
                TaiKhoanNguoiDung edit = db.TaiKhoanNguoiDungs.Where(a => a.MaTK.Equals(tk.MaTK)).FirstOrDefault();
                edit.MatKhau = password;
                db.SaveChanges();
                Session[ShoesShopOnline.Session.ConstaintUser.USER_SESSION] = edit;
                ModelState.AddModelError("ErrorUpdate", "Đổi mật khẩu thành công!");
            }
            return View();
        }


        [HttpGet]
        public ActionResult UserInfor(int id)
        {
            TaiKhoanNguoiDung session = (TaiKhoanNguoiDung)Session[ShoesShopOnline.Session.ConstaintUser.USER_SESSION];
            if (session == null)
            {
                return RedirectToAction("PageNotFound", "Error");
            }
            else
            {
                TaiKhoanNguoiDung tk = db.TaiKhoanNguoiDungs.Where(a => a.MaTK.Equals(id)).FirstOrDefault();
                return View(tk);
            }
        }

        [HttpPost]
        public ActionResult UserInfor([Bind(Include = "MaTK,HoTen,SDT,DiaChi,Email")] TaiKhoanNguoiDung tk)
        {
            TaiKhoanNguoiDung edit = db.TaiKhoanNguoiDungs.Where(a => a.MaTK.Equals(tk.MaTK)).FirstOrDefault();
            try
            {
                edit.HoTen = tk.HoTen;
                edit.DiaChi = tk.DiaChi;
                edit.Email = tk.Email;
                edit.SDT = tk.SDT;
                db.SaveChanges();
                Session[ShoesShopOnline.Session.ConstaintUser.USER_SESSION] = edit;
            }
            catch (Exception)
            {
                ModelState.AddModelError("ErrorUpdate", "Cập nhật thông tin không thành công ! Thử lại sau !");
            }
            return View(edit);
        }
    }
}