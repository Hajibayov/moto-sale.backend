using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace motosale.user.backend.Models
{
    public class BRAND
    {
        [Column("id"), Key]
        public int Id { get; set; }

        [Column("name")]
        public string? Name { get; set; }
    }
}
