using StoredProcedures;
using System.Data;
using Dapper;

namespace ClubMeBack_End.Data
{
    public class ContextSales : dbContext
    {
        public ContextSales(IDbConnection connection) : base(connection)
        {
        }
        public int sp_CreateSales(int SaleId, int ReservationId, int EmployeeId, DateTime SaleDate, decimal TotalAmount, decimal Tax, decimal Tip, string? PaymentMethod, string? Notes)
        {
            int _ID = 0;
            DynamicParameters parameters = new();
            parameters.Add("@SaleId", SaleId, DbType.Int64);
            parameters.Add("@ReservationId", ReservationId, DbType.Int64);
            parameters.Add("@EmployeeId", EmployeeId, DbType.Int64);
            parameters.Add("@SaleDate", SaleDate, DbType.DateTime);
            parameters.Add("@TotalAmount", TotalAmount, DbType.Decimal);
            parameters.Add("@Tax", Tax, DbType.Decimal);
            parameters.Add("@Tip", Tip, DbType.Decimal);
            parameters.Add("@PaymentMethod", PaymentMethod, DbType.String);
            parameters.Add("@Notes", Notes, DbType.String);

            parameters.Add("@ReturnValue", DbType.Int32, direction: ParameterDirection.ReturnValue);

            base.CurrentConnection.Execute("CreateSales", parameters, commandType: CommandType.StoredProcedure);
            _ID = parameters.Get<int>("@ReturnValue");
            return _ID;
        }

        public List<Clases.Sales> sp_GetSales(int SaleId)
        {
            DynamicParameters parameters = new();
            parameters.Add("@SaleId", SaleId, DbType.Int32);

            var result = base.CurrentConnection.Query<Clases.Sales>(
                "sp_GetSales",
                parameters,
                commandType: CommandType.StoredProcedure
            ).ToList();

            return result;
        }
    }
}
