using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ClubMeBack_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : Controller
    {
        public IConfiguration CurrentConfiguration { get; set; }

        public IDbConnection CurrentConnection { get; set; }

        public ReservationController(IConfiguration configuration, IDbConnection connection)
        {
            CurrentConfiguration = configuration;
            CurrentConnection = connection;
        }

        [HttpPost("CreateReservation")]
        public int CreateReservation(string UserId, int TableId, int EstablishmentId, DateTime ReservationDate, DateTime ReservationTime, int PartySize, string SpecialRequests)
        {
            int result = 0;
            try
            {
                var _context = new Logica.Reservation(CurrentConnection);
                // Assuming you have a method to create a reservation in your data layer
                result = _context.CreateReservation(UserId, TableId, EstablishmentId, ReservationDate, ReservationTime, PartySize, SpecialRequests);

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return result;

        }

    }
}
