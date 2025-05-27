using Clases;
using ClubMeBack_End.Common;
using ClubMeBack_End.Data;
using Data;
using StoredProcedures;
using System.Collections.Generic;
using System.Data;

namespace ClubMeBack_End.Logica
{
    public class ProductCategoriesLogic : dbContext
    {
        public ProductCategoriesLogic(IDbConnection connection) : base(connection)
        {
        }

        public ClasesRSV.RSV_ResultadoEjecucion CreateProductCategories(int CategoryId, string CategoryName, string Description, bool isActive)
        {
            ClasesRSV.RSV_ResultadoEjecucion resultadoProductCategories = new ClasesRSV.RSV_ResultadoEjecucion();
            var context = new ContextProductCategories(CurrentConnection);

            try
            {
                resultadoProductCategories.IDRegistro = context.sp_CreateProductCategories(CategoryId, CategoryName, Description, isActive);
                resultadoProductCategories.Exitoso = true;
            }
            catch (Exception ex)
            {
                resultadoProductCategories.Exitoso = false;
                resultadoProductCategories.Error = Errores.LlenarError(ex, string.Format("Se presentó un error en el método {0}. {1}",
                    ((System.Reflection.MethodInfo)System.Reflection.MethodBase.GetCurrentMethod()).Name.ToString(), ex.ToString()));
            }
            return resultadoProductCategories;
        }

        public ClasesRSV.RSV_Resultado<List<ProductCategories>> GetProductCategories(int IDEstablecimiento, string CategoryName)
        {
            var context = new ContextProductCategories(CurrentConnection);
            List<ProductCategories> productcategories = new List<ProductCategories>();
            ClasesRSV.RSV_Resultado<List<ProductCategories>> resultadoProductCategories = new ClasesRSV.RSV_Resultado<List<ProductCategories>>();

            try
            {
                productcategories = context.sp_GetProductCategories(IDEstablecimiento, CategoryName);
                resultadoProductCategories.Exitoso = true;
                resultadoProductCategories.Datos = productcategories;
            }
            catch (Exception ex)
            {
                resultadoProductCategories.Exitoso = false;
                resultadoProductCategories.Error = Errores.LlenarError(ex, string.Format("Se presentó un error en el método {0}. {1}",
                    ((System.Reflection.MethodInfo)System.Reflection.MethodBase.GetCurrentMethod()).Name.ToString(), ex.ToString()));
            }
            return resultadoProductCategories;
        }
    }
}
