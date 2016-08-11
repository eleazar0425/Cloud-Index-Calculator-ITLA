namespace Cloud_Index_Calculator_ITLA.Data
{
    using System.Data.Entity;
    using Model;

    public class IndexCalculatorContext : DbContext
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
    }
}