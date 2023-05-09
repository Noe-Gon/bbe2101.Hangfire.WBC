namespace HangFireWebService.DB.WBC_DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class so_binnacle_visit
    {
        [Key]
        public int binnacleId { get; set; }

        public int customerId { get; set; }

        public int userId { get; set; }

        public bool is_visit { get; set; }

        public bool scanned { get; set; }

        public DateTime checkin { get; set; }

        public DateTime checkout { get; set; }

        public double latitudein { get; set; }

        public double longitudein { get; set; }

        public double longitudeout { get; set; }

        public double latitudeout { get; set; }

        public DateTime? createdon { get; set; }

        public int? createdby { get; set; }

        public DateTime? modifiedon { get; set; }

        public int? modifiedby { get; set; }

        public bool? status { get; set; }

        public virtual so_customer so_customer { get; set; }

        public virtual so_user so_user { get; set; }
    }
}
