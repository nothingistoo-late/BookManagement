using BookManagement.BLL.Service;
using BookManagement.DAL.Entities;
using Microsoft.IdentityModel.Tokens;
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
using System.Windows.Shapes;

namespace BookManagement_HoangNgocTrinh
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {

        private UserService _userService = new();
        public LoginWindow()
        {
            InitializeComponent();
        }


        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text;
            string password = PasswordTextBox.Text;
            UserAccount? user = _userService.GetUserByEmailAndPassword(email, password);
            if (email.IsNullOrEmpty() || password.IsNullOrEmpty())
            {
                MessageBox.Show("Both Email And Password Is Required", "Require Information", MessageBoxButton.OK, MessageBoxImage.Error);
                return;

            }

            if (user == null)
            {
                MessageBox.Show("Invalid Email Address or Wrong Password", "Wrong Identials", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (user.Role == 3 || user.Role == 2)
            {
                MessageBox.Show("You Dont Have Permission To This Function", "Wrong Permmission", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MainWindow d = new();
            d.Show();
            this.Hide();
        }
    }
}
