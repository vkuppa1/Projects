using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBikes.Data.Entities.Security
{
    public static class SecurityRoles
    {
        public const string WebsiteAdmins = "WebsiteAdmins";
        public const string RegisteredUsers = "RegisteredUsers";
        public const string Staff = "Staff";

        public const string Purchasing = "Purchasing";
        public const string Recieving = "Recieving";
        public const string Sales = "Sales";
        public const string Jobing = "Jobing";
        public const string Services = "Services";


        public static List<string> DefaultSecurityRoles
        {
            get
            {
                List<string> value = new List<string>();
                value.Add(WebsiteAdmins);
                value.Add(RegisteredUsers);
                value.Add(Staff);
                value.Add(Recieving);
                value.Add(Purchasing);
                value.Add(Services);
                value.Add(Jobing);
                value.Add(Sales);

                return value;
            }
        }
    }
}