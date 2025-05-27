using ClubMeBack_End.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ClubMeBack_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationStatusesController : Controller
    {
        public IConfiguration CurrentConfiguration { get; set; }

        public IDbConnection CurrentConnection { get; set; }

        public ReservationStatusesController(IConfiguration configuration, IDbConnection connection)
        {
            CurrentConfiguration = configuration;
            CurrentConnection = connection;
        }


        [HttpPost("CreateReservationStatuses")]
        public ClasesRSV.RSV_ResultadoEjecucion CreateReservationStatuses(int StatusId, string StatusName, string Description, bool isActive, string? StatusCode)
        {
            var _context = new Logica.ReservationStatusesLogic(CurrentConnection);
            ClasesRSV.RSV_ResultadoEjecucion resultadoReservationStatuses = new ClasesRSV.RSV_ResultadoEjecucion();

            resultadoReservationStatuses = _context.CreateReservationStatuses(StatusId, StatusName, Description, isActive, StatusCode);

            return resultadoReservationStatuses;
        }

        [HttpGet("GetReservationStatuses")]
        public ClasesRSV.RSV_Resultado<List<Clases.ReservationStatuses>> GetReservationStatuses(int StatusId, string? StatusCode)
        {

            var _context = new Logica.ReservationStatusesLogic(CurrentConnection);
            ClasesRSV.RSV_Resultado<List<Clases.ReservationStatuses>> resultadoReservationStatuses = new ClasesRSV.RSV_Resultado<List<Clases.ReservationStatuses>>();

            resultadoReservationStatuses = _context.GetReservationStatuses(StatusId, StatusCode);

            return resultadoReservationStatuses;
        }
    }
}
