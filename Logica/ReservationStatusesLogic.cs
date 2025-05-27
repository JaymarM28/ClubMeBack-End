using Clases;
using ClubMeBack_End.Common;
using ClubMeBack_End.Data;
using Data;
using StoredProcedures;
using System.Collections.Generic;
using System.Data;

namespace ClubMeBack_End.Logica
{
    public class ReservationStatusesLogic : dbContext
    {
        public ReservationStatusesLogic(IDbConnection connection) : base(connection)
        {
        }

        public ClasesRSV.RSV_ResultadoEjecucion CreateReservationStatuses(int StatusId, string StatusName, string Description, bool isActive, string? StatusCode)
        {
            ClasesRSV.RSV_ResultadoEjecucion resultadoReservationStatuses = new ClasesRSV.RSV_ResultadoEjecucion();
            var context = new ContextReservationStatuses(CurrentConnection);

            try
            {
                resultadoReservationStatuses.IDRegistro = context.sp_CreateReservationStatuses(StatusId, StatusName, Description, isActive, StatusCode);
                resultadoReservationStatuses.Exitoso = true;
            }
            catch (Exception ex)
            {
                resultadoReservationStatuses.Exitoso = false;
                resultadoReservationStatuses.Error = Errores.LlenarError(ex, string.Format("Se presentó un error en el método {0}. {1}",
                    ((System.Reflection.MethodInfo)System.Reflection.MethodBase.GetCurrentMethod()).Name.ToString(), ex.ToString()));
            }
            return resultadoReservationStatuses;
        }

        public ClasesRSV.RSV_Resultado<List<ReservationStatuses>> GetReservationStatuses(int StatusId, string? StatusCode)
        {
            var context = new ContextReservationStatuses(CurrentConnection);
            List<ReservationStatuses> reservationstatuses = new List<ReservationStatuses>();
            ClasesRSV.RSV_Resultado<List<ReservationStatuses>> resultadoReservationStatuses = new ClasesRSV.RSV_Resultado<List<ReservationStatuses>>();

            try
            {
                reservationstatuses = context.sp_GetReservationStatuses(StatusId, StatusCode);
                resultadoReservationStatuses.Exitoso = true;
                resultadoReservationStatuses.Datos = reservationstatuses;
            }
            catch (Exception ex)
            {
                resultadoReservationStatuses.Exitoso = false;
                resultadoReservationStatuses.Error = Errores.LlenarError(ex, string.Format("Se presentó un error en el método {0}. {1}",
                    ((System.Reflection.MethodInfo)System.Reflection.MethodBase.GetCurrentMethod()).Name.ToString(), ex.ToString()));
            }
            return resultadoReservationStatuses;
        }
    }
}
