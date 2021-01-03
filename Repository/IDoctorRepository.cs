using Domin.Models;

namespace Repository
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        Doctor GetDocById(int DoctorId);
    }
}
