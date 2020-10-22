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


    }
}
