using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Media.Playback;

namespace UwpApp.ViewModel.Command
{
    
        public class RelayCommand : ICommand
        {

        Action<object> _executeMethod;
        Func<object, bool> _canexecuteMethod;


        public RelayCommand (Action <object > executeMethod,Func<object,bool> canExecuteMethod)
        {
            _executeMethod = executeMethod;
            _canexecuteMethod = canExecuteMethod;
        }
        public event EventHandler CanExecuteChanged
    ;

        public bool CanExecute(object parameter)
        {
            if (_canexecuteMethod != null)

            {
                return _canexecuteMethod(parameter);
            }
            else
            {
                return false;
            }
        }

            public void Execute(object parameter)
            {
                throw new NotImplementedException();
            }
        }
    
}
