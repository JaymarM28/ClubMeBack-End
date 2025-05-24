using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Reservations
    {
        public int ReservationId { get; set; }

        public string UserId { get; set; } = string.Empty;

        public int TableId { get; set; }

        public int EstablishmentId { get; set; }

        public DateTime ReservationDate { get; set; }

        public DateTime ReservationTime { get; set; }

        public int PartySize { get; set; }

        public int StatusId { get; set; }

        public string? SpecialRequests { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdateAt { get; set; }

        public string? AttendedBy { get; set; }
    }
}
