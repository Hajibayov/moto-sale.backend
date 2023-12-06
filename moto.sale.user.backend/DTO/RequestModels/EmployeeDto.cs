using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace moto.sale.user.backend.DTO.RequestModels
{
    public class EmployeeDto
    {
        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string? Role { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public string? ImageUrl { get; set; }
    }
}
