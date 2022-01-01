namespace ShoesShopOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDon()
        {
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
        }

        [Key]
        [DisplayName("Mã hóa đơn")]
        public int MaHD { get; set; }

        [DisplayName("Mã tài khoản")]
        public int? MaTK { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Họ tên người nhận")]
        public string HoTenNguoiNhan { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("Số điện thoại")]
        public string SDTNguoiNhan { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Địa chỉ")]
        public string DiaChiNhan { get; set; }

        [StringLength(50)]
        [DisplayName("Email")]
        public string EmailNguoiNhan { get; set; }

        [DisplayName("Ngày lập")]
        public DateTime? NgayLap { get; set; }

        [StringLength(50)]
        [DisplayName("Trạng thái")]
        public string TrangThai { get; set; }

        [StringLength(50)]
        [DisplayName("Ghi chú")]
        public string GhiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        public virtual TaiKhoanNguoiDung TaiKhoanNguoiDung { get; set; }
    }
}
