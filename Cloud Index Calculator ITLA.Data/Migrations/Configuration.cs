namespace Cloud_Index_Calculator_ITLA.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<IndexCalculatorContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(IndexCalculatorContext context)
        {
            if(!context.Qualifications.Any(e => e.Letter == "A"))
            {
                context.Qualifications.Add(new Model.Qualification
                {
                    Letter = "A",
                    Value = 4
                });
            }

            if (!context.Qualifications.Any(e => e.Letter == "B"))
            {
                context.Qualifications.Add(new Model.Qualification
                {
                    Letter = "B",
                    Value = 3
                });
            }

            if (!context.Qualifications.Any(e => e.Letter == "C"))
            {
                context.Qualifications.Add(new Model.Qualification
                {
                    Letter = "C",
                    Value = 2
                });
            }

            if (!context.Qualifications.Any(e => e.Letter == "F"))
            {
                context.Qualifications.Add(new Model.Qualification
                {
                    Letter = "F",
                    Value = 0
                });
            }

            if(!context.Careers.Any(e => e.ShortName == "TDS"))
            {
                context.Careers.Add(new Model.Career
                {
                    Name = "Tecnología en Desarrollo de Software",
                    ShortName = "TDS"
                });
            }
        }
    }
}
