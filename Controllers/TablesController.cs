using ClubMeBack_End.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;



namespace ClubMeBack_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablesController : Controller
    {
        public IConfiguration CurrentConfiguration { get; set; }

        public IDbConnection CurrentConnection { get; set; }

        public TablesController(IConfiguration configuration, IDbConnection connection)
        {
            CurrentConfiguration = configuration;
            CurrentConnection = connection;
        }

        [HttpPost("CreateTables")]
        public ClasesRSV.RSV_ResultadoEjecucion CreateTables(int TableId, int EstablishmentId, int AreaId, string TableNumber, int Capacity, decimal MinConsumption, bool IsVIP, bool IsActive)
        {
            {
                var _context = new Logica.TablesLogic(CurrentConnection);
                ClasesRSV.RSV_ResultadoEjecucion resultadoTables = new ClasesRSV.RSV_ResultadoEjecucion();

                resultadoTables = _context.CreateTables(TableId, EstablishmentId, AreaId, TableNumber, Capacity, MinConsumption, IsVIP, IsActive);

                return resultadoTables;
            }

        }

        [HttpGet("GetAvailableTables")]
        public ClasesRSV.RSV_Resultado<List<Clases.Tables>> GetAvailableTables(int EstablishmentId, DateTime ReservationDate, TimeOnly ReservationTime, int PartySize)
        {

            var _context = new Logica.TablesLogic(CurrentConnection);
            ClasesRSV.RSV_Resultado<List<Clases.Tables>> resultadoTables = new ClasesRSV.RSV_Resultado<List<Clases.Tables>>();
            List<Clases.Tables> tables = new List<Clases.Tables>();

            resultadoTables = _context.GetAvailableTables(EstablishmentId, ReservationDate, ReservationTime, PartySize);

            return resultadoTables;
        }
    }
}
