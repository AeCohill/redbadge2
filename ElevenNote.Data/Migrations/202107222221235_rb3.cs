namespace ElevenNote.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rb3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "UserId", c => c.Guid(nullable: false));
            AddColumn("dbo.Provider", "UserId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Provider", "UserId");
            DropColumn("dbo.Customer", "UserId");
        }
    }
}
