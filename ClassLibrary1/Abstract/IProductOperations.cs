using Project.Core.Utilities.Results;
using Project.Entities.Object;
using Project.Entities.ViewModel;
using System.Collections.Generic;

namespace Project.Business.Abstract {
    public interface IProductOperations {
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetProductsBySearchTittle(string searchText);
        IResult GetById(int productId);
        IResult Create(Product product);
        IResult Update(Product product);
        IResult Delete(Product product);
        void UpdateStockQuantity(int productId, int stockQty);
        IDataResult<List<Product>> GetProductListByFilters(ProductSearchModel searchModel);
    }
}
