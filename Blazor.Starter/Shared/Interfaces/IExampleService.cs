using Blazor.Starter.Server.Models;

namespace Blazor.Starter.Shared.Interfaces
{
    public interface IExampleService
    {
        Task<PersonDto?> GetPersonById(Guid Id);
        Task<List<PersonDto>> GetAllPeople();
        Task CreatePerson(PersonDto person);
    }
}
