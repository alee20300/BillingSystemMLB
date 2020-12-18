using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Infrastructure.Services;
using ViewModels.Models;
using ViewModels.Services;
using ViewModels.ViewModels.Common;

namespace ViewModels.ViewModels.Patient
{
    public class PatientDetailsArgs
    {
        static public PatientDetailsArgs CreateDefault() => new PatientDetailsArgs();

        public int PatientID { get; set; }

        public bool IsNew => PatientID <= 0;
    }

    public  class PatientDetailsViewModel : GenericDetailsViewModel<PatientModel>

    {
        

        public PatientDetailsViewModel(IPatientService patientService, ICommonServices commonServices ) :base (commonServices)
        {
            PatientService = patientService;
        }

        public IPatientService PatientService { get; }

        

        public override bool ItemIsNew => throw new NotImplementedException();

        protected override Task<bool> ConfirmDeleteAsync()
        {
            throw new NotImplementedException();
        }

        protected override Task<bool> DeleteItemAsync(PatientModel model)
        {
            throw new NotImplementedException();
        }

        protected override Task<bool> SaveItemAsync(PatientModel model)
        {
            throw new NotImplementedException();
        }
    }
}
