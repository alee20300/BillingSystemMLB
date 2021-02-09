using System;
using System.Collections.Generic;
using System.Text;

namespace Domin.Data
{
   public class RoleClaims
    {
        public int RoleClaimId { get; set; }
        public Role Role { get; set; }

        public Claim Claim { get; set; }



    }
}
