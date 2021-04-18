using Project.Business.Abstract;
using Project.Core.Utilities.Results;
using Project.DataAccess.Abstract;
using Project.Entities.Object;
using System.Collections.Generic;

namespace Project.Business.Operation {
    public class CategoryOperations : ICategoryOperations {
        private readonly ICategoryDL _categoryDL;

        public CategoryOperations(ICategoryDL categoryDL) {
            _categoryDL = categoryDL;
        }

        public IResult Create(Category category) {
            _categoryDL.Add(category);
            return new Result(true, "Kategori eklendi");
        }

        public IResult Delete(Category category) {
            _categoryDL.Delete(category);
            return new Result(true, "Kategori silindi");
        }

        public IDataResult<List<Category>> GetAll() {
            CategoryDataControl();
            var result = _categoryDL.GetList(x => x.IsActive == true);
            var resultCount = result.Count;
            return new DataResult<List<Category>>(result, true, resultCount + " adet kategori listelendi.");
        }

        public IResult GetById(int categoryId) {
            var result = _categoryDL.Get(x => x.Id == categoryId && x.IsActive == true);
            if (result == null)
                return new Result(false, "Kategori bulunamadı.");

            return new DataResult<Category>(result, true, "Kategori bulundu.");
        }

        public IResult Update(Category category) {
            _categoryDL.Update(category);
            return new Result(true, "kategori güncellendi.");
        }

        private void CategoryDataControl() {
            var booksListControl = _categoryDL.GetList();
            if (booksListControl.Count == 0) {
                var dataArray = new List<Category>() {
                     new Category {
                    CategoryName = "Kategori1", Description = "kategori 1", StockLimit = 10,IsActive=true
                },
                new Category {
                    CategoryName = "Kategori2", Description = "kategori 2", StockLimit = 5,IsActive=true
                }
                };
                foreach (var data in dataArray) {
                    _categoryDL.Add(data);

                }
            }
        }

    }
}
