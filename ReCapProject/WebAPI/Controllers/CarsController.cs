using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

    [HttpGet]
    public List<Car> Get()
        {
            //var result = _carService.GetAll();
            //if (result.Success)
            //{
            //    return Ok(result);

            //}
            //return BadRequest(result);

            return new List<Car>
            {
                new Car{ID=1,Name="car"},
                new Car{ID=2,Name="car2"}
            };
        }

     
    }
}
