using System;
using System.Collections.Generic;
using System.Text;

namespace Domin.Data
{
   public class AutorizeDetail
    {
        public int AuthorizeDetailId { get; set; }
        public User User { get; set; }

        public ICollection<Claim> Claims { get; set; } = new List<Claim>();



        public bool IsAuthenticated { get; set; }

        public string Message { get; set; }
    }
}
