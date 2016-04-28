using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessSite.AbstractLayer.Models;

namespace BussinessSite.AbstractLayer.Interfaces
{
    /// <summary>
    /// Base interface for business layer manager class. The interface defines CRUD contracts
    /// and search contract
    /// </summary>
    /// <typeparam name="TModel">The type of the business object.</typeparam>
    /// <typeparam name="TIdType">The type of the identifier type.</typeparam>
    public interface IManager<TModel, TIdType> : IDisposable
        where TModel : BusinessObject<TIdType>
        where TIdType : struct
    {
        /// <summary>
        /// Creates the specified list.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        IList<TModel> Create(IList<TModel> list);

        /// <summary>
        /// Reads the specified identifier list.
        /// </summary>
        /// <param name="idList">The identifier list.</param>
        /// <returns></returns>
        IList<TModel> Read(IList<TIdType> idList);

        /// <summary>
        /// Reads the specified identifier list.
        /// </summary>
        /// <param name="idList">The identifier list.</param>
        /// <returns></returns>
        IList<TModel> Read<TName>(IList<TName> nameList)
        where TName : struct;

        /// <summary>
        /// Updates the specified list.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        IList<TModel> Update(IList<TModel> list);

        /// <summary>
        /// Deletes the specified identifier list.
        /// </summary>
        /// <param name="idList">The identifier list.</param>
        /// <returns></returns>
        IList<TModel> Delete(IList<TIdType> idList);

        ///// <summary>
        ///// Searches the specified search data.
        ///// </summary>
        ///// <param name="searchData">The search data.</param>
        ///// <returns></returns>
        //SearchResult<TModel> Search(SearchData searchData = null);
        void Save();
    }
}
