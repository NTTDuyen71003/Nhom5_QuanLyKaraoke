namespace LTW_Karaoke.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHONG")]
    public partial class PHONG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHONG()
        {
            HOADONBANHANGs = new HashSet<HOADONBANHANG>();
        }

        [Key]
        public int IDPhong { get; set; }

        [Required]
        [StringLength(50)]
        public string TenPhong { get; set; }

        [Required]
        [StringLength(100)]
        public string TrangThai { get; set; }

        public int IDLoaiPhong { get; set; }

        public DateTime? NgayTao { get; set; }

        public DateTime? NgayCapNhat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADONBANHANG> HOADONBANHANGs { get; set; }

        public virtual LOAIPHONG LOAIPHONG { get; set; }
    }
}
