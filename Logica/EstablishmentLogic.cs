using Clases;
using ClubMeBack_End.Common;
using ClubMeBack_End.Data;
using Data;
using StoredProcedures;
using System.Collections.Generic;
using System.Data;

namespace ClubMeBack_End.Logica
{
    public class EstablishmentLogic : dbContext
    {
        public EstablishmentLogic(IDbConnection connection) : base(connection)
        {
        }

        public ClasesRSV.RSV_ResultadoEjecucion CreateEstablishment(int IDEstablecimiento, string NombreEstablecimiento, string DireccionEstablecimiento, string CelularEstablecimiento, string EmailEstablecimiento,
            string DescripcionEstablecimiento, string OppeningHoursEstablecimiento, bool Activo)
        {
            ClasesRSV.RSV_ResultadoEjecucion resultadoEstablecimiento = new ClasesRSV.RSV_ResultadoEjecucion();
            var context = new ContextEstablishments(CurrentConnection);

            try
            {
                resultadoEstablecimiento.IDRegistro = context.sp_CreateEstablishment(IDEstablecimiento, NombreEstablecimiento, DireccionEstablecimiento, CelularEstablecimiento, EmailEstablecimiento,
                DescripcionEstablecimiento, OppeningHoursEstablecimiento, Activo);
                resultadoEstablecimiento.Exitoso = true;
            }
            catch (Exception ex)
            {
                resultadoEstablecimiento.Exitoso = false;
                resultadoEstablecimiento.Error = Errores.LlenarError(ex, string.Format("Se presentó un error en el método {0}. {1}",
                    ((System.Reflection.MethodInfo)System.Reflection.MethodBase.GetCurrentMethod()).Name.ToString(), ex.ToString()));
            }
            return resultadoEstablecimiento;
        }

        public ClasesRSV.RSV_Resultado<List<Establishment>> GetEstablishment(int IDEstablecimiento)
        {
            var context = new ContextEstablishments(CurrentConnection);
            List<Establishment> establishment = new List<Establishment>();
            ClasesRSV.RSV_Resultado<List<Establishment>> resultadoEstablecimiento = new ClasesRSV.RSV_Resultado<List<Establishment>>();

            try
            {
                establishment = context.sp_GetEstablishment(IDEstablecimiento);
                resultadoEstablecimiento.Exitoso = true;
                resultadoEstablecimiento.Datos = establishment;
            }
            catch (Exception ex)
            {
                resultadoEstablecimiento.Exitoso = false;
                resultadoEstablecimiento.Error = Errores.LlenarError(ex, string.Format("Se presentó un error en el método {0}. {1}",
                    ((System.Reflection.MethodInfo)System.Reflection.MethodBase.GetCurrentMethod()).Name.ToString(), ex.ToString()));
            }
            return resultadoEstablecimiento;
        }

    }
}
