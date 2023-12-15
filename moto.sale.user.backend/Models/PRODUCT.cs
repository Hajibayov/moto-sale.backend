using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using motosale.user.backend.Models;

namespace moto.sale.user.backend.Models
{
    public class PRODUCT
{
        [Column("id"), Key]
        public int Id { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("brand_id")]
        public int? BrandId { get; set; }

        [Column("category_id")]
        public int? CategoryId { get; set; }

        [Column("color")]
        public string? Color { get; set; }

        [Column("stock_quantity")]
        public int? StockQuantity { get; set; }

        [Column("price")]
        public int? Price { get; set; }

        [Column("image_url")]
        public string? ImageUrl { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column("created_by")]
        public string? CreatedBy { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [Column("updated_by")]
        public string? UpdatedBy { get; set; }

        public virtual BRAND Brand { get; set; }
        public virtual CATEGORY Category { get; set; }

    }
}
