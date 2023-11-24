using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using Domain.Entities;

namespace Core
{
    public interface IBaseMethods<T> where T : BaseEntity
    {
        public int Create(T t);

        public T Read(int id);

        public IQueryable<T> ReadAll();

        IQueryable<T> ReadAll(Expression<Func<T, bool>> expression);

        public int Update(T t);

        public int Delete(int id);
        public void DeleteRange(List<T> entities);
    }
}
