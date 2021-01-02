using Domin.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.SQL
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepostitory
    {
        public RoleRepository(ApplicationContext db) : base(db)
        {
        }
    }
}
