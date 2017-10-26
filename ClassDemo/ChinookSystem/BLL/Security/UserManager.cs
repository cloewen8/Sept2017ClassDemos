using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Identity
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Chinook.Data.Entities.Security;
using ChinookSystem.DAL.Security;
#endregion

namespace ChinookSystem.BLL.Security
{
    public class UserManager : UserManager<ApplicationUser>
    {
        public UserManager()
            : base(new UserStore<ApplicationUser>(new ApplicationDbContext()))
        {
        }
    }
}
