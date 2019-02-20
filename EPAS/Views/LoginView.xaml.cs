using DynamicLocalization;
using EPAS.ViewModel.LoginViewModel;
using System.Windows;
using System.Windows.Controls;

namespace EPAS.Views
{
    /// <summary>
    /// Assigned to LoginViewModel
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
            this.DataContext = new LoginViewModel();
            LocUtil.SetDefaultLanguage(this);

            // Adjust checked language menu item
            foreach (MenuItem item in menuItemLanguages.Items)
            {
                if (item.Tag.ToString().Equals(LocUtil.GetCurrentCultureName(this)))
                    item.IsChecked = true;
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            foreach (MenuItem item in menuItemLanguages.Items)
            {
                item.IsChecked = false;
            }

            MenuItem mi = sender as MenuItem;
            //MessageBox.Show("menu tag: " + mi.Tag.ToString());
            mi.IsChecked = true;
            LocUtil.SwitchLanguage(this, mi.Tag.ToString());
        }
    }

}
