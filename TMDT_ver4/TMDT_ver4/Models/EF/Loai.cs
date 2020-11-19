namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Loai")]
    public partial class Loai
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDloai { get; set; }

        [StringLength(250)]
        public string TenLoai { get; set; }

        public int? IDdanhmuc { get; set; }
    }
}
