using Domin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository
{
    public interface IPatientRepository : IRepository<Patient>
    {
        Task<Patient> Update(Patient patient);
        Task<Patient> findbyid(int ID);
        Task<IEnumerable<Patient>> getpatientforsearch(string Query);
       Task bulkinsertpatient(List<Patient> patient);
    }
}
