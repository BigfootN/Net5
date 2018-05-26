using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int Price { get; set; }
    }
}
