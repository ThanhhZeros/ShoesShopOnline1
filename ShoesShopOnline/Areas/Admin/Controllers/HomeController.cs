using ShoesShopOnline.Models;
using System.Web.Mvc;

namespace ShoesShopOnline.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        Shoes db = new Shoes();
        // GET: Admin/Home
        public ActionResult Index()
        {
            int? dem = 0;
            foreach (var item in db.HoaDons)
            {
                if(item.TrangThai.Equals("Chờ xác nhận"))
                {
                    dem++;
                }
            }
            ViewBag.tong = dem;
            return View();
        }
    }
}