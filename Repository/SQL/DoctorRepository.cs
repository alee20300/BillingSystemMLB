using Domin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
