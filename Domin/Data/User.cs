using System;
using System.Collections.Generic;
using System.Text;

namespace Domin.Data
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public int RoleId { get; set; }

        public Role Role { get; set; }

        public ICollection<Role> Roles { get; set; } = new List<Role>();



    }
}
