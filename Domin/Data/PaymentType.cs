using Domin.Models;

namespace Domin.Data
{
    public class PaymentType
    {

        public int PaymentTypeId { get; set; }
        public Account Account { get; set; }
        public string AccountName { get; set; } 


    }
}
