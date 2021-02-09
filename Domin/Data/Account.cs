using System.Collections.Generic;

namespace Domin.Models
{
    public class Account : AuditEntity

    {


        public int AccountId { get; set; }

        public string AccountName { get; set; }

        public string AccountCode { get; set; }

        public ICollection<Memo> Memos { get; set; } = new List<Memo>();
        public ICollection<AccountServicePrice> accountServicePrices { get; set; } = new List<AccountServicePrice>();

    }
}
