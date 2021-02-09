using Repository.DataContexts;
using Repository.DataServices.Base;

namespace Repository.DataServices
{
    public class SQLServerDataService : DataServiceBase
    {
        public SQLServerDataService(string connectionString)
            : base(new SQLServerDb(connectionString))
        {
        }
    }
}
