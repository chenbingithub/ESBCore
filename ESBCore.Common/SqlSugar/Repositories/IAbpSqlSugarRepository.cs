using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using SqlSugar;

namespace Abp.SqlSugar.Repositories
{
    public interface IAbpSqlSugarRepository
  { 
      SqlSugarClient Database { get;  }


      bool Delete<T>(Expression<Func<T, bool>> whereExpression) where T : class, new();
      bool Delete<T>(T deleteObj) where T : class, new();
      bool DeleteById<T>(dynamic id) where T : class, new();
      bool DeleteByIds<T>(dynamic[] ids) where T : class, new();
      T GetById<T>(dynamic id) where T : class, new();
      List<T> GetList<T>() where T : class, new();
      List<T> GetList<T>(Expression<Func<T, bool>> whereExpression) where T : class, new();
      List<T> GetPageList<T>(Expression<Func<T, bool>> whereExpression, PageModel page) where T : class, new();

      List<T> GetPageList<T>(Expression<Func<T, bool>> whereExpression, PageModel page,
        Expression<Func<T, object>> orderByExpression = null, OrderByType orderByType = OrderByType.Asc) where T : class, new();

      List<T> GetPageList<T>(List<IConditionalModel> conditionalList, PageModel page) where T : class, new();

      List<T> GetPageList<T>(List<IConditionalModel> conditionalList, PageModel page,
        Expression<Func<T, object>> orderByExpression = null, OrderByType orderByType = OrderByType.Asc) where T : class, new();

      T GetSingle<T>(Expression<Func<T, bool>> whereExpression) where T : class, new();
      bool Insert<T>(T insertObj) where T : class, new();
      bool InsertRange<T>(T[] insertObjs) where T : class, new();
      bool InsertRange<T>(List<T> insertObjs) where T : class, new();
      int InsertReturnIdentity<T>(T insertObj) where T : class, new();
      bool IsAny<T>(Expression<Func<T, bool>> whereExpression) where T : class, new();
      bool Update<T>(Expression<Func<T, T>> columns, Expression<Func<T, bool>> whereExpression) where T : class, new();
      bool Update<T>(T updateObj) where T : class, new();
      bool UpdateRange<T>(T[] updateObjs) where T : class, new();
      bool UpdateRange<T>(List<T> updateObjs) where T : class, new();
    }
}
