using Clases;
using ClubMeBack_End.Common;
using ClubMeBack_End.Data;
using Data;
using StoredProcedures;
using System.Collections.Generic;
using System.Data;

namespace ClubMeBack_End.Logica
{
    public class SaleDetailsLogic : dbContext
    {
        public SaleDetailsLogic(IDbConnection connection) : base(connection)
        {
        }

        public ClasesRSV.RSV_ResultadoEjecucion CreateSaleDetails(int SaleDetailId, int SaleId, int ProductId, decimal UnitPrice, int Quantity, decimal Subtotal)
        {
            ClasesRSV.RSV_ResultadoEjecucion resultadoSaleDetails = new ClasesRSV.RSV_ResultadoEjecucion();
            var context = new ContextSaleDetails(CurrentConnection);

            try
            {
                resultadoSaleDetails.IDRegistro = context.sp_CreateSaleDetails(SaleDetailId, SaleId, ProductId, UnitPrice, Quantity, Subtotal);
                resultadoSaleDetails.Exitoso = true;
            }
            catch (Exception ex)
            {
                resultadoSaleDetails.Exitoso = false;
                resultadoSaleDetails.Error = Errores.LlenarError(ex, string.Format("Se presentó un error en el método {0}. {1}",
                    ((System.Reflection.MethodInfo)System.Reflection.MethodBase.GetCurrentMethod()).Name.ToString(), ex.ToString()));
            }
            return resultadoSaleDetails;
        }

        public ClasesRSV.RSV_Resultado<List<SaleDetails>> GetSaleDetails(int SaleDetailId, int SaleId)
        {
            var context = new ContextSaleDetails(CurrentConnection);
            List<SaleDetails> saledetails = new List<SaleDetails>();
            ClasesRSV.RSV_Resultado<List<SaleDetails>> resultadoSaleDetails = new ClasesRSV.RSV_Resultado<List<SaleDetails>>();

            try
            {
                saledetails = context.sp_GetSaleDetails(SaleDetailId, SaleId);
                resultadoSaleDetails.Exitoso = true;
                resultadoSaleDetails.Datos = saledetails;
            }
            catch (Exception ex)
            {
                resultadoSaleDetails.Exitoso = false;
                resultadoSaleDetails.Error = Errores.LlenarError(ex, string.Format("Se presentó un error en el método {0}. {1}",
                    ((System.Reflection.MethodInfo)System.Reflection.MethodBase.GetCurrentMethod()).Name.ToString(), ex.ToString()));
            }
            return resultadoSaleDetails;
        }
    }
}
