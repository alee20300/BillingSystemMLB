using Repository.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UwpApp.Configuration;
using ViewModels.Infrastructure.Services;

namespace UwpApp.Services.DataServiceFacotry
{
    public class DataServiceFactory : IDataServiceFactory
    {
        static private Random _random = new Random(0);

        public IDataService CreateDataService()
        {
            if (AppSettings.Current.IsRandomErrorsEnabled)
            {
                if (_random.Next(20) == 0)
                {
                    throw new InvalidOperationException("Random error simulation");
                }
            }

            switch (AppSettings.Current.DataProvider)
            {
                case DataProviderType.SQLServer:
                    return new SQLServerDataService(AppSettings.Current.SQLServerConnectionString);

                default:
                    throw new NotImplementedException();
            }
        }

        
    }
}
