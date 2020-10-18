using Domin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UwpApp.ViewModel
{
    public class MemoDetailViewModel:BindableBase
    {
        public MemoDetailViewModel(MemoDetail memoDetail = null) => MemoDetail = memoDetail ?? new MemoDetail();


        public MemoDetail MemoDetail { get;  }


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
