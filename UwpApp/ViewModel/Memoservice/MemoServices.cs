using Domin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UwpApp.ViewModel.Memoservice
{
    public class MemoServices : IMemoServices
    {
        public MemoServices()
        {
            Task.Run(LoadServices);
        }

        public List<Service> Services { get; } = new List<Service>();

        public async void LoadServices()
        {
            var result = await App.Repository.Service.GetServiceswithTracking();
            Services.Clear();
            foreach (var item in result)
            {
                Services.Add(item);
            }
        }
         
        public  IEnumerable<Service> GetServicesForSugesstion(string Query)
        {


            var services = Services.Where(s=>s.ServiceName.StartsWith(Query)
            ||
            s.LisCode.StartsWith(Query) ||
            s.ServiceCode.StartsWith(Query)).ToList();
          


            return services;
            
        }

        public Task<IEnumerable<Memo>> MakeBulkMemo(IEnumerable<Patient> patients)
        {
            throw new NotImplementedException();
        }

        public Task<Memo> MakeMemo(Patient patient)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Memo>> SaveBulkMemo(IEnumerable<Memo> memos)
        {
            throw new NotImplementedException();
        }

        public Task<Memo> SaveMemo(Memo memo)
        {
            throw new NotImplementedException();
        }
    }
}
