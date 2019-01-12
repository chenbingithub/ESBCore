using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using SqlSugar;

namespace Abp.MongoDb.Repositories
{
    public interface IAbpMongoRepository
    {
      MongoDatabase Database { get; }
      IQueryable GetAll<TEntity, TPrimaryKey>() where TEntity : class, IEntity<TPrimaryKey>;

      TEntity Get<TEntity, TPrimaryKey>(TPrimaryKey id) where TEntity : class, IEntity<TPrimaryKey>;
      TEntity Get<TEntity, TPrimaryKey>(IMongoQuery query) where TEntity : class, IEntity<TPrimaryKey>;
      List<TEntity> GetList<TEntity, TPrimaryKey>(IMongoQuery query) where TEntity : class, IEntity<TPrimaryKey>;

      List<TEntity> GetPageList<TEntity, TPrimaryKey>(IMongoQuery query, PageModel page)
        where TEntity : class, IEntity<TPrimaryKey>;

      List<TEntity> GetPageList<TEntity, TPrimaryKey>(PageModel page) where TEntity : class, IEntity<TPrimaryKey>;
      TEntity FirstOrDefault<TEntity, TPrimaryKey>(TPrimaryKey id) where TEntity : class, IEntity<TPrimaryKey>;

      TEntity Insert<TEntity, TPrimaryKey>(TEntity entity) where TEntity : class, IEntity<TPrimaryKey>;
      TEntity Update<TEntity, TPrimaryKey>(TEntity entity) where TEntity : class, IEntity<TPrimaryKey>;

      void Delete<TEntity, TPrimaryKey>(TEntity entity) where TEntity : class, IEntity<TPrimaryKey>;
      void Delete<TEntity, TPrimaryKey>(TPrimaryKey id) where TEntity : class, IEntity<TPrimaryKey>;
    
  }
}
