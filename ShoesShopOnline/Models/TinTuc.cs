namespace ShoesShopOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TinTuc")]
    public partial class TinTuc
    {
        [Key]
        [DisplayName("Mã tin")]
        public int MaTin { get; set; }

        [StringLength(100)]
        [DisplayName("Tên tin")]
        public string TenTin { get; set; }

        [DisplayName("Ngày đăng")]
        public DateTime NgayDang { get; set; }

        [DisplayName("Mã tài khoản")]
        public int? MaTK { get; set; }

        [Column(TypeName = "ntext")]
        [DisplayName("Nội dung")]
        public string NoiDung { get; set; }

        public virtual TaiKhoanQuanTri TaiKhoanQuanTri { get; set; }
    }
}
