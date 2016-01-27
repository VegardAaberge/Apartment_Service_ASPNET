using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ApartmentService.Models
{
    public class ApartmentServiceContext : DbContext
    {

        public ApartmentServiceContext() : base("name=ApartmentService")
        {
        }

        public DbSet<Assignment> Assignments { get; set; }
    }
}
