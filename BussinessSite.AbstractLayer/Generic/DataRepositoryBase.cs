using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessSite.AbstractLayer.Interfaces;
using BussinessSite.AbstractLayer.Models;

namespace BussinessSite.AbstractLayer.Generic
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TIdType"></typeparam>
    public abstract class DataRepositoryBase<TModel, TIdType> : IDataRepository<TModel, TIdType>
        where TModel : BusinessObject<TIdType>, new()
        where TIdType : struct
    {
        protected IDbContext m_dbContext;
        protected IBSDbSet<TModel> m_dbSet;

        public DataRepositoryBase(IDbContext dbContext)
        {
            m_dbContext = dbContext;
            m_dbSet = m_dbContext.GetDbSet<TModel, TIdType>();
        }


        /// <summary>
        /// Creates items by list of specific id's
        /// </summary>
        /// <param name="modelList">list of models</param>
        /// <returns>created items</returns>
        public IList<TModel> Create(IList<TModel> modelList)
        {

            var resultList = new List<TModel>();
            foreach (var m in modelList)
            {
                m_dbSet.Add(m);
                resultList.Add(m);
            }
            return resultList;
        }


        /// <summary>
        /// Gets items by list of specific id's
        /// </summary>
        /// <param name="idList">list of specific id's</param>
        /// <returns>list of found items</returns>
        public IList<TModel> Read(IList<TIdType> idList)
        {

            var foundList = new List<TModel>();

            foreach (var id in idList)
            {
                var model = m_dbSet.Find(id);
                foundList.Add(model);
            }

            return foundList;

        }

        /// <summary>
        /// Updates the specified item list.
        /// </summary>
        /// <param name="itemList">The item list.</param>
        /// <returns></returns>
        public IList<TModel> Update(IList<TModel> itemList)
        {
            var foundList = new List<TModel>();

            foreach (var m in itemList)
            {
                var state = m_dbContext.GetBSState < (m);

                if (state == BSState.Detached)
                {
                    m_dbSet.Attach(m);
                }
                else
                {
                    m_dbContext.SetBSState(m, BSState.Modified);
                }

                foundList.Add(m);
            }

            return foundList;
        }

        /// <summary>
        /// Deletes items by list of specific id's
        /// </summary>
        /// <param name="idList">list of specific id's</param>
        /// <returns>list of deleted items</returns>
        public IList<TModel> Delete(IList<TIdType> idList)
        {
            var foundList = new List<TModel>();

            foreach (var id in idList)
            {
                var item = m_dbSet.Find(id);
                var state = m_dbContext.GetBSState(item);

                if (state != BSState.Deleted)
                {
                    m_dbContext.SetBSState(item, BSState.Deleted);
                }
                else
                {
                    m_dbSet.Attach(item);
                    m_dbSet.Remove(item);
                }

                foundList.Add(item);
            }

            return foundList;
        }



        /// <summary>
        ///// This method returns items which match to specific criteria in Search Data.
        ///// </summary>
        ///// <param name="searchData">search criteria</param>
        ///// <returns>SearchResult is wrapper of found items and contains additional information.</returns>
        //public virtual SearchResult<TModel> Search(SearchData searchData)
        //{
        //    using (var unitOfWork = GetUnitOfWork())
        //    {
        //        return unitOfWork.Search(searchData);
        //    }
        //}
    }
}
