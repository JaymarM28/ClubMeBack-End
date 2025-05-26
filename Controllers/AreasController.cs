using ClubMeBack_End.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;


namespace ClubMeBack_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreasController : Controller
    {
        public IConfiguration CurrentConfiguration { get; set; }

        public IDbConnection CurrentConnection { get; set; }

        public AreasController(IConfiguration configuration, IDbConnection connection) 
        {
            CurrentConfiguration = configuration;
            CurrentConnection = connection;
        }

        [HttpPost("CreateAreas")]
        public ClasesRSV.RSV_ResultadoEjecucion CreateAreas(int AreaId, int EstablishmentId, string AreaName, string Description, bool isActive)
        {
            {
                var _context = new Logica.AreasLogic(CurrentConnection);
                ClasesRSV.RSV_ResultadoEjecucion resultadoAreas = new ClasesRSV.RSV_ResultadoEjecucion();

                resultadoAreas = _context.CreateAreas(AreaId, EstablishmentId, AreaName, Description, isActive);

                return resultadoAreas;
            }

        }

        //[HttpGet("GetAreas")]
        //public ClasesRSV.RSV_Resultado<List<Clases.Areas>> GetAreas(int AreaId)
        //{

        //    var _context = new Logica.AreasLogic(CurrentConnection);
        //    ClasesRSV.RSV_Resultado<List<Clases.Areas>> resultadoAreas = new ClasesRSV.RSV_Resultado<List<Clases.Areas>>();
        //    List<Clases.Areas> areas = new List<Clases.Areas>();

        //    resultadoAreas = _context.GetAreas(AreaId);

        //    return resultadoAreas;
        //}
    }
}
