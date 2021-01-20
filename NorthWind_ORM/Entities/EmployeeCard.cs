using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind_ORM.Entities
{
    public class EmployeeCard
    {
        public int EmployeeCardId { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string CardHolderName { get; set; }
        
        public int EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }



    }
}
