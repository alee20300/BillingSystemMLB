using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Markup;

namespace UwpApp.ViewModel.Converters
{
   public abstract class BaseValueConveter<T>: MarkupExtension, IValueConverter
        where T: class,new()
    {

        private static T mConveter = null;

        protected override object ProvideValue()
        {
            return mConveter ?? (mConveter = new T());
        }
        public abstract object Convert(object value, Type targetType, object parameter, string language);


        public abstract object ConvertBack(object value, Type targetType, object parameter, string language);
        
    }
}
