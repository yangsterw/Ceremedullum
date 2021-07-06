using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;
using Ceremedullum.Exe.Models;
using Ceremedullum.Exe.Models.PatientModels;
using Ceremedullum.Exe.Services;
using Microsoft.Toolkit.Uwp.UI.Controls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Ceremedullum.Exe.Views.PatientInfoView
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PatientInfoPage : Page
    {
        private string _ptId;

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            _ptId = e.Parameter.ToString();

            var api = new ApiServices();
            var patientData = await api.RequestPatientData(_ptId);

            PatientId.Text = patientData.PatientId.ToString();
            Sex.Text = patientData.Sex.ToString();
            BirthYear.Text = patientData.BirthYear.ToString();

            var visits = new ObservableCollection<VisitInfo>()
            {
                new VisitInfo()
                {
                    VisitId = 1,
                    PatientId = 5,
                    VisitDate = new DateTime(2017,1,18),
                    VisitDescription ="This is a test",
                    VisitTime = new DateTime(2017, 1,18, 4,5,6)
                },
                new VisitInfo()
                {
                    VisitId = 2,
                    PatientId = 5,
                    VisitDate = new DateTime(2017,1,18),
                    VisitDescription ="This is a another test",
                    VisitTime = new DateTime(2017, 1,18, 4,5,6)
                },
                new VisitInfo()
                {
                    VisitId = 3,
                    PatientId = 5,
                    VisitDate = new DateTime(2017,1,18),
                    VisitDescription ="This is a further test",
                    VisitTime = new DateTime(2017, 1,18, 4,5,6)
                },
            };

            PtHistGrid.ItemsSource = visits;


            // parameters.Name
            // parameters.Text
            // ...
        }

        private async void SendFileBtn_Click(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");

            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                Upload_FileAsync("http://127.0.0.1:5000/upload", file);
                // Application now has read/write access to the picked file
            }
            else
            {
                var messageDialog = new MessageDialog("No File");
                await messageDialog.ShowAsync();
            }
        }

        public async void Upload_FileAsync(string webServiceUrl, StorageFile file)
        {
            IRandomAccessStream stream = await
                file.OpenAsync(FileAccessMode.Read);
            HttpStreamContent streamfile = new HttpStreamContent(stream);
            HttpMultipartFormDataContent httpContents = new
                HttpMultipartFormDataContent();

            if (httpContents.Headers.ContentType != null)
                httpContents.Headers.ContentType.MediaType = "multipart/form-data";
            httpContents.Add(streamfile, "file", Path.GetFileName(file.Path));

            var client = new HttpClient();
            HttpResponseMessage result = await client.PostAsync(
                new Uri(webServiceUrl), httpContents);
            string stringReadResult = await result.Content.ReadAsStringAsync();
            var convertedFloat = 0.0;
            string isDigit = string.Empty;
            for (var i = 0; i < stringReadResult.Length; i++)
            {
                if (Char.IsDigit(stringReadResult[i]) || stringReadResult[i] == '.')
                    isDigit += stringReadResult[i];
            }

            if (isDigit.Length > 0)
                convertedFloat = double.Parse(isDigit);

            var floatRounded = Round2(convertedFloat, 2);
            floatRounded = floatRounded * 100;
            var returnResponse = $"Normal x-ray probability is: {floatRounded}%";
            var messageDialog = new MessageDialog(returnResponse);
            await messageDialog.ShowAsync();
        }

        public static double Round2(double number, int scale)
        {
            int pow = 10;
            for (int i = 1; i < scale; i++)
                pow *= 10;
            double tmp = number * pow;
            return ((double)((int)((tmp - (int)tmp) >= 0.5f ? tmp + 1 : tmp))) / pow;
        }

        public PatientInfoPage()
        {
            this.InitializeComponent();

            var test = _ptId;

            
        }

        private void ResultsGrid_Sorting(object sender, Microsoft.Toolkit.Uwp.UI.Controls.DataGridColumnEventArgs e)
        {

        }

        private async void PtHistGrid_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            var obj = (VisitInfo)PtHistGrid.SelectedItems[0];

            ContentDialog invalidPassword = new ContentDialog()
            {
                Title = obj.VisitId,
                Content = obj.VisitDescription,
                CloseButtonText = "Ok"
            };

            await invalidPassword.ShowAsync();
        }
    }
}
