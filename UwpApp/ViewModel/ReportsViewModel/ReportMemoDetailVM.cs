using Domin.Models;
using System.Globalization;

namespace UwpApp.ViewModel.ReportsViewModel
{
    public class ReportMemoDetailVM
    {
        public ReportMemoDetailVM(MemoDetail  memoD)
        {
            memoDetail = memoD;

            Description = memoDetail.Service.ServiceName;

        }
        public MemoDetail  memoDetail { get; set; }

        public string Code => memoDetail.MemoId.ToString();

        public string Description { get; set; } 

        public int QTY => memoDetail.Qty;
        public decimal Rate => memoDetail.Rate;
        public decimal Account => memoDetail.AccountAmmount;
        public decimal Patient => memoDetail.PatientAmmount;
    
    }
}