using StoredProcedures;
using System.Data;
using Dapper;

namespace ClubMeBack_End.Data
{
    public class ContextProductCategories :dbContext
    {
        public ContextProductCategories(IDbConnection connection) : base(connection)
        {

        }

        public int sp_CreateProductCategories(int CategoryId, string CategoryName, string Description, bool isActive)
        {
            int _ID = 0;
            DynamicParameters parameters = new();
            parameters.Add("@CategoryId", CategoryId, DbType.Int64);
            parameters.Add("@Name", CategoryName, DbType.String);
            parameters.Add("@Description", Description, DbType.String);
            parameters.Add("@isActive", isActive, DbType.Boolean);

            parameters.Add("@ReturnValue", DbType.Int32, direction: ParameterDirection.ReturnValue);

            base.CurrentConnection.Execute("sp_CreateProductCategories", parameters, commandType: CommandType.StoredProcedure);
            _ID = parameters.Get<int>("@ReturnValue");
            return _ID;
        }

        public List<Clases.ProductCategories> sp_GetProductCategories(int CategoryId, string? CategoryName)
        {
            DynamicParameters parameters = new();
            parameters.Add("@CategoryId", CategoryId, DbType.Int64);
            parameters.Add("@Name", CategoryName, DbType.String);

            var result = base.CurrentConnection.Query<Clases.ProductCategories>(
                "sp_GetProductCategories",
                parameters,
                commandType: CommandType.StoredProcedure
            ).ToList();

            return result;
        }
    }
}
