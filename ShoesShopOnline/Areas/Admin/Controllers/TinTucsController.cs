using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ShoesShopOnline.Models;

namespace ShoesShopOnline.Areas.Admin.Controllers
{
    public class TinTucsController : Controller
    {
        private Shoes db = new Shoes();

        public ActionResult Index()
        {
            var tinTucs = db.TinTucs.Include(t => t.TaiKhoanQuanTri);
            return View(tinTucs.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TinTuc tinTuc = db.TinTucs.Find(id);
            if (tinTuc == null)
            {
                return HttpNotFound();
            }
            return View(tinTuc);
        }

        public ActionResult Create()
        {
            ViewBag.MaTK = new SelectList(db.TaiKhoanQuanTris, "MaTK", "TenDangNhap");
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTin,TenTin,NgayDang,MaTK,NoiDung")] TinTuc tinTuc)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.TinTucs.Add(tinTuc);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu !" + ex.Message;
                ViewBag.MaTK = new SelectList(db.TaiKhoanQuanTris, "MaTK", "TenDangNhap", tinTuc.MaTK);
                return View(tinTuc);
            }
        }

       
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TinTuc tinTuc = db.TinTucs.Find(id);
            if (tinTuc == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaTK = new SelectList(db.TaiKhoanQuanTris, "MaTK", "TenDangNhap", tinTuc.MaTK);
            return View(tinTuc);
        }

        
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTin,TenTin,NgayDang,MaTK,NoiDung")] TinTuc tinTuc)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //var tintuc = db.TinTucs.Where(p => p.MaTin == tinTuc.MaTin).FirstOrDefault();
                    //tintuc.MaTK = tinTuc.MaTK;
                    //tintuc.NgayDang = tinTuc.NgayDang;
                    //tintuc.TenTin = tinTuc.TenTin;
                    //tintuc.NoiDung = tinTuc.NoiDung;
                    db.Entry(tinTuc).State = EntityState.Modified;
                    db.SaveChanges();
                    
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu !" + ex.Message;
                ViewBag.MaTK = new SelectList(db.TaiKhoanQuanTris, "MaTK", "TenDangNhap", tinTuc.MaTK);
                return View(tinTuc);
            }
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            try
            {
                TinTuc tinTuc = db.TinTucs.Find(id);
                db.TinTucs.Remove(tinTuc);
                db.SaveChanges();
                return Json(new { status = true });
            }
            catch (Exception)
            {
                return Json(new { status = false });
            }
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
