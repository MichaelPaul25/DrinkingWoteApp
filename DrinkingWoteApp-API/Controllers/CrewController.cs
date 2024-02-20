using AutoMapper;
using DrinkingWoteApp_API.Dto;
using DrinkingWoteApp_API.Interfaces;
using DrinkingWoteApp_API.Models;
using DrinkingWoteApp_API.Repository;
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

        //Update Crew Member
        [HttpPut("{CrewId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCrew(int CrewId, [FromBody] CrewDto updateCrew)
        {
            if (updateCrew == null)
                return BadRequest(ModelState);

            if (CrewId != updateCrew.CrewId)
                return BadRequest(ModelState);

            if (!_crewRepository.CrewExist(CrewId))
                return NotFound($"Crew Id {CrewId} Not Found!");

            if (!ModelState.IsValid)
                return BadRequest();

            var crewMap = _mapper.Map<CrewMember>(updateCrew);

            if (!_crewRepository.UpdateCrewMember(crewMap))
            {
                ModelState.AddModelError("", "Update Crew data error!");
                return StatusCode(500, ModelState);
            }

            return Ok("Update Crew Successfully");
        }

        //Delete Crew
        [HttpDelete("{CrewId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteCrew(int CrewId)
        {
            if (!_crewRepository.CrewExist(CrewId))
                return NotFound();

            var crewToDelete = _crewRepository.GetMemberDetails(CrewId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_crewRepository.DeleteCrewMember(crewToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting Crew");
            }

            return Ok("Delete Crew Successfully!");
        }
    }
}
