using Domin.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
       Doctor GetDocById(int DoctorId);
    }
}
