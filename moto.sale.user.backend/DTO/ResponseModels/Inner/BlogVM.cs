using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace moto.sale.user.backend.DTO.ResponseModels.Inner
{
    public class BlogVM
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string? CreatedBy { get; set; }
        public string? ImageUrl { get; set; }


    }
}
