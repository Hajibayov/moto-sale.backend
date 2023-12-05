using Microsoft.AspNetCore.Identity;

namespace motosale.user.backend.Models
{
    public class USER: IdentityUser<int>
    {
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
