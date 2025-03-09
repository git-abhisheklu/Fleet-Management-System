using Fleet_Management.Models;
using Fleet_Management.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fleet_Management.Controllers
{
    [Route("/api/states")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateService _StateService;

        public StateController(IStateService StateService)
        {
            _StateService = StateService;
        }

        [HttpGet]
        public async Task<ActionResult<List<StateMaster>>> GetAllStateAsync()
        {
            return await _StateService.GetAllStateAsync();
        }

    }
}
