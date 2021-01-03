using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domin.Data
{
    public class Role
    {
        public int RoleId { get; set; }
        [StringLength(20)]
        public string RoleName { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }


    }
}
