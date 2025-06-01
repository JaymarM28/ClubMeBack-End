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

        public int EstablishmentId { get; set; }

        public int CategoryId { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; } = string.Empty;

        public DateTime? ModifiedAt { get; set; }

        public string? ModifiedBy { get; set; } = string.Empty;

        // Propiedades de navegación
        public ProductCategories? ProductCategories { get; set; }

        public Establishment? Establishment { get; set; }
    }
}
