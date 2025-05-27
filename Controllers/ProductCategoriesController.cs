using ClubMeBack_End.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ClubMeBack_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoriesController : Controller
    {
        public IConfiguration CurrentConfiguration { get; set; }

        public IDbConnection CurrentConnection { get; set; }

        public ProductCategoriesController(IConfiguration configuration, IDbConnection connection)
        {
            CurrentConfiguration = configuration;
            CurrentConnection = connection;
        }


        [HttpPost("CreateProductCategories")]
        public ClasesRSV.RSV_ResultadoEjecucion CreateProductCategories(int CategoryId, string CategoryName, string Description, bool isActive)
        {
            var _context = new Logica.ProductCategoriesLogic(CurrentConnection);
            ClasesRSV.RSV_ResultadoEjecucion resultadoProductCategories = new ClasesRSV.RSV_ResultadoEjecucion();

            resultadoProductCategories = _context.CreateProductCategories(CategoryId, CategoryName, Description, isActive);

            return resultadoProductCategories;
        }

        [HttpGet("GetProductCategories")]
        public ClasesRSV.RSV_Resultado<List<Clases.ProductCategories>> GetProductCategories(int CategoryId, string CategoryName)
        {

            var _context = new Logica.ProductCategoriesLogic(CurrentConnection);
            ClasesRSV.RSV_Resultado<List<Clases.ProductCategories>> resultadoProductCategories = new ClasesRSV.RSV_Resultado<List<Clases.ProductCategories>>();
            List<Clases.ProductCategories> productcategories = new List<Clases.ProductCategories>();

            resultadoProductCategories = _context.GetProductCategories(CategoryId, CategoryName);

            return resultadoProductCategories;
        }
    }
}
