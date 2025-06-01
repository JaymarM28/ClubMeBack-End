using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Clases
{
    public class Establishment
    {

        public int EstablishmentId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Address { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public string? Description { get; set; }

        public string? OpeningHours { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; } = string.Empty;

        public DateTime? ModifiedAt { get; set; }

        public string? ModifiedBy { get; set; }

        public bool IsActive { get; set; }
    }
}
