using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PetTinderMVC.Models
{
    public class PetTinderMVCContext : IdentityDbContext<ApplicationUser>
    {
        public PetTinderMVCContext(DbContextOptions options) : base(options) {}
    }
}