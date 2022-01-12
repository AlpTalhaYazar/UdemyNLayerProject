using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyNLayerProject.Core.Models;
using UdemyNLayerProject.Core.Services;

namespace UdemyNLayerProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IService<Person> _personService;

        public PeopleController(IService<Person> service)
        {
            this._personService = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var people = await this._personService.GetAllAsync();
            return Ok(people);
        }
        [HttpPost]
        public async Task<IActionResult> Save(Person person)
        {
            var newPerson = await this._personService.AddAsync(person);
            return Ok(newPerson);
        }
    }
}
