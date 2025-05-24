using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Products
    {
        public int ProductId { get; set; }

        public ProductCategories productCategories { get; set; }

        public Establishment establishment { get; set; }

        public int Establishment { get; set; }

        public int CategoryId { get; set; }

        public string Productname { get; set; } = string.Empty;

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public bool isActive { get; set; }


    }
}
