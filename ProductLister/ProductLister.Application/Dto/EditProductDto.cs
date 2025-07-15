using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLister.Application.Dto
{
    public class EditProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Vendor { get; set; }
        public decimal Price { get; set; }
        public List<Guid> CategoryIds { get; set; }
    }
}
