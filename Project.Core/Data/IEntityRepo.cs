using Project.Core.Object;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Project.Core.Data {
    public interface IEntityRepo<T> where T : class, IEntity, new() {
        T Get(Expression<Func<T, bool>> filter = null);
        List<T> GetList(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }

}
