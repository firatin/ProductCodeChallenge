using Project.Business.Abstract;
using Project.Core.Utilities.Results;
using Project.DataAccess.Abstract;
using Project.Entities.Object;
using Project.Entities.ViewModel;
using System.Collections.Generic;

namespace Project.Business.Operation {
    public class ProductOperations : IProductOperations {
        private readonly IProductDL _productDL;

        public ProductOperations(IProductDL productDL) {
            _productDL = productDL;
        }

        public IResult Create(Product product) {
            _productDL.Add(product);
            return new Result(true, "Ürün eklendi");
        }

        public IResult Delete(Product product) {
            _productDL.Delete(product);
            return new Result(true, "Ürün silindi");
        }

        public IDataResult<List<Product>> GetAll() {
            ProductDataControl();
            var result = _productDL.GetList(x => x.IsActive == true && x.StockQuantity > 0);
            var resultCount = result.Count;
            return new DataResult<List<Product>>(result, true, resultCount + " adet ürün listelendi.");
        }

        public IResult GetById(int productId) {
            var result = _productDL.Get(x => x.Id == productId && x.StockQuantity > 0);
            if (result == null)
                return new Result(false, "Ürün bulunamadı.");

            return new DataResult<Product>(result, true, "Ürün bulundu.");
        }

        public IDataResult<List<Product>> GetProductsBySearchTittle(string searchText) {
            var result = _productDL.GetList(x => x.Title.Contains(searchText) && x.StockQuantity > 0);
            return new DataResult<List<Product>>(result, true, result.Count + " adet ürün listelendi.");
        }

        public IResult Update(Product product) {
            _productDL.Update(product);
            return new Result(true, "ürün güncellendi.");
        }

        public void UpdateStockQuantity(int productId, int stockQty) {
            var book = _productDL.Get(x => x.Id == productId);
            book.StockQuantity += stockQty;
            _productDL.Update(book);
        }
        public IDataResult<List<Product>> GetProductListByFilters(ProductSearchModel searchModel) {
            var result = _productDL.GetProductListByFilters(searchModel);
            return new DataResult<List<Product>>(result, true, result.Count + " adet ürün listelendi.");

        }
        private void ProductDataControl() {
            var booksListControl = _productDL.GetList();
            if (booksListControl.Count == 0) {
                var dataArray = new List<Product>() {
                        new Product {
                            CategoryId = 1, Title = "The Perfect Sandwich, A Real NYC Classic", Description = "This is a wider card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.", Price = 1000, StockQuantity = 15,IsActive=true
                        },
                        new Product {
                            CategoryId = 2, Title = "Let Me Tell You About This Steak", Description = "Lorem lorem lorem lorem ipsum text praesent tincidunt ipsum lipsum.", Price = 8000, StockQuantity = 5,IsActive=true
                        },
                        new Product {
                            CategoryId = 1, Title = "Cherries, interrupted", Description = "Just some random text, lorem ipsum text praesent tincidunt ipsum lipsum.", Price = 2800, StockQuantity = 9,IsActive=true
                        },
                        new Product {
                            CategoryId = 1, Title = "Robust Wine and Vegetable Pasta", Description = "Once again, some random text to lorem lorem lorem lorem ipsum text praesent tincidunt ipsum lipsum.", Price = 690, StockQuantity = 30,IsActive=true
                        }, };
                foreach (var data in dataArray) {
                    _productDL.Add(data);

                }
            }
        }

    }
}
