using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiles.Core.DTO.ProductDto
{
    public class ProductUpdateRequest
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
