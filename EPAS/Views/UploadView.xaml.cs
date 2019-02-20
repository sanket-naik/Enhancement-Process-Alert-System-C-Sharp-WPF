using DynamicLocalization;
using EPAS.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EPAS.Views
{
    /// <summary>
    /// Interaction logic for UploadPagee.xaml
    /// </summary>
    public partial class UploadView : Window
    {
        public UploadView()
        {
            InitializeComponent();
            LocUtil.SetDefaultLanguage(this);
            this.DataContext = new DocumentReadViewModel();

            foreach (MenuItem item in menuItemLanguages.Items)
            {
                if (item.Tag.ToString().Equals(LocUtil.GetCurrentCultureName(this)))
                    item.IsChecked = true;
            }
        }

        private void Info_Page(object sender, MouseButtonEventArgs e)
        {
            new AboutWindow().ShowDialog();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            foreach (MenuItem item in menuItemLanguages.Items)
            {
                item.IsChecked = false;
            }

            MenuItem mi = sender as MenuItem;
            mi.IsChecked = true;
            LocUtil.SwitchLanguage(this, mi.Tag.ToString());
        }
    }
}
