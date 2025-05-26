using Clases;
using Data;
using StoredProcedures;
using System.Data;

namespace ClubMeBack_End.Logica
{
    public class ProductsLogic : dbContext
    {
        public ProductsLogic(IDbConnection connection) : base(connection)
        {
        }

        //public int CreateProducts(int ProductId, int EstablishmentId, int CategoryId, string Productname, string Description,
        //    decimal Price, bool isActive)
        //{
        //    int _ID = 0;
        //    try
        //    {
        //        var _context = new Data.ContextReservation(CurrentConnection);
        //        _ID = _context.sp_CreateProducts(ProductId,EstablishmentId,CategoryId,Productname,Description,Price,isActive);
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Message.ToString();
        //    }
        //    return _ID;
        //}
    }
}

