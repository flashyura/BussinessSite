using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessSite.AbstractLayer.Models;

namespace BussinessSite.AbstractLayer.Interfaces
{
    /// <summary>
    /// Defines database context interface to have abitility to mock or fake for unit testing
    /// </summary>   
    public interface IDbContext : IDisposable
    {
        IBSDbSet<TModel> GetDbSet<TModel>()
            where TModel : class, new();

        /// <summary>
        /// Gets the state of the entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        BSState GetBSState<TModel>(TModel entity)
             where TModel : class, new();
        /// <summary>
        /// Sets the state of the entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <param name="state">The state.</param>
        void SetBSState<TModel>(TModel entity, BSState state)
           where TModel : class, new();
        int SaveChanges();
    }
}
