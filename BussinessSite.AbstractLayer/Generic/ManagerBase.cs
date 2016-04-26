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
    /// Provides base implementation of CRUD operation for business object.
    /// The implementation of this class uses unit of work pattern.
    /// </summary>
    /// <typeparam name="TModel">The type of the business object.</typeparam>
    /// <typeparam name="TIdType">The type of the identifier type.</typeparam>
    /// <seealso cref="MCIC.OrgHierarchy.Business.IManager{TModel, TIdType}" />
    public class ManagerBase<TModel, TIdType> : IManager<TModel, TIdType>
        where TModel : BusinessObject<TIdType>
        where TIdType : struct
    {
        protected IDbContext m_сontext;
        protected IDataRepository<TModel, TIdType> m_repository;
        protected IDataRepositoryFactory m_DataRepositoryFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagerBase{TModel, TIdType}"/> class.
        /// </summary>
        /// <param name="unitOfWorkFactory">The unit of work factory.</param>
        public ManagerBase(IDataRepositoryFactory dataRepositoryFactory, IDbContext сontext)
        {
            m_сontext = сontext;
            m_DataRepositoryFactory = dataRepositoryFactory;
            m_repository = CreateDefaultRepository();
        }

        /// <summary>
        /// Creates the specified items.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns></returns>
        public virtual IList<TModel> Create(IList<TModel> items)
        {
            if (items.Count == 0)
            {
                return null;
            }

            var repository = CreateDefaultRepository();
            return repository.Create(items);
        }

        /// <summary>
        /// Reads the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public virtual IList<TModel> Read(IList<TIdType> id)
        {
            var repository = CreateDefaultRepository();
            return repository.Read(id);
        }

        public virtual IList<TModel> Update(IList<TModel> items)
        {
            var repository = CreateDefaultRepository();
            return repository.Update(items);
        }

        public virtual IList<TModel> Delete(IList<TIdType> idList)
        {
            var itemsList = Read(idList);
            var foundItemIdList = new List<TIdType>();

            foreach (var item in itemsList)
            {
                foundItemIdList.Add(item.Id);
            }

            var repository = CreateDefaultRepository();
            return repository.Delete(foundItemIdList);
        }

        ///// <summary>
        ///// Searches the specified search data.
        ///// </summary>
        ///// <param name="searchData">The search data.</param>
        ///// <returns></returns>
        //public virtual SearchResult<TModel> Search(SearchData searchData = null)
        //{
        //    var repository = CreateDefaultRepository();
        //    return repository.Search(searchData);
        //}

        /// <summary>
        /// Creates the default repository.
        /// </summary>
        /// <returns></returns>
        protected IDataRepository<TModel, TIdType> CreateDefaultRepository()
        {
            var businessModelType = typeof(IDataRepository<TModel, TIdType>);
            return m_DataRepositoryFactory.GetRopository<TModel, TIdType>(businessModelType);
        }

        public IList<TModel> Read<TName>(IList<TName> nameList) where TName : struct
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            m_сontext.SaveChanges();
        }
    }
}
