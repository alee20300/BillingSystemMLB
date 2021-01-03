using Domin.Common;
using Domin.Models;
using Repository.DataContexts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.DataServices.Base
{
    abstract public partial class DataServiceBase : IDataService, IDisposable

    {

        private IDataSource _dataSource = null;

        public DataServiceBase(IDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public Task<int> DeleteMemoAsync(params Memo[] memos)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeletePatientAsync(params Patient[] patients)
        {
            throw new NotImplementedException();
        }









        #region Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Task<Memo> GetMemoAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Memo>> GetMemoAsync(int skip, int take, DataRequest<Patient> request)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetMemoCountAsync(DataRequest<Memo> request)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Memo>> GetMemoKeysAsync(int skip, int take, DataRequest<Patient> request)
        {
            throw new NotImplementedException();
        }

        public Task<Patient> GetPatientAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Patient>> GetPatientAsync(int skip, int take, DataRequest<Patient> request)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetPatientCountAsync(DataRequest<Patient> request)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Patient>> GetPatientKeysAsync(int skip, int take, DataRequest<Patient> request)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateMemoAsync(Memo memo)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdatePatientAsync(Patient patient)
        {
            throw new NotImplementedException();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dataSource != null)
                {
                    _dataSource.Dispose();
                }
            }
        }
        #endregion
    }
}
