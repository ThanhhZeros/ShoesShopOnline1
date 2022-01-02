namespace ShoesShopOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoanNguoiDung")]
    public partial class TaiKhoanNguoiDung
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaiKhoanNguoiDung()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        [Key]
        [DisplayName("Mã tài khoản")]
        public int MaTK { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Tên đăng nhập")]
        public string TenDangNhap { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("Mật khẩu")]
        public string MatKhau { get; set; }

        [Required]
        [StringLength(200)]
        [DisplayName("Họ tên")]
        public string HoTen { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("Số điện thoại")]
        public string SDT { get; set; }

        [Required]
        [StringLength(500)]
        [DisplayName("Địa chỉ")]
        public string DiaChi { get; set; }

        [StringLength(50)]
        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Trạng thái")]
        public bool TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
