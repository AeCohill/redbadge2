namespace ElevenNote.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rebuild1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customer", "Provider_ProviderId", "dbo.Provider");
            DropIndex("dbo.Customer", new[] { "Provider_ProviderId" });
            DropIndex("dbo.Job", new[] { "Customer_CustomerId" });
            DropColumn("dbo.Job", "CustomerId");
            RenameColumn(table: "dbo.Job", name: "Provider_ProviderId", newName: "ProviderId");
            RenameColumn(table: "dbo.Job", name: "Customer_CustomerId", newName: "CustomerId");
            RenameIndex(table: "dbo.Job", name: "IX_Provider_ProviderId", newName: "IX_ProviderId");
            AlterColumn("dbo.Job", "CustomerId", c => c.Int());
            CreateIndex("dbo.Job", "CustomerId");
            DropColumn("dbo.Customer", "JobId");
            DropColumn("dbo.Customer", "Provider_ProviderId");
            DropColumn("dbo.Provider", "JobId");
            DropColumn("dbo.Provider", "CustomerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Provider", "CustomerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Provider", "JobId", c => c.Guid(nullable: false));
            AddColumn("dbo.Customer", "Provider_ProviderId", c => c.Int());
            AddColumn("dbo.Customer", "JobId", c => c.Guid(nullable: false));
            DropIndex("dbo.Job", new[] { "CustomerId" });
            AlterColumn("dbo.Job", "CustomerId", c => c.Guid(nullable: false));
            RenameIndex(table: "dbo.Job", name: "IX_ProviderId", newName: "IX_Provider_ProviderId");
            RenameColumn(table: "dbo.Job", name: "CustomerId", newName: "Customer_CustomerId");
            RenameColumn(table: "dbo.Job", name: "ProviderId", newName: "Provider_ProviderId");
            AddColumn("dbo.Job", "CustomerId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Job", "Customer_CustomerId");
            CreateIndex("dbo.Customer", "Provider_ProviderId");
            AddForeignKey("dbo.Customer", "Provider_ProviderId", "dbo.Provider", "ProviderId");
        }
    }
}
