using moto.sale.user.backend.DTO.RequestModels;
using motosale.user.backend.DTO.ResponseModels.Main;

namespace moto.sale.user.backend.Services.Interface
{
    public interface IProductService
    {
        Task<ResponseSimple> CreateAsync(ResponseSimple response, ProductDto model);
    }
}
