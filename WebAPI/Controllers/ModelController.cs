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
    public class ModelController : ControllerBase
    {
        private readonly IModelService _modelService;
        private readonly IAsyncModelService _asyncModelService;

        public ModelController(IModelService modelService, IAsyncModelService asyncModelService)
        {
            _modelService = modelService;
            _asyncModelService = asyncModelService;
        }
        
        [HttpPost("AddAsync")]
        public async Task<CreateModelResponse> AddAsync(CreateModelRequest request)
        {
            return await _asyncModelService.AddAsync(request);
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> getAllAsync()
        {
            return Ok(await _asyncModelService.GetAll());
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
