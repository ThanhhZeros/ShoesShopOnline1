using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShoesShopOnline.Models;

namespace ShoesShopOnline.Areas.Admin.Controllers
{
    public class TaiKhoanQuanTrisController : Controller
    {
        private Shoes db = new Shoes();

        // GET: Admin/TaiKhoanQuanTris
        public ActionResult Index()
        {
            return View(db.TaiKhoanQuanTris.ToList());
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
        public ActionResult Edit([Bind(Include = "MaTK,TenDangNhap,MatKhau,HoTenUser,LoaiTK,TrangThai")] TaiKhoanQuanTri taiKhoanQuanTri)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taiKhoanQuanTri).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(taiKhoanQuanTri);
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
