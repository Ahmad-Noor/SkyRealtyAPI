using Sky.Domain;
using Sky.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sky.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public UnitController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: api/<UnitController>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var units = await unitOfWork.UnitRepository.GetAllAsync();
            return Ok(units.Where(w => !w.IsRemoved));
        }

        // GET api/<UnitController>/5
        [HttpGet]
        [Route("{id:long}")]
        public async Task<IActionResult> GetAsync([FromRoute] long id)
        {
            var units = await unitOfWork.UnitRepository.GetAsync(w => w.Id == id & !w.IsRemoved);
            if (units == null)
            {
                return NotFound();
            }

            return Ok(units);
        }

        // POST api/<UnitController>
        [HttpPost]
        public async Task<IActionResult> AddUnit([FromBody] Unit unit)
        {
            unit.CreateDate = DateTime.Now;
            await unitOfWork.UnitRepository.AddAsync(unit);
            await unitOfWork.SaveChangesAsync();

            return Ok(unit);
        }

        // PUT api/<UnitController>
        [HttpPut]
        public async Task<IActionResult> UpdateUnit([FromBody] Unit updateUnit)
        {
            Unit? unit = await unitOfWork.UnitRepository.GetByIdAsync(updateUnit.Id);
            if (unit == null)
            {
                return NotFound(updateUnit.Id);
            }

            unit.UpdateDate = DateTime.Now;
            unit.Code = updateUnit.Code;
            unit.Name = updateUnit.Name;
            unit.CreateBy = updateUnit.CreateBy;
            unit.UpdatedBy = updateUnit.UpdatedBy;
            unit.Note = updateUnit.Note;
             
            await unitOfWork.UnitRepository.UpdateAsync(unit);
            await unitOfWork.SaveChangesAsync();

            return Ok(unit);
        }

        // DELETE api/<UnitController>/5
        [HttpDelete]
        [Route("{id:long}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            Unit? unit = await unitOfWork.UnitRepository.GetByIdAsync(id);
            if (unit == null)
            {
                return NotFound(id);
            }

            unit.IsRemoved = true;

            await unitOfWork.UnitRepository.UpdateAsync(unit);
            await unitOfWork.SaveChangesAsync();


            return Ok(unit);
        }
    }
}
