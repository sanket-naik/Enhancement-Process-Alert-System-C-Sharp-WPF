using System;
using System.Windows.Input;

namespace EPAS.Helpers.DelegateCommand
{
    /// <summary>
    /// Creating a command
    /// </summary>
    class DelegateCommand: ICommand
    {
        #region Attributes
        Action<object> _execute;
        Func<bool> _canexecute;
        #endregion

        #region Constructor
        public DelegateCommand(Action<object> _execute, Func<bool> _canexecute)
        {
            this._execute = _execute;
            this._canexecute = _canexecute;
        }
        
        #endregion

        #region Events
        public bool CanExecute(object parameter)
        {
            if (_canexecute != null)
                return _canexecute();
            return true;
        }


        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        #endregion

    }
}
