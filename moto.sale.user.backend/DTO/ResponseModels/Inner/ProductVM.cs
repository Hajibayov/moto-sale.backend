﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace moto.sale.user.backend.DTO.ResponseModels.Inner
{
    public class ProductVM
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int? BrandId { get; set; }

        public int? CategoryId { get; set; }

        public string? Color { get; set; }

        public int? StockQuantity { get; set; }

        public int? Price { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }

    }
}
