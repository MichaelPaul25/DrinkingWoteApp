using AutoMapper;
using DrinkingWoteApp_API.Dto;
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
        private readonly IMapper _mapper;

        public CrewController(ICrewRepository crewRepository, IMapper mapper)
        {
            _crewRepository = crewRepository;
            _mapper = mapper;
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

        //Create new Consument
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateNewCrew([FromBody]CrewDto crewMember)
        {
            if (crewMember == null)
                return BadRequest("Crew Member data is empty!");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var crew = _mapper.Map<CrewMember>(crewMember);

            if (!_crewRepository.AddNewCrewMember(crew))
            {
                ModelState.AddModelError("", "Can't Add new Crew Member!");
                return BadRequest(ModelState);
            }

            return Ok("Successfully Create new Crew Member");
        }
    }
}
