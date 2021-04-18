using Project.Core.Utilities.Results;
using Project.Entities.Object;
using System.Collections.Generic;

namespace Project.Business.Abstract {
    public interface ICategoryOperations {
        IDataResult<List<Category>> GetAll();
        IResult GetById(int categoryId);
        IResult Create(Category category);
        IResult Update(Category category);
        IResult Delete(Category category);
    }
}
