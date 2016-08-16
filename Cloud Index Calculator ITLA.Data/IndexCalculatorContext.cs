namespace Cloud_Index_Calculator_ITLA.Data
{
    using System.Data.Entity;
    using Model;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Security.Claims;
    using Microsoft.AspNet.Identity;
    using System.Threading.Tasks;
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            return userIdentity;
        }
    }
    public class IndexCalculatorContext : IdentityDbContext<ApplicationUser>
    {
        public IndexCalculatorContext()
            : base("name=IndexCalculatorContext")
        {
        }

        public DbSet<Subject> Subjets { get; set; }

        public DbSet<Selection> Selections { get; set; }

        public DbSet<Quarter> Quarters { get; set; }

        public DbSet<Qualification> Qualifications { get; set; }

        public DbSet<Career> Careers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfigureIdentityTables(modelBuilder);
        }

        private static void ConfigureIdentityTables(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles").HasKey(m => new { m.UserId, m.RoleId });
            modelBuilder.Entity<IdentityUserLogin>().ToTable("Logins").HasKey(m => m.UserId);
            modelBuilder.Entity<IdentityUserClaim>().ToTable("Claims").HasKey(m => m.Id);
            modelBuilder.Entity<IdentityRole>().ToTable("Roles").HasKey(m => m.Id);
            modelBuilder.Entity<IdentityUser>().ToTable("Users").HasKey(m => m.Id);
        }
    }
}