using DrinkingWoteApp_API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using DrinkingWoteApp_API.Models;
using DrinkingWoteApp_API.Dto;
using DrinkingWoteApp_API.Repository;

namespace DrinkingWoteApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumentController : Controller
    {
        private readonly IConsumentRepository _consumentRepository;
        private readonly IMapper _mapper;

        public ConsumentController(IConsumentRepository consumentRepository, IMapper mapper)
        {
            _consumentRepository = consumentRepository;
            _mapper = mapper;
        }

        //Get All Consument List
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Consument>))]
        public IActionResult GetAllConsuments()
        {
            var data = _mapper.Map<List<ConsumentDto>>(_consumentRepository.GetAllConsuments());
            //var data = _consumentRepository.GetAllConsuments();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(data);
        }

        //Get Consument details
        [HttpGet("consumntId")]
        [ProducesResponseType(200, Type = typeof(Consument))]
        [ProducesResponseType(400)]
        public IActionResult GetConsumentId(int id)
        {

            if (!_consumentRepository.ConsumentExists(id))
            {
                return NotFound($"Cannot find user {id}");
            }

            var consumentDetail = _mapper.Map<ConsumentDto>(_consumentRepository.GetDetailConsument(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(consumentDetail);
        }

        //get Consument Balance
        [HttpGet("Balance/{Consumentid}")]
        [ProducesResponseType(200, Type = typeof(Consument))]
        [ProducesResponseType(400)]
        public IActionResult GetConsumentBalance(int Consumentid)
        {
            if (!_consumentRepository.ConsumentExists(Consumentid))
                return NotFound($"Cannot find user {Consumentid}");

            var balance = _consumentRepository.GetConsumentBalance(Consumentid);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(balance);
        }

        //Create new Consument
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateConsument(int userId, [FromBody] ConsumentDto createConsument)
        {
            if (createConsument == null || userId == 0)
                return BadRequest(ModelState);

            //Check if consument exist with same user id
            var consumentExist = _consumentRepository.CheckUserHaveCustomerId(userId);

            if (consumentExist)
            {
                ModelState.AddModelError("", "User already register a Customer!");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //Inject to Consument DTO
            var consument = _mapper.Map<Consument>(createConsument);

            if (!_consumentRepository.CreateConsument(userId, consument))
            {
                ModelState.AddModelError("", "Can't Add new Consument!");
                return BadRequest(ModelState);
            }

            return Ok("Successfully Create new Consument");
        }
        [HttpPut("{Id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateConsument(int Id, [FromBody] ConsumentDto updateConsument)
        {
            if (updateConsument == null)
                return BadRequest(ModelState);

            if (Id != updateConsument.Id)
                return BadRequest(ModelState);

            if (!_consumentRepository.ConsumentExists(Id))
                return NotFound($"Consument Id {Id} Not Found!");

            if (!ModelState.IsValid)
                return BadRequest();

            var consument = _mapper.Map<Consument>(updateConsument);

            if (!_consumentRepository.UpdateConsument(Id, consument))
            {
                ModelState.AddModelError("", "Update Consument data error!");
                return StatusCode(500, ModelState);
            }

            return Ok("Update Consument Successfully");
        }

        //Delete Consument
        [HttpDelete("{Id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteUser(int Id)
        {
            if (!_consumentRepository.ConsumentExists(Id))
                return NotFound();

            var consumentToDelete = _consumentRepository.GetDetailConsument(Id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_consumentRepository.DeleteConsument(consumentToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting consument");
            }

            return Ok("Delete consument Successfully!");
        }
    }
}
