using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PetTinderMVC.Models
{
    public class PetTinderMVCContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Pet> Pets { get; set; }

        public PetTinderMVCContext(DbContextOptions options) : base(options) {}
    }
}