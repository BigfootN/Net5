using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.Models
{
    public class OrderStatus
    {
        public int Id { get; set; }
        public bool IsReady { get; set; }
        public bool IsSent { get; set; }
        public bool Delivered { get; set; }
    }
}
