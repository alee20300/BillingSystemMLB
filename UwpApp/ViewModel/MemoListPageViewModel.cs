using Domin.Models;
using Microsoft.Toolkit.Uwp.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace UwpApp.ViewModel
{
     public class MemoListPageViewModel : BindableBase
    {
        public MemoListPageViewModel()
        {
            IsLoading = false;
        }


        private List<Memo> MasterMemoList { get; } = new List<Memo>();


        public ObservableCollection<Memo> Memos { get; private set; } = new ObservableCollection<Memo>();

        private bool _isLoading;

        public bool IsLoading
        {
            get => _isLoading;
            set => Set(ref _isLoading, value);
        }

        private Memo _selectedMemo; 

        public Memo  SelectedMemo
        {
            get => _selectedMemo;
            set
            {
                if (Set(ref _selectedMemo,value))
                {
                    SelectedMemo = null;
                    if (_selectedMemo!=null)
                    {
                        Task.Run(() => LoadPatient(_selectedMemo.Patient.PatientNumber));
                    }
                    //OnPropertyChanged(nameof(SelectedMemoGrandTotalFormated));
                }
            }
        }

        //public string SelectedMemoGrandTotalFormated => (SelectedMemo?.GrandTotal ?? 0).toString("c");


        private Patient _selectedPatient;

        public Patient SelectedPatient
        {
            get => _selectedPatient;
            set => Set(ref _selectedPatient, value);
        }


        private async void LoadPatient(string PatientId)
        {
            var patient = await App.Repository.Patient.GetbyIdAsync(PatientId);
            await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
            {
                SelectedPatient = patient;
            });
        }

        public async void LoadOrders()
        {
            await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
            {
                IsLoading = true;
                Memos.Clear();
                MasterMemoList.Clear();

            });

            var memos = await Task.Run(App.Repository.Memo.GetAsync);

            await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
            {
                foreach (var memo in memos)
                {
                    Memos.Add(memo);
                    MasterMemoList.Add(memo);
                }

                IsLoading = false;
            });

        }





    }

}
