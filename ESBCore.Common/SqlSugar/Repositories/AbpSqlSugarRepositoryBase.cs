using Abp.SqlSugar.Configuration;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Abp.SqlSugar.Repositories
{
   public class AbpSqlSugarRepositoryBase<T> where T : class, new()
    {
        private SimpleClient<T> _simpleClient { get { return new SimpleClient<T>(_databaseProvider.Database); } }
        public SqlSugarClient Database
        {
            get { return _databaseProvider.Database; }
        }
        private IAbpSqlSugarDatabaseProvider _databaseProvider;
        public AbpSqlSugarRepositoryBase(IAbpSqlSugarDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }
       
        public bool Delete(Expression<Func<T, bool>> whereExpression) 
        {
            return _simpleClient.Delete(whereExpression);
        }
        public bool Delete(T deleteObj) 
        {
            return _simpleClient.Delete(deleteObj);
        }
        public bool DeleteById(dynamic id) 
        {
            return _simpleClient.DeleteById(id);
        }
        public bool DeleteByIds(dynamic[] ids) 
        {
            return _simpleClient.DeleteByIds(ids);
        }
        public T GetById(dynamic id) 
        {
            return _simpleClient.GetById(id);
        }
        public List<T> GetList() 
        {
            return _simpleClient.GetList();
        }
        public List<T> GetList(Expression<Func<T, bool>> whereExpression) 
        {
            return _simpleClient.GetList(whereExpression);
        }
        public List<T> GetPageList(Expression<Func<T, bool>> whereExpression, PageModel page) 
        {
            return _simpleClient.GetPageList(whereExpression, page);
        }
        public List<T> GetPageList(Expression<Func<T, bool>> whereExpression, PageModel page, Expression<Func<T, object>> orderByExpression = null, OrderByType orderByType = OrderByType.Asc) 
        {
            return _simpleClient.GetPageList(whereExpression, page, orderByExpression, orderByType);
        }
        public List<T> GetPageList(List<IConditionalModel> conditionalList, PageModel page) 
        {
            return _simpleClient.GetPageList(conditionalList, page);
        }
        public List<T> GetPageList(List<IConditionalModel> conditionalList, PageModel page, Expression<Func<T, object>> orderByExpression = null, OrderByType orderByType = OrderByType.Asc) 
        {
            return _simpleClient.GetPageList(conditionalList, page, orderByExpression, orderByType);
        }
        public T GetSingle(Expression<Func<T, bool>> whereExpression) 
        {
            return _simpleClient.GetSingle(whereExpression);
        }
        public bool Insert(T insertObj) 
        {
            return _simpleClient.Insert(insertObj);
        }
        public bool InsertRange(T[] insertObjs) 
        {
            return _simpleClient.InsertRange(insertObjs);
        }
        public bool InsertRange(List<T> insertObjs) 
        {
            return _simpleClient.InsertRange(insertObjs);
        }
        public int InsertReturnIdentity(T insertObj) 
        {
            return _simpleClient.InsertReturnIdentity(insertObj);
        }
        public bool IsAny(Expression<Func<T, bool>> whereExpression) 
        {
            return _simpleClient.IsAny(whereExpression);
        }
        public bool Update(Expression<Func<T, T>> columns, Expression<Func<T, bool>> whereExpression) 
        {
            return _simpleClient.Update(columns, whereExpression);
        }
        public bool Update(T updateObj) 
        {
            return _simpleClient.Update(updateObj);
        }
        public bool UpdateRange(T[] updateObjs) 
        {
            return _simpleClient.UpdateRange(updateObjs);
        }
        public bool UpdateRange(List<T> updateObjs) 
        {
            return _simpleClient.UpdateRange(updateObjs);
        }

    }
}
