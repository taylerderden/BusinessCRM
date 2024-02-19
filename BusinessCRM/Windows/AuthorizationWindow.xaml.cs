using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BusinessCRM
{
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void textLogin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbLogin.Focus();
        }

        private void tbLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbLogin.Text) && tbLogin.Text.Length > 0)
            {
                textLogin.Visibility = Visibility.Collapsed;
            }
            else
            {
                textLogin.Visibility = Visibility.Visible;
            }
        }

        private void textPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tbPassword.Focus();
        }
        private void tbPassword_TextChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbPassword.Password) && tbPassword.Password.Length > 0)
            {
                textPassword.Visibility = Visibility.Collapsed;
            }
            else
            {
                textPassword.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbLogin.Text) && !string.IsNullOrEmpty(tbPassword.Password))
            {

            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton ==  MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
