using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Ceremedullum.Api.Models;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Newtonsoft.Json;

namespace Ceremedullum.Api.Services.CosmosDbService
{
    public class CosmosDbService
    {
        // This is localhost so not worried being shown
        private const string EndpointUrl = "https://localhost:8081";
        private const string PrimaryKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
        private const string PatientsDb = "PatientsDB";
        private const string PatientCollection = "PatientCollection";
        private const string UserCollection = "UserCollection";
        private const string UsersDb = "UserAccountDB";
        private readonly DocumentClient _client;

        public CosmosDbService()
        {
            this._client = new DocumentClient(new Uri(EndpointUrl), PrimaryKey);
        }

        public async Task SetupDatabase()
        {
            await this._client.CreateDatabaseIfNotExistsAsync(new Database { Id = UsersDb });
            await this._client.CreateDatabaseIfNotExistsAsync(new Database { Id = PatientsDb });


            // Create document if it does not exist
            await this._client.CreateDocumentCollectionIfNotExistsAsync(
                UriFactory.CreateDatabaseUri(PatientsDb), new DocumentCollection { Id = PatientCollection });
            await this._client.CreateDocumentCollectionIfNotExistsAsync(
                UriFactory.CreateDatabaseUri(UsersDb), new DocumentCollection { Id = UserCollection });

            var userAccount = new UserAccount()
            {
                Id = 1,
                FirstName = "Yang",
                LastName = "Wang",
                HashCode = "DDDDDDD",
                SaltCode = "EEEEEEE",
                DoctorId = 1,
                UserName = "yang@ceremedullum.com"
            };
            //await this.CreateUserDocumentIfNotExists(UsersDb, UserCollection, userAccount);

            var patient = new Patient()
            {
                PatientId = 1,
                Sex = 'm',
                BirthYear = 1990,
                PatientHistory = new List<PatientVisitInfo>()
                {
                    new PatientVisitInfo()
                    {
                        PatientId = 1,
                        VisitDate = new DateTime(2017, 10, 18),
                        VisitTime = new DateTime(2017, 10,18, 12, 1, 10),
                        VisitDescription = "This was a super cool visit. Turns out I haz no diseases. Cool...",
                        Diseases = new List<Diseases>()
                            { }
                    },
                    new PatientVisitInfo()
                    {
                        PatientId = 1,
                        VisitDate = new DateTime(2018, 10, 18),
                        VisitTime = new DateTime(2018, 10,18, 12, 1, 10),
                        VisitDescription = "Oh no i am getting sicker, undetermined diseases",
                        Diseases = new List<Diseases>()
                            { }
                    },
                    new PatientVisitInfo()
                    {
                        PatientId = 1,
                        VisitDate = new DateTime(2019, 10, 18),
                        VisitTime = new DateTime(2019, 10,18, 12, 1, 10),
                        VisitDescription = "After a year I am so very very sick... plz heal meeeee",
                        Diseases = new List<Diseases>()
                        {
                            new Diseases()
                            {
                                DiseaseId = 1,
                                DiseaseName = "Hep C",
                            }
                        }
                    },
                    new PatientVisitInfo()
                    {
                        PatientId = 1,
                        VisitDate = new DateTime(2019, 12, 18),
                        VisitTime = new DateTime(2019, 12,18, 12, 1, 10),
                        VisitDescription = "I am healed wohooo AI is kewllllll.... Cool..... No more diseases, NO MORE HEP C!!!",
                        Diseases = new List<Diseases>()
                            { }
                    },

                },
            };

            //await this.CreatePatientDocumentIfNotExists(PatientsDb, PatientCollection, patient);
        }

        private async Task CreateUserDocumentIfNotExists(string databaseName, string collectionName, UserAccount account)
        {
            try
            {
                await this._client.ReadDocumentAsync(UriFactory.CreateDocumentUri(databaseName, collectionName, account.Id.ToString()));
            }
            catch (DocumentClientException de)
            {
                if (de.StatusCode == HttpStatusCode.NotFound)
                {
                    await this._client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(databaseName, collectionName), account);
                }
                else
                {
                    throw;
                }
            }
        }

        private async Task CreatePatientDocumentIfNotExists(string databaseName, string collectionName, Patient patient)
        {
            try
            {
                await this._client.ReadDocumentAsync(UriFactory.CreateDocumentUri(databaseName, collectionName, patient.PatientId.ToString()));
            }
            catch (DocumentClientException de)
            {
                if (de.StatusCode == HttpStatusCode.NotFound)
                {
                    await this._client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(databaseName, collectionName), patient);
                }
                else
                {
                    throw;
                }
            }
        }

        public bool GetPatient(string ptid, Patient p)
        {
            return p.PatientId.ToString() == ptid;
        }

        public async Task<Patient> QueryReadPatientFile(string ptId)
        {
            FeedOptions queryOptions = new FeedOptions {MaxItemCount = 1};

            var query = this._client.CreateDocumentQuery<Patient>(
                    UriFactory.CreateDocumentCollectionUri(PatientsDb, PatientCollection), queryOptions).AsDocumentQuery();

            while (query.HasMoreResults)
            {
                var results = await query.ExecuteNextAsync();
                if (results.Any())
                {
                    return results.First(p => p.PatientId.ToString() == ptId);
                }
            }

            return null;
        }

        //public async Task<string> QueryReadPatientFile(string ptId)
        //{
        //    // Set some common query options
        //    FeedOptions queryOptions = new FeedOptions { MaxItemCount = -1 };

        //    using (var queryable = _client.CreateDocumentQuery<Patient>(
        //            collectionLink,
        //            new FeedOptions { MaxItemCount = 10 })
        //        .Where(b => b.Title == "War and Peace")
        //        .AsDocumentQuery())
        //    {
        //        while (queryable.HasMoreResults)
        //        {
        //            foreach (Book b in await queryable.ExecuteNextAsync<Book>())
        //            {
        //                // Iterate through books
        //            }
        //        }
        //    }

        //    IQueryable<Patient> patientQuery = this._client.CreateDocumentQuery<Patient>(
        //            UriFactory.CreateDocumentCollectionUri(PatientsDb, PatientCollection), queryOptions)
        //        .Where(f => f.PatientId.ToString() == ptId);

        //    var fullString = "";
        //    foreach (Patient patient in patientQuery)
        //    {
        //        fullString += patient;
        //    }
        //    return fullString;
        //}
    }
}
