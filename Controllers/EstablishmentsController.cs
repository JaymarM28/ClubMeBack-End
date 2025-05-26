using ClubMeBack_End.Common;
using Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using Logica;

namespace ClubMeBack_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstablishmentsController : Controller
    {
        public IConfiguration CurrentConfiguration { get; set; }

        public IDbConnection CurrentConnection { get; set; }

        public EstablishmentsController(IConfiguration configuration, IDbConnection connection)
        {
            CurrentConfiguration = configuration;
            CurrentConnection = connection;
        }


        [HttpPost("CreateEstablishment")]
        public int CreateEstablishment(int IDEstablecimiento, string NombreEstablecimiento, string DireccionEstablecimiento, string CelularEstablecimiento, string EmailEstablecimiento,
            string DescripcionEstablecimiento, string OppeningHoursEstablecimiento, bool Activo)
        {
            var _context = new Data.ContextEstablishments(CurrentConnection);

            // Assuming you have a method to create an establishment in your data layer
            int result = _context.sp_CreateEstablishment(IDEstablecimiento, NombreEstablecimiento, DireccionEstablecimiento, CelularEstablecimiento, EmailEstablecimiento, DescripcionEstablecimiento, OppeningHoursEstablecimiento, Activo);

            return result;
        }

        [HttpGet("GetEstablishment")]
        public ClasesRSV.RSV_Resultado<List<Clases.Establishment>> GetEstablishment(int IDEstablecimiento)
        {

            var _context = new Logica.EstablishmentLogic(CurrentConnection);
            ClasesRSV.RSV_Resultado<List<Clases.Establishment>> resultadoEstablecimiento = new ClasesRSV.RSV_Resultado<List<Clases.Establishment>>();
            List<Clases.Establishment> establishment = new List<Clases.Establishment>();

            resultadoEstablecimiento = _context.GetEstablishment(IDEstablecimiento);

            return resultadoEstablecimiento;
        }
    }
}
