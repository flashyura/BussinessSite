using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessSite.AbstractLayer.Interfaces;
using BussinessSite.AbstractLayer.Models;

namespace BussinessSite.DataLayerMSSql
{
    public partial class BusinessSuitEntities : IDbContext
    {
        public BSState GetBSState<TModel>(TModel entity) where TModel : class, new()
        {
            Type Ent = typeof(UserEntity);
            return (BSState)this.Entry(entity).State;
        }

        public IBSDbSet<TModel> GetDbSet<TModel>() where TModel : class, new()
        {
            return new BSDBSet<TModel>(Set<TModel>());
        }

        public void SetBSState<TModel>(TModel entity, BSState state) where TModel : class, new()
        {
            this.Entry<TModel>(entity).State = (EntityState)state;
        }
    }
}
