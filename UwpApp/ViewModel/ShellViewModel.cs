using Domin.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace UwpApp.ViewModel
{
    public class ShellViewModel : BindableBase

    {

        public PatientViewModel patientViewModel { get; set; }
        public ShellViewModel()
        {


        }

        public ObservableCollection<Memo> SelectedPatientMemos { get; set; }

       
        public ObservableCollection<Patient> PatientSuggestion { get; } = new ObservableCollection<Patient>();



        public async Task updatepstientSuggestion(string idcard)
        {
            PatientSuggestion.Clear();

            if (!string.IsNullOrEmpty(idcard))
            {
                var resultlist = await App.Repository.Patient.getpatientforsearch(idcard);


                foreach (var result in resultlist)
                {
                    PatientSuggestion.Add(result);
                }



            }


        }


        private Patient _patient;

        public Patient Patient
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
