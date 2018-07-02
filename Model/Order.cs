using System;
using System.Collections.Generic;
using System.Text;

namespace Warsztat.Model
{
    public class Order : BaseEntity
    { 
        public virtual ICollection<Activity> Activities { get; set; }
        //public int CarId { get; set; }
        public int CarId { get; set; }
        
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
