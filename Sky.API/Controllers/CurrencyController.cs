using Sky.Domain;
using Sky.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sky.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public CurrencyController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: api/<CurrencyController>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var currency = await unitOfWork.CurrencyRepository.GetAllAsync();
            return Ok(currency.Where(w => !w.IsRemoved));
        }

        // GET api/<CurrencyController>/5
        [HttpGet]
        [Route("{id:long}")]
        public async Task<IActionResult> GetAsync([FromRoute] long id)
        {
            var currency = await unitOfWork.CurrencyRepository.GetAsync(w => w.Id == id & !w.IsRemoved);
            if (currency == null)
            {
                return NotFound();
            }

            return Ok(currency);
        }

        // POST api/<CurrencyController>
        [HttpPost]
        public async Task<IActionResult> AddCurrency([FromBody] Currency currency)
        {  
            await unitOfWork.CurrencyRepository.AddAsync(currency);
            await unitOfWork.SaveChangesAsync();

            return Ok(currency);
        }

        // PUT api/<CurrencyController>
        [HttpPut]
        public async Task<IActionResult> UpdateCurrency([FromBody] Currency updateCurrency)
        {
            Currency? currency = await unitOfWork.CurrencyRepository.GetByIdAsync(updateCurrency.Id);
            if (currency == null)
            {
                return NotFound(updateCurrency.Id);
            }

            currency.UpdateDate = DateTime.Now;
            currency.Code = updateCurrency.Code;
            currency.Name = updateCurrency.Name;
            currency.Rate = updateCurrency.Rate;
            currency.Symbol = updateCurrency.Symbol;
            currency.CreateBy = updateCurrency.CreateBy;
            currency.UpdatedBy = updateCurrency.UpdatedBy;
            currency.Note = updateCurrency.Note;

            await unitOfWork.CurrencyRepository.UpdateAsync(currency);
            await unitOfWork.SaveChangesAsync();

            return Ok(currency);
        }

        // DELETE api/<CurrencyController>/5
        [HttpDelete]
        [Route("{id:long}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            Currency? currency = await unitOfWork.CurrencyRepository.GetByIdAsync(id);
            if (currency == null)
            {
                return NotFound(id);
            }

            currency.IsRemoved = true;
            await unitOfWork.CurrencyRepository.UpdateAsync(currency);
            await unitOfWork.SaveChangesAsync();

            return Ok(currency);
        }
    }
}
