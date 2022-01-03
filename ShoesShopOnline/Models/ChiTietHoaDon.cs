﻿namespace ShoesShopOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietHoaDon")]
    public partial class ChiTietHoaDon
    {
        [Key]
        [Column(Order = 0)]
        [DisplayName("Mã hóa đơn")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaHD { get; set; }

        [Key]
        [Column(Order = 1)]
        [DisplayName("Mã ảnh")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaAnh { get; set; }

        [Key]
        [Column(Order = 2)]
        [DisplayName("Kích cỡ")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KichCo { get; set; }

        [DisplayName("Số lượng mua")]
        public int SoluongMua { get; set; }

        public virtual HoaDon HoaDon { get; set; }

        public virtual ChiTietSanPham ChiTietSanPham { get; set; }
    }
}
