using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace UwpApp.ViewModel.Converters
{
    public class WIndowsStateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                return Visibility.Visible;
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
