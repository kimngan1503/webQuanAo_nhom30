namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhaSanXuat")]
    public partial class NhaSanXuat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDnhasx { get; set; }

        [StringLength(250)]
        public string TenNhaSX { get; set; }
    }
}
