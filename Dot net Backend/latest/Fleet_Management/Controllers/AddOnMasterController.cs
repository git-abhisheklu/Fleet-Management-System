using Fleet_Management.Exceptions;
using Fleet_Management.Models;
using Fleet_Management.Service;
using Microsoft.AspNetCore.Mvc;

namespace Fleet_Management.Controllers
{
    [Route("api/addons")]
    [ApiController]
    public class AddOnMasterController : ControllerBase
    {
        private readonly IAddOnMasterService _addOnMasterService;

        public AddOnMasterController(IAddOnMasterService addOnMasterService)
        {
            _addOnMasterService = addOnMasterService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddOnMaster>>> GetAllAddOns()
        {
            var addOns = await _addOnMasterService.GetAllAddOnsAsync();
            if (addOns.Count == 0)
            {
                return NoContent();
            }
            return Ok(addOns);
        }


        [HttpGet("{addonId}")]
        public async Task<ActionResult<AddOnMaster>> GetAddOnById(long addonId)
        {
            var addOnMaster = await _addOnMasterService.GetAddOnByIdAsync(addonId);
            if (addOnMaster == null)
            {
                return NotFound();
            }
            return Ok(addOnMaster);
        }


        [HttpDelete("{addonId}")]
        public async Task<ActionResult> DeleteAddOnById(long addonId)
        {
            var addOnMaster = await _addOnMasterService.DeleteAddOnByIdAsync(addonId);
            if (addOnMaster == null)
            {
                return NotFound("AddOn not found");
            }
            return Ok("AddOn deleted successfully");
        }


        [HttpPut("{addonId}")]
        public async Task<ActionResult<AddOnMaster>> UpdateAddOn(long addonId, [FromBody] AddOnMaster updatedAddOn)
        {
            if (addonId != updatedAddOn.AddonId)
            {
                return BadRequest("AddonId in URL does not match AddonId in the body");
            }

            var updated = await _addOnMasterService.UpdateAddOnByIdAsync(updatedAddOn);
            if (updated == null)
            {
                return NotFound();
            }
            return Ok(updated);
        }


        [HttpPost]
        public async Task<ActionResult<AddOnMaster>> CreateAddOn([FromBody] AddOnMaster addOnMaster)
        {
            var createdAddOn = await _addOnMasterService.CreateAddOnAsync(addOnMaster);
            return CreatedAtAction(nameof(GetAddOnById), new { addonId = createdAddOn?.AddonId }, createdAddOn);
        }

        // [HttpGet("throw")]
        // public IActionResult ThrowException()
        // {
        //     throw new ApiException("Test Exception for Global Middleware");
        // }
    }
}
