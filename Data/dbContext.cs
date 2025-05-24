using System.Data;

namespace StoredProcedures
{
    public abstract class dbContext
    {
        public IDbConnection CurrentConnection { get; set; }
        public dbContext(IDbConnection connection)
        {
            CurrentConnection = connection;
        }
    }
}
