using Domin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.SQL
{
    public class PatientRepository : BaseRepository<Patient>, IPatientRepository
    {
        public PatientRepository(ApplicationContext db) : base(db)
        {
           
        }
        

        public  async Task<Patient> GetSingleAsync(string PatientId)
        {
            return await dbSet.FindAsync(PatientId);
        }

       
    }
}
