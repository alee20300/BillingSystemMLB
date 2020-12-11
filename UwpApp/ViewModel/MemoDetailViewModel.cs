using Domin.Models;
using Syncfusion.UI.Xaml.Collections.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Store.Preview.InstallControl;

namespace UwpApp.ViewModel
{
    public class MemoDetailViewModel:BindableBase
    {
        public MemoDetailViewModel(int ser,int acco)
        {
            MemoDetail =  new MemoDetail();

            account(acco, ser);



        }

        public MemoDetail MemoDetail { get;  }

        public void account(int acc,int scc)
        {
           var result = App.Repository.AccountServicePrice.GetAccountServicePrice(acc, scc);
            AccountAmmount = result.AccountAmmount;
            PatientAmount = result.PatientAmmount;
            Rate = result.Rate;
        }

        public Service Service
        {
            get => MemoDetail.Service;
            set
            {
                if (MemoDetail.Service != value)
                {
                    MemoDetail.Service = value;
                    OnPropertyChanged();
                }
            }
        }

        public decimal PatientAmount 
        { get=>MemoDetail.PatientAmmount;
            set
            {
                if (MemoDetail.PatientAmmount!=value)
                {
                    MemoDetail.PatientAmmount = value;
                    OnPropertyChanged();
                }
            }
             }

        public decimal Rate
        {
            get => MemoDetail.Rate;
            set
            {
                if (MemoDetail.Rate != value)
                {
                    MemoDetail.Rate = value;
                    OnPropertyChanged();
                }
            }
        }

        public decimal AccountAmmount
        {
            get => MemoDetail.AccountAmmount;
            set
            {
                if (MemoDetail.AccountAmmount != value)
                {
                    MemoDetail.AccountAmmount = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Qty 
        { 
            get=>MemoDetail.Qty;
            set
            {
                if (MemoDetail.Qty!=value)
                {
                    MemoDetail.Qty = value;
                    OnPropertyChanged();

                }
            }
        
        }



    }
}
