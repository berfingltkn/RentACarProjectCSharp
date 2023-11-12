using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        IRentalsService _rentalsService;

        public RentalsController(IRentalsService rentalService)
        {
            _rentalsService = rentalService;
        }

        [HttpGet("getall")]

        public IActionResult GetAll()
        {
            var result = _rentalsService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _rentalsService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Rentals rental)
        {
            var result = _rentalsService.Add(rental);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Rentals rental)
        {
            var result = _rentalsService.Update(rental);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Rentals rental)
        {
            var result = _rentalsService.Delete(rental);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }

        [HttpGet("getallrentaldetails")]
        public IActionResult GetAllRentalDetails(int carId)
        {
            var result = _rentalsService.GetAllRentalDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
