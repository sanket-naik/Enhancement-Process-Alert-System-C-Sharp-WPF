using EPAS.Helpers.DelegateCommand;
using EPAS.Services;
using EPAS.ViewModel.ViewModelBase;
using System.Threading;
using System.Windows.Input;

namespace EPAS.ViewModel
{
    public class DocumentReadViewModel:BaseViewModel
    {
        Utilities _utility;
        EnhancementModel _enh;
        AssigneeModel _asn;
        FindMatch _find;
        public bool AsnResponse;
        public bool EnhResponse;

        /// <summary>
        /// Utilities for cleanup
        /// </summary>
        public DocumentReadViewModel()
        {
            _utility = new Utilities();
        }

        /// <summary>
        /// Path for enhancement
        /// </summary>
        private string enhancementpath;
        public string EnhancementPath
        {
            get { return enhancementpath; }
            set
            {
                if (enhancementpath != value)
                {
                    enhancementpath = value;
                    NotifyPropertyChanged(nameof(enhancementpath));
                }
            }
        }
        /// <summary>
        /// Path for assignee
        /// </summary>
        private string assigneepath;
        public string AssigneePath
        {
            get { return assigneepath; }
            set
            {
                if (assigneepath != value)
                {
                    assigneepath = value;
                    NotifyPropertyChanged(nameof(assigneepath));
                }
            }
        }
        /// <summary>
        /// Handles validation
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
        /// <summary>
        /// Loader visiblity
        /// </summary>
        private string loadervisiblity="Hidden";

        public string LoaderVisiblity
        {
            get { return loadervisiblity; }
            set
            {
                if (loadervisiblity != value)
                {
                    loadervisiblity = value;
                    NotifyPropertyChanged(nameof(loadervisiblity));
                }
            }
        }
        /// <summary>
        /// Submit button enable/disable
        /// </summary>
        private string buttonenable = "True";

        public string ButtonEnable
        {
            get { return buttonenable; }
            set
            {
                if (buttonenable != value)
                {
                    buttonenable = value;
                    NotifyPropertyChanged(nameof(buttonenable));
                }
            }
        }
        
        /// <summary>
        /// On browse doc click
        /// </summary>
        public ICommand EnhancementCommand
        {
            get
            {
                return new DelegateCommand(param => SelectEnhancement(), null);
            }
        }

        private void SelectEnhancement()
        {
            EnhancementPath = _utility.FileDiloge();
        }

        /// <summary>
        /// On browse doc click
        /// </summary>
        public ICommand AssigneeCommand
        {
            get
            {
                return new DelegateCommand(param => SelectAssignee(), null);
            }
        }

        private void SelectAssignee()
        {
            AssigneePath = _utility.FileDiloge();
        }

        /// <summary>
        /// Submit command
        /// </summary>
        public ICommand SubmitCommand
        {
            get
            {
                return new DelegateCommand(param => Execute(),CanExecute);
            }
        }

        private bool CanExecute()
        {
            if (this.EnhancementPath != null && this.EnhancementPath.Length > 0 && this.AssigneePath != null && this.AssigneePath.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        private void Execute()
        {
            LoaderVisiblity = "Visible";
            ButtonEnable = "False";
            StartTask();
        }
        /// <summary>
        /// New thread created
        /// </summary>
        private  void StartTask()
        {
            // create a thread  
            Thread newWindowThread = new Thread(new ThreadStart(() =>
            {
                ThreadProc(); 
                System.Windows.Threading.Dispatcher.Run();
            }));
            
            newWindowThread.SetApartmentState(ApartmentState.STA);
            newWindowThread.IsBackground = true;
            newWindowThread.Start();
        }
        /// <summary>
        /// Process in thread
        /// </summary>
        public void ThreadProc()
        {
            Validation = string.Empty;

            _asn = new AssigneeModel();
            AsnResponse = _asn.Read(AssigneePath);

            _enh = new EnhancementModel();
            EnhResponse = _enh.Read(EnhancementPath);

            if (EnhResponse == true && AsnResponse == true)
            {
                _find = new FindMatch(_asn, _enh);
                _find.Get();
                LoaderVisiblity = "Hidden";
                ButtonEnable = "True";
            }
            else if (AsnResponse == false)
            {
                Validation = "Invalid Assignee Document Format";
                LoaderVisiblity = "Hidden";
                ButtonEnable = "True";
            }
            else if (EnhResponse == false)
            {
                Validation = "Invalid Enhancement Document Format";
                LoaderVisiblity = "Hidden";
                ButtonEnable = "True";
            }
        }
    }
}
