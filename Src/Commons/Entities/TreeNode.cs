using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQF.Tutorial.EntityFramework.Commons.Entities
{
    public class TreeNode
    {
        public int Id { get; set; }

        public int ParentId { get; set; }

        public string Name { get; set; }

        public DateTime CreateTime { get; set; }


    }
}
