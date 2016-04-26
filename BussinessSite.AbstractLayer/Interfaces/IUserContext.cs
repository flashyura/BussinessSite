using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessSite.AbstractLayer.Models;

namespace BussinessSite.AbstractLayer.Interfaces
{
    public interface IUserContext<TModel, TIdType>
        where TIdType : struct
        where TModel : BusinessObject<TIdType>
    {
        TModel CallerAccount { get; }
    }
}
