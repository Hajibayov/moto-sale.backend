using moto.sale.user.backend.DTO.RequestModels;
using moto.sale.user.backend.DTO.ResponseModels.Inner;
using motosale.user.backend.DTO.ResponseModels.Main;

namespace moto.sale.user.backend.Services.Interface
{
    public interface IProductService
    {
        Task<ResponseSimple> CreateAsync(ResponseSimple response, ProductDto model);
        Task<ResponseSimple> UpdateAsync(ResponseSimple response, ProductDto model, int id);
        Task<ResponseSimple> DeleteAsync(ResponseSimple response, int id);
        Task<ProductVM> GetByIdAsync(int id);
        Task<ResponseListTotal<ProductVM>> GetAll(ResponseListTotal<ProductVM> response, int page, int pageSize);
    }
}
