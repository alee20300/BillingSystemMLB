using Domin.Data;

namespace Repository.SQL
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext db) : base(db)
        {
        }
    }
}
