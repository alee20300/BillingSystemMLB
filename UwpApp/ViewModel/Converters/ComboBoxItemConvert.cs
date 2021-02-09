using Domin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UwpApp.ViewModel.SampleRegisterViewModel;
using UwpApp.Views.SampleRegister;
using Windows.UI.Xaml.Data;

namespace UwpApp.ViewModel.Converters
{
    public class ComboBoxItemConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            //throw new NotImplementedException();

            return value as Account;
        }
    }
}
