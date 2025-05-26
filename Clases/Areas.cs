using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Areas
    {
        public int AreaId { get; set; }

        public int EstablishmentId { get; set; }

        public string AreaName { get; set; } = string.Empty;

        public string? Description { get; set; }

        public bool IsActive { get; set; }

        public Establishment? Establishment { get; set; }
    }
}
