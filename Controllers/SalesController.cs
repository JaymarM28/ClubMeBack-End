using Clases;
using ClubMeBack_End.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;

namespace ClubMeBack_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : Controller
    {
        public IConfiguration CurrentConfiguration { get; set; }

        public IDbConnection CurrentConnection { get; set; }

        public SalesController(IConfiguration configuration, IDbConnection connection)
        {
            CurrentConfiguration = configuration;
            CurrentConnection = connection;
        }

        [HttpPost("CreateSales")]
        public ClasesRSV.RSV_ResultadoEjecucion CreateSales(int SaleId, int ReservationId, int EmployeeId, DateTime SaleDate, decimal TotalAmount, decimal Tax, decimal Tip, string? PaymentMethod, string? Notes)
        {
            {
                var _context = new Logica.SalesLogic(CurrentConnection);
                ClasesRSV.RSV_ResultadoEjecucion resultadoSales = new ClasesRSV.RSV_ResultadoEjecucion();

                resultadoSales = _context.CreateSales(SaleId, ReservationId, EmployeeId, SaleDate, TotalAmount, Tax, Tip, PaymentMethod, Notes);

                return resultadoSales;
            }

        }

        //[HttpGet("GetSales")]
        //public ClasesRSV.RSV_Resultado<List<Clases.Sales>> GetSales(int SalesId)
        //{

        //    var _context = new Logica.SalesLogic(CurrentConnection);
        //    ClasesRSV.RSV_Resultado<List<Clases.Sales>> resultadoSales = new ClasesRSV.RSV_Resultado<List<Clases.Sales>>();
        //    List<Clases.Sales> sales = new List<Clases.Sales>();

        //    resultadoSales = _context.GetSales(SalesId);

        //    return resultadoSales;
        //}
    }
}
