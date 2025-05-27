using Clases;
using ClubMeBack_End.Common;
using ClubMeBack_End.Data;
using Data;
using StoredProcedures;
using System.Data;

namespace ClubMeBack_End.Logica
{
    public class SalesLogic : dbContext
    {
        public SalesLogic(IDbConnection connection) : base(connection)
        {
        }

        public ClasesRSV.RSV_ResultadoEjecucion CreateSales(int SaleId, int ReservationId, int EmployeeId, DateTime SaleDate, decimal TotalAmount, decimal Tax, decimal Tip, string? PaymentMethod, string? Notes)
        {
            ClasesRSV.RSV_ResultadoEjecucion resultadoSales = new ClasesRSV.RSV_ResultadoEjecucion();
            var context = new ContextSales(CurrentConnection);

            try
            {
                resultadoSales.IDRegistro = context.sp_CreateSales(SaleId, ReservationId, EmployeeId, SaleDate, TotalAmount, Tax, Tip, PaymentMethod, Notes);
                resultadoSales.Exitoso = true;
            }
            catch (Exception ex)
            {
                resultadoSales.Exitoso = false;
                resultadoSales.Error = Errores.LlenarError(ex, string.Format("Se presentó un error en el método {0}. {1}",
                    ((System.Reflection.MethodInfo)System.Reflection.MethodBase.GetCurrentMethod()).Name.ToString(), ex.ToString()));
            }
            return resultadoSales;
        }

        //public ClasesRSV.RSV_Resultado<List<Sales>> GetSales(int SaleId)
        //{
        //    var context = new ContextSales(CurrentConnection);
        //    var contextSaleDetails = new ContextSaleDetails(CurrentConnection);
        //    List<Sales> sales = new List<Sales>();
        //    List<SaleDetails> saledetails = new List<SaleDetails>();
        //    ClasesRSV.RSV_Resultado<List<Sales>> resultadoSales = new ClasesRSV.RSV_Resultado<List<Sales>>();

        //    try
        //    {
        //        sales = context.sp_GetSales(SaleId);
        //        saledetails = ContextSaleDetails.sp_GetSaleDetails(-1).ToList();

        //        foreach (var sale in sales)
        //        {
        //            sale.SaleDetails = saledetails.Where(s => s.SaleDetailId == sale.SaleDetailId).FirstOrDefault();
        //        }

        //        resultadoSales.Exitoso = true;
        //        resultadoSales.Datos = sales;
        //    }
        //    catch (Exception ex)
        //    {
        //        resultadoSales.Exitoso = false;
        //        resultadoSales.Error = Errores.LlenarError(ex, string.Format("Se presentó un error en el método {0}. {1}",
        //            ((System.Reflection.MethodInfo)System.Reflection.MethodBase.GetCurrentMethod()).Name.ToString(), ex.ToString()));
        //    }
        //    return resultadoSales;
        //}
    }
}
