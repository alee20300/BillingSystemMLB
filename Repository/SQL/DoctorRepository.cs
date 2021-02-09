using Domin.Models;
using System.Linq;

namespace Repository.SQL
{
    public class DoctorRepository : BaseRepository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(ApplicationContext db) : base(db)
        {
        }

        public Doctor GetDocById(int DoctorId)
        {
            return dbSet.FirstOrDefault(d => d.DoctorId == DoctorId);

        }
    }
}
