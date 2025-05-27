using ClubMeBack_End.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using ClubMeBack_End.Logica;

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
        public ClasesRSV.RSV_ResultadoEjecucion CreateReservation(string UserId, int TableId, int EstablishmentId, DateTime ReservationDate, DateTime ReservationTime, int PartySize, string SpecialRequests)
        {
            {
                var _context = new Logica.ReservationLogic(CurrentConnection);
                ClasesRSV.RSV_ResultadoEjecucion resultadoReserva = new ClasesRSV.RSV_ResultadoEjecucion();

                resultadoReserva = _context.CreateReservation(UserId, TableId, EstablishmentId, ReservationDate, ReservationTime, PartySize, SpecialRequests);

                return resultadoReserva;
            }

        }

        [HttpGet("GetReservationsByUser")]
        public ClasesRSV.RSV_Resultado<List<Clases.Reservations>> GetReservationsByUser(string UserId)
        {

            var _context = new Logica.ReservationLogic(CurrentConnection);
            ClasesRSV.RSV_Resultado<List<Clases.Reservations>> resultadoReserva = new ClasesRSV.RSV_Resultado<List<Clases.Reservations>>();
            List<Clases.Reservations> reservations = new List<Clases.Reservations>();

            resultadoReserva = _context.GetReservationsByUser(UserId);

            return resultadoReserva;
        }

        [HttpGet("GetReservationsByEstablishment")]
        public ClasesRSV.RSV_Resultado<List<Clases.Reservations>> GetReservationsByEstablishment(int EstablishmentId, DateTime ReservationDate, int StatusId)
        {

            var _context = new Logica.ReservationLogic(CurrentConnection);
            ClasesRSV.RSV_Resultado<List<Clases.Reservations>> resultadoReserva = new ClasesRSV.RSV_Resultado<List<Clases.Reservations>>();
            List<Clases.Reservations> reservations = new List<Clases.Reservations>();

            resultadoReserva = _context.GetReservationsByEstablishment(EstablishmentId, ReservationDate, StatusId);

            return resultadoReserva;
        }
    }
}
