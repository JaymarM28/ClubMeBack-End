using Clases;
using Data;
using StoredProcedures;
using System.Data;

namespace Logica
{
    public class AreasLogic : dbContext
    {
        public AreasLogic(IDbConnection connection) : base(connection)
        {
        }

        public int CreateAreas(int AreaId, int EstablishmentId, string AreaName, string Description, bool isActive) 
        {
            int _ID = 0;
            try
            {
                var _context = new Data.ContextReservation(CurrentConnection);
                _ID = _context.sp_CreateAreas(AreaId,EstablishmentId,AreaName,Description,isActive);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return _ID;
        }
    }
}
