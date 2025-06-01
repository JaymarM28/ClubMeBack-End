using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class ProductCategories
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = string.Empty;

        public string? Description { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; } = string.Empty;

        public DateTime? ModifiedAt { get; set; }

        public string? ModifiedBy { get; set; } = string.Empty;

    }
}
