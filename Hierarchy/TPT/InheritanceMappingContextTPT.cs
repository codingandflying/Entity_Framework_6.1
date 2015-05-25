using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace TPT
{
    public class InheritanceMappingContextTPT:DbContext
    {
        public DbSet<BillingDetail> BillingDetails { get; set; }
    }
}
