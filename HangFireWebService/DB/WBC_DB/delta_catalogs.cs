namespace HangFireWebService.DB.WBC_DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class delta_catalogs
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idDelta { get; set; }

        [Key]
        [StringLength(50)]
        public string code { get; set; }

        [Required]
        [StringLength(100)]
        public string catalog_name { get; set; }

        public DateTime delta_date { get; set; }

        public DateTime? createdon { get; set; }

        public int? createdby { get; set; }

        public DateTime? modifiedon { get; set; }

        public int? modifiedby { get; set; }

        public bool status { get; set; }
    }
}
