using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessSite.AbstractLayer.Interfaces
{
    /// <summary>
    /// Defines database context interface to have abitility to mock or fake for unit testing
    /// </summary>   
    public interface IDbContext : IDisposable
    {
        int SaveChanges();
    }
}
