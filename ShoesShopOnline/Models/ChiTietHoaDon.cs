namespace ShoesShopOnline.Models
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
        [DisplayName("Mã hóa đơn")]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaHD { get; set; }

        [Key]
        [DisplayName("Mã ảnh")]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaAnh { get; set; }

        [Key]
        [DisplayName("Kích cỡ")]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KichCo { get; set; }

        
        [DisplayName("Số lượng mua")]
        public int SoluongMua { get; set; }

        public virtual HoaDon HoaDon { get; set; }

        public virtual ChiTietSanPham ChiTietSanPham { get; set; }
    }
}
