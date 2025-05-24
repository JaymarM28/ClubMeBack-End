using Data;
using StoredProcedures;
using System.Data;

namespace Logica
{
    public class Reservation : dbContext
    {
        public Reservation(IDbConnection connection) : base(connection)
        {

        }

        public int CreateReservation(string UserId, int TableId, int EstablishmentId, DateTime ReservationDate, DateTime ReservationTime, int PartySize, string SpecialRequests)
        {
            int _ID = 0;
            try
            {
                var _context = new Data.ContextReservation(CurrentConnection);
                _ID = _context.sp_CreateReservation(UserId, TableId, EstablishmentId, ReservationDate, ReservationTime, PartySize, SpecialRequests);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return _ID;
        }

    }
}
