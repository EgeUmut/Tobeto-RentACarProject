using Business.Abstracts.Async;
using Business.Abstracts.Sync;
using Business.Requests;
using Business.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;
        private readonly IAsyncCarService _asyncCarService;

        public CarController(ICarService carService, IAsyncCarService asyncCarService)
        {
            _carService = carService;
            _asyncCarService = asyncCarService;
        }

        [HttpPost("AddAsync")]
        public async Task<CreateCarResponse> AddAsync(CreateCarRequest request)
        {
            return await _asyncCarService.AddAsync(request);
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> getAllAsync()
        {
            return Ok(await _asyncCarService.GetAll());
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
