using Repository.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UwpApp.Services.DataServiceFacotry
{
    public interface IDataServiceFactory
    {
        IDataService CreateDataService();
    }
}
