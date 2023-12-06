using moto.sale.user.backend.Services.Interface;
using AutoMapper;
using motosale.user.backend.Infrastructure.Repository;
using motosale.user.backend.Services.Interface;
using moto.sale.user.backend.Models;
using motosale.user.backend.DTO.ResponseModels.Main;
using moto.sale.user.backend.DTO.RequestModels;
using motosale.user.backend.DTO.HelperModels.Const;
using Microsoft.EntityFrameworkCore;
using moto.sale.user.backend.DTO.ResponseModels.Inner;

namespace moto.sale.user.backend.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<EMPLOYEE> _employees;
        private readonly ILoggerManager _logger;
        private readonly IConfiguration _configuration;
        private readonly ISqlService _sqlService;
        private readonly IMapper _mapper;

        public EmployeeService(
            IRepository<EMPLOYEE> employees,
            ILoggerManager logger,
            IConfiguration configuration,
            ISqlService sqlService,
            IMapper mapper)
        {
            _employees = employees;
            _logger = logger;
            _configuration = configuration;
            _sqlService = sqlService;
            _mapper = mapper;
        }
        public async Task<ResponseSimple> CreateAsync(ResponseSimple response, EmployeeDto model)
        {
            try
            {
                var employee = _mapper.Map<EMPLOYEE>(model);
                employee.CreatedAt = DateTime.Now;
                _employees.Insert(employee);
                await _employees.SaveAsync();
                response.Status.Message = "Uğurla əlavə olundu!";
            }
            catch (Exception e)
            {
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(CreateAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.DB;
                response.Status.Message = "Problem baş verdi!";
            }
            return response;
        }

        public async Task<ResponseSimple> UpdateAsync(ResponseSimple response, EmployeeDto model, int id)
        {
            try
            {
                var employee = _mapper.Map<EMPLOYEE>(model);

                var employeeDb = await _employees.AllQuery
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);

                employee.Id = id;
                employee.UpdatedAt = DateTime.Now;
                employee.CreatedAt = employeeDb.CreatedAt;

                _employees.Update(employee);
                await _employees.SaveAsync();
                response.Status.Message = "Uğurla yeniləndi!";
            }
            catch (Exception e)
            {
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(UpdateAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.DB;
                response.Status.Message = "Problem baş verdi!";
            }
            return response;
        }

        public async Task<ResponseSimple> DeleteAsync(ResponseSimple response, int id)
        {
            try
            {
                var employee = await _employees.AllQuery.FirstOrDefaultAsync(x => x.Id == id);
                _employees.Remove(employee);
                await _employees.SaveAsync();
                response.Status.Message = "Uğurla silindi!";
            }
            catch (Exception e)
            {
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(DeleteAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.DB;
                response.Status.Message = "Problem baş verdi!";
            }
            return response;
        }

        public async Task<EmployeeVM> GetByIdAsync(int id)
        {
            var employee = await _employees.AllQuery.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<EmployeeVM>(employee);
        }

        public async Task<ResponseListTotal<EmployeeVM>> GetAll(ResponseListTotal<EmployeeVM> response, int page, int pageSize)
        {

            var db_data = await _employees.AllQuery.OrderByDescending(x => x.CreatedAt).ToListAsync();
            response.Response.Total = db_data.Count;
            db_data = db_data.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            response.Response.Data = _mapper.Map<List<EmployeeVM>>(db_data);
            return response;
        }


    }
}
