using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessSite.AbstractLayer.Models;

namespace BussinessSite.BusinessLayer.Models
{
    public class User : BusinessObject<int>
    {
        /// <summary>
        /// Active
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Login
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// Pass
        /// </summary>
        public string Pass { get; set; }

        /// <summary>
        /// First Name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// LastName
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Phone
        /// </summary>
        public string Phone { get; set; }

        ///// <summary>
        ///// Organization available
        ///// </summary>
        //public ICollection<Organization> Organizations { get; set; }

        ///// <summary>
        ///// Assigned Roles
        ///// </summary>
        //public ICollection<Role> Roles { get; set; }
    }
}
