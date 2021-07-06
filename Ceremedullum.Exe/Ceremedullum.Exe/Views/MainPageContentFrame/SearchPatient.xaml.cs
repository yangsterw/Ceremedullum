using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Ceremedullum.Exe.Views.MainPageContentFrame
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SearchPatient : Page
    {
        public SearchPatient()
        {
            this.InitializeComponent();
        }

        private async void SearchPatientData_Btn(object sender, RoutedEventArgs e)
        {
            var currentAv = ApplicationView.GetForCurrentView();
            var newAv = CoreApplication.CreateNewView();
            var data = PatientIdInput.Text;
            await newAv.Dispatcher.RunAsync(
                CoreDispatcherPriority.Normal,
                async () =>
                {
                    var newWindow = Window.Current;
                    var newAppView = ApplicationView.GetForCurrentView();
                    newAppView.Title = "Patient Data";

                    var frame = new Frame();
                    frame.Navigate(typeof(PatientInfoView.PatientInfoPage), data);
                    newWindow.Content = frame;
                    newWindow.Activate();

                    await ApplicationViewSwitcher.TryShowAsStandaloneAsync(
                        newAppView.Id,
                        ViewSizePreference.UseMinimum,
                        currentAv.Id,
                        ViewSizePreference.UseMinimum);
                });
        }

        private async Task<string> getPatientRecord()
        {
            return PatientIdInput.Text;
        }
    }
}
