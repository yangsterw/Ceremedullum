using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Ceremedullum.Exe.Models;
using Ceremedullum.Exe.Services;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Ceremedullum.Exe.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        readonly Frame _rootFrame = Window.Current.Content as Frame;

        public LoginPage()
        {
            this.InitializeComponent();
        }

        private async void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            var api = new ApiServices();
            var user = await api.RequestToken(LoginInputBox.Text, PasswordInputBox.Password);
            if (user.token != null)
            {
                _rootFrame.Navigate(typeof(MainPage));
            }
            else
            {
                ContentDialog invalidPassword = new ContentDialog()
                {
                    Title = "Incorrect Password",
                    Content = "Please try again, the password is incorrect.",
                    CloseButtonText = "Ok"
                };

                await invalidPassword.ShowAsync();
            }
        }
    }
}
