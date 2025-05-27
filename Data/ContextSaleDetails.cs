using StoredProcedures;
using System.Data;
using Dapper;

namespace ClubMeBack_End.Data
{
    public class ContextSaleDetails : dbContext
    {
        public ContextSaleDetails(IDbConnection connection) : base(connection)
        {

        }

        public int sp_CreateSaleDetails(int SaleDetailId, int SaleId, int ProductId, decimal UnitPrice, int Quantity, decimal Subtotal)
        {
            int _ID = 0;
            DynamicParameters parameters = new();
            parameters.Add("@SaleDetailId", SaleDetailId, DbType.Int64);
            parameters.Add("@SaleId", SaleId, DbType.Int64);
            parameters.Add("@ProductId", ProductId, DbType.Int64);
            parameters.Add("@UnitPrice", UnitPrice, DbType.Decimal);
            parameters.Add("@Quantity", Quantity, DbType.Int64);
            parameters.Add("@Subtotal", Subtotal, DbType.Decimal);

            parameters.Add("@ReturnValue", DbType.Int32, direction: ParameterDirection.ReturnValue);

            base.CurrentConnection.Execute("sp_CreateSaleDetails", parameters, commandType: CommandType.StoredProcedure);
            _ID = parameters.Get<int>("@ReturnValue");
            return _ID;
        }

        public List<Clases.SaleDetails> sp_GetSaleDetails(int SaleDetailId, int SaleId)
        {
            DynamicParameters parameters = new();
            parameters.Add("@SaleDetailId", SaleDetailId, DbType.Int64);
            parameters.Add("@SaleId", SaleId, DbType.Int64);

            var result = base.CurrentConnection.Query<Clases.SaleDetails>(
                "sp_GetSaleDetails",
                parameters,
                commandType: CommandType.StoredProcedure
            ).ToList();

            return result;
        }
    }
}
