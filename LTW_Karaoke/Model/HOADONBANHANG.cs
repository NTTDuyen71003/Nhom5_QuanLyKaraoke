namespace LTW_Karaoke.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOADONBANHANG")]
    public partial class HOADONBANHANG
    {
        [Key]
        public int IDHoaDon { get; set; }

        public int IDPhong { get; set; }

        public int IDMatHang { get; set; }

        public DateTime? ThoiGianBD { get; set; }

        public DateTime? ThoiGianKT { get; set; }

        [StringLength(150)]
        public string Sl { get; set; }

        public double? DonGia { get; set; }

        [Required]
        [StringLength(50)]
        public string TenTaiKhoan { get; set; }

        public DateTime? NgayTao { get; set; }

        public decimal? ThanhTien { get; set; }

        public double? TongHoaDon { get; set; }

        public virtual MATHANG MATHANG { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }

        public virtual PHONG PHONG { get; set; }
    }
}
