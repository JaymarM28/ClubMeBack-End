using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Tables
    {
        public int TableId { get; set; }

        public int EstablishmentId { get; set; }

        public int AreaId { get; set; }

        public string TableNumber { get; set; } = string.Empty;

        public int Capacity { get; set; }   

        public decimal MinConsumption { get; set; }

        public bool IsVIP { get; set; }

        public bool IsActive { get; set; }

        public Establishment Establishment { get; set; }

    }
}
