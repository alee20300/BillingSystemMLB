using Domin.Models;

namespace UwpApp.ViewModel.SettingsViewModelfolder
{
    public class DoctorViewModel : BindableBase
    {
        public DoctorViewModel(Doctor doctor = null)
        {
            Doctor = doctor ?? new Doctor();
        }



        private Doctor _doctor;

        public Doctor Doctor
        {
            get => _doctor;
            set
            {
                if (_doctor != value)
                {
                    _doctor = value;
                    OnPropertyChanged(string.Empty);

                }

            }
        }

        public int Id

        {
            get => Doctor.DoctorId;

            set
            {
                if (value != Doctor.DoctorId)
                {
                    Doctor.DoctorId = value;
                    OnPropertyChanged();
                }
            }
        }


        public string DoctorName

        {
            get => Doctor.DoctorName;

            set
            {
                if (value != Doctor.DoctorName)
                {
                    Doctor.DoctorName = value;
                    OnPropertyChanged();
                }
            }
        }

    }
}
