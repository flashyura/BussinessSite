using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessSite.AbstractLayer.Models;

namespace BussinessSite.AbstractLayer.Interfaces
{
    public interface IDataRepositoryFactory
    {
        /// <summary>
        /// Gets the ropository.
        /// </summary>
        /// <typeparam name="TModel">The type of the business object.</typeparam>
        /// <typeparam name="TIdType">The type of the identifier type.</typeparam>
        /// <param name="businessObjectType">Type of the business object.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        IDataRepository<TModel, TIdType> GetRopository<TModel, TIdType>(Type businessObjectType)
            where TModel : BusinessObject<TIdType>
            where TIdType : struct;

    }
}
