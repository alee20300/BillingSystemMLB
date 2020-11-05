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

        ApplicationContext _db;
        public PatientRepository(ApplicationContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Patient> Update(Patient patient)
        {
            
                var existing = await dbSet.FirstOrDefaultAsync(_patient => _patient.Id == patient.Id);
                if (null == existing)

                {
                    dbSet.Add(existing);
                }
                else
                {
                    _db.Entry(existing).CurrentValues.SetValues(patient);
                }

                await _db.SaveChangesAsync();
                return patient;
            
        }
    }
}
