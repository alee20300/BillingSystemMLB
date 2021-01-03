using Domin.Data;

namespace Repository.SQL
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepostitory
    {
        public RoleRepository(ApplicationContext db) : base(db)
        {
        }
    }
}
