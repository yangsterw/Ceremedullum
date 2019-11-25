using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
        Frame rootFrame = Window.Current.Content as Frame;

        public LoginPage()
        {
            this.InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            var api = new ApiServices();
            var token = api.RequestToken(LoginInputBox.Text, PasswordInputBox.Password);
            if (token != null)
            {
                rootFrame.Navigate(typeof(MainPage));
            }
        }
    }
}
