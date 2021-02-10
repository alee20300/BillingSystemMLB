using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UwpApp.Models;

namespace UwpApp.ViewModel.Statistics
{
   public class DailySummaryViewModel : BindableBase
    {
        public DailySummaryViewModel()
        {
            GetData();
        }

        public  void GetData()
        {

            var result =  App.Repository.Memo.GetDailySummary(DateTime.Now);
            
            
        }

        public DailySummaryModel DailySummaryModel { get; set; }



    }
}
