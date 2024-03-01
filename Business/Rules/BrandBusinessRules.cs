using Core.CrossCuttingConcerns;
using Core.Exceptios.Types;
using Core.Utilities.Helpers;
using DataAccess.Abstracts;

namespace Business.Rules;

public class BrandBusinessRules : BaseBusinessRules
{
    private readonly IBrandRepository _brandRepository;

    public BrandBusinessRules(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }


    //Business Rules
    public async Task CheckIfBrandNameNotExist(string brandName)
    {
        var isExist = await _brandRepository.GetAsync(brand => brand.Name == SeoHelper.ToSeoUrl(brandName));
        if (isExist != null)
        {
            throw new BusinessException("Brand name already exist.");
        }
    }

    public async Task CheckIfIdNotExist(int Id)
    {
        var isExist = await _brandRepository.GetAsync(p => p.Id == Id);
        if (isExist == null)
        {
            throw new NotFoundException("Brand does not exist.");
        }
    }
}
