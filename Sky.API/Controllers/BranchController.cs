using Sky.Domain;
using Sky.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sky.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public BranchController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: api/<AddressController>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var branchs = await unitOfWork.BranchRepository.GetAllAsync();
            return Ok(branchs.Where(w => !w.IsRemoved));
        }

        // GET api/<AddressController>/5
        [HttpGet]
        [Route("{id:long}")]
        public async Task<IActionResult> GetAsync([FromRoute] long id)
        {
            var branchs = await unitOfWork.BranchRepository.GetAsync(w => w.Id == id & !w.IsRemoved);
            if (branchs == null)
            {
                return NotFound();
            }

            return Ok(branchs);
        }

        // POST api/<BranchController>
        [HttpPost]
        public async Task<IActionResult> AddBranch([FromBody] Branch branch)
        { 
            branch.CreateDate = DateTime.Now;
            await unitOfWork.BranchRepository.AddAsync(branch);
            await unitOfWork.SaveChangesAsync();

            return Ok(branch);
        }

        // PUT api/<AddressController>
        [HttpPut]
        public async Task<IActionResult> UpdateBranch([FromBody] Branch updateBranch)
        {
            Branch? branch = await unitOfWork.BranchRepository.GetByIdAsync(updateBranch.Id);
            if (branch == null)
            {
                return NotFound(updateBranch.Id);
            }
 
        branch.UpdateDate = DateTime.Now;
            branch.Code = updateBranch.Code;
            branch.Name = updateBranch.Name;
            branch.LogoURL = updateBranch.LogoURL;
            branch.ShowLogo = updateBranch.ShowLogo;
            branch.AddressId = updateBranch.AddressId;
            branch.ContactId = updateBranch.ContactId;
            branch.CommercialNo = updateBranch.CommercialNo;
            branch.SiteURL = updateBranch.SiteURL;
            branch.DefaultCurrencyId = updateBranch.DefaultCurrencyId;
            branch.DefaultInventoryId = updateBranch.DefaultInventoryId;
            branch.DefaultCostCenterId = updateBranch.DefaultCostCenterId;
            branch.AccPurchasesId = updateBranch.AccPurchasesId;
            branch.AccSuppliersId = updateBranch.AccSuppliersId;
            branch.AccCashId = updateBranch.AccCashId;
            branch.AccPurchasesReturnsId = updateBranch.AccPurchasesReturnsId;
            branch.AccSalesTaxonPurchasesId = updateBranch.AccSalesTaxonPurchasesId;
            branch.AccSalesId = updateBranch.AccSalesId;
            branch.AccInventoryId = updateBranch.AccInventoryId;
            branch.AccSalesCostId = updateBranch.AccSalesCostId;
            branch.InventoryAccountingTypes = updateBranch.InventoryAccountingTypes;
            branch.SystemType = updateBranch.SystemType;
            branch.CreateBy = updateBranch.CreateBy;
            branch.UpdatedBy = updateBranch.UpdatedBy;
            branch.Note = updateBranch.Note;

            await unitOfWork.BranchRepository.UpdateAsync(branch);
            await unitOfWork.SaveChangesAsync();

            return Ok(branch);
        }

        // DELETE api/<AddressController>/5
        [HttpDelete]
        [Route("{id:long}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            Branch? branch = await unitOfWork.BranchRepository.GetByIdAsync(id);
            if (branch == null)
            {
                return NotFound(id);
            }
            branch.IsRemoved = true;
            await unitOfWork.BranchRepository.UpdateAsync(branch);
            await unitOfWork.SaveChangesAsync();

            return Ok(branch);
        }
    }
}
