using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BussinessSite.AbstractLayer.Interfaces
{
    /// <summary>
    /// copied from entity framework
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IBSDbSet<TEntity> : IQueryable<TEntity>, IEnumerable<TEntity>, IQueryable, IEnumerable
        where TEntity : class
    {
        ObservableCollection<TEntity> Local { get; }
        TEntity Add(TEntity entity);
        TEntity Attach(TEntity entity);
        TEntity Create();
        TEntity Find(params object[] keyValues);
        TEntity Remove(TEntity entity);

    }
}