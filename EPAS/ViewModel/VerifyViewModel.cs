using EPAS.Helpers.DelegateCommand;
using EPAS.Models;
using EPAS.Services;
using EPAS.ViewModel.ViewModelBase;
using System.Collections.Generic;
using System.Windows.Input;

namespace EPAS.ViewModel
{
    /// <summary>
    /// Handling Verify Page Command
    /// </summary>
    public class VerifyViewModel
    {
        List<Jobs> Datalist = new List<Jobs>();

        public VerifyViewModel(List<Jobs> list)
        {
            this.Datalist = list;
        }
        /// <summary>
        /// Verify submit
        /// </summary>
        public ICommand SubmitCommand
        {
            get
            {
                return new DelegateCommand(param => Execute(), CanExecute);
            }
        }
        /// <summary>
        /// Can executable
        /// </summary>
        /// <returns></returns>
        private bool CanExecute()
        {
            return true;
        }
        /// <summary>
        /// Cmmand method
        /// </summary>
        public void Execute()
        {
            OutlookEventModel oe = new OutlookEventModel(Datalist);
            oe.Event();
        }
    }
}
