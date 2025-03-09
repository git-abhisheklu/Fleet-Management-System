using Fleet_Management.Models;

namespace Fleet_Management.Service
{
    public interface IMembershipService
    {
        Task<Membership> CreateMembershipAsync(Membership membership);
        Task<Membership?> GetMembershipByIdAsync(long membershipId);
        Task<List<Membership>> GetAllMembershipsAsync();
        Task<List<Membership>> GetMembershipsByCustomerIdAsync(long customerId);
        Task<Membership?> UpdateMembershipAsync(long membershipId, Membership updatedMembership);
        Task<bool> DeleteMembershipAsync(long membershipId);
    }

}
