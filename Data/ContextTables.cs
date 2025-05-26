using StoredProcedures;
using System.Data;
using Dapper;

namespace ClubMeBack_End.Data
{
    public class ContextTables : dbContext
    {
        public  ContextTables(IDbConnection connection) : base(connection) 
        {
        }

        public int sp_CreateTables(int TableId, int EstablishmentId, int AreaId, string TableNumber, int Capacity, decimal MinConsumption, bool IsVIP, bool IsActive)
        {
            int _ID = 0;
            DynamicParameters parameters = new();
            parameters.Add("@TableId", TableId, DbType.Int64);
            parameters.Add("@EstablishmentId", EstablishmentId, DbType.String);
            parameters.Add("@AreaId", AreaId, DbType.Int64);
            parameters.Add("@TableNumber", TableNumber, DbType.String);
            parameters.Add("@Capacity", Capacity, DbType.Int32);
            parameters.Add("@MinConsumption", MinConsumption, DbType.Decimal);
            parameters.Add("@IsVIP", IsVIP, DbType.Boolean);
            parameters.Add("@IsActive", IsActive, DbType.Boolean);

            parameters.Add("@ReturnValue", DbType.Int32, direction: ParameterDirection.ReturnValue);

            base.CurrentConnection.Execute("CreateTables", parameters, commandType: CommandType.StoredProcedure);
            _ID = parameters.Get<int>("@ReturnValue");
            return _ID;
        }

        public List<Clases.Tables> sp_GetTables(int TableId)
        {
            DynamicParameters parameters = new();
            parameters.Add("@TableId", TableId, DbType.Int32);

            var result = base.CurrentConnection.Query<Clases.Tables>(
                "sp_GetTables",
                parameters,
                commandType: CommandType.StoredProcedure
            ).ToList();

            return result;
        }
    }
}
