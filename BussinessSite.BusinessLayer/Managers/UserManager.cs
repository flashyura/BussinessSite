using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessSite.AbstractLayer.Generic;
using BussinessSite.AbstractLayer.Interfaces;
using BussinessSite.BusinessLayer.Models;

namespace BussinessSite.BusinessLayer.Managers
{
    public class UserManager : ManagerBase<User, int>
    {
        protected IUserContext<User, int> m_userContext;
        public UserManager(IDataRepositoryFactory dataRepositoryFactory, IDbContext сontex, IUserContext<User, int> userContext = null)
            : base(dataRepositoryFactory, сontex)
        {
            m_userContext = userContext;
        }

    }
}
