using ProductLister.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLister.Application.Dto
{
    public class ProductItemDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Vendor { get; set; }
        public decimal Price { get; set; }
        public List<CategoryDto> Categories { get; set; } = new();
    }
}
