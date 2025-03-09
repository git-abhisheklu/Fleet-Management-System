using Fleet_Management.Models;
using Fleet_Management.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fleet_Management.Service
{
    public class MembershipService : IMembershipService
    {
        private readonly FleetDbContext _context;

        public MembershipService(FleetDbContext context)
        {
            _context = context;
        }

        public async Task<Membership> CreateMembershipAsync(Membership membership)
        {
            _context.Memberships.Add(membership);
            await _context.SaveChangesAsync();
            return membership;
        }

        public async Task<Membership?> GetMembershipByIdAsync(long membershipId)
        {
            return await _context.Memberships
                .Include(m => m.Customer)  // Include customer details
                .FirstOrDefaultAsync(m => m.MembershipId == membershipId);
        }

        public async Task<List<Membership>> GetAllMembershipsAsync()
        {
            return await _context.Memberships
                .Include(m => m.Customer)  // Include customer details
                .ToListAsync();
        }

        public async Task<List<Membership>> GetMembershipsByCustomerIdAsync(long customerId)
        {
            return await _context.Memberships
                .Include(m => m.Customer)  // Include customer details
                .Where(m => m.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<Membership?> UpdateMembershipAsync(long membershipId, Membership updatedMembership)
        {
            var existingMembership = await _context.Memberships.FindAsync(membershipId);
            if (existingMembership == null)
                return null;

            existingMembership.StartDate = updatedMembership.StartDate;
            existingMembership.EndDate = updatedMembership.EndDate;
            existingMembership.Fee = updatedMembership.Fee;
            existingMembership.MembershipType = updatedMembership.MembershipType;
            existingMembership.CustomerId = updatedMembership.CustomerId;

            await _context.SaveChangesAsync();
            return existingMembership;
        }

        public async Task<bool> DeleteMembershipAsync(long membershipId)
        {
            var membership = await _context.Memberships.FindAsync(membershipId);
            if (membership == null)
                return false;

            _context.Memberships.Remove(membership);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
