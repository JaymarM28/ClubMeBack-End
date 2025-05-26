using Clases;
using ClubMeBack_End.Common;
using ClubMeBack_End.Data;
using Data;
using StoredProcedures;
using System.Data;

namespace ClubMeBack_End.Logica
{
    public class TablesLogic :dbContext
    {
        public TablesLogic(IDbConnection connection) : base(connection)
        {

        }

        public ClasesRSV.RSV_ResultadoEjecucion CreateTables(int TableId, int EstablishmentId, int AreaId, string TableNumber, int Capacity, decimal MinConsumption, bool IsVIP, bool IsActive)
        {
            ClasesRSV.RSV_ResultadoEjecucion resultadoTables = new ClasesRSV.RSV_ResultadoEjecucion();
            var context = new ContextTables(CurrentConnection);

            try
            {
                resultadoTables.IDRegistro = context.sp_CreateTables(TableId, EstablishmentId, AreaId, TableNumber, Capacity, MinConsumption, IsVIP, IsActive);
                resultadoTables.Exitoso = true;
            }
            catch (Exception ex)
            {
                resultadoTables.Exitoso = false;
                resultadoTables.Error = Errores.LlenarError(ex, string.Format("Se presentó un error en el método {0}. {1}",
                    ((System.Reflection.MethodInfo)(System.Reflection.MethodInfo.GetCurrentMethod())).Name.ToString(), ex.ToString()));
            }
            return resultadoTables;
        }

        //public ClasesRSV.RSV_Resultado<List<Clases.Tables>> GetTables(int TableId)
        //{
        //    var context = new ContextTables(CurrentConnection);
        //    var contextEstablecimiento = new ContextTables(CurrentConnection);
        //    List<Clases.Tables> tables = new List<Clases.Tables>();
        //    List<Clases.Establishment> establecimientos = new List<Clases.Establishment>();
        //    ClasesRSV.RSV_Resultado<List<Clases.Tables>> resultadoTables = new ClasesRSV.RSV_Resultado<List<Clases.Tables>>();

        //    try
        //    {
        //        tables = context.sp_GetTables(TableId);
        //        establecimientos = contextEstablecimiento.sp_GetEstablishment(-1).ToList();

        //        foreach (var table in tables)
        //        {
        //            table.Establishment = establecimientos.Where(t => t.EstablishmentId == table.EstablishmentId).FirstOrDefault();
        //        }

        //        resultadoTables.Exitoso = true;
        //        resultadoTables.Datos = tables;
        //    }
        //    catch (Exception ex)
        //    {
        //        resultadoTables.Exitoso = false;
        //        resultadoTables.Error = Errores.LlenarError(ex, string.Format("Se presentó un error en el método {0}. {1}",
        //            ((System.Reflection.MethodInfo)(System.Reflection.MethodInfo.GetCurrentMethod())).Name.ToString(), ex.ToString()));
        //    }
        //    return resultadoTables;
        //}
    }
}
