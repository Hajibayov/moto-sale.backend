using Microsoft.AspNetCore.Mvc;
using motosale.user.backend.DTO.HelperModels.Const;
using motosale.user.backend.DTO.HelperModels;
using motosale.user.backend.DTO.ResponseModels.Main;
using motosale.user.backend.Services.Interface;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;
using System.Diagnostics;
using moto.sale.user.backend.DTO.RequestModels;
using moto.sale.user.backend.Services.Interface;

namespace moto.sale.user.backend.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IValidationCommon _validation;
        private readonly ILoggerManager _logger;
        public ProductController(
            IProductService productService,
            IValidationCommon validation,
            ILoggerManager logger
            )
        {
            _productService = productService;
            _validation = validation;
            _logger = logger;
        }


        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateProductAsync(ProductDto model)
        {
            ResponseSimple response = new ResponseSimple();
            response.Status = new StatusModel();
            response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            try
            {

                response = await _productService.CreateAsync(response, model);
                if (response.Status.ErrorCode != 0)
                {
                    return StatusCode(_validation.CheckErrorCode(response.Status.ErrorCode), response);
                }
                else
                {
                    return Ok(response);
                }
            }
            catch (Exception e)
            {
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(CreateProductAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "Sistemdə xəta baş verdi.";
                return StatusCode(StatusCodeModel.INTERNEL_SERVER, response);
            }
        }
    }
}

