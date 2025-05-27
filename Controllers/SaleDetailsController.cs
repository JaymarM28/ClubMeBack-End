using ClubMeBack_End.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ClubMeBack_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleDetailsController : Controller
    {
        public IConfiguration CurrentConfiguration { get; set; }

        public IDbConnection CurrentConnection { get; set; }

        public SaleDetailsController(IConfiguration configuration, IDbConnection connection)
        {
            CurrentConfiguration = configuration;
            CurrentConnection = connection;
        }


        [HttpPost("CreateSaleDetails")]
        public ClasesRSV.RSV_ResultadoEjecucion CreateSaleDetails(int SaleDetailId, int SaleId, int ProductId, decimal UnitPrice, int Quantity, decimal Subtotal)
        {
            var _context = new Logica.SaleDetailsLogic(CurrentConnection);
            ClasesRSV.RSV_ResultadoEjecucion resultadoSaleDetails = new ClasesRSV.RSV_ResultadoEjecucion();

            resultadoSaleDetails = _context.CreateSaleDetails(SaleDetailId, SaleId, ProductId, UnitPrice, Quantity, Subtotal);

            return resultadoSaleDetails;
        }

        [HttpGet("GetSaleDetails")]
        public ClasesRSV.RSV_Resultado<List<Clases.SaleDetails>> GetSaleDetails(int SaleDetailId, int SaleId)
        {

            var _context = new Logica.SaleDetailsLogic(CurrentConnection);
            ClasesRSV.RSV_Resultado<List<Clases.SaleDetails>> resultadoSaleDetails = new ClasesRSV.RSV_Resultado<List<Clases.SaleDetails>>();
            List<Clases.SaleDetails> productcategories = new List<Clases.SaleDetails>();

            resultadoSaleDetails = _context.GetSaleDetails(SaleDetailId, SaleId);

            return resultadoSaleDetails;
        }
    }
}
