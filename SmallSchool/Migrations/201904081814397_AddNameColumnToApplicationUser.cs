namespace SmallSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameColumnToApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Courses", "LecturerId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Courses", "LecturerId");
            AddForeignKey("dbo.Courses", "LecturerId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "LecturerId", "dbo.AspNetUsers");
            DropIndex("dbo.Courses", new[] { "LecturerId" });
            AlterColumn("dbo.Courses", "LecturerId", c => c.String(nullable: false));
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}
