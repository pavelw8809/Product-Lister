using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLister.Domain.Entities
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductVendor { get; set; }
        public decimal ProductPrice { get; set; }
        public List<Guid> CategoryIds { get; set; } = new();
    }
}
