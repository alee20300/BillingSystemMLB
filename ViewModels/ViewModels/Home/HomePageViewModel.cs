using Domin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Infrastructure.Services;
using ViewModels.Infrastructure.ViewModels;
using ViewModels.Models;
using ViewModels.Services;
using ViewModels.ViewModels.Patient;

namespace ViewModels.ViewModels.Home
{
    public class HomePageViewModel : ViewModelBase
    {
        public HomePageViewModel(IPatientService patientService,  ICommonServices commonServices) : base(commonServices)
        {
            PatientService = patientService;
        }


        public IPatientService PatientService { get;  }

        public PatientViewModel patientViewModel { get; set; }
       

        public ObservableCollection<Memo> SelectedPatientMemos { get; set; }

        //public List<Patient> MasterPatientList { get; } = new List<Patient>();
        public ObservableCollection<PatientModel> PatientSuggestion { get; } = new ObservableCollection<PatientModel>();



        public async Task updatepstientSuggestion(string idcard)
        {
            PatientSuggestion.Clear();

            if (!string.IsNullOrEmpty(idcard))
            {
                var resultlist = await PatientService.getpatientforsearch(idcard);
                   


                foreach (var result in resultlist)
                {
                    PatientSuggestion.Add(result);
                }



            }


        }


        private PatientModel _patient;

        public PatientModel Patient
        {
            get => _patient;
            set => Set(ref _patient, value);
        }





        //public ObservableCollection<PatientViewModel> Patients { get; } = new ObservableCollection<PatientViewModel>();

        private PatientViewModel _selectedPatient;

        public PatientViewModel SelectedPatient
        {
            get => _selectedPatient;
            set => Set(ref _selectedPatient, value);
        }




    }
}
