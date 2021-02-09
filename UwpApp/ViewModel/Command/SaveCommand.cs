using Domin.Models;
using System;
using System.Windows.Input;

namespace UwpApp.ViewModel.Command
{
    public class SaveCommand : ICommand
    {
        public PatientViewModel PatientViewModel { get; set; }
        public SaveCommand(PatientViewModel patientViewModel)

        {
            PatientViewModel = patientViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {

            Patient result = null;
            try
            {

                result = await App.Repository.Patient.UpsertAsync(PatientViewModel.Patient);

            }
            catch (Exception ex)
            {

                throw new MemoSavingException("Unable to Save Memo. There might have been a problem Connecting to Database. Please Try again later", ex);
            }




        }
    }
}
