﻿using DrinkingWoteApp_API.Interfaces;
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
    }
}