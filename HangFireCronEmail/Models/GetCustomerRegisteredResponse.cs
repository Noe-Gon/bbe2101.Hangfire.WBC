using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HangFireCronEmail.Models
{
    public class GetCustomerRegisteredResponse
    {
        public bool status { get; set; }
        public DataResponse data { get; set; }
        public List<object> errors { get; set; }
    }

    public class DataResponse
    {
        public int total { get; set; }
        public int totalPages { get; set; }
        public List<Item> items { get; set; }
    }

    public class Item
    {
        public int branchId { get; set; }
        public string branchName { get; set; }
        public int routeId { get; set; }
        public string routeName { get; set; }
        public int customerId { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string code { get; set; }
        public string createdBy { get; set; }
        public int created_by { get; set; }
        public DateTime createdOn { get; set; }
        public bool status { get; set; }
        public string validatedBy { get; set; }
        public DateTime validatedOn { get; set; }
        public string email_2 { get; set; }
        public string phone_2 { get; set; }
        public string codePlace { get; set; }
        public string street { get; set; }
        public string numExt { get; set; }
        public object numInt { get; set; }
        public string crossNumber { get; set; }
        public string crossNumber_2 { get; set; }
        public string country { get; set; }
        public string state { get; set; }
        public string municipality { get; set; }
        public string neighborhood { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public bool monday { get; set; }
        public bool tuesday { get; set; }
        public bool wednesday { get; set; }
        public bool thursday { get; set; }
        public bool friday { get; set; }
        public bool saturday { get; set; }
        public string neighborhoodId { get; set; }
        public string statusName { get; set; }
    }
}