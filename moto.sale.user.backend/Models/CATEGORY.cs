using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace moto.sale.user.backend.Models
{
    public class CATEGORY
    {
        [Column("id"), Key]
        public int Id { get; set; }

        [Column("name")]
        public string? Name { get; set; }
    }
}
