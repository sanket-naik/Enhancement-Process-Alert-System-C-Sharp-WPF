using EPAS.Models;
using EPAS.ViewModel;
using System.Collections.Generic;
using System.Windows;

namespace EPAS.Views
{
    /// <summary>
    /// Interaction logic for VerifyView.xaml
    /// </summary>
    public partial class VerifyView : Window
    {
        List<Jobs> Datalist = new List<Jobs>();

        public VerifyView(List<Jobs> list)
        {
            this.Datalist = list;
            InitializeComponent();
            DataContext = new VerifyViewModel(Datalist);
        }
    }
}
