using Domin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UwpApp.Views;
using Windows.UI.Xaml;

namespace UwpApp.ViewModel.Command
{
   public class SaveCommand :ICommand
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

        public void Execute(object parameter)
        {

            App.Repository.Patient.UpsertAsync(PatientViewModel.Patient);
            
           
        }
    }
}
