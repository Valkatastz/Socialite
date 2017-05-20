namespace Socialite.Migrations.DashboardDbContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dashboard : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Comment", name: "PostId", newName: "Post_Id");
            RenameColumn(table: "dbo.Reply", name: "PostId", newName: "Post_Id");
            RenameIndex(table: "dbo.Comment", name: "IX_PostId", newName: "IX_Post_Id");
            RenameIndex(table: "dbo.Reply", name: "IX_PostId", newName: "IX_Post_Id");
            AddColumn("dbo.Comment", "PageId", c => c.String());
            AlterColumn("dbo.Category", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Post", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Post", "ShortDescription", c => c.String(nullable: false));
            AlterColumn("dbo.Post", "Meta", c => c.String(nullable: false));
            AlterColumn("dbo.Comment", "Body", c => c.String(nullable: false));
            AlterColumn("dbo.Reply", "Body", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reply", "Body", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.Comment", "Body", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.Post", "Meta", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Post", "ShortDescription", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Post", "Title", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Category", "Description", c => c.String(nullable: false, maxLength: 20));
            DropColumn("dbo.Comment", "PageId");
            RenameIndex(table: "dbo.Reply", name: "IX_Post_Id", newName: "IX_PostId");
            RenameIndex(table: "dbo.Comment", name: "IX_Post_Id", newName: "IX_PostId");
            RenameColumn(table: "dbo.Reply", name: "Post_Id", newName: "PostId");
            RenameColumn(table: "dbo.Comment", name: "Post_Id", newName: "PostId");
        }
    }
}
