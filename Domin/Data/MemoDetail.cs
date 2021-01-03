using System.ComponentModel.DataAnnotations.Schema;

namespace Domin.Models
{
    public class MemoDetail
    {
        public MemoDetail()
        {

        }
        public MemoDetail(int serviceId)
            : this()
        {
            ServiceId = serviceId;



        }
        public int MemoDetailId { get; set; }

        public decimal Rate { get; set; }
        public int Qty { get; set; } = 1;
        public decimal PatientAmmount { get; set; }
        public decimal AccountAmmount { get; set; }



        #region Navigation
        [ForeignKey("MemoId")]
        public Memo Memo { get; set; }
        public int MemoId { get; set; }
        [ForeignKey("ServiceId")]
        public Service Service { get; set; }
        public int ServiceId { get; set; }



        #endregion


    }
}
