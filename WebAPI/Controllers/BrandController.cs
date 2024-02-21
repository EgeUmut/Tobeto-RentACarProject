using Business.Abstracts;
using Business.Requests;
using Business.Responses.Brand;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpPost("AddAsync")]
        public async Task<CreateBrandResponse> AddAsync(CreateBrandRequest request)
        {
            return await _brandService.AddAsync(request);
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> getAllAsync()
        {
            return Ok(await _brandService.GetAllAsync());
        }

        [HttpPost("Add")]
        public CreateBrandResponse Add(CreateBrandRequest request)
        {
            return _brandService.Add(request);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_brandService.GetAll());
        }

        [HttpPost("GetById")]
        public GetByIdBrandResponse GetById(int id)
        {
            return _brandService.GetById(id);
        }
    }
}
