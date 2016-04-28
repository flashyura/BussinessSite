using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BussinessSite.AbstractLayer.Interfaces;

namespace BussinessSite.DataLayerMSSql
{
    public class BSDBSet<TEntity> : IBSDbSet<TEntity>
        where TEntity : class
    {
        protected DbSet<TEntity> m_dbSet;
        public BSDBSet(DbSet<TEntity> dbSet)
        {
            m_dbSet = dbSet;
        }

        public Type ElementType
        {
            get
            {
                return m_dbSet.GetType();
            }
        }

        public Expression Expression
        {
            get
            {
                return (m_dbSet as IQueryable).Expression;
            }
        }

        public IQueryProvider Provider
        {
            get
            {
                return (m_dbSet as IQueryable).Provider;
            }
        }

        ObservableCollection<TEntity> IBSDbSet<TEntity>.Local
        {
            get
            {
                return m_dbSet.Local;
            }
        }

        public TEntity Add(TEntity entity)
        {
            return m_dbSet.Add(entity);
        }

        public TEntity Attach(TEntity entity)
        {
            return m_dbSet.Attach(entity);
        }

        public IEnumerator<TEntity> GetEnumerator()
        {
            return (m_dbSet as IEnumerable<TEntity>).GetEnumerator();
        }

        public TEntity Remove(TEntity entity)
        {
            return m_dbSet.Remove(entity);
        }

        TEntity IBSDbSet<TEntity>.Create()
        {
            return m_dbSet.Create();
        }

        TEntity IBSDbSet<TEntity>.Find(params object[] keyValues)
        {
            return m_dbSet.Find(keyValues);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (m_dbSet as IEnumerable).GetEnumerator();
        }
    }
}
