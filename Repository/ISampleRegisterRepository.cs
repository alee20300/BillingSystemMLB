using Domin.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
   public interface ISampleRegisterRepository : IRepository<SampleRegister>
    {

        Task<IEnumerable<SampleRegister>> getregforsearch(string Query);
    }
}
