using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessSite.AbstractLayer.Models
{
    public abstract class BusinessObject<TIdType>
       where TIdType : struct
    {
        public TIdType Id { get; set; }
    }
}
