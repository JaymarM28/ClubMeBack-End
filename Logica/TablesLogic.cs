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

        public ClasesRSV.RSV_Resultado<List<Clases.Tables>> GetAvailableTables(int EstablishmentId, DateTime ReservationDate, TimeOnly ReservationTime, int PartySize)
        {
            var context = new ContextTables(CurrentConnection);
            var contextAreas = new ContextAreas(CurrentConnection);
            List<Clases.Tables> tables = new List<Clases.Tables>();
            List<Clases.Areas> areas = new List<Clases.Areas>();
            ClasesRSV.RSV_Resultado<List<Clases.Tables>> resultadoTables = new ClasesRSV.RSV_Resultado<List<Clases.Tables>>();

            try
            {
                tables = context.sp_GetAvailableTables(EstablishmentId, ReservationDate, ReservationTime, PartySize);
                areas = contextAreas.sp_GetAreas(-1);

                foreach (var table in tables)
                {
                    table.Areas = areas.Where(a => a.AreaId == table.AreaId).FirstOrDefault();
                }

                resultadoTables.Exitoso = true;
                resultadoTables.Datos = tables;
            }
            catch (Exception ex)
            {
                resultadoTables.Exitoso = false;
                resultadoTables.Error = Errores.LlenarError(ex, string.Format("Se presentó un error en el método {0}. {1}",
                    ((System.Reflection.MethodInfo)(System.Reflection.MethodInfo.GetCurrentMethod())).Name.ToString(), ex.ToString()));
            }
            return resultadoTables;
        }
    }
}
