using ShoesShopOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace ShoesShopOnline.Models
{
    public class CartItem
    {
        [ScriptIgnore]
<<<<<<< HEAD
        public virtual ChiTietSanPham ChiTietSanPham{ set; get; }
=======
        public virtual ChiTietSanPham ChiTietSanPham { set; get; }
>>>>>>> 3ef677c70d3ebdedd570a5cebc28b220eb812637
        public int MaAnh { set; get; }
        public int KichCo { set; get; }
        public int SoLuong { set; get; }
        public decimal Gia { set; get; }
    }
}