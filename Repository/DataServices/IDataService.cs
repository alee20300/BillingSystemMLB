using Domin.Common;
using Domin.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.DataServices
{
    public interface IDataService : IDisposable
    {
        Task<Patient> GetPatientAsync(int id);
        Task<IList<Patient>> GetPatientAsync(int skip, int take, DataRequest<Patient> request);
        Task<IList<Patient>> GetPatientKeysAsync(int skip, int take, DataRequest<Patient> request);
        Task<int> GetPatientCountAsync(DataRequest<Patient> request);
        Task<int> UpdatePatientAsync(Patient patient);
        Task<int> DeletePatientAsync(params Patient[] patients);


        Task<Memo> GetMemoAsync(long id);
        Task<IList<Memo>> GetMemoAsync(int skip, int take, DataRequest<Patient> request);
        Task<IList<Memo>> GetMemoKeysAsync(int skip, int take, DataRequest<Patient> request);
        Task<int> GetMemoCountAsync(DataRequest<Memo> request);
        Task<int> UpdateMemoAsync(Memo memo);
        Task<int> DeleteMemoAsync(params Memo[] memos);



    }
}
