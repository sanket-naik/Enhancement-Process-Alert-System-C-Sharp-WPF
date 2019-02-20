using System.Windows;
using System.Windows.Controls;

namespace EPAS.Helpers
{
    class PasswordHelper
    {
        #region Password

        public static string GetPassword(DependencyObject obj)
        {
            return (string)obj.GetValue(PasswordProperty);
        }

        public static void SetPassword(DependencyObject dp, string value)
        {
            dp.SetValue(PasswordProperty, value);
        }

        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.RegisterAttached("Password", typeof(string), typeof(PasswordHelper), new FrameworkPropertyMetadata(string.Empty, OnPasswordPropertyChanged));

        private static void OnPasswordPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox password = (PasswordBox)sender;
            password.PasswordChanged -= PassWordChanged;

            if (!GetIsUpdating(password))
            {
                password.Password = (string)e.NewValue;
            }

            password.PasswordChanged += PassWordChanged;
        }

        private static void PassWordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            SetIsUpdating(passwordBox, true);
            SetPassword(passwordBox, passwordBox.Password);
            SetIsUpdating(passwordBox, false);

        }

        #endregion

        #region boolean Attach

        public static bool GetAttach(DependencyObject obj)
        {
            return (bool)obj.GetValue(AttachProperty);
        }

        public static void SetAttach(DependencyObject obj, bool value)
        {
            obj.SetValue(AttachProperty, value);
        }

        public static readonly DependencyProperty AttachProperty =
            DependencyProperty.RegisterAttached("Attach", typeof(bool), typeof(PasswordHelper), new PropertyMetadata(false, Attach));

        private static void Attach(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;

            if (passwordBox == null)
            {
                return;
            }
            if ((bool)e.OldValue)
            {
                passwordBox.PasswordChanged -= PassWordChanged;

            }

            if ((bool)e.NewValue)
            {
                passwordBox.PasswordChanged += PassWordChanged;
            }

        }

        #endregion

        #region Isupdating



        public static bool GetIsUpdating(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsUpdatingProperty);
        }

        public static void SetIsUpdating(DependencyObject obj, bool value)
        {
            obj.SetValue(IsUpdatingProperty, value);
        }

        public static readonly DependencyProperty IsUpdatingProperty =
            DependencyProperty.RegisterAttached("IsUpdating", typeof(bool), typeof(PasswordHelper));
        
        #endregion

    }
}
