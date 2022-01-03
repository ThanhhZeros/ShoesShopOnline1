using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using ShoesShopOnline.Models;

namespace ShoesShopOnline.Areas.Admin.Controllers
{
    public class TaiKhoanQuanTrisController : BaseController
    {
        private Shoes db = new Shoes();

        // GET: Admin/TaiKhoanQuanTris
        public ActionResult Index(int? page)
        {
            ViewBag.Error = TempData["Error"];
            ViewBag.Success = TempData["Success"];
            var taikhoans = db.TaiKhoanQuanTris.Select(tk => tk);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(taikhoans.OrderBy(tk => tk.MaTK).ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/TaiKhoanQuanTris/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoanQuanTri taiKhoanQuanTri = db.TaiKhoanQuanTris.Find(id);
            if (taiKhoanQuanTri == null)
            {
                return HttpNotFound();
            }
            return View(taiKhoanQuanTri);
        }

        // GET: Admin/TaiKhoanQuanTris/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/TaiKhoanQuanTris/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTK,TenDangNhap,MatKhau,HoTenUser,LoaiTK,TrangThai")] TaiKhoanQuanTri taiKhoanQuanTri)
        {
            if (ModelState.IsValid)
            {
                db.TaiKhoanQuanTris.Add(taiKhoanQuanTri);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(taiKhoanQuanTri);
        }

        // GET: Admin/TaiKhoanQuanTris/Edit/5
        public ActionResult Edit(int? id)
        {        
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoanQuanTri taiKhoanQuanTri = db.TaiKhoanQuanTris.Find(id);
            if (taiKhoanQuanTri == null)
            {
                return HttpNotFound();
            }
            return View(taiKhoanQuanTri);
        }

        // POST: Admin/TaiKhoanQuanTris/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, bool TrangThai)
        {
            string Error = null;
            string Success = null;
            try
            {
                TaiKhoanQuanTri login = (TaiKhoanQuanTri)Session[ShoesShopOnline.Session.ConstaintUser.ADMIN_SESSION];
                if (ModelState.IsValid)
                {
                    TaiKhoanQuanTri acc = (from tk in db.TaiKhoanQuanTris where tk.MaTK.Equals(id) select tk).FirstOrDefault();
                    if (login.MaTK == acc.MaTK)
                    {
                        Error = "Bạn không thể sửa tài khoản này!";
                    }
                    else
                    {
                        var taiKhoanQuanTri = db.TaiKhoanQuanTris.Find(id);
                        taiKhoanQuanTri.TrangThai = TrangThai;
                        db.Entry(taiKhoanQuanTri).State = EntityState.Modified;
                        db.SaveChanges();
                        Success = "Update thành công!";
                    }
                }
                TempData["Error"] = Error;
                TempData["Success"] = Success;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi edit dữ liệu! " + ex.Message;
                return View();
            }
        }

        // GET: Admin/TaiKhoanQuanTris/Delete/5
        public ActionResult Delete(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoanQuanTri taiKhoanQuanTri = db.TaiKhoanQuanTris.Find(id);
            if (taiKhoanQuanTri == null)
            {
                return HttpNotFound();
            }
            return View(taiKhoanQuanTri);
        }

        // POST: Admin/TaiKhoanQuanTris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TaiKhoanQuanTri taiKhoanQuanTri = db.TaiKhoanQuanTris.Find(id);
            db.TaiKhoanQuanTris.Remove(taiKhoanQuanTri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}