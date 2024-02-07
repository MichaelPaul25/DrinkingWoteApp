using DrinkingWoteApp_API.Interfaces;
using DrinkingWoteApp_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DrinkingWoteApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrewController : Controller
    {
        private readonly ICrewRepository _crewRepository;

        public CrewController(ICrewRepository crewRepository)
        {
            _crewRepository = crewRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CrewMember>))]
        public IActionResult GetAllCrew()
        {
            var crewMembers = _crewRepository.GetAllMembers();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(crewMembers);
        }

        [HttpGet("CrewId")]
        [ProducesResponseType(200, Type =typeof(CrewMember))]
        [ProducesResponseType(400)]
        public IActionResult GetCrewByDetails(int id)
        {
            var crewDetails = _crewRepository.GetMemberDetails(id);

            if (crewDetails == null)
                return NotFound($"Crew Member {id} not Found!");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(crewDetails);
        }
    }
}
