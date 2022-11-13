using Blazor.Starter.Server.Models;
using Blazor.Starter.Shared.Interfaces;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace Blazor.Starter.Client.Services.HttpClients
{
    public class ExampleServiceHttpClient : IExampleService
    {
        private readonly HttpClient httpClient;
        private readonly ILogger<ExampleServiceHttpClient> _logger;

        public ExampleServiceHttpClient(HttpClient client, ILogger<ExampleServiceHttpClient> logger)
        {
            httpClient = client;
            _logger = logger;
        }


        public async Task CreatePerson(PersonDto person)
        {          
            _logger.LogDebug($"[Person Service] Creating Person {person.PersonId}...");

            var personJson = JsonSerializer.Serialize(person);
            var contentToPost = new StringContent(personJson, Encoding.UTF8, "application/json");

            var result = await httpClient.PostAsync($"api/Example/CreatePerson", contentToPost, CancellationToken.None);

            _logger.LogDebug($"[Person Service] Person {person.PersonId} Created!");
            _logger.LogDebug($"{result.StatusCode}");
        }

        public async Task<List<PersonDto>> GetAllPeople()
        {
            _logger.LogDebug("[Person Service] Getting all customers...");

            var result = await httpClient.GetFromJsonAsync<List<PersonDto>>("api/Example/GetAll", CancellationToken.None);

            _logger.LogDebug("[Person Service] Getting all customers SUCCESSFUL");

            return result;
        }

        public async Task<PersonDto?> GetPersonById(Guid Id)
        {
            _logger.LogDebug($"[Customer Service] Getting customer {Id}...");

            var result = await httpClient.GetFromJsonAsync<PersonDto>($"api/Example/GetCustomerById?Id={Id}", CancellationToken.None);

            _logger.LogDebug($"[Customer Service] Customer {Id} found!");

            return result;
        }
    }
}
