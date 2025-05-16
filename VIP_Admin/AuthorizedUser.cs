using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIP_Admin
{
    public class AuthorizedUser
    {
        public AuthorizedUser()
        {
        }
        private static AuthorizedUser instance;
        public static AuthorizedUser GetInstance()
        {
            if (instance == null)
                instance = new AuthorizedUser();
            return instance;
        }

       public User AuthUser { get; set; }
    }
}
