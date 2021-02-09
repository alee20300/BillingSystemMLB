using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domin.Data
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }

        
        public string Name { get; set; }

        public ICollection<UsernameAndHash> UsernameAndHash { get; set; }

     

        public ICollection<UserRole> UserRoles { get; set; }

        



    }
}
