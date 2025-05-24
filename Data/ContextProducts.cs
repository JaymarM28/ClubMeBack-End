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

        public int sp_CreateEstablishment(string IDEstablecimiento, string NombreEstablecimiento, string DireccionEstablecimiento, string CelularEstablecimiento, string EmailEstablecimiento,
            string DescripcionEstablecimiento, string OppeningHoursEstablecimiento, bool Activo)
        {
            int _ID = 0;
            DynamicParameters parameters = new();
            parameters.Add("@EstablishmentId", IDEstablecimiento, DbType.Int64);
            parameters.Add("@Name", NombreEstablecimiento, DbType.String);
            parameters.Add("@Address", DireccionEstablecimiento, DbType.String);
            parameters.Add("@Phone", CelularEstablecimiento, DbType.String);
            parameters.Add("@Email", EmailEstablecimiento, DbType.String);
            parameters.Add("@Description", DescripcionEstablecimiento, DbType.String);
            parameters.Add("@OpeningHours", OppeningHoursEstablecimiento, DbType.String);
            parameters.Add("@isActive", Activo, DbType.Boolean);

            parameters.Add("@ReturnValue", DbType.Int32, direction: ParameterDirection.ReturnValue);

            base.CurrentConnection.Execute("sp_CreateEstablishment", parameters, commandType: CommandType.StoredProcedure);
            _ID = parameters.Get<int>("@ReturnValue");
            return _ID;
        }

        public List<Clases.Establishment> sp_GetEstablishment(int IDEstablecimiento)
        {
            List<Clases.Establishment> establishment = new List<Clases.Establishment>();

            return establishment;
        }

    }
}