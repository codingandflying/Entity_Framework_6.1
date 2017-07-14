using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HQF.Tutorial.EntityFramework.Commons.Entities;

namespace HQF.Tutorial.EntityFramework.Commons.DbContexts
{
    public class TreeNodeDbContext:DbContext
    {
        public DbSet<TreeNode> TreeNodes { get; set; }

    }
}
