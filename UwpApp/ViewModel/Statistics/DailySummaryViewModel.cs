using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UwpApp.Models;
using UwpApp.ViewModel.Command;

namespace UwpApp.ViewModel.Statistics
{
   public class DailySummaryViewModel : BindableBase
    {
        public DailySummaryViewModel()
        {
            GetDataByServie();
        }

        public void Searchselector ()
        {


        }

        public ICommand Loadby => new RelayCommand(Searchselector);




        public  void GetDataByServie()
        {
            var result =  App.Repository.Memo.GetDailySummaryByService(DateTime.Now);
            foreach (var r in result)
            {
                DailySummary.Add(r);
            }            
        }

        public void GetDataByAccount()
        {
            var result = App.Repository.Memo.GetDailySummaryByAccount(DateTime.Now);
            foreach (var r in result)
            {
                DailySummary.Add(r);
            }
        }


        public DailySummaryModel DailySummaryModel { get; set; }

        public ObservableCollection<DailySummaryModel> DailySummary { get; set; } = new ObservableCollection<DailySummaryModel>();

    }
}
