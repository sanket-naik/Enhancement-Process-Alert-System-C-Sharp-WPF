using EPAS.Helpers.DelegateCommand;
using EPAS.Models.LoginModel;
using EPAS.ViewModel.ViewModelBase;
using EPAS.Views;
using System.Windows;
using System.Windows.Input;

namespace EPAS.ViewModel.LoginViewModel
{
    /// <summary>
    /// View Model Login
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        #region Constructor
        private LoginModel _model;
      //  private UploadView _page;
        /// <summary>
        /// Object of LoginModel
        /// </summary>
        public LoginViewModel()
        {
            _model = new LoginModel();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Properties Used Here
        /// </summary>
        private string userName;

        public string Username
        {
            get
            {
                return userName;
            }
            set
            {
                if (userName != value)
                {
                    userName = value;
                    NotifyPropertyChanged(nameof(Username));

                }
            }
        }
        /// <summary>
        /// Password for login
        /// </summary>
        private string password;
        
        public string Password
        {
            private get
            {
                return password;
            }
            set
            {
                if (password != value)
                {
                    password = value;
                    NotifyPropertyChanged(Password);
                }
            }
        }
        /// <summary>
        /// Form validations
        /// </summary>
        private string validation;

        public string Validation
        {
            get { return validation; }
            set
            {
                if (validation != value)
                {
                    validation = value;
                    NotifyPropertyChanged(nameof(validation));
                }
            }
        }
        #endregion

        #region ICommand Call
        /// <summary>
        /// Login page submit
        /// </summary>
        public ICommand SubmitCommand
        {
            get
            {
                return new DelegateCommand(param =>Execute(), CanExecute);
            }
        }
        #endregion

        #region CanExecute
        public bool CanExecute()
        {
            if (this.Username != null && this.Username.Length > 0 && this.Password != null && this.Password.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        #endregion

        #region Execute
        /// <summary>
        /// Command method
        /// </summary>
        public void Execute()
        {
            Validation = string.Empty;

            //Check Internet Availability
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() == true)
            {

                bool approved = _model.Authenticate(this.Username, this.Password);
                if (approved==true)
                {
                    UploadView _view = new UploadView();
                    _view.ShowDialog();
                    var mainWindow = (Application.Current.MainWindow as LoginView);
                    if (mainWindow != null)
                    {
                        mainWindow.Close();
                    }
                }
                else
                {
                    Validation = "Invalid Username Password !!";
                }
                
            }
            else
            {
                Validation = "Check Your Internet Connection !!";            
            }
        }
        #endregion
       

    }
}
