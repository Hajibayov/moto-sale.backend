using AutoMapper;
using Microsoft.EntityFrameworkCore;
using moto.sale.user.backend.DTO.RequestModels;
using moto.sale.user.backend.DTO.ResponseModels.Inner;
using moto.sale.user.backend.Models;
using moto.sale.user.backend.Services.Interface;
using motosale.user.backend.DTO.HelperModels;
using motosale.user.backend.DTO.HelperModels.Const;
using motosale.user.backend.DTO.RequestModels;
using motosale.user.backend.DTO.ResponseModels.Main;
using motosale.user.backend.Infrastructure.Repository;
using motosale.user.backend.Services.Interface;

namespace moto.sale.user.backend.Services.Implementation
{
    public class ProductService : IProductService
    {

        private readonly IRepository<PRODUCT> _products;
        private readonly ILoggerManager _logger;
        private readonly IConfiguration _configuration;
        private readonly ISqlService _sqlService;
        private readonly IMapper _mapper;

        public ProductService(
            IRepository<PRODUCT> products,
            ILoggerManager logger,
            IConfiguration configuration,
            ISqlService sqlService,
            IMapper mapper)
        {
            _products = products;
            _logger = logger;
            _configuration = configuration;
            _sqlService = sqlService;
            _mapper = mapper;
        }

        public async Task<ResponseSimple> CreateAsync(ResponseSimple response, ProductDto model)
        {
            try
            {
                var product = _mapper.Map<PRODUCT>(model);
                product.CreatedAt = DateTime.Now;
                _products.Insert(product);
                await _products.SaveAsync();
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

        public async Task<ResponseSimple> UpdateAsync(ResponseSimple response, ProductDto model, int id)
        {
            try
            {
                var product = _mapper.Map<PRODUCT>(model);

                var employeeDb = await _products.AllQuery
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);

                product.Id = id;
                product.UpdatedAt = DateTime.Now;
                product.CreatedAt = employeeDb.CreatedAt;

                _products.Update(product);
                await _products.SaveAsync();
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
                var product = await _products.AllQuery.FirstOrDefaultAsync(x => x.Id == id);
                _products.Remove(product);
                await _products.SaveAsync();
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

        public async Task<ProductVM> GetByIdAsync(int id)
        {
            var db_model = await _products.AllQuery.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<ProductVM>(db_model);
        }

        public ResponseTotal<PRODUCT> GetAll( CommonFilterVM filterVM)
        {
            int recordsToSkip = (filterVM.Page - 1) * filterVM.PageSize;

            var query = _products.AllQuery
                .OrderByDescending(x => x.UpdatedAt != null ? x.UpdatedAt : x.CreatedAt);

            var response = new ResponseTotal<PRODUCT>();
            response.Total = query.Count();
            response.Data = query
                .Skip(recordsToSkip)
                .Take(filterVM.PageSize)
                .ToList();

            return response;
        }




    }
}
