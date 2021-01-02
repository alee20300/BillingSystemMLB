using Domin.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.SQL
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext db) : base(db)
        {
        }
    }
}
