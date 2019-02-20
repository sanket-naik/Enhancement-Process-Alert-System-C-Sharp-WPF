using System.ComponentModel;

namespace EPAS.ViewModel.ViewModelBase
{
    /// <summary>
    /// INotifyPropertyChanged to notify on property change
    /// </summary>
    public class BaseViewModel:INotifyPropertyChanged
    {

        #region NotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
