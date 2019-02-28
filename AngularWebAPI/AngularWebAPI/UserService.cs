using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AngularWebAPIDataAccess;

namespace AngularWebAPI
{
    public class UserService
    {
        public static bool Login(string username, string password)
        {
            using (AngularWebAPIEntities entities = new AngularWebAPIEntities())
            {
                return entities.CORUSERMSTs.Any(user =>
                       user.User_Username.Equals(username, StringComparison.OrdinalIgnoreCase)
                                          && user.User_Password == password);
            }
        }
    }
}