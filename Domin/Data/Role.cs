using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domin.Data
{
    public class Role
    {
        public int RoleId { get; set; }
        [StringLength(20)]
        public string RoleName { get; set; }
        
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<User> users { get; set; } = new List<User>();


    }
}
