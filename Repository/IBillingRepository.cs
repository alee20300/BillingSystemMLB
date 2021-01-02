using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public interface IBillingRepository 
    {
        IPatientRepository Patient { get; }
        IMemoRepository Memo { get; }

        IAtollRepository Atoll { get; }
        
        IIslandRepository Island { get; }

        IDoctorRepository Doctor { get; }

        IServiceRepository Service { get; }

        IAccountRepository Account { get; }

        ICountryRepository Country { get; }

        IAccountServicePrice AccountServicePrice { get; }

        ICollectionSiteRepository CollectionSite { get; }


        IUserRepository Users { get; }

        IRoleRepostitory Roles { get; }
    }
}
