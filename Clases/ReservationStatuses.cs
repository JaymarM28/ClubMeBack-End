using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class ReservationStatuses
    {
        public int StatusId { get; set; }
        public string StatusName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool isActive { get; set; }
    }
}
