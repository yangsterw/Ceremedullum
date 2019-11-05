using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using Container = System.ComponentModel.Container;

namespace Ceremedullum.Api.Services
{
    public class DatabaseService
    {
        private static readonly string EndpointUri = "https://ceremedullumdb.documents.azure.com:443/";
        // The primary key for the Azure Cosmos account.
        private static readonly string PrimaryKey = "s0kJS1s2SgUfGSQ8vPB8loT3kmbmFkVPX1kqjbakKbuwdnUbKcyWR9grrnzsi6llnS9Ec3dWZwSr4a9WwyGFmA==";

        // The Cosmos client instance
        private CosmosClient cosmosClient;

        // The database we will create
        private Database database;

        // The container we will create.
        private Container container;

        // The name of the database and container we will create
        private string databaseId = "CeremedullumDatabase";
        private string containerId = "CeremedullumContainer";

        
    }
}
