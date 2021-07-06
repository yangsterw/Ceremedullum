using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.Web.Http;
using Ceremedullum.Exe.Models;
using System.Text.Json;
using Ceremedullum.Exe.Models.PatientModels;

namespace Ceremedullum.Exe.Services
{
    public class ApiServices : IApiServices
    {
        private readonly string _apiUri = "http://localhost:22860";

        public async Task<UserAccount> RequestToken(string username, string password)
        {
            // TODO: Abstract this to a interface later
            var user = new UserAccount();

            try
            {
                // Construct the HttpClient and Uri. This endpoint is for test purposes only.
                HttpClient httpClient = new HttpClient();
                Uri uri = new Uri(_apiUri + "/users/authenticate");

                // Construct the JSON to post.
                HttpStringContent content = new HttpStringContent(
                    $"{{ \"username\": \"{username}\", \"password\": \"{password}\" }}",
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
                
                user = jsonUser;

                return user;
            }

            catch (Exception ex)
            {
                // Write out any exceptions.
                Debug.WriteLine(ex);
            }
            
            return user;
            
        }

        public async Task<PatientInfo> RequestPatientData(string ptId)
        {
            // TODO: Abstract this to a interface later
            var patient = new PatientInfo();

            try
            {
                // Construct the HttpClient and Uri. This endpoint is for test purposes only.
                HttpClient httpClient = new HttpClient();
                Uri uri = new Uri(_apiUri + "/patientapi/Patient/" + ptId);

                // Post the JSON and wait for a response.
                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(
                    uri);

                // Make sure the posXt succeeded, and write out the response.
                httpResponseMessage.EnsureSuccessStatusCode();
                var httpResponseBody = await httpResponseMessage.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };


                //var jsonUser = JsonSerializer.Deserialize<PatientInfo>(httpResponseBody, options);

                String[] ss = httpResponseBody.Split(",");
                patient.PatientId = Int32.Parse(ss[0]);
                patient.Sex = Char.Parse(ss[1]);
                patient.BirthYear = Int32.Parse(ss[2]);

                return patient;
            }

            catch (Exception ex)
            {
                // Write out any exceptions.
                Debug.WriteLine(ex);
            }

            return patient;

        }
    }
}
