﻿namespace Domin.Data
{
    public class UserRole
    {
        public int UserRoleId { get; set; }

        public User User { get; set; }


        public Role Role { get; set; }
    }
}
