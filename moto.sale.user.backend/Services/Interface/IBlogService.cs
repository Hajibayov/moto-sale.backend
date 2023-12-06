using moto.sale.user.backend.DTO.RequestModels;
using moto.sale.user.backend.DTO.ResponseModels.Inner;
using motosale.user.backend.DTO.ResponseModels.Main;

namespace moto.sale.user.backend.Services.Interface
{
    public interface IBlogService
    {
        Task<ResponseSimple> CreateAsync(ResponseSimple response, BlogDto model);
        Task<ResponseSimple> UpdateAsync(ResponseSimple response, BlogDto model, int id);
        Task<ResponseSimple> DeleteAsync(ResponseSimple response, int id);
        Task<BlogVM> GetByIdAsync(int id);
        Task<ResponseListTotal<BlogVM>> GetAll(ResponseListTotal<BlogVM> response, int page, int pageSize);
    }
}
