using Sky.Domain;
using Sky.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sky.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public RoleController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: api/<RoleController>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var units = await unitOfWork.RoleRepository.GetAllAsync();
            return Ok(units.Where(w => !w.IsRemoved));
        }

        // GET api/<RoleController>/5
        [HttpGet]
        [Route("{id:long}")]
        public async Task<IActionResult> GetAsync([FromRoute] long id)
        {
            var role = await unitOfWork.RoleRepository.GetAsync(w => w.Id == id & !w.IsRemoved);
            if (role == null)
            {
                return NotFound();
            }

            return Ok(role);
        }

        // POST api/<RoleController>
        [HttpPost]
        public async Task<IActionResult> AddRole([FromBody] Role role)
        {
            await unitOfWork.RoleRepository.AddAsync(role);
            await unitOfWork.SaveChangesAsync();

            return Ok(role);
        }

        
        [HttpPut]
        public async Task<IActionResult> UpdateRole([FromBody] Role updateRole)
        {
            Role? role = await unitOfWork.RoleRepository.GetByIdAsync(updateRole.Id);
            if (role == null)
            {
                return NotFound(updateRole.Id);
            }

            role.UpdateDate = DateTime.Now;
            role.Code = updateRole.Code;
            role.Name = updateRole.Name;
            role.CreateBy = updateRole.CreateBy;
            role.UpdatedBy = updateRole.UpdatedBy;
            

            await unitOfWork.RoleRepository.UpdateAsync(role);
            await unitOfWork.SaveChangesAsync();

            return Ok(role);
        }

        // DELETE api/<RoleController>/5
        [HttpDelete]
        [Route("{id:long}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            Role? role = await unitOfWork.RoleRepository.GetByIdAsync(id);
            if (role == null)
            {
                return NotFound(id);
            }
            role.IsRemoved = true;

            await unitOfWork.RoleRepository.UpdateAsync(role);
            await unitOfWork.SaveChangesAsync();

            return Ok(role);
        }
    }
}
