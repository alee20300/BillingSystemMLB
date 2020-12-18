using Domin.Common;
using Domin.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Models;

namespace ViewModels.Services
{
    public interface IPatientService
    {

        Task<IEnumerable<PatientModel>> getpatientforsearch(string Query);
        Task<PatientModel> GetPatientAsync(int id);
        Task<IList<PatientModel>> GetPatientAsync(DataRequest<Patient> request);
        Task<IList<PatientModel>> GetPatientAsync(int skip, int take, DataRequest<Patient> request);
        Task<int> GetPatientCountAsync(DataRequest<Patient> request);

        Task<int> UpdatePatientAsync(PatientModel model);

        Task<int> DeletePatientAsync(PatientModel model);
        Task<int> DeletePatientRangeAsync(int index, int length, DataRequest<Patient> request);


    }
}
