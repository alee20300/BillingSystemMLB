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

        public async Task<Patient> findbyid(int ID)
        {
            return await _db.Patients
                .AsNoTracking()
                .FirstOrDefaultAsync(patient => patient.PatientId == ID);
        }

        public async Task<IEnumerable<Patient>> getpatientforsearch(string Query)
        {

            return await dbSet.Where(patient =>
            patient.IdCardNumber.StartsWith(Query) ||
            patient.PatientName.Contains(Query) ||
            patient.Contact.StartsWith(Query))
                .AsNoTracking()
                .ToListAsync();
                     
            
                  }

        public async Task<Patient> Update(Patient patient)
        {
            
                var existing = await dbSet.FirstOrDefaultAsync(_patient => _patient.PatientId == patient.PatientId);
                if (null == existing)

                {
                    dbSet.Add(patient);
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
