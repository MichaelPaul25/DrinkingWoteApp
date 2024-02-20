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
    public class BillController : Controller
    {
        private readonly IBillRepository _billRepository;
        private readonly IMapper _mapper;

        public BillController(IBillRepository billRepository, IMapper mapper)
        {
            _billRepository = billRepository;
            _mapper = mapper;
        }

        //Get All Bills
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Bill>))]
        public IActionResult GetAllBill()
        {
            var bills = _billRepository.GetAllBill();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(bills);
        }

        //Get Details bill by id
        [HttpGet("BillId")]
        [ProducesResponseType(200, Type = typeof(Bill))]
        [ProducesResponseType(400)]
        public IActionResult GetDetailsBill(int id)
        {
            var billDetails = _billRepository.GetBillDetails(id);

            if (billDetails == null)
                return NotFound($"Bill {id} Not Found!");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(billDetails);
        }

        //Get Bill by Consument Id
        [HttpGet("ConsumenId")]
        [ProducesResponseType(200, Type = typeof(Bill))]
        [ProducesResponseType(400)]
        public IActionResult GetDetailsbyConsumen(int consumendId)
        {
            var billConsument = _billRepository.GetBillByConsumenId(consumendId);

            if (billConsument == null)
                return NotFound($"Bill with consument id : {consumendId} Not Found!");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(billConsument);
        }

        //Get all Unpaid Bill
        [HttpGet("UnpaidBills")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Bill>))]
        [ProducesResponseType(400)]
        public IActionResult GetAllUnpaid()
        {
            var unpaidBills = _billRepository.UnpaidBIll();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(unpaidBills);
        }

        //Create new Bill
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateBill(Bill createBill, int consumentId, int orderId)
        {
            if (createBill == null || consumentId == 0 || orderId == 0)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var bill = _mapper.Map<Bill>(createBill);

            if(!_billRepository.CreateBill(bill, consumentId, orderId))
            {
                ModelState.AddModelError("", "Can't Add new Consument!");
                return BadRequest(ModelState);
            }

            return Ok("Successfully Create new Bill");
        }

        //Update Data Bill
        [HttpPut("{BillId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateBill(int BillId, [FromBody] BillDto updateBill)
        {
            if (updateBill == null)
                return BadRequest(ModelState);

            if (BillId != updateBill.BillId)
                return BadRequest(ModelState);

            if (!_billRepository.ExistBill(BillId))
                return NotFound($"Bill Id {BillId} Not Found!");

            if (!ModelState.IsValid)
                return BadRequest();

            var billMap = _mapper.Map<Bill>(updateBill);

            if (!_billRepository.UpdateBill(billMap))
            {
                ModelState.AddModelError("", "Update Bill data error!");
                return StatusCode(500, ModelState);
            }

            return Ok("Update Bill Successfully");
        }
        //Delete Bill
        [HttpDelete("{BillId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteBill(int BillId)
        {
            if (!_billRepository.ExistBill(BillId))
                return NotFound();

            var billToDelete = _billRepository.GetBillDetails(BillId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_billRepository.DeleteBill(billToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting Bill");
            }

            return Ok("Delete Bill Successfully!");
        }
    }
}
