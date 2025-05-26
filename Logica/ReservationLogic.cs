using Clases;
using ClubMeBack_End.Common;
using Data;
using StoredProcedures;
using System;
using System.Collections.Generic;
using System.Data;

namespace Logica
{
    public class ReservationLogic : dbContext
    {
        public ReservationLogic(IDbConnection connection) : base(connection)
        {

        }

        public ClasesRSV.RSV_ResultadoEjecucion CreateReservation(string UserId, int TableId, int EstablishmentId, DateTime ReservationDate, DateTime ReservationTime, int PartySize, string SpecialRequests)
        {

            ClasesRSV.RSV_ResultadoEjecucion resultadoReserva = new ClasesRSV.RSV_ResultadoEjecucion();
            var context = new ContextReservation(CurrentConnection);

            try
            {
                resultadoReserva.IDRegistro = context.sp_CreateReservation(UserId, TableId, EstablishmentId, ReservationDate, ReservationTime, PartySize, SpecialRequests);
                resultadoReserva.Exitoso = true;
            }
            catch (Exception ex)
            {
                resultadoReserva.Exitoso = false;
                resultadoReserva.Error = Errores.LlenarError(ex, string.Format("Se presentó un error en el método {0}. {1}",
                    ((System.Reflection.MethodInfo)(System.Reflection.MethodInfo.GetCurrentMethod())).Name.ToString(), ex.ToString()));
            }
            return resultadoReserva;
        }

        public ClasesRSV.RSV_Resultado<List<Clases.Reservations>> GetReservations(int UserId)
        {
            var context = new ContextReservation(CurrentConnection);
            List<Clases.Reservations> reservations = new List<Clases.Reservations>();
            ClasesRSV.RSV_Resultado<List<Clases.Reservations>> resultadoReserva = new ClasesRSV.RSV_Resultado<List<Clases.Reservations>>();

            try
            {
                reservations = context.sp_GetReservations(UserId);
                resultadoReserva.Exitoso = true;
                resultadoReserva.Datos = reservations;
            }
            catch (Exception ex)
            {
                resultadoReserva.Exitoso = false;
                resultadoReserva.Error = Errores.LlenarError(ex, string.Format("Se presentó un error en el método {0}. {1}",
                    ((System.Reflection.MethodInfo)(System.Reflection.MethodInfo.GetCurrentMethod())).Name.ToString(), ex.ToString()));
            }
            return resultadoReserva;
        }
    }
}
