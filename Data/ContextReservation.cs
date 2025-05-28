using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using StoredProcedures;
using System.Data;

namespace Data
{
    public class ContextReservation : dbContext
    {
        public ContextReservation(IDbConnection connection) : base(connection)
        {
        }
        public int sp_CreateReservation(string UserId, int TableId, int EstablishmentId, DateTime ReservationDate, TimeOnly ReservationTime, int PartySize, string SpecialRequests)
        {
            int _ID = 0;
            DynamicParameters parameters = new();
            parameters.Add("@UserId", UserId, DbType.String);
            parameters.Add("@TableId", TableId, DbType.Int64);
            parameters.Add("@EstablishmentId", EstablishmentId, DbType.Int64);
            parameters.Add("@ReservationDate", ReservationDate, DbType.DateTime);
            parameters.Add("@ReservationTime", ReservationTime, DbType.Time);
            parameters.Add("@PartySize", PartySize, DbType.Int32);
            parameters.Add("@SpecialRequests", SpecialRequests, DbType.String);

            parameters.Add("@ReturnValue", DbType.Int32, direction: ParameterDirection.ReturnValue);

            base.CurrentConnection.Execute("sp_CreateReservation", parameters, commandType: CommandType.StoredProcedure);
            _ID = parameters.Get<int>("@ReturnValue");
            return _ID;
        }

        public List<Clases.Reservations> sp_GetReservationsByUser(string UserId)
        {
            DynamicParameters parameters = new();
            parameters.Add("@UserId", UserId, DbType.Int32);

            var result = base.CurrentConnection.Query<Clases.Reservations>(
                "sp_GetReservationsByUser",
                parameters,
                commandType: CommandType.StoredProcedure
            ).ToList();

            return result;
        }

        public List<Clases.Reservations> sp_GetReservationsByEstablishment(int EstablishmentId, DateTime ReservationDate, int StatusId)
        {
            DynamicParameters parameters = new();
            parameters.Add("@EstablishmentId", EstablishmentId, DbType.Int32);
            parameters.Add("@ReservationDate", ReservationDate, DbType.DateTime);
            parameters.Add("@StatusId", StatusId, DbType.Int32);

            var result = base.CurrentConnection.Query<Clases.Reservations>(
                "sp_GetReservationsByEstablishment",
                parameters,
                commandType: CommandType.StoredProcedure
            ).ToList();

            return result;
        }
    }
}
