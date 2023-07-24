using Sky.Domain;
using Sky.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sky.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public CountryController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: api/<CountryController>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var country = await unitOfWork.CountryRepository.GetAllAsync();
            return Ok(country.Where(w => !w.IsRemoved));
        }

        // GET api/<CountryController>/5
        [HttpGet]
        [Route("{id:long}")]
        public async Task<IActionResult> GetAsync([FromRoute] long id)
        {
            var country = await unitOfWork.CountryRepository.GetAsync(w => w.Id == id & !w.IsRemoved);
            if (country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }

        // POST api/<CountryController>
        [HttpPost]
        public async Task<IActionResult> AddCountry([FromBody] Country country)
        { 
            country.CreateDate = DateTime.Now;
            await unitOfWork.CountryRepository.AddAsync(country);
            await unitOfWork.SaveChangesAsync();

            return Ok(country);
        }

        // PUT api/<CountryController>
        [HttpPut]
        public async Task<IActionResult> UpdateCountry([FromBody] Country updateCountry)
        {
            Country? country = await unitOfWork.CountryRepository.GetByIdAsync(updateCountry.Id);
            if (country == null)
            {
                return NotFound(updateCountry.Id);
            }

            country.UpdateDate = DateTime.Now;
            country.CountryName = updateCountry.CountryName;
            country.CreateBy = updateCountry.CreateBy;
            country.UpdatedBy = updateCountry.UpdatedBy;
            country.Note = updateCountry.Note;

            await unitOfWork.CountryRepository.UpdateAsync(country);
            await unitOfWork.SaveChangesAsync();

            return Ok(country);
        }

        // DELETE api/<CountryController>/5
        [HttpDelete]
        [Route("{id:long}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            Country? country = await unitOfWork.CountryRepository.GetByIdAsync(id);
            if (country == null)
            {
                return NotFound(id);
            }
            country.IsRemoved = true;
            await unitOfWork.CountryRepository.UpdateAsync(country);
            await unitOfWork.SaveChangesAsync();


            return Ok(country);
        }
    }
}
