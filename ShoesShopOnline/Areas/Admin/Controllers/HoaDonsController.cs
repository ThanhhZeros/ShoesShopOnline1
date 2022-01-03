using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PagedList;
using ShoesShopOnline.Models;

namespace ShoesShopOnline.Areas.Admin.Controllers
{
    public class HoaDonsController : BaseController
    {
        private Shoes db = new Shoes();

        // GET: Admin/HoaDons
        public ActionResult Index(int? page, DateTime? searchString)
        {

            List<HoaDon> hoaDons = db.HoaDons.Include(h => h.TaiKhoanNguoiDung).Select(p => p).ToList();
            /*HoaDon hoaDonss = (from hd in db.HoaDons where hd.MaHD == 1 select hd).FirstOrDefault();*/
            if (searchString != null)
            {
                ViewBag.searchString = searchString.Value.ToShortDateString();
                string search = searchString.Value.ToShortDateString()/*ToString("MM/dd/yyyy")*/;
                hoaDons = hoaDons.Where(hd => hd.NgayLap.ToShortDateString().Equals(search)).ToList();
                /*hoaDonss = (from hd in db.HoaDons where hd.MaHD == 1 select hd).FirstOrDefault();*/
            }
            if (hoaDons.Count()==0)
            {
                ViewBag.Error = "Oops, Không thấy đơn hàng nào cậu ạ!" ;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(hoaDons.OrderBy(hd => hd.NgayLap).ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/HoaDons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // GET: Admin/HoaDons/Create
        public ActionResult Create()
        {
            ViewBag.MaTK = new SelectList(db.TaiKhoanNguoiDungs, "MaTK", "TenDangNhap");
            return View();
        }

        // POST: Admin/HoaDons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHD,MaTK,HoTenNguoiNhan,SDTNguoiNhan,DiaChiNhan,EmailNguoiNhan,NgayLap,TrangThai,GhiChu")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                db.HoaDons.Add(hoaDon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaTK = new SelectList(db.TaiKhoanNguoiDungs, "MaTK", "TenDangNhap", hoaDon.MaTK);
            return View(hoaDon);
        }

        // GET: Admin/HoaDons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaTK = new SelectList(db.TaiKhoanNguoiDungs, "MaTK", "TenDangNhap", hoaDon.MaTK);
            return View(hoaDon);
        }

        // POST: Admin/HoaDons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, string TrangThai)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var hoaDon = db.HoaDons.Find(id);
                    hoaDon.TrangThai = TrangThai;
                    db.Entry(hoaDon).State = EntityState.Modified;
                    db.SaveChanges();

                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi edit dữ liệu! " + ex.Message;
                return View();
            }
        }

        // GET: Admin/HoaDons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // POST: Admin/HoaDons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HoaDon hoaDon = db.HoaDons.Find(id);
            db.HoaDons.Remove(hoaDon);
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
        [HttpPost]
        public ActionResult ChangeStatus()
        {
            HoaDon hoaDon = db.HoaDons.Select(p => p).FirstOrDefault();
            if (hoaDon != null)
            {
                String trangthai = Request.Form["trangthai"];
            }
            return View();
        }
    }
}