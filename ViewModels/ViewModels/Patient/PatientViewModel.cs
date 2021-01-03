﻿using ViewModels.Infrastructure.Services;
using ViewModels.Infrastructure.ViewModels;

namespace ViewModels.ViewModels.Patient
{
    public class PatientViewModel : ViewModelBase

    {

        public PatientViewModel(ICommonServices commonServices) : base(commonServices)
        {

        }
    }
}
