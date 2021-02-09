using Domin.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UwpApp.ViewModel;

namespace UwpApp.Validation
{
   public class PatientValidation :AbstractValidator<PatientViewModel>
    {
        public PatientValidation()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Full name cannot be empty");

        }

      
             
    }
}
