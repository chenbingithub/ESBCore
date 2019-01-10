using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;

namespace ESBCore.SQLData
{
    public class SQLManager 
    {
        private SimpleClient _simpleClient;
        private SqlSugarClient _db;
        public SQLManager(SQLConfig config) 
        {
            _db = ContextDb.CreateRepository(config);
            _simpleClient =new SimpleClient(_db);
        }
        public bool Delete<T>(Expression<Func<T, bool>> whereExpression) where T : class, new(){
           return  _simpleClient.Delete<T>(whereExpression);
        }
        public bool Delete<T>(T deleteObj) where T : class, new(){
            return _simpleClient.Delete<T>(deleteObj);
        }
        public bool DeleteById<T>(dynamic id) where T : class, new(){
            return _simpleClient.DeleteById<T>(id);
        }
        public bool DeleteByIds<T>( dynamic[] ids) where T : class, new(){
            return _simpleClient.DeleteByIds<T>(ids);
        }
        public T GetById<T>(dynamic id) where T : class, new(){
            return _simpleClient.GetById<T>(id);
        }
        public List<T> GetList<T>() where T : class, new(){
            return _simpleClient.GetList<T>();
        }
        public List<T> GetList<T>(Expression<Func<T, bool>> whereExpression) where T : class, new(){
            return _simpleClient.GetList<T>(whereExpression);
        }
        public List<T> GetPageList<T>(Expression<Func<T, bool>> whereExpression, PageModel page) where T : class, new(){
            return _simpleClient.GetPageList<T>(whereExpression, page);
        }
        public List<T> GetPageList<T>(Expression<Func<T, bool>> whereExpression, PageModel page, Expression<Func<T, object>> orderByExpression = null, OrderByType orderByType = OrderByType.Asc) where T : class, new(){
            return _simpleClient.GetPageList<T>(whereExpression, page, orderByExpression, orderByType);
        }
        public List<T> GetPageList<T>(List<IConditionalModel> conditionalList, PageModel page) where T : class, new(){
            return _simpleClient.GetPageList<T>(conditionalList, page);
        }
        public List<T> GetPageList<T>(List<IConditionalModel> conditionalList, PageModel page, Expression<Func<T, object>> orderByExpression = null, OrderByType orderByType = OrderByType.Asc) where T : class, new(){
            return _simpleClient.GetPageList<T>(conditionalList, page, orderByExpression, orderByType);
        }
        public T GetSingle<T>(Expression<Func<T, bool>> whereExpression) where T : class, new(){
            return _simpleClient.GetSingle<T>(whereExpression);
        }
        public bool Insert<T>(T insertObj) where T : class, new(){
            return _simpleClient.Insert<T>(insertObj);
        }
        public bool InsertRange<T>(T[] insertObjs) where T : class, new(){
            return _simpleClient.InsertRange<T>(insertObjs);
        }
        public bool InsertRange<T>(List<T> insertObjs) where T : class, new(){
            return _simpleClient.InsertRange<T>(insertObjs);
        }
        public int InsertReturnIdentity<T>(T insertObj) where T : class, new(){
            return _simpleClient.InsertReturnIdentity<T>(insertObj);
        }
        public bool IsAny<T>(Expression<Func<T, bool>> whereExpression) where T : class, new(){
            return _simpleClient.IsAny<T>(whereExpression);
        }
        public bool Update<T>(Expression<Func<T, T>> columns, Expression<Func<T, bool>> whereExpression) where T : class, new(){
            return _simpleClient.Update<T>(columns, whereExpression);
        }
        public bool Update<T>(T updateObj) where T : class, new(){
            return _simpleClient.Update<T>(updateObj);
        }
        public bool UpdateRange<T>(T[] updateObjs) where T : class, new(){
            return _simpleClient.UpdateRange<T>(updateObjs);
        }
        public bool UpdateRange<T>(List<T> updateObjs) where T : class, new(){
            return _simpleClient.UpdateRange<T>(updateObjs);
        }
    }
}
