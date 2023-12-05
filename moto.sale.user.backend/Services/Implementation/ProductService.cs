using AutoMapper;
using moto.sale.user.backend.DTO.RequestModels;
using moto.sale.user.backend.Models;
using moto.sale.user.backend.Services.Interface;
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
    }
}
