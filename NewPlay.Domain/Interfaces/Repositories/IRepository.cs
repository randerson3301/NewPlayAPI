using System.Collections.Generic;

namespace NewPlay.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
         void Add(TEntity entity);
         void Update(TEntity entity);
         void Remove(TEntity entity);
         void BulkInsert(List<TEntity> entities);
         TEntity GetById(params object[] key);
        //  object FilterBy(string key, object value);
         IEnumerable<TEntity> GetAll();
        object GetValueTest(object src, string propName);

    }
}