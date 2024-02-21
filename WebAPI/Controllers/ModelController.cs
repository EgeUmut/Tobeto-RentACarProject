using Business.Abstracts;
using Business.Requests;
using Business.Responses.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        private readonly IModelService _modelService;

        public ModelController(IModelService modelService)
        {
            _modelService = modelService;

        }
        
        [HttpPost("AddAsync")]
        public async Task<CreateModelResponse> AddAsync(CreateModelRequest request)
        {
            return await _modelService.AddAsync(request);
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> getAllAsync()
        {
            return Ok(await _modelService.GetAllAsync());
        }

        [HttpPost("Add")]
        public CreateModelResponse Add(CreateModelRequest request)
        {
            return _modelService.Add(request);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_modelService.GetAll());
        }

        [HttpPost("GetById")]
        public GetByIdModelResponse GetById(int id)
        {
            return _modelService.GetById(id);
        }
    }
}
