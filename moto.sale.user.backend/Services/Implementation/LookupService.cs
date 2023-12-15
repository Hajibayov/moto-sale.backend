using AutoMapper;
using Microsoft.EntityFrameworkCore;
using moto.sale.user.backend.Models;
using moto.sale.user.backend.Services.Interface;
using motosale.user.backend.DTO.HelperModels.Const;
using motosale.user.backend.DTO.ResponseModels.Inner;
using motosale.user.backend.DTO.ResponseModels.Main;
using motosale.user.backend.Infrastructure.Repository;
using motosale.user.backend.Models;

namespace moto.sale.user.backend.Services.Implementation
{
    public class LookupService : ILookupService
    {
        private readonly IRepository<BRAND> _brand;
        private readonly IRepository<CATEGORY> _category;

        private readonly IMapper _mapper;

        public LookupService(IRepository<BRAND> brand, IRepository<CATEGORY> category, IMapper mapper)
        {
            _brand = brand;
            _category = category;
            _mapper = mapper;

        }



        public async Task<ResponseList<BrandVM>> GetBrandsAsync(ResponseList<BrandVM> response)
    {
        try
        {
            var result = await _brand.AllQuery.ToListAsync();
          
            response.Data = _mapper.Map<List<BrandVM>>(result);
            
        }
        catch (Exception ex)
        {
            response.Status.ErrorCode = ErrorCodes.DB;
            response.Status.Message = "Problem baş verdi!";
        }
        return response;
    }

        public async Task<ResponseList<CategoryVM>> GetCategoriesAsync(ResponseList<CategoryVM> response)
        {
            try
            {
                var result = await _category.AllQuery.ToListAsync();

                response.Data = _mapper.Map<List<CategoryVM>>(result);

            }
            catch (Exception ex)
            {
                response.Status.ErrorCode = ErrorCodes.DB;
                response.Status.Message = "Problem baş verdi!";
            }
            return response;
        }

    }
}

