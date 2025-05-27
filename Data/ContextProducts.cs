using Clases;
using StoredProcedures;
using System.Data;
using Dapper;

namespace Data
{
    public class ContextProducts : dbContext
    {
        public ContextProducts(IDbConnection connection) : base(connection)
        {

        }

        public int sp_CreateProducts(int ProductId, int EstablishmentId, int CategoryId, string Productname, string Description,
            decimal Price, bool isActive)
        {
            int _ID = 0;
            DynamicParameters parameters = new();
            parameters.Add("@ProductId", ProductId, DbType.Int64);
            parameters.Add("@EstablishmentId", EstablishmentId, DbType.String);
            parameters.Add("@CategoryId", CategoryId, DbType.Int64);
            parameters.Add("@Productname", Productname, DbType.String);
            parameters.Add("@Description", Description, DbType.String);
            parameters.Add("@Price", Price, DbType.Decimal);
            parameters.Add("@isActive", isActive, DbType.Boolean);

            parameters.Add("@ReturnValue", DbType.Int32, direction: ParameterDirection.ReturnValue);

            base.CurrentConnection.Execute("sp_CreateProducts", parameters, commandType: CommandType.StoredProcedure);
            _ID = parameters.Get<int>("@ReturnValue");
            return _ID;
        }

        public List<Clases.Products> sp_GetProducts(int ProductId)
        {
            List<Clases.Products> products = new List<Clases.Products>();

            return products;
        }

    }
}