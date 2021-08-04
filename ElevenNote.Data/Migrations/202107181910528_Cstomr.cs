namespace ElevenNote.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cstomr : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Job", "Location", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Job", "Location");
        }
    }
}
