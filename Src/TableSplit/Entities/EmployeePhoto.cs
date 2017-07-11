using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace TableSplit.Entities
{
    public class EmployeePhoto
    {
        [Key]
        public int EmployeeID { get; set; }
        public byte[] Photo { get; set; }
        public string PhotoPath { get; set; }
    }
}
