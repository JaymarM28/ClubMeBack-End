using Microsoft.AspNetCore.Mvc;
using System.Data;
using Data;

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
        public int CreateEstablishment(string IDEstablecimiento, string NombreEstablecimiento, string DireccionEstablecimiento, string CelularEstablecimiento, string EmailEstablecimiento,
            string DescripcionEstablecimiento, string OppeningHoursEstablecimiento, bool Activo)
        {
            var _context = new Data.ContextEstablishments(CurrentConnection);

            // Assuming you have a method to create an establishment in your data layer
            int result = _context.sp_CreateEstablishment(IDEstablecimiento, NombreEstablecimiento, DireccionEstablecimiento, CelularEstablecimiento, EmailEstablecimiento, DescripcionEstablecimiento, OppeningHoursEstablecimiento, Activo);

            return result;
        }
    }
}
