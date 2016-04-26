using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessSite.AbstractLayer.Interfaces
{
    /// <summary>
    /// Defines contracts for data layer repository 
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    /// <typeparam name="TIdType">The type of the identifier type.</typeparam>
    /// <seealso cref="System.IDisposable" />
    public interface IDataRepository<TModel, TIdType> : IDisposable
    {
        /// <summary>
        /// Creates the specified item list.
        /// </summary>
        /// <param name="itemList">The item list.</param>
        /// <returns></returns>
        IList<TModel> Create(IList<TModel> itemList);

        /// <summary>
        /// Reads the specified identifier list.
        /// </summary>
        /// <param name="idList">The identifier list.</param>
        /// <returns></returns>
        IList<TModel> Read(IList<TIdType> idList);

        /// <summary>
        /// Updates the specified item list.
        /// </summary>
        /// <param name="itemList">The item list.</param>
        /// <returns></returns>
        IList<TModel> Update(IList<TModel> itemList);

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
        //SearchResult<TModel> Search(SearchData searchData);
    }
}
