namespace HangFireWebService.DB.WBC_DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class so_customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public so_customer()
        {
            so_binnacle_visit = new HashSet<so_binnacle_visit>();
        }

        [Key]
        public int customerId { get; set; }

        [Required]
        [StringLength(50)]
        public string code { get; set; }

        [Required]
        public string contact { get; set; }

        [Required]
        public string name { get; set; }

        public string address { get; set; }

        public string description { get; set; }

        public double? latitude { get; set; }

        public double? longitude { get; set; }

        public string email { get; set; }

        public DateTime? createdon { get; set; }

        public int? createdby { get; set; }

        public DateTime? modifiedon { get; set; }

        public int? modifiedby { get; set; }

        public bool status { get; set; }

        public int? providerId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<so_binnacle_visit> so_binnacle_visit { get; set; }
    }
}
