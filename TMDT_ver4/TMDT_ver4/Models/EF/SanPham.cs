namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDsanpham { get; set; }

        [StringLength(250)]
        public string TenSanPham { get; set; }

        [StringLength(500)]
        public string ThongTinChiTiet { get; set; }

        [StringLength(250)]
        public string HinhAnh { get; set; }

        public decimal? Gia { get; set; }

        public int SoLuong { get; set; }

        public int? IDdanhmuc { get; set; }

        public int? IDnhasx { get; set; }

        public decimal? GiamGia { get; set; }

        public int IDloai { get; set; }
    }
}
