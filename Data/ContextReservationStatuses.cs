using StoredProcedures;
using System.Data;
using Dapper;

namespace ClubMeBack_End.Data
{
    public class ContextReservationStatuses : dbContext
    {
        public ContextReservationStatuses(IDbConnection connection) : base(connection)
        {

        }

        public int sp_CreateReservationStatuses(int StatusId, string StatusName, string Description, bool isActive, string StatusCode)
        {
            int _ID = 0;
            DynamicParameters parameters = new();
            parameters.Add("@StatusId", StatusId, DbType.Int64);
            parameters.Add("@StatusName", StatusName, DbType.String);
            parameters.Add("@Description", Description, DbType.String);
            parameters.Add("@isActive", isActive, DbType.Boolean);
            parameters.Add("@StatusCode", StatusCode, DbType.String);

            parameters.Add("@ReturnValue", DbType.Int32, direction: ParameterDirection.ReturnValue);

            base.CurrentConnection.Execute("sp_CreateReservationStatuses", parameters, commandType: CommandType.StoredProcedure);
            _ID = parameters.Get<int>("@ReturnValue");
            return _ID;
        }

        public List<Clases.ReservationStatuses> sp_GetReservationStatuses(int StatusId, string? StatusCode)
        {
            DynamicParameters parameters = new();
            parameters.Add("@StatusId", StatusId, DbType.Int64);
            parameters.Add("@StatusCode", StatusCode, DbType.String);

            var result = base.CurrentConnection.Query<Clases.ReservationStatuses>(
                "sp_GetReservationStatuses",
                parameters,
                commandType: CommandType.StoredProcedure
            ).ToList();

            return result;
        }
    }
}
