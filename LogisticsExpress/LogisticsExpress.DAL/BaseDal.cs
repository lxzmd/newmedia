using LogisticsExpress.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsExpress.DAL
{
    public class BaseDal<TEntity, TPrimaryKey> where TEntity : class,IEntity<TPrimaryKey>
    {
        //1.0实例化EF上下文容器对象
        private BaseDBContext db = new BaseDBContext();
        DbSet<TEntity> Table { get { return db.Set<TEntity>(); } }
        public BaseDal()
        {
        }

        #region 查询
        public List<TEntity> Query(Expression<Func<TEntity, bool>> where)
        {
            return Table.Where(where).ToList();
        }

        public List<TEntity> Query()
        {
            return Table.ToList();
        }

        public List<TEntity> QueryJoin(Expression<Func<TEntity, bool>> where, string[] tableNames)
        {
            //将子类_dbset 赋值给父类的query
            DbQuery<TEntity> query = Table;

            foreach (var item in tableNames)
            {
                //遍历要连表的表名称，最终得到所有连表以后的DbQuery对象
                query = query.Include(item);
            }
            return query.Where(where).ToList();
        }
        #endregion

        #region 新增
        public TPrimaryKey Insert(TEntity entity)
        {
            entity = Table.Add(entity);

            db.SaveChanges();

            return entity.Id;
        }
        #endregion

        #region 编辑
        public TEntity Update(TEntity entity)
        {
            if (!Table.Local.Contains(entity))
            {
                db.Set<TEntity>().Attach(entity);
            }
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
            return entity;
        }
        #endregion

        #region 物理删除
        //EntityState.Unchanged
        public void Delete(TEntity model, bool isAddedEFContext)
        {
            if (isAddedEFContext == false)
            {
                Table.Attach(model);
            }
            //修改状态为deleted
            Table.Remove(model);
            db.SaveChanges();
        }
        #endregion

        #region 统一执行保存
        public int SaveChanges()
        {
            return db.SaveChanges();
        }
        #endregion

    }
}
