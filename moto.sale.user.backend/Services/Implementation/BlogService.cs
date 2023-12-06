using AutoMapper;
using Microsoft.EntityFrameworkCore;
using moto.sale.user.backend.DTO.RequestModels;
using moto.sale.user.backend.DTO.ResponseModels.Inner;
using moto.sale.user.backend.Models;
using moto.sale.user.backend.Services.Interface;
using motosale.user.backend.DTO.HelperModels.Const;
using motosale.user.backend.DTO.ResponseModels.Main;
using motosale.user.backend.Infrastructure.Repository;
using motosale.user.backend.Services.Interface;

namespace moto.sale.user.backend.Services.Implementation
{
    public class BlogService : IBlogService
    {
        private readonly IRepository<BLOG> _blog;
        private readonly ILoggerManager _logger;
        private readonly IConfiguration _configuration;
        private readonly ISqlService _sqlService;
        private readonly IMapper _mapper;

        public BlogService(
            IRepository<BLOG> blog,
            ILoggerManager logger,
            IConfiguration configuration,
            ISqlService sqlService,
            IMapper mapper)
        {
            _blog = blog;
            _logger = logger;
            _configuration = configuration;
            _sqlService = sqlService;
            _mapper = mapper;
        }

        public async Task<ResponseSimple> CreateAsync(ResponseSimple response, BlogDto model)
        {
            try
            {
                var blog = _mapper.Map<BLOG>(model);
                blog.CreatedAt = DateTime.Now;
                _blog.Insert(blog);
                await _blog.SaveAsync();
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

        public async Task<ResponseSimple> UpdateAsync(ResponseSimple response, BlogDto model, int id)
        {
            try
            {
                var blog = _mapper.Map<BLOG>(model);

                var blogDb = await _blog.AllQuery
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);

                blog.Id = id;
                blog.UpdatedAt = DateTime.Now;
                blog.CreatedAt = blogDb.CreatedAt;

                _blog.Update(blog);
                await _blog.SaveAsync();
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
                var employee = await _blog.AllQuery.FirstOrDefaultAsync(x => x.Id == id);
                _blog.Remove(employee);
                await _blog.SaveAsync();
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

        public async Task<BlogVM> GetByIdAsync(int id)
        {
            var blog = await _blog.AllQuery.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<BlogVM>(blog);
        }

        public async Task<ResponseListTotal<BlogVM>> GetAll(ResponseListTotal<BlogVM> response, int page, int pageSize)
        {

            var db_data = await _blog.AllQuery.OrderByDescending(x => x.CreatedAt).ToListAsync();
            response.Response.Total = db_data.Count;
            db_data = db_data.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            response.Response.Data = _mapper.Map<List<BlogVM>>(db_data);
            return response;
        }

    }
}
