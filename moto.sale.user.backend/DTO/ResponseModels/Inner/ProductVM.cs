using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace moto.sale.user.backend.DTO.ResponseModels.Inner
{
    public class ProductVM
    {

        public string? Name { get; set; }

        public string? Brand { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? Category { get; set; }

        public string? Color { get; set; }

        public int? StockQuantity { get; set; }

        public int? Price { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
