using Sky.Domain;
using Sky.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sky.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public CustomerController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var customer = await unitOfWork.CustomerRepository.GetAllAsync();
            return Ok(customer.Where(w => !w.IsRemoved));
        }

        // GET api/<CustomerController>/5
        [HttpGet]
        [Route("{id:long}")]
        public async Task<IActionResult> GetAsync([FromRoute] long id)
        {
            var customer = await unitOfWork.CustomerRepository.GetAsync(w => w.Id == id & !w.IsRemoved);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody] Customer customer)
        {  
            await unitOfWork.CustomerRepository.AddAsync(customer);
            await unitOfWork.SaveChangesAsync();

            return Ok(customer);
        }

        // PUT api/<CustomerController>
        [HttpPut]
        public async Task<IActionResult> UpdateCustomer([FromBody] Customer updateCustomer)
        {
            Customer? customer = await unitOfWork.CustomerRepository.GetByIdAsync(updateCustomer.Id);
            if (customer == null)
            {
                return NotFound(updateCustomer.Id);
            }

            customer.UpdateDate = DateTime.Now;
            customer.Code = updateCustomer.Code;
            customer.Name = updateCustomer.Name;
            customer.IsActive = updateCustomer.IsActive;
            customer.AddressId = updateCustomer.AddressId;
            customer.ContactId = updateCustomer.ContactId;
            customer.CreateBy = updateCustomer.CreateBy;
            customer.UpdatedBy = updateCustomer.UpdatedBy;
            customer.Note = updateCustomer.Note;

            await unitOfWork.CustomerRepository.UpdateAsync(customer);
            await unitOfWork.SaveChangesAsync();

            return Ok(customer);
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete]
        [Route("{id:long}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            Customer? customer = await unitOfWork.CustomerRepository.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound(id);
            }

            customer.IsRemoved = true;
            await unitOfWork.CustomerRepository.UpdateAsync(customer);
            await unitOfWork.SaveChangesAsync();

            return Ok(customer);
        }
    }
}
