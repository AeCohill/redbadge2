namespace ElevenNote.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Provider : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        JobId = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        Provider_ProviderId = c.Int(),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.Provider", t => t.Provider_ProviderId)
                .Index(t => t.Provider_ProviderId);
            
            CreateTable(
                "dbo.Provider",
                c => new
                    {
                        ProviderId = c.Int(nullable: false, identity: true),
                        JobId = c.Guid(nullable: false),
                        CustomerId = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Location = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ProviderId);
            
            AddColumn("dbo.Job", "Customer_CustomerId", c => c.Int());
            AddColumn("dbo.Job", "Provider_ProviderId", c => c.Int());
            CreateIndex("dbo.Job", "Customer_CustomerId");
            CreateIndex("dbo.Job", "Provider_ProviderId");
            AddForeignKey("dbo.Job", "Customer_CustomerId", "dbo.Customer", "CustomerId");
            AddForeignKey("dbo.Job", "Provider_ProviderId", "dbo.Provider", "ProviderId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Job", "Provider_ProviderId", "dbo.Provider");
            DropForeignKey("dbo.Customer", "Provider_ProviderId", "dbo.Provider");
            DropForeignKey("dbo.Job", "Customer_CustomerId", "dbo.Customer");
            DropIndex("dbo.Job", new[] { "Provider_ProviderId" });
            DropIndex("dbo.Job", new[] { "Customer_CustomerId" });
            DropIndex("dbo.Customer", new[] { "Provider_ProviderId" });
            DropColumn("dbo.Job", "Provider_ProviderId");
            DropColumn("dbo.Job", "Customer_CustomerId");
            DropTable("dbo.Provider");
            DropTable("dbo.Customer");
        }
    }
}
