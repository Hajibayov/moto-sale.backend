using motosale.user.backend.DTO.ResponseModels.Inner;
using motosale.user.backend.DTO.ResponseModels.Main;

namespace moto.sale.user.backend.Services.Interface
{
    public interface ILookupService
    {
        Task<ResponseList<BrandVM>> GetBrandsAsync(ResponseList<BrandVM> response);
        Task<ResponseList<CategoryVM>> GetCategoriesAsync(ResponseList<CategoryVM> response);
    }
}
