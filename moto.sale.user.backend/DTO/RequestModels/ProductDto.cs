using System.ComponentModel.DataAnnotations.Schema;

namespace moto.sale.user.backend.DTO.RequestModels
{
    public class ProductDto
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public int? BrandId { get; set; }

        public int? CategoryId { get; set; }

        public string? Color { get; set; }

        public int? StockQuantity { get; set; }

        public int? Price { get; set; }

        public string? ImageUrl { get; set; }

    }
}
