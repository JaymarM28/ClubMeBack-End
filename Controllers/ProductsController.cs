using ClubMeBack_End.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;


namespace ClubMeBack_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        public IConfiguration CurrentConfiguration { get; set; }

        public IDbConnection CurrentConnection { get; set; }

        public ProductsController(IConfiguration configuration, IDbConnection connection)
        {
            CurrentConfiguration = configuration;
            CurrentConnection = connection;
        }

        [HttpPost("CreateProducts")]
        public ClasesRSV.RSV_ResultadoEjecucion CreateProducts(int ProductId, int EstablishmentId, int CategoryId, string Productname, string Description, decimal Price, bool isActive)
        {
            {
                var _context = new Logica.ProductsLogic(CurrentConnection);
                ClasesRSV.RSV_ResultadoEjecucion resultadoProducts = new ClasesRSV.RSV_ResultadoEjecucion();

                resultadoProducts = _context.CreateProducts(ProductId, EstablishmentId, CategoryId, Productname, Description, Price, isActive);

                return resultadoProducts;
            }

        }

        [HttpGet("GetProducts")]
        public ClasesRSV.RSV_Resultado<List<Clases.Products>> GetAreas(int ProductId)
        {

            var _context = new Logica.ProductsLogic(CurrentConnection);
            ClasesRSV.RSV_Resultado<List<Clases.Products>> resultadoProducts = new ClasesRSV.RSV_Resultado<List<Clases.Products>>();
            List<Clases.Products> products = new List<Clases.Products>();

            resultadoProducts = _context.GetProducts(ProductId);

            return resultadoProducts;
        }
    }
}
