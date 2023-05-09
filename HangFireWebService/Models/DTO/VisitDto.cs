using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HangFireWebService.Models.DTO
{
    public class VisitDto
    {
        public int BinnacleVisitId { get; set; }
        public int BranchCode { get; set; }
        public int UserCode { get; set; }
        public int CustomerCode { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public double LatitudeIn { get; set; }
        public double LongitudeIn { get; set; }
        public bool Scanned { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UserType { get; set; }
        public string Figura { get; set; }
    }
}