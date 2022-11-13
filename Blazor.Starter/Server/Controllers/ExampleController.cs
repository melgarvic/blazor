using Blazor.Starter.Server.Models;
using Blazor.Starter.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.Starter.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExampleController : ControllerBase
    {
        private readonly IExampleService _exampleService;

        public ExampleController(IExampleService exampleService)
        {
            _exampleService = exampleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPersonById(Guid? Id)
        {
            if (Id is null || Id == Guid.Empty)
                return BadRequest();

            var person = await _exampleService.GetPersonById(Id.Value);

            if (person is null)
                return NotFound();

            return Ok(person);
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllPeople()
        {
            var all = await _exampleService.GetAllPeople();
            return Ok(all);

        }

        [HttpPost]
        public async Task<IActionResult> CreatePerson(PersonDto person)
        {
            try
            {
                await _exampleService.CreatePerson(person);
                return CreatedAtAction(nameof(CreatePerson), person);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
