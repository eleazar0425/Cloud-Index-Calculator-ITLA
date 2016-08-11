namespace Cloud_Index_Calculator_ITLA.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatinglettertype : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Qualifications", "Letter", c => c.String(maxLength: 1));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Qualifications", "Letter");
        }
    }
}
