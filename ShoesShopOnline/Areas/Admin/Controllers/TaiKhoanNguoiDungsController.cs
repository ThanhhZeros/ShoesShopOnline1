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
    public class TaiKhoanNguoiDungsController : Controller
    {
        private Shoes db = new Shoes();

        // GET: Admin/TaiKhoanNguoiDungs
        public ActionResult Index()
        {
            return View(db.TaiKhoanNguoiDungs.ToList());
        }

        // GET: Admin/TaiKhoanNguoiDungs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoanNguoiDung taiKhoanNguoiDung = db.TaiKhoanNguoiDungs.Find(id);
            if (taiKhoanNguoiDung == null)
            {
                return HttpNotFound();
            }
            return View(taiKhoanNguoiDung);
        }

        // GET: Admin/TaiKhoanNguoiDungs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/TaiKhoanNguoiDungs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTK,TenDangNhap,MatKhau,HoTen,SDT,DiaChi,Email,TrangThai")] TaiKhoanNguoiDung taiKhoanNguoiDung)
        {
            if (ModelState.IsValid)
            {
                db.TaiKhoanNguoiDungs.Add(taiKhoanNguoiDung);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(taiKhoanNguoiDung);
        }

        // GET: Admin/TaiKhoanNguoiDungs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoanNguoiDung taiKhoanNguoiDung = db.TaiKhoanNguoiDungs.Find(id);
            if (taiKhoanNguoiDung == null)
            {
                return HttpNotFound();
            }
            return View(taiKhoanNguoiDung);
        }

        // POST: Admin/TaiKhoanNguoiDungs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTK,TenDangNhap,MatKhau,HoTen,SDT,DiaChi,Email,TrangThai")] TaiKhoanNguoiDung taiKhoanNguoiDung)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taiKhoanNguoiDung).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(taiKhoanNguoiDung);
        }

        // GET: Admin/TaiKhoanNguoiDungs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoanNguoiDung taiKhoanNguoiDung = db.TaiKhoanNguoiDungs.Find(id);
            if (taiKhoanNguoiDung == null)
            {
                return HttpNotFound();
            }
            return View(taiKhoanNguoiDung);
        }

        // POST: Admin/TaiKhoanNguoiDungs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TaiKhoanNguoiDung taiKhoanNguoiDung = db.TaiKhoanNguoiDungs.Find(id);
            db.TaiKhoanNguoiDungs.Remove(taiKhoanNguoiDung);
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
