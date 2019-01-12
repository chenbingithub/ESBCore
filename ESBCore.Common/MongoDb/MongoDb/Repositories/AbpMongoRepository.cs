using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Abp.Dependency;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using SqlSugar;

namespace Abp.MongoDb.Repositories
{
   
    /// <summary>
    /// Implements IRepository for MongoDB.
    /// </summary>
    public class AbpMongoRepository : IAbpMongoRepository, ITransientDependency

  {
        public  MongoDatabase Database
        {
            get { return _databaseProvider.Database; }
        }

       

        private readonly IAbpMongoDatabaseProvider _databaseProvider;

        public AbpMongoRepository(IAbpMongoDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public  IQueryable GetAll<TEntity, TPrimaryKey>() where TEntity : class, IEntity<TPrimaryKey>
    {
            return _databaseProvider.Database.GetCollection<TEntity>(typeof(TEntity).Name).AsQueryable();
        }
        
        public  TEntity Get<TEntity, TPrimaryKey>(TPrimaryKey id) where TEntity : class, IEntity<TPrimaryKey>
    {

            var query = MongoDB.Driver.Builders.Query<TEntity>.EQ(e => e.Id, id);
            var entity = _databaseProvider.Database.GetCollection<TEntity>(typeof(TEntity).Name).FindOne(query);
            if (entity == null)
            {
                throw new EntityNotFoundException("There is no such an entity with given primary key. Entity type: " + typeof(TEntity).FullName + ", primary key: " + id);
            }

            return entity;
        }
      public TEntity Get<TEntity, TPrimaryKey>(IMongoQuery query) where TEntity : class, IEntity<TPrimaryKey>
      {

        var entity = _databaseProvider.Database.GetCollection<TEntity>(typeof(TEntity).Name).FindOne(query);
        return entity;
      }
      public List<TEntity>  GetList<TEntity, TPrimaryKey>(IMongoQuery query) where TEntity : class, IEntity<TPrimaryKey>
      {
        var entity = _databaseProvider.Database.GetCollection<TEntity>(typeof(TEntity).Name).Find(query).ToList();
        return entity;
      }

      public List<TEntity> GetPageList<TEntity, TPrimaryKey>(IMongoQuery query, PageModel page) where TEntity : class, IEntity<TPrimaryKey>
      {
        page.PageCount = _databaseProvider.Database.GetCollection<TEntity>(typeof(TEntity).Name).Find(query).Size().ObjToInt();
        var entity = _databaseProvider.Database.GetCollection<TEntity>(typeof(TEntity).Name).Find(query).SetSkip(page.PageSize*(page.PageIndex)).SetLimit(page.PageSize).ToList();
        return entity;
    }
      public List<TEntity> GetPageList<TEntity, TPrimaryKey>( PageModel page) where TEntity : class, IEntity<TPrimaryKey>
      {
        var query = MongoDB.Driver.Builders.Query.Empty;
      page.PageCount = _databaseProvider.Database.GetCollection<TEntity>(typeof(TEntity).Name).Find(query).Size().ObjToInt();
        var entity = _databaseProvider.Database.GetCollection<TEntity>(typeof(TEntity).Name).Find(query).SetSkip(page.PageSize * (page.PageIndex)).SetLimit(page.PageSize).ToList();
        return entity;
      }
    public  TEntity FirstOrDefault<TEntity, TPrimaryKey>(TPrimaryKey id) where TEntity : class, IEntity<TPrimaryKey>
    {
            var query = MongoDB.Driver.Builders.Query<TEntity>.EQ(e => e.Id, id);
            return _databaseProvider.Database.GetCollection<TEntity>(typeof(TEntity).Name).FindOne(query);
        }

        public  TEntity Insert<TEntity, TPrimaryKey>(TEntity entity) where TEntity : class, IEntity<TPrimaryKey>
    {
            _databaseProvider.Database.GetCollection<TEntity>(typeof(TEntity).Name).Insert(entity);
            return entity;
        }
        public  TEntity Update<TEntity, TPrimaryKey>(TEntity entity) where TEntity : class, IEntity<TPrimaryKey>
    {
            _databaseProvider.Database.GetCollection<TEntity>(typeof(TEntity).Name).Save(entity);
            return entity;
        }

        public  void Delete<TEntity, TPrimaryKey>(TEntity entity) where TEntity : class, IEntity<TPrimaryKey>
    {
            Delete<TEntity, TPrimaryKey>(entity.Id);
        }

        public  void Delete<TEntity, TPrimaryKey>(TPrimaryKey id) where TEntity : class, IEntity<TPrimaryKey>
    {
            var query = MongoDB.Driver.Builders.Query<TEntity>.EQ(e => e.Id, id);
            _databaseProvider.Database.GetCollection<TEntity>(typeof(TEntity).Name).Remove(query);
        }
    }
}