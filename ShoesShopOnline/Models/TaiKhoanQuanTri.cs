namespace ShoesShopOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoanQuanTri")]
    public partial class TaiKhoanQuanTri
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaiKhoanQuanTri()
        {
            TinTucs = new HashSet<TinTuc>();
        }

        [Key]
        [DisplayName("Mã tài khoản")]
        public int MaTK { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Tên đăng nhập")]
        public string TenDangNhap { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Mật khẩu")]
        public string MatKhau { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Họ tên")]
        public string HoTenUser { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Loại tài khoản")]
        public string LoaiTK { get; set; }

        [DisplayName("Trạng thái")]
        public bool TrangThai { get; set; }

        [StringLength(20)]
        [DisplayName("Số điện thoại")]
        public string SDT { get; set; }

        [StringLength(500)]
        [DisplayName("Địa chỉ")]
        public string DiaChi { get; set; }

        [StringLength(50)]
        [DisplayName("Email")]
        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TinTuc> TinTucs { get; set; }
    }
}
