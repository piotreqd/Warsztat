using System;
using System.Collections.Generic;
using System.Text;

namespace Warsztat.Model
{
    public class Activity : BaseEntity
    { 
        public virtual ICollection<Part> Parts { get; set; }
        public int OrderId { get; set; }

        public string Name { get; set; }
        public decimal LaborPrice { get; set; }
    }
}
