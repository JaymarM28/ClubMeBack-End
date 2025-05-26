using Clases;
using ClubMeBack_End.Common;
using Data;
using StoredProcedures;
using System.Data;

namespace Logica
{
    public class AreasLogic : dbContext
    {
        public AreasLogic(IDbConnection connection) : base(connection)
        {
        }

        public ClasesRSV.RSV_ResultadoEjecucion CreateAreas(int AreaId, int EstablishmentId, string AreaName, string Description, bool isActive)
        {
            ClasesRSV.RSV_ResultadoEjecucion resultadoAreas = new ClasesRSV.RSV_ResultadoEjecucion();
            var context = new ContextAreas(CurrentConnection);

            try
            {
                resultadoAreas.IDRegistro = context.sp_CreateAreas(AreaId, EstablishmentId,  AreaName, Description, isActive);
                resultadoAreas.Exitoso = true;
            }
            catch (Exception ex)
            {
                resultadoAreas.Exitoso = false;
                resultadoAreas.Error = Errores.LlenarError(ex, string.Format("Se presentó un error en el método {0}. {1}",
                    ((System.Reflection.MethodInfo)(System.Reflection.MethodInfo.GetCurrentMethod())).Name.ToString(), ex.ToString()));
            }
            return resultadoAreas;
        }

        public ClasesRSV.RSV_Resultado<List<Clases.Areas>> GetAreas(int AreaId)
        {
            var context = new ContextAreas(CurrentConnection);
            var contextEstablecimiento = new ContextEstablishments(CurrentConnection);
            List<Clases.Areas> areas = new List<Clases.Areas>();
            List<Clases.Establishment> establecimientos = new List<Clases.Establishment>();
            ClasesRSV.RSV_Resultado<List<Clases.Areas>> resultadoAreas = new ClasesRSV.RSV_Resultado<List<Clases.Areas>>();

            try
            {
                areas = context.sp_GetAreas(AreaId);
                establecimientos = contextEstablecimiento.sp_GetEstablishment(-1).ToList();

                foreach (var area in areas)
                {
                    area.Establishment = establecimientos.Where(e => e.EstablishmentId == area.EstablishmentId).FirstOrDefault();
                }

                resultadoAreas.Exitoso = true;
                resultadoAreas.Datos = areas;
            }
            catch (Exception ex)
            {
                resultadoAreas.Exitoso = false;
                resultadoAreas.Error = Errores.LlenarError(ex, string.Format("Se presentó un error en el método {0}. {1}",
                    ((System.Reflection.MethodInfo)(System.Reflection.MethodInfo.GetCurrentMethod())).Name.ToString(), ex.ToString()));
            }
            return resultadoAreas;
        }
    }
}
