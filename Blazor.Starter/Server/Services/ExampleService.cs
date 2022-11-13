using AutoMapper;
using Blazor.Starter.Server.Interfaces;
using Blazor.Starter.Server.Models;
using Blazor.Starter.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blazor.Starter.Server.Services
{
    public class ExampleService : IExampleService
    {
        public IExampleDbContext _db;
        public IMapper _mapper;
        public ExampleService(IExampleDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task CreatePerson(PersonDto person)
        {
           if(person is null)
                throw new ArgumentNullException(nameof(person));

            _db.People.Add(new Person
            {
                PersonId = person.PersonId ?? Guid.NewGuid(), // Dto responsible for guid, if null then handle
                Age = person.Age,
                DateOfBirth = person.DateOfBirth,
                FirstName = person.FirstName,
                LastName = person.LastName,
                MiddleName = person.MiddleName,
                HasDriversLicense = person.HasDriversLicense,
            });

            await _db.SaveChangesAsync();
        }

        public async Task<List<PersonDto>> GetAllPeople()
        {
            var people = await _db.People.ToListAsync();
            return _mapper.Map<List<PersonDto>>(people);
        }

        public async Task<PersonDto?> GetPersonById(Guid Id)
        {
            var person = await _db.People.Where(p => p.PersonId== Id).FirstOrDefaultAsync();
            return _mapper.Map<PersonDto>(person);
        }
    }
}
