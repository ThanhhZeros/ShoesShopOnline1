using ShoesShopOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoesShopOnline.Areas.Admin.Controllers
{
    public class ProfileController : Controller
    {
        Shoes db = new Shoes();
        // GET: Admin/Profile
        [HttpGet]
        public ActionResult AdminInfor(int id)
        {
            TaiKhoanQuanTri session = (TaiKhoanQuanTri)Session[ShoesShopOnline.Session.ConstaintUser.ADMIN_SESSION];
            if (session == null)
            {
                return RedirectToAction("PageNotFound", "Error");
            }
            else
            {
                TaiKhoanQuanTri tk = db.TaiKhoanQuanTris.Where(a => a.MaTK.Equals(id)).FirstOrDefault();
                return View(tk);
            }
        }

        [HttpPost]
        public ActionResult AdminInfor([Bind(Include = "MaTK,HoTenUser,TenDangNhap,MatKhau,LoaiTK")] TaiKhoanQuanTri tk)
        {
            TaiKhoanQuanTri edit = db.TaiKhoanQuanTris.Where(a => a.MaTK.Equals(tk.MaTK)).FirstOrDefault();
            try
            {
                edit.HoTenUser = tk.HoTenUser;
                edit.TenDangNhap = tk.TenDangNhap;
                edit.MatKhau = tk.MatKhau;
                edit.LoaiTK = tk.LoaiTK;
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