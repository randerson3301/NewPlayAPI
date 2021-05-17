using NewPlay.Domain.Interfaces;
using System.Collections.Generic;
using NewPlay.Infrastructure.Context;
using System.Linq;
using System;


namespace NewPlay.Infrastructure.Repositories
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public void Add(TEntity entity){
            using(var db = new NewPlayDbContext()){
                db.Add(entity);
                db.SaveChanges();                
            };
        }
        public void Update(TEntity entity){
            using(var db = new NewPlayDbContext()){
                db.Update(entity);
                db.SaveChanges();
            };
        }
        public void Remove(TEntity entity){
            using(var db = new NewPlayDbContext()){
                db.Remove(entity);
                db.SaveChanges();                
            };
        }
        public void BulkInsert(List<TEntity> entities){
            using(var db = new NewPlayDbContext()){
                db.AddRange(entities);
                db.SaveChanges();
            };
        }
        public TEntity GetById(params object[] key){
            using(var db = new NewPlayDbContext()){
               return db.Set<TEntity>().Find(key);                         
            };
        }  

        // public object FilterBy(string key, object value){

        //     using(var db = new NewPlayDbContext()){
        //        //Type type = db.Set<TEntity>().GetType();

        //        //var prop = db.Set<TEntity>().GetType().GetProperty(key).GetValue(db.Set<TEntity>().GetType());
        //        //var _value = prop.GetValue(db.Set<TEntity>());
        //     //    return db.Set<typeof(TEntity)>().ToList()
        //     //             .FindAll(e => 
        //     //             e.GetType()
        //     //             .get(key)
        //     //             .GetValue(e) 
        //     //             == value);                         
        //     };
        //     return null;
        // }   
        
        public IEnumerable<TEntity> GetAll(){
            using(var db = new NewPlayDbContext()){
               return db.Set<TEntity>().ToList();                         
            };
        }

        public object GetValueTest(object src, string propName){
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }
    }
}