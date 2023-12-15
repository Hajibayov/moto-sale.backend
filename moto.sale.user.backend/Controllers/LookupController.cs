using Microsoft.AspNetCore.Mvc;
using moto.sale.user.backend.Services.Interface;
using motosale.user.backend.DTO.HelperModels;
using motosale.user.backend.DTO.HelperModels.Const;
using motosale.user.backend.DTO.ResponseModels.Inner;
using motosale.user.backend.DTO.ResponseModels.Main;
using System.Diagnostics;

namespace moto.sale.user.backend.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LookupController : ControllerBase
    {
        private readonly ILookupService _lookupService;
        public LookupController(ILookupService lookupService) {
            _lookupService = lookupService;
        }

        [HttpGet]
        [Route("get-brands")]
        public async Task<IActionResult> GetBrands()
        {
            ResponseList<BrandVM> response = new ResponseList<BrandVM>();
            response.Status = new StatusModel();
            response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            try
            {
                response = await _lookupService.GetBrandsAsync(response);
                return Ok(response);
            }
            catch (Exception e)
            {

                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "Sistemdə xəta baş verdi.";
                return StatusCode(StatusCodeModel.INTERNEL_SERVER, response);
            }
        }

        [HttpGet]
        [Route("get-categories")]
        public async Task<IActionResult> GetCategories()
        {
            ResponseList<CategoryVM> response = new ResponseList<CategoryVM>();
            response.Status = new StatusModel();
            response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            try
            {
                response = await _lookupService.GetCategoriesAsync(response);
                return Ok(response);
            }
            catch (Exception e)
            {

                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "Sistemdə xəta baş verdi.";
                return StatusCode(StatusCodeModel.INTERNEL_SERVER, response);
            }
        }

    }
    }

