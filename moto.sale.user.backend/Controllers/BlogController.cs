using Microsoft.AspNetCore.Mvc;
using moto.sale.user.backend.DTO.RequestModels;
using moto.sale.user.backend.Services.Implementation;
using moto.sale.user.backend.Services.Interface;
using motosale.user.backend.DTO.HelperModels.Const;
using motosale.user.backend.DTO.HelperModels;
using motosale.user.backend.DTO.ResponseModels.Main;
using motosale.user.backend.Services.Interface;
using System.Diagnostics;
using moto.sale.user.backend.DTO.ResponseModels.Inner;

namespace moto.sale.user.backend.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;
        private readonly IValidationCommon _validation;
        private readonly ILoggerManager _logger;
        public BlogController(
            IBlogService blogService,
            IValidationCommon validation,
            ILoggerManager logger
            )
        {
            _blogService = blogService;
            _validation = validation;
            _logger = logger;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateBlogAsync(BlogDto model)
        {
            ResponseSimple response = new ResponseSimple();
            response.Status = new StatusModel();
            response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            try
            {

                response = await _blogService.CreateAsync(response, model);
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
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(CreateBlogAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "Sistemdə xəta baş verdi.";
                return StatusCode(StatusCodeModel.INTERNEL_SERVER, response);
            }
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateBlogAsync(BlogDto model, int id)
        {
            ResponseSimple response = new ResponseSimple();
            response.Status = new StatusModel();
            response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            try
            {

                response = await _blogService.UpdateAsync(response, model, id);
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
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(UpdateBlogAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "Sistemdə xəta baş verdi.";
                return StatusCode(StatusCodeModel.INTERNEL_SERVER, response);
            }
        }
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteBlogAsync(int id)
        {
            ResponseSimple response = new ResponseSimple();
            response.Status = new StatusModel();
            response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            try
            {

                response = await _blogService.DeleteAsync(response, id);
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
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(DeleteBlogAsync)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "Sistemdə xəta baş verdi.";
                return StatusCode(StatusCodeModel.INTERNEL_SERVER, response);
            }
        }

        [HttpGet]
        [Route("get-by-id")]
        public async Task<IActionResult> GetById(int id)
        {
            ResponseObject<BlogVM> response = new ResponseObject<BlogVM>();
            response.Status = new StatusModel();
            response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            try
            {
                response.Response = await _blogService.GetByIdAsync(id);
                if (response.Response == null)
                {
                    response.Status.Message = "Məlumat tapılmadı!";
                    response.Status.ErrorCode = ErrorCodes.NOT_FOUND;
                    StatusCode(_validation.CheckErrorCode(response.Status.ErrorCode), response);
                }
                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(GetById)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "Sistemdə xəta baş verdi.";
                return StatusCode(StatusCodeModel.INTERNEL_SERVER, response);
            }
        }
        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll(int page, int pageSize)
        {
            ResponseListTotal<BlogVM> response = new ResponseListTotal<BlogVM>();
            response.Response = new ResponseTotal<BlogVM>();
            response.Status = new StatusModel();
            response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            try
            {
                response = await _blogService.GetAll(response, page, pageSize);
                if (response.Response.Data == null)
                {
                    response.Status.Message = "Məlumat tapılmadı!";
                    response.Status.ErrorCode = ErrorCodes.NOT_FOUND;
                    StatusCode(_validation.CheckErrorCode(response.Status.ErrorCode), response);
                }
                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(GetAll)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "Sistemdə xəta baş verdi.";
                return StatusCode(StatusCodeModel.INTERNEL_SERVER, response);
            }
        }
    }
}
