using Business.Abstracts;
using Business.Requests;
using Business.Responses.Car;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;

        }

        [HttpPost("AddAsync")]
        public async Task<CreateCarResponse> AddAsync(CreateCarRequest request)
        {
            return await _carService.AddAsync(request);
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> getAllAsync()
        {
            return Ok(await _carService.GetAllAsync());
        }

        [HttpPost("Add")]
        public CreateCarResponse Add(CreateCarRequest request)
        {
            return _carService.Add(request);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_carService.GetAll());
        }

        [HttpPost("GetById")]
        public GetByIdCarResponse GetById(int id)
        {
            return _carService.GetById(id);
        }
    }
}
