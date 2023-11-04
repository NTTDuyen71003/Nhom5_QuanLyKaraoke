namespace LTW_Karaoke.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHACHHANG")]
    public partial class KHACHHANG
    {
        [Key]
        [StringLength(50)]
        public string SDT { get; set; }

        [Required]
        [StringLength(50)]
        public string HoTenKH { get; set; }

        [StringLength(50)]
        public string GioiTinh { get; set; }

        [StringLength(50)]
        public string DiaChiKH { get; set; }

        public int? TichLuy { get; set; }

        [StringLength(50)]
        public string HangThanhVien { get; set; }

        public int? Status { get; set; }
    }
}
