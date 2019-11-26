using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.Web.Http;
using Ceremedullum.Exe.Models;
using System.Text.Json;

namespace Ceremedullum.Exe.Services
{
    public class ApiServices : IApiServices
    {
        private static Uri _requestUri = new Uri("http://localhost:22860/");

        public async Task RequestToken(string username, string password)
        {
            try
            {
                // Construct the HttpClient and Uri. This endpoint is for test purposes only.
                HttpClient httpClient = new HttpClient();
                Uri uri = new Uri("http://localhost:22860/users/authenticate");

                // Construct the JSON to post.
                HttpStringContent content = new HttpStringContent(
                    "{ \"username\": \"test\"," + "\"password\":\"test\" }",
                    UnicodeEncoding.Utf8,
                    "application/json");

                // Post the JSON and wait for a response.
                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(
                    uri,
                    content);

                // Make sure the post succeeded, and write out the response.
                httpResponseMessage.EnsureSuccessStatusCode();
                var httpResponseBody = await httpResponseMessage.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };

                var jsonUser = JsonSerializer.Deserialize<UserAccount>(httpResponseBody, options);

                Debug.WriteLine(httpResponseBody);
            }
            catch (Exception ex)
            {
                // Write out any exceptions.
                Debug.WriteLine(ex);
            }
        }

        public async Task RequestPatientInfo(string patientId)
        {
            try
            {
            }
            catch(Exception e)
            {

            }
        }
    }
}
