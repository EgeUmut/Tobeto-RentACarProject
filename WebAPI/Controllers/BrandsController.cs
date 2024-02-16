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
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;
        private readonly IAsyncBrandService _asyncBrandService;

        public BrandsController(IBrandService brandService, IAsyncBrandService asyncBrandService)
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

        [HttpPost("GetById")]
        public GetByIdBrandResponse GetById(int id)
        {
            return _brandService.GetById(id);
        }
    }
}
