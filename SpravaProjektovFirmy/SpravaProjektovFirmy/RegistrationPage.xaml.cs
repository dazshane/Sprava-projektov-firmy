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

namespace SpravaProjektovFirmy
{
    /// <summary>
    /// Interaction logic for RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : UserControl
    {
        Users usersObj;
        public RegistrationPage(Users usersArg)
        {
            InitializeComponent();

            usersObj = usersArg;
        }
        private void CreateRegistrationClick(object sender, RoutedEventArgs e)
        {
            int newId = Int32.Parse(usersObj.users[usersObj.users.Count - 1].Id.Remove(0, 1)) + 1;

            User newUser = new()
            {
                Id = "u" + newId,
                Username = NewUsernameInput.Text.ToString(),
                Password = NewPasswordInput.Text.ToString()
            };
            usersObj.users.Add(newUser);

            //Content = new LoginPage(usersObj);
            Content = new LoginPage();
        }

        private void CancelRegistrationClick(object sender, RoutedEventArgs e)
        {
            //Content = new LoginPage(usersObj);
            Content = new LoginPage();
        }
    }
}