using moto.sale.user.backend.DTO.RequestModels;
using moto.sale.user.backend.DTO.ResponseModels.Inner;
using motosale.user.backend.DTO.ResponseModels.Main;

namespace moto.sale.user.backend.Services.Interface
{
    public interface IEmployeeService
    {
        Task<ResponseSimple> CreateAsync(ResponseSimple response, EmployeeDto model);
        Task<ResponseSimple> UpdateAsync(ResponseSimple response, EmployeeDto model, int id);
        Task<ResponseSimple> DeleteAsync(ResponseSimple response, int id);
        Task<EmployeeVM> GetByIdAsync(int id);
        Task<ResponseListTotal<EmployeeVM>> GetAll(ResponseListTotal<EmployeeVM> response, int page, int pageSize);

    }
}
