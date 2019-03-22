using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace V01_InnovtionWebAPP.DBContext
{
    public class innovationDbContext : DbContext
    {
        public innovationDbContext() : base("name=innovationDBConnection")
        {

        }

        public System.Data.Entity.DbSet<V01_InnovtionWebAPP.Models.ServiceCategory> ServiceCategories { get; set; }
    }
}