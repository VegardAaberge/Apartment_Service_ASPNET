using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApartmentService.Models
{
    public class Assignment
    {
        public int ID { get; set; }
        public string CreatedBy { get; set; }
        public string ProjectName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Information { get; set; }
        public string Category { get; set; }
        public string Subcategory { get; set; }
        public DateTime TimeCreated { get; set; }
        public string Responsible { get; set; }
        public string TechnicalInfo { get; set; }
        public string Status { get; set; }
    }
}