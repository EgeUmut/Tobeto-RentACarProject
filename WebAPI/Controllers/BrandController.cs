using Business.Abstracts;
using Business.Requests;
using Business.Responses.Brand;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : BaseController
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpPost("AddAsync")]
        public async Task<IActionResult> AddAsync(CreateBrandRequest request)
        {
            var item = await _brandService.AddAsync(request);
            return HandleDataResult(item);
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> getAllAsync()
        {
            var item = await _brandService.GetAllAsync();
            return HandleDataResult(item);
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

        [HttpDelete("DeleteAsync")]
        public async Task<IActionResult> DeleteAsync(int request)
        {
            return HandleResult(await _brandService.DeleteAsync(request));
        }

        [HttpDelete("SoftDeleteAsync")]
        public async Task<IActionResult> SoftDeleteAsync(int request)
        {
            return HandleResult(await _brandService.SoftDeleteAsync(request));
        }
    }
}
