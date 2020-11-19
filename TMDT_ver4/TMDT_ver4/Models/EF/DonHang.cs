namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHang")]
    public partial class DonHang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDorder { get; set; }

        public DateTime? Ngaydat { get; set; }

        public int? IDkhach { get; set; }

        [StringLength(50)]
        public string Shipname { get; set; }

        [StringLength(50)]
        public string Shipmobile { get; set; }

        [StringLength(50)]
        public string ShipAdress { get; set; }

        [StringLength(50)]
        public string ShipEmail { get; set; }

        public int? Tinhtrang { get; set; }
    }
}
