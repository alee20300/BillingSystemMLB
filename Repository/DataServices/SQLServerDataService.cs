using Repository.DataContexts;
using Repository.DataServices.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.DataServices
{
    class SQLServerDataService :DataServiceBase
    {

        public SQLServerDataService(string connectionString)
          : base(new SQLServerDb(connectionString))
        {
        }
    }
}
