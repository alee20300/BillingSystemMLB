using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UwpApp.ViewModel.SampleRegisterViewModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UwpApp.Views.SampleRegister
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MakeBulkMemo : Page
    {
       
        public MakeBulkMemo()
        {
            this.InitializeComponent();
        }

        public BulkSampleMemoViewModel bulkMemoViewModel { get; set; }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ObservableCollection<Domin.Data.SampleRegister > id = (ObservableCollection<Domin.Data.SampleRegister>)e.Parameter;


            if (id != null)
            {
                // Order is a new order
                bulkMemoViewModel = new BulkSampleMemoViewModel(id);
               
            }
            //else
            //{
            //    // Order is an existing order.
            //    var memo = await App.Repository.Memo.GetMemoAsync(id);
            //    ViewModel = new MemoViewModel(memo);
            //}

            base.OnNavigatedTo(e);
        }
    }
}
