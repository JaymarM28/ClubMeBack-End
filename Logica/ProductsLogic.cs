using Clases;
using ClubMeBack_End.Common;
using ClubMeBack_End.Data;
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

        public ClasesRSV.RSV_ResultadoEjecucion CreateProducts(int ProductId, int EstablishmentId, int CategoryId, string Productname, string Description,decimal Price, bool isActive)
        {
            ClasesRSV.RSV_ResultadoEjecucion resultadoProducts = new ClasesRSV.RSV_ResultadoEjecucion();
            var context = new ContextProducts(CurrentConnection);

            try
            {
                resultadoProducts.IDRegistro = context.sp_CreateProducts(ProductId, EstablishmentId, CategoryId, Productname, Description, Price, isActive);
                resultadoProducts.Exitoso = true;
            }
            catch (Exception ex)
            {
                resultadoProducts.Exitoso = false;
                resultadoProducts.Error = Errores.LlenarError(ex, string.Format("Se presentó un error en el método {0}. {1}",
                    ((System.Reflection.MethodInfo)System.Reflection.MethodBase.GetCurrentMethod()).Name.ToString(), ex.ToString()));
            }
            return resultadoProducts;
        }

        public ClasesRSV.RSV_Resultado<List<Products>> GetProducts(int ProductId)
        {
            var contextProducts = new ContextProducts(CurrentConnection);
            var contextEstablecimientos = new ContextEstablishments(CurrentConnection);
            var contextProductCategories = new ContextProductCategories(CurrentConnection);
            List<Products> products = new List<Products>();
            List<Establishment> establecimientos = new List<Establishment>();
            List<ProductCategories> productcategories = new List<ProductCategories>();
            ClasesRSV.RSV_Resultado<List<Products>> resultadoProducts = new ClasesRSV.RSV_Resultado<List<Products>>();

            try
            {
                products = contextProducts.sp_GetProducts(ProductId);
                establecimientos = contextEstablecimientos.sp_GetEstablishment(-1).ToList();
                productcategories = contextProductCategories.sp_GetProductCategories(-1, null).ToList();

                foreach (var product in products)
                {
                    product.establishment = establecimientos.Where(e => e.EstablishmentId == product.EstablishmentId).FirstOrDefault();
                    product.productCategories = productcategories.Where(p => p.CategoryId == product.CategoryId).FirstOrDefault();
                }

                resultadoProducts.Exitoso = true;
                resultadoProducts.Datos = products;
            }
            catch (Exception ex)
            {
                resultadoProducts.Exitoso = false;
                resultadoProducts.Error = Errores.LlenarError(ex, string.Format("Se presentó un error en el método {0}. {1}",
                    ((System.Reflection.MethodInfo)System.Reflection.MethodBase.GetCurrentMethod()).Name.ToString(), ex.ToString()));
            }
            return resultadoProducts;
        }
    }
}

