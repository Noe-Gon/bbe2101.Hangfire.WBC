using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HangFireCronEmail.Models
{
    public class GetCustomerRegisteredRequest
    {
        public int? branchId { get; set; }
        public int? routeId { get; set; }
        public List<int> routes { get; set; }
        public string customerName { get; set; }
        public int? customerId { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public string code { get; set; }
        public bool? status { get; set; }
        public int? start { get; set; }
        public int? size { get; set; }
    }
}