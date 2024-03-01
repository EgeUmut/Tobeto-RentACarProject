using Business.Abstracts;
using Core.CrossCuttingConcerns;
using Core.Exceptios.Types;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Rules;

public class ModelBusinessRules : BaseBusinessRules
{
    private readonly IModelRepository _modelRepository;
    private readonly IBrandService _brandService;

    public ModelBusinessRules(IModelRepository modelRepository, IBrandService brandService)
    {
        _modelRepository = modelRepository;
        _brandService = brandService;
    }

    public async Task CheckIfBrandExist(int brandId)
    {
        var brand = await _brandService.GetByIdAsync(brandId);
        if (brand == null)
        {
            throw new BusinessException("Brand could not be found.");
        }
    }
}
