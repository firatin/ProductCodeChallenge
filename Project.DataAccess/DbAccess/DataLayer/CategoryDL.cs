using Project.Core.Data;
using Project.DataAccess.Abstract;
using Project.Entities.Object;

namespace Project.DataAccess.DbAccess.DataLayer {
    public class CategoryDL : EntityRepoBase<Category, SqlContext>, ICategoryDL {
    }
}
