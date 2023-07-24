using Sky.Domain;
using Sky.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sky.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public AddressController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: api/<AddressController>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var adress = await unitOfWork.AddressRepository.GetAllAsync();
            return Ok(adress.Where(w => !w.IsRemoved));
        }

        // GET api/<AddressController>/5
        [HttpGet]
        [Route("{id:long}")]
        public async Task<IActionResult> GetAsync([FromRoute] long id)
        {
            var adress = await unitOfWork.AddressRepository.GetAsync(w => w.Id == id & !w.IsRemoved);
            if (adress == null)
            {
                return NotFound();
            }

            return Ok(adress);
        }

        // POST api/<AddressController>
        [HttpPost]
        public async Task<IActionResult> AddAddress([FromBody] Address adress)
        { 
            adress.CreateDate = DateTime.Now;
            await unitOfWork.AddressRepository.AddAsync(adress);
            await unitOfWork.SaveChangesAsync();

            return Ok(adress);
        }

        // PUT api/<AddressController>
        [HttpPut]
        public async Task<IActionResult> UpdateAddress([FromBody] Address updateAddress)
        {
            Address? adress = await unitOfWork.AddressRepository.GetByIdAsync(updateAddress.Id);
            if (adress == null)
            {
                return NotFound(updateAddress.Id);
            }

            adress.UpdateDate = DateTime.Now;
            adress.Street = updateAddress.Street;
            adress.Line2 = updateAddress.Line2;
            adress.City = updateAddress.City;
            adress.State = updateAddress.State;
            adress.PostalCode = updateAddress.PostalCode;
            adress.IsActive = updateAddress.IsActive;
            adress.CreateBy = updateAddress.CreateBy;
            adress.UpdatedBy = updateAddress.UpdatedBy;
            adress.Note = updateAddress.Note;

            await unitOfWork.AddressRepository.UpdateAsync(adress);
            await unitOfWork.SaveChangesAsync();

            return Ok(adress);
        }

        // DELETE api/<AddressController>/5
        [HttpDelete]
        [Route("{id:long}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            Address? adress = await unitOfWork.AddressRepository.GetByIdAsync(id);
            if (adress == null)
            {
                return NotFound(id);
            }
           
            adress.IsRemoved = true;
            await unitOfWork.AddressRepository.UpdateAsync(adress);
            await unitOfWork.SaveChangesAsync();


            return Ok(adress);
        }
    }
}
