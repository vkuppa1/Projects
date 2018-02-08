
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using eBikes.Data.Entities;
using eBikesSystem.DAL;
#endregion

namespace eBikesSystem.BLL
{
    public class EmployeeController
    {
        public Employee Employee_Get(int employeeid)
        {
            using (var context = new eBikesContext())
            {
                return context.Employees.Find(employeeid);
            }
        }
    }
}