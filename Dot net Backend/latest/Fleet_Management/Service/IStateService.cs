using Fleet_Management.Models;

namespace Fleet_Management.Service
{
    public interface IStateService
    {
        Task<List<StateMaster>> GetAllStateAsync();
    }
}
