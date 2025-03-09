using Fleet_Management.Models;
using Fleet_Management.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Fleet_Management.DTO;

namespace Fleet_Management.Controllers
{
    [Route("api/membership")]
    [ApiController]
    public class MembershipController : ControllerBase
    {
        private readonly IMembershipService _membershipService;

        public MembershipController(IMembershipService membershipService)
        {
            _membershipService = membershipService;
        }

        [HttpPost("create")]
        public async Task<ActionResult<Membership>> CreateMembership([FromBody] Membership membership)
        {
            var createdMembership = await _membershipService.CreateMembershipAsync(membership);
            return CreatedAtAction(nameof(GetMembershipById), new { membershipId = createdMembership.MembershipId }, createdMembership);
        }

        [HttpGet("{membershipId}")]
        public async Task<ActionResult<object>> GetMembershipById(long membershipId)
        {
            var membership = await _membershipService.GetMembershipByIdAsync(membershipId);
            if (membership == null)
                return NotFound();

            return Ok(MapMembershipToResponse(membership));
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<object>>> GetAllMemberships()
        {
            var memberships = await _membershipService.GetAllMembershipsAsync();
            return Ok(memberships.Select(MapMembershipToResponse).ToList());
        }

        [HttpGet("customer/{customerId}")]
        public async Task<ActionResult<List<object>>> GetMembershipsByCustomerId(long customerId)
        {
            var memberships = await _membershipService.GetMembershipsByCustomerIdAsync(customerId);
            return Ok(memberships.Select(MapMembershipToResponse).ToList());
        }

        [HttpPut("update/{membershipId}")]
        public async Task<ActionResult<Membership>> UpdateMembership(long membershipId, [FromBody] Membership updatedMembership)
        {
            var updated = await _membershipService.UpdateMembershipAsync(membershipId, updatedMembership);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        [HttpDelete("delete/{membershipId}")]
        public async Task<IActionResult> DeleteMembership(long membershipId)
        {
            var deleted = await _membershipService.DeleteMembershipAsync(membershipId);
            if (!deleted)
                return NotFound();

            return NoContent();
        }

        // Helper method to map Membership to response format
        private object MapMembershipToResponse(Membership membership)
        {
            return new
            {
                membership.MembershipId,
                membership.MembershipType,
                membership.Fee,
                membership.StartDate,
                membership.EndDate,
                Customer = membership.Customer != null ? new CustomerDTO
                {
                    CustomerId = membership.Customer.CustomerId,
                    FirstName = membership.Customer.FirstName,
                    LastName = membership.Customer.LastName,
                    AddressLine1 = membership.Customer.AddressLine1,
                    AddressLine2 = membership.Customer.AddressLine2,
                    Email = membership.Customer.Email,
                    City = membership.Customer.City,
                    Pincode = membership.Customer.Pincode,
                    PhoneNumber = membership.Customer.PhoneNumber,
                    MobileNumber = membership.Customer.MobileNumber,
                    CreditCardType = membership.Customer.CreditCardType,
                    CreditCardNumber = membership.Customer.CreditCardNumber,
                    DrivingLicenseNumber = membership.Customer.DrivingLicenseNumber,
                    IdpNumber = membership.Customer.IdpNumber,
                    IssuedByDL = membership.Customer.IssuedBydl,
                    ValidThroughDL = membership.Customer.ValidThroughdl,
                    PassportNumber = membership.Customer.PassportNumber,
                    PassportValidThrough = membership.Customer.PassportValidThrough,
                    PassportIssuedBy = membership.Customer.PassportIssuedBy,
                    PassportValidFrom = membership.Customer.PassportValidFrom,
                    PassportIssueDate = membership.Customer.PassportIssueDate,
                    DateOfBirth = membership.Customer.DateOfBirth
                } : null
            };
        }
    }
}
