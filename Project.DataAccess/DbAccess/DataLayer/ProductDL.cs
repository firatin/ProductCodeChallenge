using Microsoft.EntityFrameworkCore;
using Project.Core.Data;
using Project.DataAccess.Abstract;
using Project.Entities.Object;
using Project.Entities.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace Project.DataAccess.DbAccess.DataLayer {
    public class ProductDL : EntityRepoBase<Product, SqlContext>, IProductDL {

        public List<Product> GetProductListByFilters(ProductSearchModel searchModel) {
            using (var context = new SqlContext()) {
                var query = context.Set<Product>().Include(x => x.Category)
                    .Where(x => searchModel.CategoryName == null || x.Category.CategoryName.Contains(searchModel.CategoryName))
                    .Where(x => searchModel.Description == null || x.Description.Contains(searchModel.Description))
                    .Where(x => searchModel.Title == null || x.Title.Contains(searchModel.Title))
                    .Where(x => searchModel.MinStock == null || x.StockQuantity >= searchModel.MinStock)
                    .Where(x => searchModel.MaxStock == null || x.StockQuantity <= searchModel.MaxStock);

                return query.Where(x => x.StockQuantity >= x.Category.StockLimit).ToList();
            }
        }
    }
}
