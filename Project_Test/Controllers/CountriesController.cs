using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project_Test.Models;
using Project_Test.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService _countriesService;
        public CountriesController(ICountryService countriesService)
        {
            _countriesService = countriesService;
        }

        // GET: api/<CountriesController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _countriesService.GetAllAsync().ConfigureAwait(false));
        }
        [HttpGet("{id:length(24)}")]
        public async Task<IActionResult> Get(string id)
        {
            var countries = await _countriesService.GetByIdAsync(id).ConfigureAwait(false);
            if (countries == null)
            {
                return NotFound();
            }
            return Ok(countries);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Country countries)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _countriesService.CreateAsync(countries).ConfigureAwait(false);
            return Ok(countries.Id);
        }
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Country countries)
        {
            var data = await _countriesService.GetByIdAsync(id).ConfigureAwait(false);
            if (data == null)
            {
                return NotFound();
            }
            await _countriesService.UpdateAsync(id, data).ConfigureAwait(false);
            return NoContent();
        }
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var customer = await _countriesService.GetByIdAsync(id).ConfigureAwait(false);
            if (customer == null)
            {
                return NotFound();
            }
            await _countriesService.DeleteAsync(customer.Id).ConfigureAwait(false);
            return NoContent();
        }
    }
}
