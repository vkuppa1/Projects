using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Microsoft.AspNet.Identity.EntityFramework;
#endregion

namespace eBikes.Data.Entities.Security
{
    public class ApplicationUser : IdentityUser
    {
        public int? CustomerID { get; set; }
        public int? EmployeeID { get; set; }
    }
}
