using Project.Core.Data;
using Project.Entities.Object;
using Project.Entities.ViewModel;
using System.Collections.Generic;

namespace Project.DataAccess.Abstract {
    public interface IProductDL : IEntityRepo<Product> {
        List<Product> GetProductListByFilters(ProductSearchModel searchModel);
    }
}
