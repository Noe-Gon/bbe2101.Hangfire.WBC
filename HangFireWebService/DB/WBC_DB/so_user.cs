namespace HangFireWebService.DB.WBC_DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class so_user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public so_user()
        {
            so_binnacle_visit = new HashSet<so_binnacle_visit>();
        }

        [Key]
        public int userId { get; set; }

        public int branchId { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        [StringLength(50)]
        public string code { get; set; }

        public int type { get; set; }

        public DateTime? createdon { get; set; }

        public int? createdby { get; set; }

        public DateTime? modifiedon { get; set; }

        public int? modifiedby { get; set; }

        public bool status { get; set; }

        public int? closureTypeId { get; set; }

        [StringLength(50)]
        public string tag { get; set; }

        public int? tracking_configurationId { get; set; }

        public int? providerId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<so_binnacle_visit> so_binnacle_visit { get; set; }

        public virtual so_branch so_branch { get; set; }
    }
}
