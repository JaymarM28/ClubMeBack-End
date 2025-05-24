using StoredProcedures;
using System.Data;
using Dapper;


namespace Data
{
    public class ContextAreas : dbContext
    {
        public ContextAreas (IDbConnection connection) : base(connection)
        { 
        }
        public int sp_CreateAreas(int AreaId, int EstablishmentId, string AreaName, string Description, bool isActive)
        {
            int _ID = 0;
            DynamicParameters parameters = new();
            parameters.Add("@AreaId", AreaId, DbType.Int64);
            parameters.Add("@EstablishmentId", EstablishmentId, DbType.String);
            parameters.Add("@AreaName", AreaName, DbType.String);
            parameters.Add("@Description", Description, DbType.String);           
            parameters.Add("@isActive", isActive, DbType.Boolean);

            parameters.Add("@ReturnValue", DbType.Int32, direction: ParameterDirection.ReturnValue);

            base.CurrentConnection.Execute("CreateAreas", parameters, commandType: CommandType.StoredProcedure);
            _ID = parameters.Get<int>("@ReturnValue");
            return _ID;
        }

        public List<Clases.Areas> sp_GetpRoducts(int AreaId)
        {
            List<Clases.Areas> areas = new List<Clases.Areas>();

            return areas;
        }

    }
}
