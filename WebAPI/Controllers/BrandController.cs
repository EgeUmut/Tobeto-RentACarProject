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
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;
        private readonly IAsyncBrandService _asyncBrandService;

        public BrandController(IBrandService brandService, IAsyncBrandService asyncBrandService)
        {
            _brandService = brandService;
            _asyncBrandService = asyncBrandService;
        }

        [HttpPost("AddAsync")]
        public async Task<CreateBrandResponse> AddAsync(CreateBrandRequest request)
        {
            return await _asyncBrandService.AddAsync(request);
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> getAllAsync()
        {
            return Ok(await _asyncBrandService.GetAll());
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
