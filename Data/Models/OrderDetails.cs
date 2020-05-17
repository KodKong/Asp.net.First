using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class OrderDetails
    {
        public int ID { get; set; }
        public int IdOrder { get; set; }
        public int CarId { get; set; }
        public uint Cost { get; set; }
        
        public virtual Car Car { get; set; }
        public virtual Order Order { get; set; }
    }
}
